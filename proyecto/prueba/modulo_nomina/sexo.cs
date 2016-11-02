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

namespace puntoVenta
{
    public partial class sexo : Form
    {
        public sexo()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            busqueda_sexo bs = new busqueda_sexo();
            bs.pasado += new busqueda_sexo.pasar(ejecutar_codigo_sexo);
            bs.mantenimiento = true;
            bs.ShowDialog();
        }
        public void ejecutar_codigo_sexo(string dato)
        {
            codigo_sexo_txt.Text = dato.ToString();
            sexo_txt.Focus();
            cargar_datos();
        }
        public void cargar_datos()
        {
            try
            {
                string sql = "select sexo,estado from sexo where codigo='"+codigo_sexo_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                sexo_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                if (ds.Tables[0].Rows[0][1].ToString()=="True")
                {
                    ck_activo.Checked=true;
                }
                else
                {
                    ck_activo.Checked=false;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los datos del genero");
            }
        }

        private void sexo_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //salvar sexo
            /*
             ALTER proc [dbo].[insert_sexo]
              @sexo varchar(50),@estado bit,@codigo_sexo int

             */
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    int estado = 0;
                    if (ck_activo.Checked == true)
                        estado = 1;
                    else
                        estado = 0;
                    if (codigo_sexo_txt.Text != "")
                    {
                        string sql = "exec insert_sexo '" + sexo_txt.Text.Trim() + "','" + estado.ToString() + "','" + codigo_sexo_txt.Text + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Se actualizo");
                            limpiar();
                        }
                        else
                        {
                            MessageBox.Show("No se actualizo");
                        }
                    }
                    else
                    {
                        string sql = "exec insert_sexo '" + sexo_txt.Text.Trim() + "','" + estado.ToString() + "','0'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Se agrego");
                            limpiar();
                        }
                        else
                        {
                            MessageBox.Show("No se agrego");
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error agregando el sexo");
                }

            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                limpiar();
            }
        }
        public void limpiar()
        {
            try
            {
                codigo_sexo_txt.Clear();
                sexo_txt.Clear();
                ck_activo.Checked = false;
            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }
    }
}
