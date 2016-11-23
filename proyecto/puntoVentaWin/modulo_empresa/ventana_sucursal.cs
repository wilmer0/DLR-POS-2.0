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
using puntoVentaModelo.modelos;

namespace puntoVentaWin.modulo_empresa
{
    public partial class ventana_sucursal : FormBase
    {


        //modelos
        modeloSucursal modeloSucursal=new modeloSucursal();


        //empleado
        private empleado empleado;
        utilidades utilidades=new utilidades();
        private sucursal sucursal;


        public ventana_sucursal(empleado empleadoA)
        {
            this.empleado = empleadoA;
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "sucursal");
            this.Text = tituloLabel.Text;
            InitializeComponent();
            LoadVentana();
        }

        private void ventana_sucursal_Load(object sender, EventArgs e)
        {

        }

        public override void LoadVentana()
        {
            if (sucursal != null)
            {
                secuenciaText.Text = sucursal.secuencia;
                direccionText.Text = sucursal.direccion;
                activoCheck.Checked = (bool) sucursal.activo;
            }
            else
            {
                secuenciaText.Text = "";
                direccionText.Text = "";
                activoCheck.Checked = false;
            }
        }

        public override bool ValidarGetAction()
        {
            try
            {
                if (secuenciaText.Text.Trim() == "")
                {
                    MessageBox.Show("Falta la secuencia","", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    secuenciaText.Focus();
                    secuenciaText.SelectAll();
                    return false;
                }

                if (direccionText.Text.Trim() == "")
                {
                    MessageBox.Show("Falta la dirección", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    direccionText.Focus();
                    direccionText.SelectAll();
                    return false;
                }
                if (secuenciaText.Text.Length!=3)
                {
                    MessageBox.Show("La secuencia esta incompleta", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    secuenciaText.Focus();
                    secuenciaText.SelectAll();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ValidarGetAction.: " + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }


        public override void GetAcion()
        {
            try
            {

                if (!ValidarGetAction())
                    return;


                if (sucursal == null)
                {
                    //agrega
                    sucursal = new sucursal();
                    sucursal.secuencia = secuenciaText.Text.Trim();

                }
                else
                {
                    //modifica
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error GetAcion.: " + ex.ToString(), "", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                
            }
        }
    }
}
