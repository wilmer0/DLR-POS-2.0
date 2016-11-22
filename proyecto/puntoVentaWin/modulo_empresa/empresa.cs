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
    public partial class empresa : FormBase
    {


        //modelos
        modeloEmpresa modeloEmpresa=new modeloEmpresa();

        //objetos 
        public empresa empresa;
        utilidades utilidades=new utilidades();
        public  empleado empleado;

        public empresa(empleado empleadoA)
        {
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "empresa");
            this.Text = tituloLabel.Text;
            InitializeComponent();
            this.empleado = empleadoA;
            LoadVentana();
        }

        public override void LoadVentana()
        {
            if (empresa != null)
            {

            }
            else
            {
                
            }



        }

        public override bool ValidarGetAction()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override void GetAcion()
        {

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
