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



namespace puntoVenta.modulo_facturacion
{
    public partial class busqueda_ingresos_caja_conceptos : Form
    {
        public busqueda_ingresos_caja_conceptos()
        {
            InitializeComponent();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        public bool mantenimiento = false;
        internal singleton s { get; set; }
        public string codigo_sucursal = null;
        private void busqueda_ingresos_caja_conceptos_Load(object sender, EventArgs e)
        {

            cargar_datos();
        }
        public void cargar_datos()
        {
            try
            {
                if (mantenimiento == false)
                {
                    dataGridView1.Rows.Clear();
                    string sql = "select codigo,nombre,estado from ingresos_conceptos where estado='1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                    }
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    string sql = "select codigo,nombre,estado from ingresos_conceptos";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando los datos: "+ex.ToString());
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
            DialogResult dr = MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            caja_ingresos_conceptos ci = new caja_ingresos_conceptos();
            ci.ShowDialog();
        }

        private void nombre_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (mantenimiento == false)
                {
                    dataGridView1.Rows.Clear();
                    string sql = "select codigo,nombre,estado from ingresos_conceptos where estado='1' and nombre like '%" + nombre_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                    }
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    string sql = "select codigo,nombre,estado from ingresos_conceptos where nombre like '%" + nombre_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando por nombre");
            }
        }
    }
}
