using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVentaModelo;

namespace puntoVentaWin.ventanas
{
    public partial class ventana_busqueda_caja : Form
    {

        //listas



        //objetos
        private empleado empleado;

        public ventana_busqueda_caja()
        {
            InitializeComponent();

        }
        public ventana_busqueda_caja(empleado empleadoApp)
        {
            InitializeComponent();
            this.empleado = empleadoApp;
            
        }

        private void ventana_busqueda_caja_Load(object sender, EventArgs e)
        {

        }
    }
}
