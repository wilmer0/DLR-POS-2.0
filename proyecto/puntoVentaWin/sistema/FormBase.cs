﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using puntoVentaModelo;
using System.Runtime.InteropServices;
using puntoVentaWin.ventanas;
using  puntoVentaWin.ventanas;
using puntoVentaWin.ventanas;

namespace puntoVentaWin
{
    public partial class FormBase : Form
    {

        //mover form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //objeto
        utilidades utilidades=new utilidades();
        private empleado empleado;

        public FormBase()
        {
            InitializeComponent();
            LoadVentana();
        }



        public virtual void LoadVentana()
        {
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "menú");
            this.Text = tituloLabel.Text;
        }

        public virtual Boolean ValidarGetAction()
        {

            return true;
        }

        public virtual void limpiar()
        {
            if (MessageBox.Show("Desea limpiar los campos?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
            }
        }

        public virtual void Salir()
        {
            if(MessageBox.Show("Desea salir?","",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Close();
            }
        }

        public virtual void GetAction()
        {
            if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            
        }
        

        private void usuarioText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Salir();
            }

            if (e.KeyCode == Keys.F6)
            {
                limpiar();
            }

            if (e.KeyCode == Keys.F8)
            {
                GetAction();
            }
        }

        private void claveText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Salir();
            }

            if (e.KeyCode == Keys.F6)
            {
                limpiar();
            }

            if (e.KeyCode == Keys.F8)
            {
                GetAction();
            }
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            //panel para ocultar los controles que no quiero mostrar en los hijos en tiempo de diseño
        }

        private void FormBase_Load_1(object sender, EventArgs e)
        {

        }

        private void FormBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Salir();
            }

            if (e.KeyCode == Keys.F6)
            {
                limpiar();
            }

            if (e.KeyCode == Keys.F8)
            {
                GetAction();
            }
            //mover form sin borde
            //ReleaseCapture();
            //SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void tituloLabel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

    }
}
