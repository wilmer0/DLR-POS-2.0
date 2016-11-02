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
    public partial class busqueda_cliente_subcategoria : Form
    {
        public busqueda_cliente_subcategoria()
        {
            InitializeComponent();
        }
        public bool mantenimiento = false;
        public string codigo_categoria = "";
        public delegate void pasar(string dato);
        public event pasar pasado;
        internal singleton s { get; set; }
        private void busqueda_cliente_subcategoria_Load(object sender, EventArgs e)
        {
            cargar_datos();
        }
        public void cargar_datos()
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();
                if(mantenimiento==false && codigo_categoria=="")
                {
                    sql = "select codigo,nombre,estado from cliente_subcategoria where estado='1'";
                    ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (mantenimiento == false && codigo_categoria != "")
                {
                    sql = "select codigo,nombre,estado from cliente_subcategoria where estado='1' and cod_categoria='"+codigo_categoria.ToString()+"'";
                    ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }


                if(mantenimiento==true && codigo_categoria=="")
                {
                        sql = "select codigo,nombre,estado from cliente_subcategoria";
                        ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                }
                if(mantenimiento==true && codigo_categoria!="")
                {
                    sql = "select codigo,nombre,estado from cliente_subcategoria where cod_categoria='"+codigo_categoria.ToString()+"'";
                    ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }

            }
            catch(Exception)
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

        private void nombre_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();
                if (mantenimiento == false && codigo_categoria == "")
                {
                    sql = "select codigo,nombre,estado from cliente_subcategoria where estado='1' and nombre like '%"+nombre_txt.Text.Trim()+"%'";
                    ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (mantenimiento == false && codigo_categoria != "")
                {
                    sql = "select codigo,nombre,estado from cliente_subcategoria where estado='1' and cod_categoria='" + codigo_categoria.ToString() + "' and nombre like '%" + nombre_txt.Text.Trim() + "%'";
                    ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }


                if (mantenimiento == true && codigo_categoria == "")
                {
                    sql = "select codigo,nombre,estado from cliente_subcategoria and nombre like '%" + nombre_txt.Text.Trim() + "%'";
                    ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (mantenimiento == true && codigo_categoria != "")
                {
                    sql = "select codigo,nombre,estado from cliente_subcategoria where cod_categoria='" + codigo_categoria.ToString() + "' and nombre like '%" + nombre_txt.Text.Trim() + "%'";
                    ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las subcategorias por nombre");
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
    }
}
