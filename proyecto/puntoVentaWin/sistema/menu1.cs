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
using puntoVentaWin.modulo_empresa;
using puntoVentaWin.modulo_facturacion;
using puntoVentaWin.modulo_opciones;
using puntoVentaWin.pruebas;

namespace puntoVenta.sistema
{
    public partial class menu1 : FormBase
    {

        //objetos
        private empleado empleado;
        private utilidades utilidades = new utilidades();


        //modelos
        modeloEmpleado modeloEmpleado=new modeloEmpleado();


        //listas
        List<sistema_modulo> listaModulos=new List<sistema_modulo>();
        List<sistema_ventanas> listaModuloVentanas = new List<sistema_ventanas>(); 
        List<empleado_accesos_ventanas> listaEmpleadoVentanas=new List<empleado_accesos_ventanas>(); 

        public menu1(empleado empleadoA)
        {
            this.empleado = empleadoA;
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "menú");
            this.Text = tituloLabel.Text;
            InitializeComponent();
            LoadVentana();
        }

        public  void LoadVentana()
        {
            //cargar todos los modulos que tiene habilitados el empleado con todas las ventanas que tiene habilitadas
            //listaModuloVentanas = modeloEmpleado.GetListaVentanasByEmpleado(empleado);

            

        }

        private void menu1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Salir();
        }

        public override void Salir()
        {
            login2 ventana=new login2();
            ventana.Show();
            this.Close();
        }

        public override void limpiar()
        {
            //limpiar para recargar permisos
        }

        public override void GetAction()
        {
            //cargar todos los modulos y ventanas que el usuario tenga permitido ver
        }

        public override bool ValidarGetAction()
        {
            try
            {
                //

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ValidarGetAction.:" + ex.ToString());
                return false;
            }
        }

        private void menu1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            ventana_empresa ventana=new ventana_empresa(empleado);
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void flowLayoutOpciones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ventana_sucursal ventana=new ventana_sucursal(empleado);
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ventana_caja ventana=new ventana_caja(empleado);
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ventana_mapa ventana=new ventana_mapa();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ventana_configuracion_modulos ventana=new ventana_configuracion_modulos(empleado);
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ventana_crear_ventana ventana=new ventana_crear_ventana(empleado);
            ventana.Owner = this;
            ventana.ShowDialog();
        }
        
    }
}
