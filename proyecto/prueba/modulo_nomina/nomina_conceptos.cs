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
    public partial class nomina_conceptos : Form
    {
        public nomina_conceptos()
        {
            InitializeComponent();
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
                cargar_datos();
                codigo_tipo_nomina_txt.Clear();
                nombre_tipo_nomina_txt.Clear();
                ck_activo.Checked = true;
                ck_aumenta.Checked = true;
                ck_disminuye.Checked = false;
            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                guardar();   
            }
        }
        public void guardar()
        {
            try
            {
                /*
                  create proc insert_nomina_concepto
                  @nombre varchar(max),@aumenta int,@estado int,@codigo int
                 */

                if(nombre_tipo_nomina_txt.Text.Trim()!="")
                {
                    if(ck_aumenta.Checked==true || ck_disminuye.Checked==true)
                    {
                        int estado = 0;
                        if(ck_activo.Checked==true)
                        {
                            estado = 1;
                        }
                        else
                        {
                            estado = 0;
                        }
                        int aumenta=0;
                        if(ck_aumenta.Checked==true)
                        {
                            aumenta=1;
                        }
                        else
                        {
                            aumenta=0;
                        }
                        if(codigo_tipo_nomina_txt.Text.Trim()=="")
                        {
                            //guarda
                            string sql = "exec insert_nomina_concepto '"+nombre_tipo_nomina_txt.Text.Trim()+"','"+aumenta.ToString()+"','"+estado.ToString()+"','0'";
                            DataSet ds = Utilidades.ejecutarcomando(sql);
                            if(ds.Tables[0].Rows.Count>0)
                            {
                                MessageBox.Show("Se guardo");
                                cargar_datos();
                            }
                            else
                            {
                                MessageBox.Show("No se guardo");
                            }
                        }
                        else
                        {
                            //actualiza
                            string sql = "exec insert_nomina_concepto '" + nombre_tipo_nomina_txt.Text.Trim() + "','" + aumenta.ToString() + "','" + estado.ToString() + "','"+codigo_tipo_nomina_txt.Text.Trim()+"'";
                            DataSet ds = Utilidades.ejecutarcomando(sql);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show("Se actualizo");
                                cargar_datos();
                            }
                            else
                            {
                                MessageBox.Show("No se actualizo");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar si aumenta o disminuye al sueldo");
                    }
                }
                else
                {
                    MessageBox.Show("Falta el nombre");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error guardando");
            }
        }
        private void nomina_conceptos_Load(object sender, EventArgs e)
        {
            cargar_datos();
        }
        public void cargar_datos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select codigo,nombre,aumenta_sueldo,estado from nomina_conceptos";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    if(row[2].ToString()=="1")
                    {
                        dataGridView1.Rows.Add(row[0].ToString(),row[1].ToString(),"1","0",row[3].ToString());
                    }
                    else
                    {
                        dataGridView1.Rows.Add(row[0].ToString(),row[1].ToString(),"0","1",row[3].ToString());
                    }
                }
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    if(row.Cells[2].Value.ToString()=="1")
                    {
                        //si aumenta sueldo
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.SelectionBackColor = Color.Blue;
                    }
                    else
                    {
                        //si baja sueldo
                        row.DefaultCellStyle.BackColor = Color.Orange;
                        row.DefaultCellStyle.SelectionBackColor = Color.Blue;
                    }
                }

            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los datos");
            }
        }

        private void ck_aumenta_Click(object sender, EventArgs e)
        {
            try
            {
                ck_aumenta.Checked = true;
                ck_disminuye.Checked = false;
            }
            catch (Exception)
            {

            }
        }

        private void ck_disminuye_Click(object sender, EventArgs e)
        {
            try
            {
                ck_aumenta.Checked = false;
                ck_disminuye.Checked = true;
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = dataGridView1.CurrentRow.Index;
                codigo_tipo_nomina_txt.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                nombre_tipo_nomina_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                if (dataGridView1.Rows[fila].Cells[2].Value.ToString() == "1")
                {
                    ck_aumenta.Checked = true;
                    ck_disminuye.Checked = false;
                }
                if (dataGridView1.Rows[fila].Cells[3].Value.ToString() == "1")
                {
                    ck_disminuye.Checked = true;
                    ck_aumenta.Checked = false;
                }
                if (dataGridView1.Rows[fila].Cells[4].Value.ToString() == "1")
                {
                    ck_activo.Checked = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error seleccionando");
            }
        }
    }
}
