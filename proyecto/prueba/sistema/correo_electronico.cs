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

namespace puntoVenta.sistema
{
    public partial class correo_electronico : Form
    {


       
        public correo_electronico()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Deseas salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            /*
                create proc insert_correo_electronico
                @correo varchar(max),@clave varchar(max),@host varchar(max),@ssl int,@puerto varchar(max),@codigo int*/
            getAction();
            
        }
        public Boolean validarGetAction()
        {

            if(correoText.Text.Trim()=="")
            {
                MessageBox.Show("Falta el correo","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }

            if(claveText.Text.Trim()=="")
            {
                MessageBox.Show("Falta la clave", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (hostText.Text.Trim() == "")
            {
                MessageBox.Show("Falta el host", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (puertoText.Text.Trim() == "")
            {
                MessageBox.Show("Falta el puerto", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public void getAction()
        {
            bool validar = validarGetAction();

            if (validar==false)
                return;

            int sslActivo = 0;
            if (ssl_check.Checked == true)
                sslActivo = 1;
            else
                sslActivo = 0;

            if(codigoCorreoText.Text.Trim()=="")
            {
                //guardar
                /*
                 create proc insert_correo_electronico
                 @correo varchar(max),@clave varchar(max),@host varchar(max),@ssl int,@puerto varchar(max),@codigo int*/
                string sql = "exec insert_correo_electronico '" + correoText.Text.Trim() + "','" + claveText.Text.Trim() + "','" + hostText.Text.Trim() + "','" + sslActivo.ToString() + "','" + puertoText.Text.Trim() + "','0'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Se agrego el correo", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se agrego el correo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //actualiza
                string sql = "exec insert_correo_electronico '" + correoText.Text.Trim() + "','" + claveText.Text.Trim() + "','" + hostText.Text.Trim() + "','" + sslActivo.ToString() + "','" + puertoText.Text.Trim() + "','" + codigoCorreoText.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Se actualizo el correo", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se actualizo el correo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_correo bc = new busqueda_correo();
            bc.pasado += new busqueda_correo.pasar(ejecutar_codigo_correo);
            bc.ShowDialog();
            cargar_datos_correo();
        }
        public void ejecutar_codigo_correo(string dato)
        {
            codigoCorreoText.Text = dato.ToString();
        }
        public void cargar_datos_correo()
        {
            try
            {
                if(codigoCorreoText.Text.Trim()!="")
                {

                    string sql = "select correo,clave,ssl_activo,host,puerto from correo_electronicos where codigo='"+codigoCorreoText.Text.Trim()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    correoText.Text = ds.Tables[0].Rows[0][0].ToString();
                    claveText.Text = ds.Tables[0].Rows[0][1].ToString();
                    ssl_check.Checked =Convert.ToBoolean(ds.Tables[0].Rows[0][2].ToString());
                    hostText.Text = ds.Tables[0].Rows[0][3].ToString();
                    puertoText.Text = ds.Tables[0].Rows[0][4].ToString();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: "+ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        public void limpiar()
        {
            codigoCorreoText.Clear();
            correoText.Clear();
            claveText.Clear();
            ssl_check.Checked = false;
            hostText.Clear();
            puertoText.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Utilidades.enviarCoreeoElectronico(correoText.Text, "dextroyex21@gmail.com", "mensaje de prueba", "Esto es un mensaje de prueba"))
                {
                    MessageBox.Show("Exito");
                }
                else
                {
                    MessageBox.Show("Fallo");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error enviando el correo: "+ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
