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
    public partial class impuesto_sobre_renta : Form
    {
        public impuesto_sobre_renta()
        {
            InitializeComponent();
        }

        private void impuesto_sobre_renta_Load(object sender, EventArgs e)
        {
            cargar_datos();
        }
        public void cargar_datos()
        {
            try
            {
                string sql = "";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                porciento_isr_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los datos");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
