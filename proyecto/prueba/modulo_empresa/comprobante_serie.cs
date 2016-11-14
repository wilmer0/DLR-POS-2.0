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
namespace puntoVenta
{
    public partial class comprobante_serie : Form
    {
        public comprobante_serie()
        {
            InitializeComponent();
        }

        private void comprobante_serie_Load(object sender, EventArgs e)
        {
            cargar_datos();
        }
        public void cargar_datos()
        {
            try
            {
                string sql = "select codigo,serie,nombre,estado from comprobante_serie order by codigo";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando las series de comprobantes");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    codigo_txt.Clear();
                    nombre_txt.Clear();
                    dataGridView1.Rows.Clear();
                    cargar_datos();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if(codigo_txt.Text.Trim()=="")
                    {
                        //guarda
                        if(nombre_txt.Text.Trim()!="")
                        {
                            if (serie_txt.Text.Trim() != "")
                            {
                                int estado = 0;
                                if (ck_activo.Checked == true)
                                    estado = 1;
                                else
                                    estado = 0;
                                /*
                                 create proc insert_comprobante_serie
                                 @nombre varchar(50),@serie varchar(5),@estado bit,@codigo int
                                 */
                                string sql = "select *from comprobante_serie where serie='" + serie_txt.Text.Trim() + "'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                if (ds.Tables[0].Rows.Count == 0)
                                {
                                    sql = "select *from comprobante_serie where nombre='"+nombre_txt.Text.Trim()+"'";
                                    ds = Utilidades.ejecutarcomando(sql);
                                    if (ds.Tables[0].Rows.Count == 0)
                                    {
                                        sql = "exec insert_comprobante_serie '" + nombre_txt.Text.Trim() + "','" + serie_txt.Text.Trim() + "','" + estado.ToString() + "','0'";
                                        ds = Utilidades.ejecutarcomando(sql);
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            codigo_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                                            cargar_datos();
                                            MessageBox.Show("Se guardo");
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se guardo");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ya hay una serie registrada con ese nombre");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ya hay una serie registrada con la misma serie, por favor modifiquela o escoja otra");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Falta la serie");
                                serie_txt.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta el nombre");
                            nombre_txt.Focus();
                        }
                    }
                    else
                    {
                        //actualiza
                        if (nombre_txt.Text.Trim() != "")
                        {
                            if (serie_txt.Text.Trim() != "")
                            {
                                int estado = 0;
                                if (ck_activo.Checked == true)
                                {
                                    estado = 1;
                                }
                                else
                                {
                                    estado = 0;
                                }
                                /*
                                 create proc insert_comprobante_serie
                                 @nombre varchar(50),@serie varchar(5),@estado bit,@codigo int
                                 */
                                string sql = "select *from comprobante_serie where nombre='" + nombre_txt.Text.Trim() + "' and codigo!='"+codigo_txt.Text.Trim()+"'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                if (ds.Tables[0].Rows.Count == 0)
                                {
                                    sql = "exec insert_comprobante_serie '" + nombre_txt.Text.Trim() + "','" + serie_txt.Text.Trim() + "','" + estado.ToString() + "','" + codigo_txt.Text.Trim() + "'";
                                    ds = Utilidades.ejecutarcomando(sql);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        cargar_datos();
                                        MessageBox.Show("Se actualizo");
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se actualizo");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ya hay una serie registrada con ese nombre");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Falta la serie");
                                serie_txt.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta el nombre");
                            nombre_txt.Focus();
                        }
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Error guardando la serie del comprobante");
                }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = dataGridView1.CurrentRow.Index;
                codigo_txt.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                serie_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                nombre_txt.Text = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                if (dataGridView1.Rows[fila].Cells[3].Value.ToString() == "1")
                    ck_activo.Checked = true;
                else
                    ck_activo.Checked = false;
            }
            catch (Exception)
            {

            }
        }

        private void serie_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
            //if (Utilidades.solo_letras(serie_txt.Text.Trim()) == true)
            //    MessageBox.Show("Letras");
            //else
            //    MessageBox.Show("Numeros");

        }

        private void serie_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
