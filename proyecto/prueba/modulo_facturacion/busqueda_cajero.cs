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
    public partial class busqueda_cajero : Form
    {
        public busqueda_cajero()
        {
            InitializeComponent();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        public bool mantenimiento = false;
        public string codigo_sucursal_global = "";
        private void busqueda_cajero_Load(object sender, EventArgs e)
        {
            cargar_datos();
            nombre_txt.Focus();
        }
        public void cargar_datos()
        {
            try
            {
                if (mantenimiento == false)
                {
                    dataGridView1.Rows.Clear();
                    string sql = "select t.codigo,(t.nombre+' '+p.apellido),t.identificacion,c.estado from tercero t join persona p on t.codigo=p.codigo join cajero c on c.codigo=t.codigo join caja caj on caj.codigo=c.cod_caja where c.estado='1' and caj.cod_sucursal='"+codigo_sucursal_global.ToString()+"'";
                    if(nombre_txt.Text.Trim()!="")
                    {
                        sql += " and t.nombre like '%" + nombre_txt.Text.Trim() + "%' or p.apellido like '%" + nombre_txt.Text.Trim() + "%'";
                    }
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                    }
                }
                else
                {
                    string sql = "select t.codigo,(t.nombre+' '+p.apellido),t.identificacion,c.estado from tercero t join persona p on t.codigo=p.codigo join cajero c on c.codigo=t.codigo join caja caj on caj.codigo=c.cod_caja where c.estado='1' and caj.cod_sucursal='"+codigo_sucursal_global.ToString()+"'";
                    if (nombre_txt.Text.Trim() != "")
                    {
                        sql += " and t.nombre like '%" + nombre_txt.Text.Trim() + "%' or p.apellido like '%" + nombre_txt.Text.Trim() + "%'";
                    }
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

        private void nombre_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (mantenimiento == false)
                {

                    string sql = "select t.codigo,(t.nombre+' '+p.apellido),t.identificacion,c.estado from tercero t join persona p on t.codigo=p.codigo join cajero c on c.codigo=t.codigo join caja caj on caj.codigo=c.cod_caja  where c.estado='1' and t.nombre like '%" + nombre_txt.Text.Trim() + "%' or p.apellido like '%" + nombre_txt.Text.Trim() + "%' or t.identificacion like '%" + nombre_txt.Text.Trim() + "%' and caj.cod_sucursal='" + codigo_sucursal_global.ToString() + "'";
                    if (nombre_txt.Text.Trim() != "")
                    {
                        sql += " and t.nombre like '%" + nombre_txt.Text.Trim() + "%' or p.apellido like '%" + nombre_txt.Text.Trim() + "%'";
                    }
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.Rows.Clear();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                    }
                }
                else
                {
                    string sql = "select t.codigo,(t.nombre+' '+p.apellido),t.identificacion,c.estado from tercero t join persona p on t.codigo=p.codigo join cajero c on c.codigo=t.codigo join caja caj on caj.codigo=c.cod_caja where t.nombre like '%" + nombre_txt.Text.Trim() + "%' or p.apellido like '%" + nombre_txt.Text.Trim() + "%' or t.identificacion like '%" + nombre_txt.Text.Trim() + "%'";
                    if (nombre_txt.Text.Trim() != "")
                    {
                        sql += " and t.nombre like '%" + nombre_txt.Text.Trim() + "%' or p.apellido like '%" + nombre_txt.Text.Trim() + "%'";
                    }
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

        private void button3_Click(object sender, EventArgs e)
        {
            cajeros ca = new cajeros();
            ca.ShowDialog();
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
