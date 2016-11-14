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
    public partial class busqueda_subcategoria : Form
    {
        public busqueda_subcategoria()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        public string codigo_categoria_global = null;
        public bool mantenimiento = false;
        private void busqueda_subcategoria_Load(object sender, EventArgs e)
        {
            cargar_subcategoria();
            //MessageBox.Show("categoria-->"+codigo_categoria_global.ToString());
        }
        public void cargar_subcategoria()
        {
            try
            {
                //cuando tiene codigo de la categoria global
                if (mantenimiento == false && codigo_categoria_global.ToString() != "")
                {   
                        string sql = "select codigo,nombre,cod_categoria,estado from subcategoria_producto where  estado='1' and cod_categoria='" + codigo_categoria_global.ToString() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select codigo,nombre,cod_categoria,estado from subcategoria_producto where cod_categoria='" + codigo_categoria_global.ToString() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                //cuando no tiene codigo de la categoria global
                if (mantenimiento == false && codigo_categoria_global.ToString() =="")
                {
                    string sql = "select codigo,nombre,cod_categoria,estado from subcategoria_producto where  estado='1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las subcategorias");
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
                    string sql = "select codigo,nombre,cod_categoria,estado from subcategoria_producto where estado='1' and cod_categoria='" + codigo_categoria_global.ToString() + "' and nombre like '%" + nombre_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {

                    string sql = "select codigo,nombre,cod_categoria,estado from subcategoria_producto where cod_categoria='" + codigo_categoria_global.ToString() + "' and nombre like '%" + nombre_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando buscando las subcategorias");
            }
        }
    }
}
