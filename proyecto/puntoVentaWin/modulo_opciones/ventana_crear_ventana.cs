using System;
using System.Drawing;
using System.Windows.Forms;
using puntoVentaModelo;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using puntoVentaWin;
using puntoVentaModelo;
using puntoVentaModelo.Modelos;

namespace puntoVentaWin.ventanas
{
    public partial class ventana_crear_ventana : FormBase
    {

        //variable
        private string rutaProyectoActual = Directory.GetCurrentDirectory()+@"\";
        private string RutaImagenesVentanas = "";
        


        //objetos
        private empleado empleado;
        private sistema_ventanas ventana_sistema;
        private sistema_modulo modulo_sistema;
        utilidades utilidades=new utilidades();



        //modelos
        private modeloVentana modeloVentana=new modeloVentana();
        modeloModulos modeloModulo=new modeloModulos();






        public ventana_crear_ventana(empleado empleadoApp)
        {
            InitializeComponent();
            this.empleado = empleadoApp;
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "creación de ventanas");
            this.Text = tituloLabel.Text;
            loadVentana();
            RutaImagenesVentanas=rutaProyectoActual+@"Resources\ventanas\";
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
                    panel3.BackgroundImage=Image.FromFile(RutaImagenesVentanas+imagenRutaText.Text.Trim());
                    modulo_sistema = modeloModulo.getModuloById(ventana_sistema.cod_modulo);
                    idModuloText.Text = ventana_sistema.cod_modulo.ToString();
                    nombreModuloLabel.Text = ventana_sistema.sistema_modulo.nombre;
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
                    panel3.BackgroundImage = null;
                    modulo_sistema = null;
                    idModuloText.Text = "";
                    nombreModuloLabel.Text = "";
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
                ventana_sistema.imagen = Path.GetFileName(imagenRutaText.Text);
                ventana_sistema.activo = (bool) activoCheck.Checked;

                //MessageBox.Show("existe?->" + RutaImagenesVentanas + Path.GetFileName(imagenRutaText.Text));
                if (!(System.IO.File.Exists(RutaImagenesVentanas + Path.GetFileName(imagenRutaText.Text))))
                {
                    utilidades.copiarPegarArchivo(imagenRutaText.Text.Trim(), RutaImagenesVentanas, false);
                }
                else
                {
                    if (MessageBox.Show("Se ha detectado una imagen con el mismo nombre, desea remplazarla por la que seleccionó ahora?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) ==
                        DialogResult.Yes)
                    {
                        utilidades.copiarPegarArchivo(imagenRutaText.Text.Trim(), RutaImagenesVentanas, true);
                    }
                }
                //saber si el archivo imagen esta
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

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_buscar_ventana ventana=new ventana_buscar_ventana(empleado);
            ventana.Owner = this;
            ventana.ShowDialog();
            if ((ventana_sistema=ventana.Getventana) != null)
            {
                loadVentana();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        public void loadModulo()
        {
            try
            {
                if (modulo_sistema != null)
                {
                    idModuloText.Text = modulo_sistema.id.ToString();
                    nombreModuloLabel.Text = modulo_sistema.nombre;
                }
                else
                {
                    idModuloText.Text = "";
                    nombreModuloLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadModulo.: " + ex.Data, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ventana_buscar_modulo ventana = new ventana_buscar_modulo(empleado);
            ventana.Owner = this;
            ventana.ShowDialog();
            if ((modulo_sistema = ventana.GetModulo) != null)
            {
                loadModulo();
            }
        }

        private void idText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                ventanaText.Focus();
                ventanaText.SelectAll();
            }
        }

        private void ventanaText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                nombreLogicoText.Focus();
                nombreLogicoText.SelectAll();
            }
        }

        private void nombreLogicoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                imagenRutaText.Focus();
                imagenRutaText.SelectAll();
            }
        }

        private void imagenRutaText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                idModuloText.Focus();
                idModuloText.SelectAll();
            }
            if (e.KeyCode == Keys.F1)
            {
                button6_Click(null,null);
            }
        }

        private void idModuloText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                activoCheck.Focus();
            }
            if (e.KeyCode == Keys.F1)
            {
                button5_Click(null, null);
            }
        }

        private void activoCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                button1.Focus();
            }
            if (e.KeyCode == Keys.Space)
            {
                activoCheck.Checked = !(bool) activoCheck.Checked;
            }
        }
    }
}
