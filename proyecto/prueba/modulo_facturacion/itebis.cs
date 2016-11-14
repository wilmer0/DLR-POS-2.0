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
    public partial class itebis : Form
    {
        public itebis()
        {
            InitializeComponent();
        }

        private void itebis_txt_Load(object sender, EventArgs e)
        {
            cargar_datos();
        }
        public void cargar_datos()
        {
            try
            {
                string sql = "select codigo,descripcion,it,estado from itebis";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Erro cargando los itbis");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = dataGridView1.CurrentRow.Index;
                codigo_txt.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                nombre_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                itebis_txt.Text = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                if(dataGridView1.Rows[fila].Cells[3].Value.ToString()=="True")
                {
                    ck_activo.Checked = true;
                }
                else
                {
                    ck_activo.Checked = false;
                }
            }
            catch(Exception)
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if(codigo_txt.Text.Trim()=="")
                    {
                        if(nombre_txt.Text.Trim()!="")
                        {
                            if(itebis_txt.Text.Trim()!="")
                            {
                                int estado = 0;
                                if (ck_activo.Checked == true)
                                    estado = 1;
                                else
                                    estado = 0;
                                /*
                                 exec insert_itebis 'nombre','1','18 numero','codigo'
                                 */
                                string sql = "exec insert_itebis '"+nombre_txt.Text.Trim()+"','"+estado.ToString()+"','"+itebis_txt.Text.Trim()+"','0'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                if(ds.Tables[0].Rows.Count>0)
                                {

                                    MessageBox.Show("Se guardo");
                                    dataGridView1.Rows.Clear();
                                    cargar_datos();
                                }
                                else
                                {
                                    MessageBox.Show("No se guardo");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Falta el numero itbis, ejemplo 18,16,13 o 0");
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
                            if (itebis_txt.Text.Trim() != "")
                            {
                                int estado = 0;
                                if (ck_activo.Checked == true)
                                    estado = 1;
                                else
                                    estado = 0;
                                /*
                                 exec insert_itebis 'nombre','1','18 numero','codigo'
                                 */
                                string sql = "exec insert_itebis '" + nombre_txt.Text.Trim() + "','" + estado.ToString() + "','" + itebis_txt.Text.Trim() + "','" + codigo_txt.Text.Trim() +"'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show("Se actualizo");
                                    dataGridView1.Rows.Clear();
                                    cargar_datos();
                                }
                                else
                                {
                                    MessageBox.Show("No se actualizo");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Falta el numero itbis, ejemplo 18,16,13 o 0");
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
                    MessageBox.Show("Error guardando el itbis");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    codigo_txt.Clear();
                    nombre_txt.Clear();
                    itebis_txt.Clear();
                    ck_activo.Checked = true;
                    dataGridView1.Rows.Clear();
                    nombre_txt.Focus();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void itebis_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (Utilidades.numero_entero(itebis_txt.Text) == false)
                itebis_txt.Clear();
        }
    }
}
