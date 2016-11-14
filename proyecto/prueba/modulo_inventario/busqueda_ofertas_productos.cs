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
    public partial class busqueda_ofertas_productos : Form
    {
        public busqueda_ofertas_productos()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            productos_ofertas po = new productos_ofertas();
            po.ShowDialog();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        public bool mantenimiento = false;
        public string codigo_sucursal_global = "";
        private void busqueda_ofertas_productos_Load(object sender, EventArgs e)
        {
            cargar_datos();
        }
        public void cargar_datos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                if (mantenimiento == false)
                {

                    string sql = "select codigo,nombre,descuento,estado from producto_oferta where estado='1' and cod_sucursal='"+codigo_sucursal_global.ToString()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(),row[1].ToString(),row[2].ToString(),row[3].ToString());
                    }
                }
                else
                {
                    string sql = "select codigo,nombre,descuento,estado from producto_oferta and cod_sucursal='" + codigo_sucursal_global.ToString() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los datos");
            }
        }

        private void nombre_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                if (mantenimiento == false)
                {

                    string sql = "select codigo,nombre,descuento,estado from producto_oferta where estado='1' nombre like '%" + nombre_txt.Text.Trim() + "%' and cod_sucursal='" + codigo_sucursal_global.ToString() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                    }
                }
                else
                {
                    string sql = "select codigo,nombre,descuento,estado from producto_oferta where nombre like '%"+nombre_txt.Text.Trim()+"%' and cod_sucursal='" + codigo_sucursal_global.ToString() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los datos por nombres");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = "";
                //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                codigo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                pasado(codigo.ToString());
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error pasando variable hacia atras");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
