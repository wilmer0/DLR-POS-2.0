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
    public partial class ventana_empresa : FormBase
    {


        //modelos
        modeloEmpresa modeloEmpresa=new modeloEmpresa();

        //objetos 
        public puntoVentaModelo.empresa empresa;
        utilidades utilidades=new utilidades();
        public  empleado empleado;

        public ventana_empresa(empleado empleadoA)
        {
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana empresa");
            this.Text = tituloLabel.Text;
            InitializeComponent();
            this.empleado = empleadoA;
            LoadVentana();
        }

        public override void LoadVentana()
        {
            try
            {
                if (empresa != null)
                {
                    empresaText.Text = empresa.nombre;
                    RncText.Text = empresa.rnc;
                    divisionText.Text = empresa.division;
                    activoCheck.Checked = (bool)empresa.activo;
                }
                else
                {
                    empresaText.Text = "";
                    RncText.Text = "";
                    divisionText.Text = "";
                    activoCheck.Checked = false;
                }
            }
            catch (Exception)
            {
            }
          
        }

        public override bool ValidarGetAction()
        {
            try
            {
                if (empresaText.Text == "")
                {
                    MessageBox.Show("Falta el nombre ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    empresaText.Focus();
                    empresaText.SelectAll();
                    return false;
                }
                if (RncText.Text == "")
                {
                    MessageBox.Show("Falta el rnc ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RncText.Focus();
                    RncText.SelectAll();
                    return false;
                }
                if (divisionText.Text == "")
                {
                    MessageBox.Show("Falta la división ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    divisionText.Focus();
                    divisionText.SelectAll();
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override void GetAcion()
        {
            try
            {
                if (!ValidarGetAction())
                    return;


                if (empresa == null)
                {
                    //agrega
                    empresa = new empresa();
                    empresa.codigo = modeloEmpresa.getNext();
                    empresa.nombre = empresaText.Text.Trim();
                    empresa.rnc = RncText.Text.Trim();
                    empresa.division = divisionText.Text.Trim();
                    empresa.activo = (bool) activoCheck.Checked;
                    if (modeloEmpresa.agregarEmpresa(empresa))
                    {
                        MessageBox.Show("Se agrego", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    empresa.nombre = empresaText.Text.Trim();
                    empresa.rnc = RncText.Text.Trim();
                    empresa.division = divisionText.Text.Trim();
                    empresa.activo = (bool)activoCheck.Checked;
                    if (modeloEmpresa.ModificarEmpresa(empresa))
                    {
                        MessageBox.Show("Se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAcion .:"+ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void limpiar()
        {
            LoadVentana();
        }

        private void empresa_Load(object sender, EventArgs e)
        {

        }
    }
}
