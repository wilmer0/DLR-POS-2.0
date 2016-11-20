using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using puntoVentaModelo1.modelos;

namespace puntoVenta.sistema
{
    public partial class login2 : FormBase
    {



        //modelos
        private modeloEmpleado modeloEmpleado = new modeloEmpleado();


        //objetos
        public puntoVentaModelo1.empleado empleado;




        public login2()
        {
            InitializeComponent();
            LoadVentana();
        }

        public override void LoadVentana()
        {
            this.tituloLabel.Text = "Inicio sesión";
            this.Text = tituloLabel.Text;
            //usuarioText.SelectAll();
            
        }

        private void login2_Load(object sender, EventArgs e)
        {

        }


        public override bool ValidarCampos()
        {
            try
            {
                if (usuarioText.Text == "")
                {
                    MessageBox.Show("Falta el usuario","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    usuarioText.Focus();
                    usuarioText.SelectAll();
                    return false;
                }

                if (claveText.Text == "")
                {
                    MessageBox.Show("Falta el clave", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    claveText.Focus();
                    claveText.SelectAll();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ValidarCampos.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }


        public override void GetAcion()
        {
            if (!ValidarCampos())
                return;

            empleado=new puntoVentaModelo1.empleado();
            empleado.login = usuarioText.Text.Trim();
            empleado.clave = claveText.Text.Trim();

            if (modeloEmpleado.validarLogin(empleado))
            {
                menu1 ventana = new menu1(empleado);
                ventana.ShowDialog();
                this.Hide();
            }
            else
            {
                empleado = null;
                MessageBox.Show("No existe el usuario", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usuarioText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                claveText.Focus();
                claveText.SelectAll();
            }
        }

        private void claveText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }
    }
}
