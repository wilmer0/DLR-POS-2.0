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
    public partial class busqueda_departamento : Form
    {
        public busqueda_departamento()
        {
            InitializeComponent();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        public bool mantenimiento = false;
        public string codigo_sucursal = "";
        private void busqueda_departamento_Load(object sender, EventArgs e)
        {
            cargar_departamento();
        }
        public void cargar_departamento()
        {
            try
            {
                if (mantenimiento == false)
                {
                    if (codigo_sucursal.ToString() == "")
                    {
                        string sql = "select codigo,nombre,estado from departamento where estado='1'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        
                        string sql = "select codigo,nombre,estado from departamento where estado='1' and cod_sucursal='"+codigo_sucursal.ToString()+"'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else
                {
                    if (codigo_sucursal.ToString() == "")
                    {
                        string sql = "select codigo,nombre,estado from departamento";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        string sql = "select codigo,nombre,estado from departamento where cod_sucursal='"+codigo_sucursal.ToString()+"'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los departamentos");
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

            try
            {
                if (mantenimiento == false)
                {
                    if (codigo_sucursal.ToString() == "")
                    {
                        string sql = "select codigo,nombre,estado from departamento where estado='1' and nombre like '%" + nombre.Text.Trim() + "%'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        string sql = "select codigo,nombre,estado from departamento where estado='1' and nombre like '%" + nombre.Text.Trim() + "%' and cod_sucursal='" + codigo_sucursal.ToString() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else
                {
                    if (codigo_sucursal.ToString() == "")
                    {
                        string sql = "select codigo,nombre,estado from departamento where nombre like '%" + nombre.Text.Trim() + "%'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        string sql = "select codigo,nombre,estado from departamento where nombre like '%" + nombre.Text.Trim() + "%' and cod_sucursal='"+codigo_sucursal.ToString()+"'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los departamentos");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            departamento d = new departamento();
            d.ShowDialog();
        }
    }
}
