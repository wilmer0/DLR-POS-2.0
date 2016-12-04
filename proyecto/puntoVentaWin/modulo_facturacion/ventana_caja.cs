using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVentaWin;
using puntoVentaModelo;

namespace puntoVentaWin.ventanas
{
    public partial class ventana_caja : FormBase
    {


        //objetos
        private empleado empleado;
        utilidades utilidades=new utilidades();



        public ventana_caja( empleado empleadoA)
        {
            this.empleado = empleadoA;
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana caja");
            this.Text = tituloLabel.Text;
            InitializeComponent();
            LoadVentana();
            cajaIdText.Select();
        }

        public  void LoadVentana()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadVentana.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ventana_caja_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_caja ventana=new ventana_busqueda_caja(empleado);
            ventana.Owner = this;
            ventana.ShowDialog();
        }
    }
}
