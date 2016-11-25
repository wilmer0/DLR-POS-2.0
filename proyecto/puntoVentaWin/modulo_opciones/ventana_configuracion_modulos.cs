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
        private sistema_modulo sistemaVentana;


        //listas
        List<sistema_modulo> listaVentanas=new List<sistema_modulo>();
        List<sistema_modulo> listaModulos=new List<sistema_modulo>(); 
        List<sistema_modulo> listaSistemaModulosVentanasGuardar=new List<sistema_modulo>(); 




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
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentanasList.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        public bool validarAgregarVentana()
        {
            try
            {
                if (sistemaModulo == null)
                {
                    MessageBox.Show("Debe seleccionar un módulo", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (sistemaVentana == null)
                {
                    MessageBox.Show("Debe seleccionar una ventana", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (listaModulos.ToList().Count==0)
                {
                    MessageBox.Show("No hay Módulos para agregar ventanas", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (dataGridViewVentanas.Rows.Count == 0)
                {
                    MessageBox.Show("No hay ventanas que agregar", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                
             
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewModulos_Leave(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewModulos_SelectionChanged(object sender, EventArgs e)
        {
            //modulo
            GetVentanaSistema();

        }

        private void dataGridViewVentanas_SelectionChanged(object sender, EventArgs e)
        {
            //ventana
            GetVentanaSistema();
            
        }

        public void GetVentanaSistema()
        {
            //modulo
            int index = dataGridViewModulos.CurrentRow.Index;
            if (index < 0)
                return;

            sistemaModulo = listaModulos[index];
            
            //ventana
            index = dataGridViewVentanas.CurrentRow.Index;
            if (index < 0)
                return;

        }
    }
}
