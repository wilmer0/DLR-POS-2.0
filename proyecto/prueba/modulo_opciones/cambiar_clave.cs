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
    public partial class cambiar_clave : Form
    {
        public cambiar_clave()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void nombre_txt_TextChanged(object sender, EventArgs e)
        {

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
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //limpiar ventana
                limpiar();
            }
        }
        public void limpiar()
        {
            try
            {
                clave_actual_txt.Clear();
                clave_nueva_txt.Clear();
                clave_confirmar_txt.Clear();
                clave_actual_txt.Focus();
            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                guardar();
            }
        }
        internal singleton s{get;set;}
        public void guardar()
        {
            //alter proc insert_clave_empleado
            //@codigo_empleado int,@clave_vieja varchar(50),@clave_nueva varchar(50)
            try
            {
                if (clave_actual_txt.Text.Trim() != "")
                {
                    if (clave_nueva_txt.Text.Trim() != "")
                    {
                        if (clave_confirmar_txt.Text != "")
                        {
                            if (clave_confirmar_txt.Text.Trim() == clave_nueva_txt.Text.Trim())
                            {

                                s = singleton.obtenerDatos();
                                string clave_actual = Utilidades.encriptar(clave_actual_txt.Text);
                                string clave_nueva = Utilidades.encriptar(clave_nueva_txt.Text.Trim());
                                string sql = "exec insert_clave_empleado '" + s.codigo_usuario.ToString() + "','" + clave_actual.ToString() + "','" + clave_nueva.ToString() + "'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show("Se actualizo");
                                }
                                else
                                {
                                    MessageBox.Show("No se actualizo");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Las claves no coinciden, vuelva a digitarlas");
                                clave_nueva_txt.Clear();
                                clave_confirmar_txt.Clear();
                                clave_nueva_txt.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta confirmar la clave");
                            clave_confirmar_txt.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta la clave nueva");
                        clave_nueva_txt.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Falta la clave actual");
                    clave_actual_txt.Focus();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error actualizando la clave");
            }

        }
    }
}
