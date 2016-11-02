using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVenta;
namespace puntoVenta
{
    public partial class busqueda_oferta_producto_descuento : Form
    {
        public busqueda_oferta_producto_descuento()
        {
            InitializeComponent();
        }
        internal singleton s { get; set; }
        public delegate void pasar(string dato);
        public event pasar pasado;
        public string codigo_producto_global = "";
        public string fecha_global;
        private void busqueda_oferta_producto_descuento_Load(object sender, EventArgs e)
        {
            cargar();
            dataGridView1.Focus();
        }
        public void cargar()
        {
            if (codigo_producto_global.ToString() != "")
            {
                s = singleton.obtenerDatos();
                string sql = "select ofe.cod_oferta,po.nombre,po.descuento from oferta_producto_subcate_detalle ofe join producto p on p.cod_categoria=ofe.cod_categoria or p.cod_subcategoria=ofe.cod_subcategoria join producto_oferta po on po.codigo=ofe.cod_oferta and po.cod_sucursal='" + s.codigo_sucursal.ToString() + "' where p.codigo='" + codigo_producto_global.ToString() + "' and (('" + fecha_global.ToString() + "' between fecha_inicial and fecha_final)) and po.estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
                dataGridView1.Focus();
            }
            else
            {
                MessageBox.Show("No se pudo recivir el producto");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea aplicar este descuento de oferta?", "Oferta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        int fila = dataGridView1.CurrentRow.Index;
                        string codigo = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                        pasado(codigo.ToString());
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No hay oferta que seleccionar");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error devolviendo el valor a la facturacion");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        if (dataGridView1.Rows.Count > 0)
                        {
                            int fila = dataGridView1.CurrentRow.Index;
                            string codigo = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                            pasado(codigo.ToString());
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No hay oferta que seleccionar");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay ofertas que seleccionar");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error devolviendo el valor a la facturacion");
                }
            }
        }
    }
}
