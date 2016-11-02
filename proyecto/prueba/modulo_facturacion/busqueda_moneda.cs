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
    public partial class busqueda_moneda : Form
    {
        public busqueda_moneda()
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    nombre_txt.Clear();
                    dataGridView1.Rows.Clear();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        public void cargar_monedas()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select codigo,nombre,tasa_actual,estado from moneda where estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando las monedas");
            }
        }
        private void busqueda_moneda_Load(object sender, EventArgs e)
        {
            cargar_monedas();
        }

        private void nombre_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select codigo,nombre,tasa_actual,estado from moneda where estado='1' and nombre like '%"+nombre_txt.Text.Trim()+"%'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las monedas por nombre");
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
    }
}
