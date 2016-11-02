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
    public partial class banco : Form
    {
        public banco()
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                /*
                 create proc insert_banco
                 @nombre varchar(100),@identificacion varchar(20),@estado int,@codigo int
                 */

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            busqueda_tercero bt = new busqueda_tercero();
            bt.pasado += new busqueda_tercero.pasar(ejecutar_codigo_banco);
            bt.ShowDialog();
            cargar_telefono();
            cargar_datos();
        }
        public void cargar_datos()
        {
            try
            {
                if(codigo_banco_txt.Text.Trim()!="")
                {
                    string sql = "";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los datos del banco");
            }
        }
        public void cargar_telefono()
        {
            try
            {
                string sql = "select telefono,tipo_telefono from tercero_vs_telefono tt where tt.cod_tercero='" + codigo_banco_txt.Text.Trim() + "' and tt.tipo_entidad='BAN'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView2.Rows.Add(row[0].ToString(), row[1].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los telefonos");
            }
        }
        public void ejecutar_codigo_banco(string dato)
        {
            limpiar();
            codigo_banco_txt.Text = dato.ToString();
        }
        public void limpiar()
        {
            codigo_banco_txt.Clear();
            nombre_banco_txt.Clear();
            ck_activo.Checked = true;
            dataGridView2.Rows.Clear();
            telefono_txt.Clear();
            nombre_banco_txt.Focus();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int cont = 0;
            try
            {
                DataSet ds = new DataSet();
                if (telefono_txt.Text != "")
                {
                    if (tipo_telefono_combo_txt.Text != "")
                    {
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                if (row.Cells[0].Value.ToString() == telefono_txt.Text.Trim())
                                {
                                    cont++;
                                }
                            }
                            if (cont == 0)
                            {
                                dataGridView2.Rows.Add(telefono_txt.Text.Trim(), tipo_telefono_combo_txt.Text.Trim());
                                telefono_txt.Clear();
                                telefono_txt.Focus();
                            }
                            else
                            {
                                MessageBox.Show("El telefono que intenta poner ya se encuentra puesto");
                                telefono_txt.Focus();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Falta el tipo de telefono");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el tipo de telefono");
                    }
                }
                else
                {
                    MessageBox.Show("Falta el telefono");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error agregando el numero");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea quitar el telefono?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (dataGridView2.Rows.Count > 0)
                    {
                        dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                    }
                    else
                    {
                        dr = MessageBox.Show("No hay elementos para eliminar", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error eliminando la fila seleccionada");
                }
            }
        }
    }
}
