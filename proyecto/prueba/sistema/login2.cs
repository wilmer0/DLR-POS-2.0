using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVenta.sistema;
namespace puntoVenta.sistema
{
    public partial class login2 : FormBase
    {


        //objetos
        Utilidades utilidades=new Utilidades();


        public login2()
        {
            InitializeComponent();
            loadVentana();
        }

        private void login2_Load(object sender, EventArgs e)
        {
            
        }

        public override void loadVentana()
        {
           this.Text= utilidades.GetTituloVentana("Usuario", "Login");
        }

        public override bool ValidarCampos()
        {
            try
            {


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validando.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public override void Procesar()
        {
            try
            {


                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error procesando.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
