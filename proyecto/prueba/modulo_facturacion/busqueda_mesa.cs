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
    public partial class busqueda_mesa : Form
    {
        public busqueda_mesa()
        {
            InitializeComponent();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        internal singleton s { get; set; }
        public bool mantenimiento = false;
        private void busqueda_mesa_Load(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select codigo,nombre,estado from mesas where estado='1' and cod_sucursal='" + s.codigo_sucursal.ToString() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select codigo,nombre,estado from mesas where cod_sucursal='" + s.codigo_sucursal.ToString() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los datos");
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

        private void button3_Click(object sender, EventArgs e)
        {
            mesas me = new mesas();
            me.ShowDialog();
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
            s = singleton.obtenerDatos();
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select codigo,nombre,estado from mesas where estado='1' and cod_sucursal='" + s.codigo_sucursal.ToString() + "' and nombre like '%" + nombre_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select codigo,nombre,estado from mesas where cod_sucursal='" + s.codigo_sucursal.ToString() + "' and nombre like '%" + nombre_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los datos");
            }
        }
    }
}
