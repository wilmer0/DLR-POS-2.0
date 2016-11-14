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
    public partial class busqueda_almacen : Form
    {
        public busqueda_almacen()
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
        public delegate void pasar(string dato);
        public event pasar pasado;
        internal singleton s { get; set; }
        public string codigo_sucursal = null;
        public bool mantenimiento = false;
        private void busqueda_almacen_Load(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            cargar_almacen();
            // MessageBox.Show(s.codigo_sucursal.ToString()+"-"+s.codigo_usuario.ToString());
        }
        public void cargar_almacen()
        {
            try
            {
                if (mantenimiento == false)
                {
                    if (codigo_sucursal.ToString() != null)
                    {
                        string sql = "select a.codigo,a.nombre,t.nombre as sucursal,a.estado from almacen a join tercero t  on a.cod_sucursal=t.codigo where a.estado='1' and a.cod_sucursal='" + codigo_sucursal.ToString() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        string sql = "select a.codigo,a.nombre,t.nombre as sucursal,a.estado from almacen a join tercero t on a.cod_sucursal=t.codigo where a.estado='1'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else
                {
                    //entonces es para mantenimiento sin importar si esta activo o no el almacen
                    if (codigo_sucursal.ToString() != null)
                    {
                        string sql = "select a.codigo,a.nombre,t.nombre as sucursal,a.estado from almacen a join tercero t  on a.cod_sucursal=t.codigo where a.cod_sucursal='" + codigo_sucursal.ToString() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        string sql = "select a.codigo,a.nombre,t.nombre as sucursal,a.estado from almacen a join tercero t on a.cod_sucursal=t.codigo";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los almacenes");
            }
        }

        private void nombre_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (mantenimiento == false)
                {
                    if (codigo_sucursal.ToString() != null)
                    {
                        string sql = "select a.codigo,a.nombre,t.nombre as sucursal,a.estado from almacen a join tercero t  on a.cod_sucursal=t.codigo where a.estado='1' and a.cod_sucursal='" + codigo_sucursal.ToString() + "' and a.nombre like '%" + nombre_txt.Text.Trim() + "%'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        string sql = "select a.codigo,a.nombre,t.nombre as sucursal,a.estado from almacen a join tercero t  on a.cod_sucursal=t.codigo where a.estado='1' and a.nombre like '%" + nombre_txt.Text.Trim() + "%'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                else
                {
                    if (codigo_sucursal.ToString() != null)
                    {
                        string sql = "select a.codigo,a.nombre,t.nombre as sucursal,a.estado from almacen a join tercero t  on a.cod_sucursal=t.codigo where  a.cod_sucursal='" + codigo_sucursal.ToString() + "' and a.nombre like '%" + nombre_txt.Text.Trim() + "%'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        string sql = "select a.codigo,a.nombre,t.nombre as sucursal,a.estado from almacen a join tercero t  on a.cod_sucursal=t.codigo where a.nombre like '%" + nombre_txt.Text.Trim() + "%'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando almacenes por nombre");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            almacen a = new almacen();
            a.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
