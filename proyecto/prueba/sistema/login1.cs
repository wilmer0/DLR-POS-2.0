using puntoVenta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Data.Entity;

namespace puntoVenta
{
    public partial class login : Form
    {


        //modelos
        //private ModeloLogin modeloLogin = new ModeloLogin();


        //objetos
        //public puntoVentaModelo.Modelos.empleado empleado;


        //variables
        DataSet ds;
        string sql = "";
        Boolean respuestaHilo = false;
        private splashscreen ventanaCargaLoading=new splashscreen();
        private principal menuPrincipal = new principal();

        //hilos
        Thread hilo;


        public login()
        {
            loadVentana();
            InitializeComponent();
            //usuarioText.Text = "wilmer";
            //claveText.Text = "123";
            //inicioSesion();

        }

        public void loadVentana()
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        public void salir()
        {
            DialogResult dr = MessageBox.Show("Deseas salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inicioSesion();
        }
        public Boolean validarCampos()
        {

            if (usuarioText.Text.Trim() =="")
            {
                MessageBox.Show("Falta el usuario","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                usuarioText.Focus();
                return false;
            }

            if (claveText.Text.Trim() == "")
            {
                MessageBox.Show("Falta la clave", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                claveText.Focus();
                return false;
            }

            DateTime fecha_hoy = DateTime.Today;
            string sql = "select fecha_vencimiento from sistema";
            ds = Utilidades.ejecutarcomando(sql);
            DateTime fecha_vencimiento = Convert.ToDateTime(ds.Tables[0].Rows[0][0].ToString());
            if (fecha_hoy >= fecha_vencimiento)
            {
                MessageBox.Show("El periodo de usabilidad ha expirado", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

             
        }
        public void primerUsuario()
        {
            sql = "exec insert_admin";
            Utilidades.ejecutarcomando(sql);
            s.codigo_usuario = "1";
            MessageBox.Show("Eres admin");
            principal p = new principal();
            p.Show();
            this.Hide();
        }
        public void ProcesandoLoaging()
        {
            ventanaCargaLoading = new splashscreen();
            ventanaCargaLoading.Show();
            this.hilo.Join();
            
        }
        public Boolean inicioSesion()
        {
            try
            {
                Boolean validar = validarCampos();
                if (!validar)
                    return false;

                string claveEncriptada = Utilidades.encriptar(claveText.Text.Trim());

                //empleado = modeloLogin.login(usuarioText.Text.Trim(), claveEncriptada.ToString().Trim());
                //if (empleado == null)
                //{
                //    MessageBox.Show("Los datos no son correctos","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                //    return false;
                //}
                
                s=singleton.obtenerDatos();
                sql = "select *from empleado where login='"+usuarioText.Text.Trim()+"' and clave='"+claveEncriptada.ToString()+"'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No hubo coincidencia", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                
                s.codigo_usuario = ds.Tables[0].Rows[0][0].ToString();
                
                //sacando el nombre del usuario
                sql ="select (t.nombre+' '+p.apellido) from tercero t join persona p on t.codigo=p.codigo where t.codigo='"+s.codigo_usuario+"'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows[0][0].ToString()!="")
                s.nombre = ds.Tables[0].Rows[0][0].ToString();



                //sacando el codigo de sucursal que pertenece el empleado
                sql = "select s.codigo,s.codigo_empresa from sucursal s join empleado e on e.cod_sucursal=s.codigo where e.codigo='" + s.codigo_usuario+ "'";
                ds = Utilidades.ejecutarcomando(sql);
                s.codigo_sucursal = ds.Tables[0].Rows[0][0].ToString();
                s.codigo_empresa = ds.Tables[0].Rows[0][1].ToString();
                menuPrincipal = new principal();
                menuPrincipal.Show();
                this.Hide();
                
                    
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en inicio de sesion: "+ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiar();
                return false;
            }
        }
        string codigo_sucursal = "";
        public void limpiar()
        {
            usuarioText.Clear();
            claveText.Clear();
            usuarioText.Focus();
        }
        internal singleton s { get; set; }
        public void cargar_idioma_combo()
        {
          
        }
        private void login_Load(object sender, EventArgs e)
        {
            try
            {
                cargar_idioma_combo();
                s = singleton.obtenerDatos();
               
                usuarioText.Focus();
            }
            catch(Exception)
            {
                MessageBox.Show(e.ToString());
            }
        }
        
       

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //evitar que se cierre pulsando la x o alt + f4
            //e.Cancel = true;
            //evita que se cierre con alt+ f4 pero tampoco puedo cerrarlo con codigo revisar esto
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                claveText.Focus();
            }
            if(e.KeyCode==Keys.F5)
            {
                
            }
        }

        private void clave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                inicioSesion();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
       
        private void label2_Click(object sender, EventArgs e)
        {
            dlrsoft d = new dlrsoft();
            d.ShowDialog();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void idioma_combobox_txt_KeyUp(object sender, KeyEventArgs e)
        {
          
        }

        private void login_KeyUp(object sender, KeyEventArgs e)
        {

            
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            host h = new host();
            h.ShowDialog();
        }

        private void usuario_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            inicioSesion();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void LoginPanel_Paint(object sender, PaintEventArgs e)
        {

        }

       
        private void espanolRadioButton_Click(object sender, EventArgs e)
        {
           
        }

        private void SalirPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
