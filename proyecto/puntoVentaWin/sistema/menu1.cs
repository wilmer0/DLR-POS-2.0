using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVentaModelo;
using puntoVentaModelo.modelos;
using puntoVentaModelo.Modelos;
using puntoVentaWin.modulo_empresa;
using puntoVentaWin.modulo_facturacion;
using puntoVentaWin.modulo_opciones;
using puntoVentaWin.pruebas;

namespace puntoVenta.sistema
{
    public partial class menu1 : FormBase
    {


        //variable
        private string rutaProyectoActual = Directory.GetCurrentDirectory() + @"\";
        private string RutaImagenesVentanas = "";
        private string RutaImagenesModulos = "";
        Dictionary<string, Form> Ins = new Dictionary<string, Form>(); // Se Gurdan aqui los formularios que hayan sido abiertos para no volver a llamarlos




        //objetos
        private empleado empleado;
        private utilidades utilidades = new utilidades();
        private sistema_ventanas ventana;
        private sistema_modulo modulo;
        private Button botonModulo;
        private Button botonVentana;

        //modelos
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        modeloModulosVsVentanas modeloModuloVsVentanas=new modeloModulosVsVentanas();
        modeloModulos modeloModulo=new modeloModulos();
        modeloVentana modeloVentana=new modeloVentana();



        //listas
        private List<modulos_vs_ventanas> listaModulosVsVentanas;
        private List<sistema_modulo> listaModulos;
        List<sistema_ventanas> listaVentanas; 
        List<empleado_accesos_ventanas> listaEmpleadoVentanas; 




        public menu1(empleado empleadoAPP)
        {
            InitializeComponent();
            this.empleado = empleadoAPP;
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "menú");
            this.Text = tituloLabel.Text;
            RutaImagenesVentanas = rutaProyectoActual + @"Resources\ventanas\";
            RutaImagenesModulos = rutaProyectoActual + @"Resources\modulos\";
            LoadVentana();
        }


        public void loadModulos()
        {
            try
            {
                //cargar los modulos y ponerlo en el layout de modulos
                //if (listaModulosVsVentanas == null)
                //{
                //    listaModulosVsVentanas = new List<modulos_vs_ventanas>();
                //    listaModulosVsVentanas = modeloModuloVsVentanas.getListaCompleta();
                //}
                if (listaModulos == null)
                {
                    listaModulos=new List<sistema_modulo>();
                    listaModulos = modeloModulo.GetListaCompleta();
                }

                //limpiar el layout de modulos para empezar agregar
                if (flowLayoutModulos.Controls.Count > 0)
                {
                    flowLayoutModulos.Controls.Clear();
                }
               listaModulos.ForEach(x =>
               {
                   botonModulo=new Button();
                   botonModulo.FlatStyle = FlatStyle.Flat;
                   botonModulo.Width = 97;
                   botonModulo.Height = 77;
                   botonModulo.BackgroundImageLayout = ImageLayout.Stretch;
                   botonModulo.BackgroundImage=Image.FromFile(RutaImagenesModulos+x.imagen);
                   flowLayoutModulos.Controls.Add(botonModulo);
                   botonModulo.Click += (sender, args) =>  loadVentanas(x.id);
                 
               });


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadModulos.: " + ex.ToString(), "", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        public void loadVentanas(int idModulo)
        {
            try
            {
                listaVentanas = modeloVentana.getListaByModuloID(idModulo);
                if (flowLayoutVentanas.Controls.Count > 0)
                {
                    flowLayoutVentanas.Controls.Clear();
                }
                listaVentanas.ForEach(x =>
                {
                    botonVentana = new Button();
                    botonVentana.FlatStyle = FlatStyle.Flat;
                    botonVentana.Width = 93;
                    botonVentana.Height = 77;
                    botonVentana.BackgroundImageLayout=ImageLayout.Stretch;
                    botonVentana.BackgroundImage = Image.FromFile(RutaImagenesVentanas + x.imagen);
                    //instanciar formulario de la ventana con el nombre logico
                    botonVentana.Click += (sender, args) =>
                    {
                        //Assembly asm = Assembly.GetEntryAssembly();
                        string form = "puntoVentaWin." + x.sistema_modulo.nombre_modulo_proyecto + "."+ x.nombre_logico ;
                        //form = "puntoVentaWin.Form1";
                        MessageBox.Show(form);
                        Assembly asm = Assembly.GetEntryAssembly();
                        Type formtype = asm.GetType(form);

                        Form f = (Form)Activator.CreateInstance(formtype);
                        if (f != null)
                        {
                            f.ShowInTaskbar = false;
                            f.Owner = this;
                            f.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Form esta llgando nulo-->" + form);
                        }
                    };


                    flowLayoutVentanas.Controls.Add(botonVentana);
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentanas.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadVentana()
        {
            try
            {
                //cargar todos los modulos que tiene habilitados el empleado con todas las ventanas que tiene habilitadas
               loadModulos();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadVentana.: " + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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

        private void button11_Click(object sender, EventArgs e)
        {
            ventana_crear_modulo ventana = new ventana_crear_modulo(empleado);
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Maximized;
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }
        
    }
}
