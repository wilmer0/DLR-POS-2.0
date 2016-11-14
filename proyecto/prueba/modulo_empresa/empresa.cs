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
    public partial class empresa : Form
    {
        public empresa()
        {
            InitializeComponent();
        }

        private void empresa_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            codigo_empresa_txt.Clear();
            nombre_empresa_txt.Clear();
            //secuencia_txt.Clear();
            identificacion_txt.Clear();
            ck_activo.Checked = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            busqueda_empresa be = new busqueda_empresa();
            be.pasado += new busqueda_empresa.pasar(ejecutar_codigo_empresa);
            be.mantenimiento = true;
            be.ShowDialog();
            
        }
        public void ejecutar_codigo_empresa(string dato)
        {
            codigo_empresa_txt.Text = dato.ToString();
        }

        private void codigo_empresa_txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "select t.nombre,t.identificacion,e.estado,e.division from tercero t join empresa e on t.codigo=e.codigo where e.codigo='"+codigo_empresa_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_empresa_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                identificacion_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                if (ds.Tables[0].Rows[0][2].ToString() == "True")
                    ck_activo.Checked = true;
                else
                    ck_activo.Checked = false;
                division_txt.Text = ds.Tables[0].Rows[0][3].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando la empresa");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }


        private void button4_Click(object sender, EventArgs e)
        {
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
                //exec insert_empresa 'nombre','identificacion','secuencia','estado','codigo_actualizar'
                string sql = "";
                int estado=0;
                DataSet ds = Utilidades.ejecutarcomando(sql);
                    if (nombre_empresa_txt.Text.Trim() != "")
                    {
                        
                            sql = "select *from tercero where identificacion='" + identificacion_txt.Text.Trim() + "' and codigo!='"+codigo_empresa_txt.Text.Trim()+"' and identificacion!=''";
                            ds = Utilidades.ejecutarcomando(sql);
                            if (ds.Tables[0].Rows.Count == 0)
                            {

                                    if (ck_activo.Checked == true)
                                    {
                                        estado = 1;
                                    }
                                    else
                                    {
                                        estado = 0;
                                    }
                                    
                                        sql = "";
                                        if (codigo_empresa_txt.Text.Trim() == "")
                                        {
                                            if (division_txt.Text.Trim() != "")
                                            {
                                                sql = "select *from empresa where division='" + division_txt.Text.Trim() + "'";
                                                ds = Utilidades.ejecutarcomando(sql);
                                                if (ds.Tables[0].Rows.Count == 0)
                                                {
                                                    sql = "exec insert_empresa '" + nombre_empresa_txt.Text.Trim() + "','" + identificacion_txt.Text.Trim() + "','000','" + estado.ToString() +"','"+division_txt.Text.Trim() +"','0'";
                                                    ds = Utilidades.ejecutarcomando(sql);
                                                    if (ds.Tables[0].Rows.Count > 0)
                                                    {
                                                        MessageBox.Show("Se guardo");
                                                        codigo_empresa_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("No se guardo");
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("El numero de la division ya la tiene otra empresa");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Falta la division, son solo dos digitos");
                                            }
                                        }
                                        else
                                        {
                                            //se actualiza
                                            sql = "select *from empresa where division='"+division_txt.Text.Trim()+"' and codigo!='"+codigo_empresa_txt.Text.Trim()+"'";
                                            ds = Utilidades.ejecutarcomando(sql);
                                            if (ds.Tables[0].Rows.Count == 0)
                                            {
                                                sql = "exec insert_empresa '" + nombre_empresa_txt.Text.Trim() + "','" + identificacion_txt.Text.Trim() + "','000','" + estado.ToString() + "','" + division_txt.Text.Trim() + "','" + codigo_empresa_txt.Text.Trim() + "'";
                                                ds = Utilidades.ejecutarcomando(sql);
                                                if (ds.Tables[0].Rows.Count > 0)
                                                {
                                                    MessageBox.Show("Se guardo");
                                                }
                                                else
                                                {
                                                    MessageBox.Show("No se guardo");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Ya hay una empresa con esa division");
                                            }
                                        }
                            }
                            else
                            {
                                MessageBox.Show("La identificacion ya existe");
                            }
                    }
                    else
                    {
                        MessageBox.Show("Nombre no puede estar en blanco");
                    }
            }
            catch (Exception)
            {
                MessageBox.Show("Error guardando la empresa");
            }
        }

        private void division_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if(Utilidades.numero_entero(division_txt.Text.Trim())==false)
            {
                division_txt.Clear();
            }
        }
    }
}
