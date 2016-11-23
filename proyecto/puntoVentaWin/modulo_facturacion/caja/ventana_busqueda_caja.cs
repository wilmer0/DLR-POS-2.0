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
using puntoVentaModelo;

namespace puntoVentaWin.modulo_facturacion.caja
{
    public partial class ventana_busqueda_caja : FormBase
    {

        //modelos


        //objetos
        utilidades utilidades=new utilidades();
        private empleado empleado;

        public ventana_busqueda_caja(empleado empleadoA)
        {
            this.empleado = empleadoA;
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana busqueda caja");
            this.Text = tituloLabel.Text;
            InitializeComponent();
            LoadVentana();
        }


        public override void LoadVentana()
        {
            try
            {
                nombreText.Focus();
                nombreText.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ventana_busqueda_caja_Load(object sender, EventArgs e)
        {

        }
    }
}
