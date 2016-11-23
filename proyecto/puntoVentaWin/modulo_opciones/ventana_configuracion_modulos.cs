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
using puntoVenta.clases;
using puntoVentaModelo;

namespace puntoVentaWin.modulo_opciones
{
    public partial class ventana_configuracion_modulos : FormBase
    {

        
        //modelos


        //objetos
        private empleado empleado;
        utilidades utilidades=new utilidades();


        public ventana_configuracion_modulos(empleado empleado)
        {
            InitializeComponent();
        }

        private void ventana_configuracion_modulos_Load(object sender, EventArgs e)
        {

        }
    }
}
