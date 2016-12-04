using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVenta;
using puntoVentaModelo;
using puntoVentaModelo.Modelos;

namespace puntoVentaWin.modulo_opciones
{
    public partial class ventana_crear_modulo : FormBase
    {


        //variables
        private string rutaProyectoActual = Directory.GetCurrentDirectory() + @"\";
        private string RutaImagenesModulos = "";


        //modelos
        modeloModulos modeloModulo=new modeloModulos();

        //objetos
        private empleado empleado;
        private sistema_modulo modulo;
        utilidades utilidades=new utilidades();


        
        public ventana_crear_modulo(empleado empleadoApp)
        {
            InitializeComponent();
            this.empleado = empleadoApp;
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "crear móodulo");
            this.Text = tituloLabel.Text;
            RutaImagenesModulos = rutaProyectoActual + @"Resources\modulos\";
        }

        public void loadVentana()
        {
            try
            {
                if (modulo != null)
                {
                    idText.Focus();
                    idText.SelectAll();
                    moduloText.Text = modulo.nombre;
                    nombreLogicoText.Text = modulo.nombre_modulo_proyecto;
                    imagenRutaText.Text = modulo.imagen;
                    panel3.BackgroundImage = Image.FromFile(RutaImagenesModulos + imagenRutaText.Text.Trim());
                    activoCheck.Checked = (bool) modulo.activo;
                }
                else
                {
                    idText.Focus();
                    idText.SelectAll();
                    moduloText.Text = "";
                    nombreLogicoText.Text = "";
                    imagenRutaText.Text = "";
                    panel3.BackgroundImage = null;
                    activoCheck.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private void ventana_crear_modulo_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_buscar_modulo ventana=new ventana_buscar_modulo(empleado);
            ventana.Owner = this;
            ventana.ShowDialog();
            if ((modulo = ventana.GetModulo) != null)
            {
                loadVentana();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public override bool ValidarGetAction()
        {
            try
            {
                if (moduloText.Text == "")
                {
                    MessageBox.Show("Falta el nombre del móodulo.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    moduloText.Focus();
                    moduloText.SelectAll();
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
                if (modulo == null)
                {
                    //se crea
                    crear = true;
                    modulo = new sistema_modulo();
                    modulo.id = modeloModulo.getNext();
                }
                modulo.nombre = moduloText.Text;
                modulo.nombre_modulo_proyecto = nombreLogicoText.Text;
                modulo.imagen = Path.GetFileName(imagenRutaText.Text);
                modulo.activo = (bool)activoCheck.Checked;

                //MessageBox.Show("existe?->" + RutaImagenesVentanas + Path.GetFileName(imagenRutaText.Text));
                if (!(System.IO.File.Exists(RutaImagenesModulos + Path.GetFileName(imagenRutaText.Text))))
                {
                    utilidades.copiarPegarArchivo(imagenRutaText.Text.Trim(), RutaImagenesModulos, false);
                }
                else
                {
                    if (MessageBox.Show("Se ha detectado una imagen con el mismo nombre, desea remplazarla por la que seleccionó ahora?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) ==
                        DialogResult.Yes)
                    {
                        utilidades.copiarPegarArchivo(imagenRutaText.Text.Trim(), RutaImagenesModulos, true);
                    }
                }
                //saber si el archivo imagen esta
                if (crear == true)
                {
                    //se agrega
                    if ((modeloModulo.agregarModulo(modulo)) == true)
                    {
                        MessageBox.Show("Se agregó el módulo", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No agregó la módulo", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    //se modifica
                    if ((modeloModulo.modificarModulo(modulo)) == true)
                    {
                        MessageBox.Show("Se modificó el móodulo", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No modificó el móodulo", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAcion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //MessageBox.Show(Path.GetFileName(imagenRutaText.Text));

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
    }
}
