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
using puntoVentaModelo.Modelos;

namespace puntoVentaWin.modulo_opciones
{
    public partial class ventana_crear_modulo : FormBase
    {


        //modelos
        modeloModulos modeloModulo=new modeloModulos();

        //objetos
        private empleado empleado;
        private sistema_modulo modulo;
        utilidades utilidades=new utilidades();


        
        public ventana_crear_modulo(empleado empleadoApp)
        {
            InitializeComponent();
            this.empleado = empleadoApp;
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "crear móodulo");
            this.Text = tituloLabel.Text;
            
        }

        public void loadVentana()
        {
            try
            {
                if (modulo != null)
                {
                    idText.Focus();
                    idText.SelectAll();
                    moduloText.Text = modulo.nombre;
                    nombreLogicoText.Text = modulo.nombre_modulo_proyecto;
                    imagenRutaText
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private void ventana_crear_modulo_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_buscar_modulo ventana=new ventana_buscar_modulo(empleado);
            ventana.Owner = this;
            ventana.ShowDialog();
        }
    }
}
