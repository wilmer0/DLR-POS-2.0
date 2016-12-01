﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVenta;
using puntoVenta.clases;
using puntoVentaModelo;
using puntoVentaModelo.Modelos;

namespace puntoVentaWin.modulo_opciones
{
    public partial class ventana_configuracion_modulos : FormBase
    {

        
        //modelos
        modeloSistemaModulos modeloModulos=new modeloSistemaModulos();
        modeloSistemaVentana modeloVentana=new modeloSistemaVentana();


        //objetos
        private empleado empleado;
        utilidades utilidades=new utilidades();
        private sistema_modulo modulo;
        private sistema_ventanas ventana;
        private sistema_ventanas ventanaAgregar;

        //listas
        private List<sistema_ventanas> listaVentanas=new List<sistema_ventanas>();
        private List<sistema_modulo> listaModulos =new List<sistema_modulo>();
        private List<sistema_ventanas> listaVentanasGuardar=new List<sistema_ventanas>();
        

        public ventana_configuracion_modulos(empleado empleadoA)
        {
            InitializeComponent();
            this.empleado = empleadoA;
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana configuración módulos");
            this.Text = tituloLabel.Text;
           
            loadVentana();
        }

        private void ventana_configuracion_modulos_Load(object sender, EventArgs e)
        {
           
        }
        

        public void loadVentana()
        {
            try
            {
                listaVentanasGuardar = modeloVentana.getListaCompleta();
                loadModulosList();
                loadVentanasList();
                loadList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
            }
        }

        public override void Salir()
        {
            this.Close();
        }

        public override void limpiar()
        {
            listaVentanasGuardar = null;
            loadVentana();
        }

        public override bool ValidarGetAction()
        {
            try
            {
                if (listaVentanasGuardar == null)
                {
                    MessageBox.Show("Debe crear uns lista de modulos y ventanas", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ValidarGetAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public override void GetAction()
        {
            try
            {
                if (!ValidarGetAction())
                    return;

                //agregar o modificar
                if ((modeloVentana.agregarModulosVentanas(listaVentanasGuardar)) == true)
                {
                    MessageBox.Show("Se realizó correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No realizó correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAcion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        public void loadList()
        {
            try
            {

                //MessageBox.Show("nueva cantidad items-->" + listaVentanasGuardar.ToList().Count);
                if (dataGridView.Rows.Count > 0)
                {
                    dataGridView.Rows.Clear();
                }

                if (listaVentanas == null)
                    return;

                if (listaVentanasGuardar == null)
                {
                    listaVentanasGuardar = new List<sistema_ventanas>();
                    listaVentanasGuardar = modeloVentana.getListaCompleta();
                }

                listaVentanasGuardar.ForEach(x =>
                {
                    //MessageBox.Show("1");
                    //MessageBox.Show("modulo->" + x.sistema_modulo.nombre_modulo_proyecto + "- ventana->" + x.nombre_ventana);
                    //if (x.sistema_modulo.nombre == null && x.nombre_ventana!=null)
                    //{
                    //dataGridView.Rows.Add(x.sistema_modulo.nombre, x.nombre_ventana);
                    //eploto poniendo el nombre del modulo
                    modulo = new sistema_modulo();
                    if (x.cod_modulo != null)
                    {
                        modulo = modeloModulos.getModuloById(x.cod_modulo);
                    }
                    dataGridView.Rows.Add(modulo.nombre, x.nombre_ventana);
                    //}
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadList.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validarAgregarVentana())
                    return;

               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregando.: " + ex.ToString());
            }
        }

        public bool validarAgregarVentana()
        {
            try
            {
                ventana = ventanaCombo.SelectedItem as sistema_ventanas;
                modulo = moduloCombo.SelectedItem as sistema_modulo;
                
                if (modulo == null)
                {
                    MessageBox.Show("Debe seleccionar un módulo", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (ventana == null)
                {
                    MessageBox.Show("Debe seleccionar una ventana", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                bool existe = false;
                listaVentanasGuardar.ForEach(ven =>
                {
                    //MessageBox.Show("insertar: modulo-->"+modulo.id+"   ventana-->"+ventana.codigo+"    actual: modulo-->"+ven.cod_modulo+"  ventana--> "+ven.codigo);
                    if (ven.cod_modulo==modulo.id && ven.codigo==ventana.codigo)
                    {
                        existe = true;
                    }
                });

                if (existe == true)
                {
                    MessageBox.Show("Ya existe el modulo->" + modulo.nombre + "-  y la ventana-->" + ventana.nombre_ventana);
                    return false;
                }
                ventanaAgregar=new sistema_ventanas();
                ventanaAgregar.codigo = ventana.codigo;
                ventanaAgregar.nombre_ventana = ventana.nombre_ventana;
                ventanaAgregar.cod_modulo = modulo.id;
                ventanaAgregar.nombre_logico = ventana.nombre_logico;
                ventanaAgregar.imagen = ventana.imagen;
                ventanaAgregar.activo = ventana.activo;

                listaVentanasGuardar.Add(ventanaAgregar);
                loadList();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarAgregarVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void agregarItem()
        {
            try
            {
                if (!validarAgregarVentana())
                    return;


               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarItem.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewModulos_Leave(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewModulos_SelectionChanged(object sender, EventArgs e)
        {
           //modulo
           loadModulosList();

        }

        private void dataGridViewVentanas_SelectionChanged(object sender, EventArgs e)
        {
            //ventana
            loadVentanasList(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea quitar de la lista?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                eliminarItem();
            }
        }

        public void eliminarItem()
        {
            try
            {
                int index = dataGridView.CurrentRow.Index;
                if (index < 0)
                    return;


                listaVentanasGuardar.RemoveAt(index);
                loadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void moduloCombo_TextChanged(object sender, EventArgs e)
        {
            modulo=moduloCombo.SelectedItem as sistema_modulo;
        }

        private void ventanaCombo_TextChanged(object sender, EventArgs e)
        {
            ventana=ventanaCombo.SelectedItem as sistema_ventanas;
        }

        public void loadModulosList()
        {
            try
            {
                listaModulos = modeloModulos.GetListaCompleta();
                moduloCombo.DisplayMember = "nombre";
                moduloCombo.SelectedValue = "id";
                moduloCombo.DataSource = listaModulos.ToList();
                moduloCombo.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadModulosList.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadVentanasList()
        {
            try
            {

                listaVentanas = modeloVentana.getListaCompleta();
                ventanaCombo.DisplayMember = "nombre_ventana";
                ventanaCombo.SelectedValue = "codigo";
                ventanaCombo.DataSource = listaVentanas.ToList();
                ventanaCombo.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentanasList.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
    }
}
