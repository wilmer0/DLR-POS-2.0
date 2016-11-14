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
    public partial class busqueda_cliente_categoria : Form
    {
        public busqueda_cliente_categoria()
        {
            InitializeComponent();
        }
        public bool mantenimiento = false;
        public delegate void pasar(string dato);
        public event pasar pasado;
        internal singleton s { get; set; }
        private void busqueda_cliente_categoria_Load(object sender, EventArgs e)
        {
            cargar_datos();
        }

        public void cargar_datos()
        {
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select codigo,nombre,estado from cliente_categoria where estado='1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select codigo,nombre,estado from cliente_categoria";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro cargando las categorias");
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void nombre_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select codigo,nombre,estado from cliente_categoria where estado='1' and  nombre like '%"+nombre_txt.Text.Trim()+"%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select codigo,nombre,estado from cliente_categoria where nombre like '%"+nombre_txt.Text.Trim()+"%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro cargando las categorias");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            categoria_subcatecoria_cliente cs = new categoria_subcatecoria_cliente();
            cs.ShowDialog();
        }
    }
}
