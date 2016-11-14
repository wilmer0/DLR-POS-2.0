using puntoVenta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puntoVenta
{
    public partial class busqueda_sucursal : Form
    {
        public busqueda_sucursal()
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
        public delegate void pasar(string dato);
        public event pasar pasado;
        public string codigo_empresa_global = "";
        public bool mantenimiento = false;
        private void busqueda_sucursal_Load(object sender, EventArgs e)
        {
            cargar_sucursal();
        }
        public void cargar_sucursal()
        {
            try
            {
                if (mantenimiento == false)
                {
                    if (codigo_empresa_global != "")
                    {
                        string sql = "select s.codigo,t.nombre,s.secuencia from tercero t join sucursal s on s.codigo=t.codigo where s.codigo_empresa='" + codigo_empresa_global.ToString() + "' and s.estado='1' order by t.nombre";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        string sql = "select t.codigo,t.nombre,s.secuencia from tercero t join  sucursal s on t.codigo=s.codigo where s.estado='1' order by t.nombre";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else
                {
                    if (codigo_empresa_global != "")
                    {
                        string sql = "select s.codigo,t.nombre,s.secuencia from tercero t join sucursal s on t.codigo=s.codigo where s.codigo_empresa='" + codigo_empresa_global.ToString() + "' order by t.nombre";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        string sql = "select s.codigo,t.nombre,t.identificacion,s.secuencia from tercero t sucursal s on t.codigo=s.codigo order by t.nombre";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando las sucursaless");
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (mantenimiento == false)
                {
                    if (codigo_empresa_global != "")
                    {
                        string sql = "select s.codigo,t.nombre,s.secuencia from tercero t join sucursal s on t.codigo=s.codigo where s.estado='1' and  s.codigo_empresa='" + codigo_empresa_global.ToString() + "' and s.estado='1' and  t.nombre like '%" + nombre_txt.Text.Trim() + "%' order by t.nombre";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        string sql = "select s.codigo,t.nombre,s.secuencia from tercero t join sucursal s on t.codigo=s.codigo where t.nombre like '%" + nombre_txt.Text.Trim() + "%' and s.estado='1' order by t.nombre";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else
                {
                    if (codigo_empresa_global != "")
                    {
                        string sql = "select s.codigo,t.nombre,s.secuencia from tercero t join sucursal s on t.codigo=s.codigo where s.codigo_empresa='" + codigo_empresa_global.ToString() + "' and  t.nombre like '%" + nombre_txt.Text.Trim() + "%' order by t.nombre";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        string sql = "select s.codigo,t.nombre,s.secuencia from tercero t join sucursal s on t.codigo=s.codigo where  t.nombre like '%" + nombre_txt.Text.Trim() + "%' order by t.nombre";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando las sucursales");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sucursal s = new sucursal();
            s.ShowDialog();
        }
    }
}
