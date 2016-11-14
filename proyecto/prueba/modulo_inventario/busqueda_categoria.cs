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
    public partial class busqueda_categoria : Form
    {
        public busqueda_categoria()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public string codigo_categoria_global = null;
        public delegate void pasar(string dato);
        public event pasar pasado;
        public bool mantenimiento = false;
        
        private void busqueda_categoria_Load(object sender, EventArgs e)
        {
            cargar_categoria();
        }
        public void cargar_categoria()
        {
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select codigo,nombre,estado from categoria_producto where estado='1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select codigo,nombre,estado from categoria_producto";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las categorias");
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select codigo,nombre,estado from categoria_producto where estado='1' and nombre like '%" + nombre_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select codigo,nombre,estado from categoria_producto where nombre like '%" + nombre_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las categorias");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            categoria_subcategoria_producto cs = new categoria_subcategoria_producto();
            cs.ShowDialog();
        }
    }
}
