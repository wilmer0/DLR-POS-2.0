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
    public partial class busqueda_sexo : Form
    {
        public busqueda_sexo()
        {
            InitializeComponent();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        public bool mantenimiento = false;
        private void busqueda_sexo_Load(object sender, EventArgs e)
        {
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select *from sexo where estado='1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select *from sexo";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
               
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los datoss");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo_sexo = "";
                //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                codigo_sexo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                pasado(codigo_sexo.ToString());
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error pasando variable hacia atras");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select *from sexo where estado='1' and sexo like '%" + nombre_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select *from sexo where sexo like '%" + nombre_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando sexo");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sexo s = new sexo();
            s.ShowDialog();
        }
    }
}
