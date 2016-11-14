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
    public partial class busqueda_tercero : Form
    {
        public busqueda_tercero()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        public bool mantenimiento = false;
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo_sup = "";
                //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                codigo_sup = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                pasado(codigo_sup.ToString());
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error pasando variable hacia atras");
            }
        }

        private void nombre_suplidor_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select t.codigo,(t.nombre+' '+p.apellido),t.identificacion,t.estado from tercero t join persona p on t.codigo=p.codigo where p.estado='1' and t.nombre like '%" + nombre_txt.Text.Trim() + "%' or p.apellido like '%" + nombre_txt.Text.Trim() + "%' or t.identificacion like '%" + nombre_txt.Text.Trim() + "%' and t.codigo>'1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.Rows.Clear();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                    }
                }
                else
                {
                    string sql = "select t.codigo,(t.nombre+' '+p.apellido),t.identificacion,t.estado from tercero t join persona p on t.codigo=p.codigo where t.nombre like '%" + nombre_txt.Text.Trim() + "%' or p.apellido like '%" + nombre_txt.Text.Trim() + "%' or t.identificacion like '%" + nombre_txt.Text.Trim() + "%' and t.codigo>'1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.Rows.Clear();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las personas");
            }
        }

        private void busqueda_persona_Load(object sender, EventArgs e)
        {
            cargar_personas();
            nombre_txt.Focus();
        }
        public void cargar_personas()
        {
            try
            {
                if (mantenimiento == false)
                {
                    dataGridView1.Rows.Clear();
                    string sql = "select t.codigo,(t.nombre+' '+p.apellido),t.identificacion,t.estado from tercero t join persona p on t.codigo=p.codigo where t.estado='1' and t.codigo>'1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                   foreach(DataRow row in ds.Tables[0].Rows)
                   {
                       dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                   }
                }
                else
                {
                    string sql = "select t.codigo,(t.nombre+' '+p.apellido),t.identificacion,t.estado from tercero t join persona p on t.codigo=p.codigo where t.codigo>'1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.Rows.Clear();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                    }
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los suplidores");
            }
        }

        private void nombre_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            button7_Click(null, null);
        }
    }
}
