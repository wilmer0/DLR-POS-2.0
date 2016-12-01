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
using puntoVentaModelo;
using puntoVentaModelo.Modelos;

namespace puntoVentaWin.modulo_opciones
{
    public partial class ventana_crear_ventana : FormBase
    {


        //objetos
        private empleado empleado;
        private sistema_ventanas ventana_sistema;
        private sistema_modulo modulo_sistema;
        utilidades utilidades=new utilidades();



        //modelos
        private modeloSistemaVentana modeloVentana=new modeloSistemaVentana();







        public ventana_crear_ventana(empleado empleadoApp)
        {
            InitializeComponent();
            this.empleado = empleadoApp;
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "creación de ventanas");
            this.Text = tituloLabel.Text;
            loadVentana();

        }

        public void loadVentana()
        {
            try
            {
                if (ventana_sistema != null)
                {
                    ventanaText.Focus();
                    ventanaText.SelectAll();
                    idText.Text = ventana_sistema.codigo.ToString();
                    ventanaText.Text = ventana_sistema.nombre_ventana;
                    nombreLogicoText.Text = ventana_sistema.nombre_logico;
                    imagenRutaText.Text = ventana_sistema.imagen;
                    activoCheck.Checked = (bool) ventana_sistema.activo;
                }
                else
                {
                    ventanaText.Focus();
                    ventanaText.SelectAll();
                    idText.Text = "";
                    ventanaText.Text = "";
                    nombreLogicoText.Text = "";
                    imagenRutaText.Text = "";
                    activoCheck.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_crear_ventana_Load(object sender, EventArgs e)
        {

        }

        public override bool ValidarGetAction()
        {
            try
            {
                if (ventanaText.Text == "")
                { 
                    MessageBox.Show("Falta el nombre de la ventana.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ventanaText.Focus();
                    ventanaText.SelectAll();
                    return false;
                }
                if (nombreLogicoText.Text == "")
                {
                    MessageBox.Show("Falta el nombre lógico.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nombreLogicoText.Focus();
                    nombreLogicoText.SelectAll();
                    return false;
                }
                if (imagenRutaText.Text == "")
                {
                    MessageBox.Show("Falta la imagen.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    imagenRutaText.Focus();
                    imagenRutaText.SelectAll();
                    return false;
                }
                if (modulo_sistema==null)
                {
                    MessageBox.Show("Falta el módulo.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    idModuloText.Focus();
                    idModuloText.SelectAll();
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


                bool crear = false;
                if (ventana_sistema == null)
                {
                    //se crea
                    crear = true;
                    ventana_sistema=new sistema_ventanas();
                    ventana_sistema.codigo = modeloVentana.getNext();
                }
                ventana_sistema.nombre_ventana = ventanaText.Text;
                ventana_sistema.nombre_logico = nombreLogicoText.Text;
                ventana_sistema.cod_modulo = modulo_sistema.id;
                ventana_sistema.imagen = imagenRutaText.Text;
                ventana_sistema.activo = (bool) activoCheck.Checked;


                if (crear == true)
                {
                    //se agrega
                    if ((modeloVentana.agregarVentana(ventana_sistema))==true)
                    {
                        MessageBox.Show("Se agregó la ventana", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No agregó la ventana", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }    
                }
                else
                {
                    //se modifica
                    if ((modeloVentana.modificarVentanas(ventana_sistema)) == true)
                    {
                        MessageBox.Show("Se modificó la ventana", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No modificó la ventana", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAcion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public override void limpiar()
        {
            if (MessageBox.Show("Desea limpiar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ventana_sistema = null;
                loadVentana();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    //MessageBox.Show(file.FileName);
                    imagenRutaText.Text = file.FileName;
                    panel3.BackgroundImage = Image.FromFile(imagenRutaText.Text);
                }
            }
            catch (Exception)
            {
                imagenRutaText.Text = "";
                panel3.BackgroundImage = null;
                MessageBox.Show("Debe seleccionar una imagen valida", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                imagenRutaText.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_buscar_ventana ventana=new ventana_buscar_ventana();
            ventana.Owner = this;
            ventana.ShowDialog();
        }
    }
}
