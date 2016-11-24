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
using puntoVentaModelo.Modelos;

namespace puntoVentaWin.modulo_opciones
{
    public partial class ventana_configuracion_modulos : FormBase
    {

        
        //modelos
        modeloSistemaModulos modeloSistemaModulos=new modeloSistemaModulos();


        //objetos
        private empleado empleado;
        utilidades utilidades=new utilidades();
        private sistema_modulo sistemaModulo;
        private sistema_modulo_ventanas sistemaVentana;

        public ventana_configuracion_modulos(empleado empleadoA)
        {
            this.empleado = empleadoA;
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana configuración móodulos");
            this.Text = tituloLabel.Text;
            InitializeComponent();
        }

        private void ventana_configuracion_modulos_Load(object sender, EventArgs e)
        {

        }


        public void loadVentana()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
            }
        }


        public override bool ValidarGetAction()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ValidarGetAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public override void GetAcion()
        {
            if (!ValidarGetAction())
                return;




        }
    }
}
