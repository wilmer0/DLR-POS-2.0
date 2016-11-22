﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVentaModelo;
using puntoVentaModelo.modelos;


namespace puntoVenta.sistema
{
    public partial class login2 : FormBase
    {



        //modelos
        private modeloEmpleado modeloEmpleado = new modeloEmpleado();


        //objetos
        public puntoVentaModelo.empleado empleado;
        utilidades utilidades = new utilidades();
        


        public login2()
        {
            InitializeComponent();
            LoadVentana();
        }

        public override void LoadVentana()
        {
            this.tituloLabel.Text = "Inicio sesión";
            this.Text = tituloLabel.Text;
            if (usuarioText != null)
            {
                usuarioText.Clear();
                usuarioText.Focus();
                usuarioText.SelectAll();
            }
            if (claveText != null)
            {
                claveText.Clear();
            }
        }

        
        private void login2_Load(object sender, EventArgs e)
        {
            
        }


        public override bool ValidarGetAction()
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
            if (MessageBox.Show("Desea procesar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) ==DialogResult.No)
            {
                return;
            }
            if (!ValidarGetAction())
                return;

            empleado = new puntoVentaModelo.empleado();
            empleado.login = usuarioText.Text.Trim();
            empleado.clave = utilidades.encriptar(claveText.Text.Trim());
            

            bool existe = false;
            existe = modeloEmpleado.validarLogin(empleado);
            if (existe==true)
            {
                menu1 ventana = new menu1(empleado);
                ventana.ShowDialog();
                this.Hide();
                //MessageBox.Show("Existe");
            }
            else
            {
                empleado = null;
                MessageBox.Show("No existe el usuario", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        public override void limpiar()
        {
            if (MessageBox.Show("Desea limpiar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) ==DialogResult.Yes)
            {
                LoadVentana();
            }
        }

        public override void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) ==DialogResult.Yes)
            {
                Application.Exit();
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

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
