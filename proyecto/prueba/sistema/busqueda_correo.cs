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
namespace puntoVenta.sistema
{
    public partial class busqueda_correo : Form
    {
        public busqueda_correo()
        {
            InitializeComponent();
            cargar_correos();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        internal singleton s { get; set; }
        public string codigo_sucursal = null;
        public bool mantenimiento = false;
        private void busqueda_correo_Load(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Deseas salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public void cargar_correos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select codigo,correo from correo_electronicos";
                if(correoText.Text.Trim()!="")
                {
                    sql += " where correo like '%"+correoText.Text.Trim()+"%'";
                }
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando los correos: "+ex.ToString());
            }
        }

        private void correoText_KeyUp(object sender, KeyEventArgs e)
        {
            cargar_correos();
        }



    }
}
