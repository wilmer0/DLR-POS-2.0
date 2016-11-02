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
    public partial class busqueda_permisos : Form
    {
        public busqueda_permisos()
        {
            InitializeComponent();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        internal singleton s { get; set; }
        
        private void busqueda_permisos_Load(object sender, EventArgs e)
        {
            cargar_permisos();
        }
        public void cargar_permisos()
        {
            try
            {
                string sql = "select codigo,descripcion from permiso where estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los permisos");
            }
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
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
                string sql = "select codigo,descripcion,estado from permiso where estado='1' and descripcion like '%"+nombre_txt.Text.Trim()+"%'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando los permisos por nombre");
            }
        }
    }
}
