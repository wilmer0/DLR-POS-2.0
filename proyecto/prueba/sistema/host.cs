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
using System.Data.SqlClient;

namespace puntoVenta
{
    public partial class host : Form
    {
        public host()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                if(ip_txt.Text.Trim()!="")
                {
                    if(base_de_datos_txt.Text.Trim()!="")
                    {
                        if(usuario_base_datos_txt.Text.Trim()!="")
                        {
                            if(clave_dba_txt.Text.Trim()!="")
                            {
                                /*
                                 create proc insert_ip_base_datos
                                 @nombre_base_datos varchar(max),@ip varchar(max),@base_datos_usuario varchar(max),@base_datos_clave varchar(max)
                                 */
                                string sql = "";
                                //sql = "exec insert_ip_base_datos '"+base_de_datos_txt.Text.Trim()+"','"+ip_txt.Text.Trim()+"','"+usuario_base_datos_txt.Text.Trim()+"','"+clave_dba_txt.Text.Trim()+"'";
                                sql = "update sistema set ip_server='"+ip_txt.Text.Trim()+"',base_datos='"+base_de_datos_txt.Text.Trim()+"',base_datos_usuario='"+usuario_base_datos_txt.Text.Trim()+"',base_datos_clave='"+clave_dba_txt.Text.Trim()+"'";
                                SqlConnection conn = new SqlConnection("Data Source=" + ip_txt.Text.Trim() + ";" + "Initial Catalog=" + base_de_datos_txt.Text.Trim() + ";" + "User id=" + usuario_base_datos_txt.Text.Trim() + ";" + "Password=" + clave_dba_txt.Text.Trim() + ";");
                                DataSet ds = new DataSet();
                                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                                da.Fill(ds);
                                
                                MessageBox.Show("actualizo"); 
                            }
                            else
                            {
                                MessageBox.Show("Falta la clave");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta el usuario");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta la base de datos");
                    }
                }
                else
                {
                    MessageBox.Show("Falta la ip");
                }
            //}
            //catch(Exception)
            //{
            //    MessageBox.Show("Error");
            //}
        }

        private void host_Load(object sender, EventArgs e)
        {
            string sql = "select fecha_vencimiento from sistema";
            DataSet ds = Utilidades.ejecutarcomando(sql);
            if(ds.Tables[0].Rows[0][0].ToString()!="")
            {
                fecha_vencimiento.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                MessageBox.Show("No hay fecha de vencimiento registrada");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "update sistema set fecha_vencimiento='"+fecha_vencimiento.Value.ToString("yyyy-MM-dd")+"'";
            Utilidades.ejecutarcomando(sql);
            MessageBox.Show("Actualizado");
        }
    }
}
