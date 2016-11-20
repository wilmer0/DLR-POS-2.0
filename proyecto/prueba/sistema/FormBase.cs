﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using puntoVenta.sistema;
using MySql.Data.Entity;
using System.Data.Entity;

namespace puntoVenta
{
    public partial class FormBase : Form
    {


        //objeto
        

        public FormBase()
        {
            InitializeComponent();
            LoadVentana();
        }



        public virtual void LoadVentana()
        {

        }

        public virtual Boolean ValidarCampos()
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

        public virtual void GetAcion()
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
            GetAcion();
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
                GetAcion();
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
                GetAcion();
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
                GetAcion();
            }
        }

    }
}
