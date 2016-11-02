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
    public partial class comprobante_tipo_comprobante : Form
    {
        public comprobante_tipo_comprobante()
        {
            InitializeComponent();
        }

        private void comprobante_tipo_comprobante_Load(object sender, EventArgs e)
        {
            cargar_datos();
        }
        public void cargar_datos()
        {
            try
            {
                string sql = "select codigo,secuencia,nombre,estado from tipo_comprobante_fiscal";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los tipos de comprobantes");
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

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (codigo_txt.Text.Trim() == "")
                    {
                        //guarda
                        if (nombre_txt.Text.Trim() != "")
                        {
                            if (secuencia_txt.Text.Trim() != "")
                            {
                                int estado = 0;
                                if (ck_activo.Checked == true)
                                    estado = 1;
                                else
                                    estado = 0;
                                /*
                                 * create proc insert_comprobante_tipo
                                   @nombre varchar(50),@secuencia varchar(5),@estado bit,@codigo int
                                 */
                                string sql = "select *from tipo_comprobante_fiscal  where secuencia='" + secuencia_txt.Text.Trim() + "'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                if (ds.Tables[0].Rows.Count == 0)
                                {
                                    sql = "select *from tipo_comprobante_fiscal where nombre='"+nombre_txt.Text.Trim()+"'";
                                    ds = Utilidades.ejecutarcomando(sql);
                                    if (ds.Tables[0].Rows.Count == 0)
                                    {
                                        sql = "exec insert_comprobante_tipo '" + nombre_txt.Text.Trim() + "','" + secuencia_txt.Text.Trim() + "','" + estado.ToString() + "','0'";
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
                                        MessageBox.Show("Ya hay un tipo de comprobante registrado con ese nombre");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ya hay una secuencia registrada con la misma secuencia, por favor modifiquela o escoja otra");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Falta la serie");
                                secuencia_txt.Focus();
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
                            if (secuencia_txt.Text.Trim() != "")
                            {
                                int estado = 0;
                                if (ck_activo.Checked == true)
                                    estado = 1;
                                else
                                    estado = 0;
                                /*
                                 create proc insert_comprobante_tipo
                                 @nombre varchar(50),@secuencia varchar(5),@estado bit,@codigo int
                                 */
                                 string sql = "select *from tipo_comprobante_fiscal  where secuencia='" + secuencia_txt.Text.Trim() + "' and codigo!='"+codigo_txt.Text.Trim()+"'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                if (ds.Tables[0].Rows.Count == 0)
                                {
                                    sql = "select *from tipo_comprobante_fiscal where nombre='" + nombre_txt.Text.Trim() + "' and codigo!='" + codigo_txt.Text.Trim() + "'";
                                    ds = Utilidades.ejecutarcomando(sql);
                                    if (ds.Tables[0].Rows.Count == 0)
                                    {
                                        sql = "exec insert_comprobante_tipo '" + nombre_txt.Text.Trim() + "','" + secuencia_txt.Text.Trim() + "','" + estado.ToString() + "','" + codigo_txt.Text.Trim() + "'";
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
                                        MessageBox.Show("Ya hay un comprobante fiscalregistrado con ese nombre");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ya hay un comprobante con esa secuencia");
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("Falta la secuencia");
                                secuencia_txt.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta el nombre");
                            nombre_txt.Focus();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error guardando el tipo del comprobante");
                }
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
                    secuencia_txt.Clear();
                    ck_activo.Checked = true;
                    dataGridView1.Rows.Clear();
                    cargar_datos();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int fila=dataGridView1.CurrentRow.Index;
                codigo_txt.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                secuencia_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                nombre_txt.Text = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                if (dataGridView1.Rows[fila].Cells[3].Value.ToString() == "1")
                    ck_activo.Checked = true;
                else
                    ck_activo.Checked = false;
            }
            catch(Exception)
            {
                
            }
        }

        private void secuencia_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void secuencia_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
