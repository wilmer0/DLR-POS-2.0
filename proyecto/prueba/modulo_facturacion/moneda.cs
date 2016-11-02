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
    public partial class moneda : Form
    {
        public moneda()
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
            DialogResult dr = MessageBox.Show("Desea limpair?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
                codigo_moneda_txt.Clear();
                nombre_txt.Clear();
                tasa_txt.Clear();
                ck_activo.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if(nombre_txt.Text.Trim()!="")
                    {
                        if(tasa_txt.Text.Trim()!="")
                        {
                            int estado = 0;
                            if (ck_activo.Checked==true)
                            estado=1;
                            else
                            estado=0;

                            /*
                             create proc insert_moneda
                             @nombre varchar(50),@tasa_actual float,@estado int,@codigo_v int
                             */
                            if  (codigo_moneda_txt.Text.Trim() =="")
                            {
                                //se guarda
                                string sql = "exec insert_moneda '"+nombre_txt.Text.Trim()+"','"+tasa_txt.Text.Trim()+"','"+estado.ToString()+"','0'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                if (ds.Tables[0].Rows.Count > 0)
                                    MessageBox.Show("Se agrego");
                                else
                                    MessageBox.Show("No se agrego");
                                cargar_monedas();
                            }
                            else
                            {
                                //se actualiza
                                string sql = "exec insert_moneda '" + nombre_txt.Text.Trim() + "','" + tasa_txt.Text.Trim() + "','" + estado.ToString() + "','"+codigo_moneda_txt.Text.Trim()+"'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show("Se modifico");
                                }
                                else
                                {
                                    MessageBox.Show("No se modifico");
                                } 
                                cargar_monedas();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta la tasa");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el nombre");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error agregando la moneda");
            }
        }
        private void moneda_Load(object sender, EventArgs e)
        {
            cargar_monedas();
        }
        public void cargar_monedas()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select codigo,nombre,tasa_actual,estado from moneda";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                }
            }
            catch(Exception)
            {
                
            }
        }

        private void tasa_txt_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tasa_txt_TextChanged(object sender, EventArgs e)
        {
            if (Utilidades.numero_decimal(tasa_txt.Text.Trim()) == false)
            {
                tasa_txt.Clear();
            }
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = dataGridView1.CurrentRow.Index;
                codigo_moneda_txt.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                nombre_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                tasa_txt.Text = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                if(dataGridView1.Rows[fila].Cells[3].Value.ToString()=="1")
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
    }
}
