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
    public partial class busqueda_cuadre : Form
    {
        public busqueda_cuadre()
        {
            InitializeComponent();
        }
        internal singleton s { get; set; }
        public delegate void pasar(string dato);
        public event pasar pasado;
        private void busquedas_cuadre_Load(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            cargar_datos();
        }
        public void cargar_datos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select codigo,cod_cajero,fecha,turno from cuadre_caja where estado='1' and abierta_cerrada='C' order by fecha desc";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    string cmd="select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='"+row[0].ToString()+"'";
                    DataSet dx = Utilidades.ejecutarcomando(cmd);
                    string nombre = dx.Tables[0].Rows[0][0].ToString();
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(),nombre,row[2].ToString(),row[3].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los datos");
            }
        }

        private void nombre_txt_KeyUp(object sender, KeyEventArgs e)
        {
            buscar();
        }
        public void buscar()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select codigo,cod_cajero,fecha,turno from cuadre_caja where estado='1' and abierta_cerrada='C' and fecha<='" + fecha.Value.ToString("yyyy-MM-dd")+ "' order by fecha desc";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string cmd = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + row[0].ToString() + "'";
                    DataSet dx = Utilidades.ejecutarcomando(cmd);
                    string nombre = dx.Tables[0].Rows[0][0].ToString();
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), nombre, row[2].ToString(), row[3].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los datos por fecha");
                fecha.Value = DateTime.Today;
                cargar_datos();
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

        private void fecha_ValueChanged(object sender, EventArgs e)
        {
            buscar();
        }
    }
}
