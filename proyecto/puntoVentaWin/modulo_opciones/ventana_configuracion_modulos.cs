using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVentaWin;
using puntoVentaWin.clases;
using puntoVentaModelo;
using puntoVentaModelo.Modelos;

namespace puntoVentaWin.ventanas
{
    public partial class ventana_configuracion_modulos : FormBase
    {

        
        //modelos
        modeloModulos modeloModulos=new modeloModulos();
        modeloVentana modeloVentana=new modeloVentana();


        //objetos
        private empleado empleado;
        utilidades utilidades=new utilidades();
        private sistema_modulo modulo;
        private sistema_ventanas ventana;
        private modulos_vs_ventanas moduloVsVentana;

        //listas
        private List<sistema_ventanas> listaVentanas=new List<sistema_ventanas>();
        private List<sistema_modulo> listaModulos =new List<sistema_modulo>();
        private List<modulos_vs_ventanas> listaModuloVentanaGuardar = new List<modulos_vs_ventanas>();
        

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
                listaModuloVentanaGuardar = modeloVentana.getListaCompletaModulosVsVentanas();
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
            listaModuloVentanaGuardar = null;
            loadVentana();
        }

        public override bool ValidarGetAction()
        {
            try
            {
                if (listaModuloVentanaGuardar == null)
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

                //agregar y modificar
                listaModuloVentanaGuardar = listaModuloVentanaGuardar.Distinct().ToList();
                if ((modeloVentana.agregarModuloVsVentana(listaModuloVentanaGuardar)) == true)
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

                if (listaModuloVentanaGuardar == null)
                {
                    listaModuloVentanaGuardar = new List<modulos_vs_ventanas>();
                    listaModuloVentanaGuardar = modeloVentana.getListaCompletaModulosVsVentanas();
                }


                listaModuloVentanaGuardar.ForEach(x =>
                {
                    //MessageBox.Show("modulo->"+x.id_modulo+"     ventana-> "+x.id_ventana);
                    //dataGridView.Rows.Add(x.sistema_modulo.nombre,x.sistema_ventanas.nombre_ventana);                   
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
                listaModuloVentanaGuardar.ForEach(ven =>
                {
                    //MessageBox.Show("insertar: modulo-->"+modulo.id+"   ventana-->"+ventana.codigo+"    actual: modulo-->"+ven.cod_modulo+"  ventana--> "+ven.codigo);
                    if (ven.id_modulo==modulo.id && ven.id_ventana==ventana.codigo)
                    {
                        existe = true;
                    }
                });

                if (existe == true)
                {
                    MessageBox.Show("Ya existe el modulo->" + modulo.nombre + "-  y la ventana-->" + ventana.nombre_ventana);
                    return false;
                }

                moduloVsVentana=new modulos_vs_ventanas();
                moduloVsVentana.id_modulo = modulo.id;
                moduloVsVentana.id_ventana = ventana.codigo;
                listaModuloVentanaGuardar.Add(moduloVsVentana);
                loadList();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarAgregarVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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


                listaModuloVentanaGuardar.RemoveAt(index);
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
            GetAction();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }
}
