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
using puntoVenta.clases;
using puntoVentaModelo;
using puntoVentaModelo.Modelos;

namespace puntoVentaWin.modulo_opciones
{
    public partial class ventana_configuracion_modulos : FormBase
    {

        
        //modelos
        modeloSistemaModulos modeloSistemaModulos=new modeloSistemaModulos();
        

        //objetos
        private empleado empleado;
        utilidades utilidades=new utilidades();
        private sistema_modulo sistemaModulo;
        private sistema_modulo_ventanas sistemaVentana;


        //listas
        List<sistema_modulo_ventanas> listaVentanas=new List<sistema_modulo_ventanas>();
        List<sistema_modulo> listaModulos=new List<sistema_modulo>(); 
        List<sistema_modulo_ventanas> listaSistemaModulosVentanasGuardar=new List<sistema_modulo_ventanas>(); 




        public ventana_configuracion_modulos(empleado empleadoA)
        {
            this.empleado = empleadoA;
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana configuración módulos");
            this.Text = tituloLabel.Text;
            InitializeComponent();
            loadVentana();
        }

        private void ventana_configuracion_modulos_Load(object sender, EventArgs e)
        {

        }
        

        public void loadModulosList()
        {
            try
            {
                dataGridViewModulos.Rows.Clear();
                listaModulos = modeloSistemaModulos.getListaSistemaModulos();
                listaModulos.ForEach(x =>
                {
                    //id-nombre modulo
                    dataGridViewModulos.Rows.Add(x.id, x.nombre);
                });
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
                dataGridViewVentanas.Rows.Clear();
                listaVentanas = modeloSistemaModulos.getListaSistemaVentanas();
                listaVentanas.ForEach(x =>
                {
                    //id-nombre ventana
                    dataGridViewVentanas.Rows.Add(x.codigo, x.descripcion);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentanasList.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadVentana()
        {
            try
            {
                loadModulosList();
                loadVentanasList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
            }
        }

        public override void limpiar()
        {
            loadVentana();
        }

        public override bool ValidarGetAction()
        {
            try
            {
                if (listaSistemaModulosVentanasGuardar.Count == 0 || listaSistemaModulosVentanasGuardar==null)
                {
                    MessageBox.Show("No hay elemento para agregar.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public override void GetAcion()
        {
            try
            {
                if (!ValidarGetAction())
                    return;


                modeloSistemaModulos.agregarModulosVentanas(listaSistemaModulosVentanasGuardar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAcion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        public void loadListVentanasGuardar()
        {
            try
            {
                dataGridViewVentanasGuardar.Rows.Clear();
                listaSistemaModulosVentanasGuardar.ForEach(x =>
                {
                    //nombre modulo-nombre ventana
                    dataGridViewVentanasGuardar.Rows.Add(x.sistema_modulo.nombre, x.descripcion);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentanasList.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
           agregarVentana();
        }

        public bool validarAgregarVentana()
        {
            try
            {
                if (dataGridViewModulos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay Módulos para agregar ventanas", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (dataGridViewVentanas.Rows.Count == 0)
                {
                    MessageBox.Show("No hay ventanas que agregar", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                bool existe = false;
                listaSistemaModulosVentanasGuardar.ForEach(x =>
                {
                    if (x.cod_modulo == sistemaModulo.id && x.codigo == sistemaVentana.codigo)
                    {
                        existe = true;
                        
                    }
                });
                if (existe)
                {
                    MessageBox.Show("Ya esta agregado el modulo seleccionado con la ventana seleccionada", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarAgregarVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void agregarVentana()
        {
            try
            {
                
                if (!validarAgregarVentana())
                    return;


                //modulo
                int index = dataGridViewModulos.CurrentRow.Index;
                sistemaModulo = listaModulos[index] as sistema_modulo;
                //MessageBox.Show("modulo--> " + sistemaModulo.id + "-" + sistemaModulo.nombre + "-" +sistemaModulo.nombre_modulo_proyecto);

                //ventana
                sistemaVentana = new sistema_modulo_ventanas();
                index = dataGridViewVentanas.CurrentRow.Index;
                sistemaVentana = listaVentanas[index] as sistema_modulo_ventanas;
                //MessageBox.Show("ventana--> " + sistemaVentana.codigo + "-" + sistemaVentana.descripcion + "-" +sistemaVentana.nombre_logico);
                
                listaSistemaModulosVentanasGuardar.Add(sistemaVentana);
                loadListVentanasGuardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
