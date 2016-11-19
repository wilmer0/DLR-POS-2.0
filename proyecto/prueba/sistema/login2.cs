﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVentaModelo.modelos;

namespace puntoVenta.sistema
{
    public partial class login2 : FormBase
    {



        //modelos
        private modeloEmpleado modeloEmpleado = new modeloEmpleado();


        //objetos
        public puntoVentaModelo.empleado empleado;




        public login2()
        {
            InitializeComponent();
            LoadVentana();
        }

        public override void LoadVentana()
        {
            
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
    }
}
