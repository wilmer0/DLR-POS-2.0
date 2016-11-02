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
    public partial class busqueda_cargo : Form
    {
        public busqueda_cargo()
        {
            InitializeComponent();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        public bool mantenimiento = false;
        private void busqueda_cargo_Load(object sender, EventArgs e)
        {
            nombre.Focus();
            cargar_cargos();
        }

        public void cargar_cargos()
        {
            string sql = "";

            try
            {
                if(mantenimiento==false)
                {
                    sql = "select codigo,nombre,estado from cargo where estado='1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    //retornar aunq no esten activo
                    sql = "select codigo,nombre,estado from cargo";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los cargos");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = "";
                codigo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                pasado(codigo.ToString());
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

        private void nombre_KeyUp(object sender, KeyEventArgs e)
        {
            string sql = "";
            try
            {
                if (mantenimiento == false)
                {
                    sql = "select codigo,nombre,estado from cargo where estado='1' where nombre like '%"+nombre.Text.Trim()+"%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    //retornar aunq no esten activo
                    sql = "select codigo,nombre,estado from cargo where nombre like '%" + nombre.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando los cargos");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cargo c = new cargo();
            c.ShowDialog();
        }
    }
}
