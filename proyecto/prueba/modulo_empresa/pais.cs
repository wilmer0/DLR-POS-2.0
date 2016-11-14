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
    public partial class pais : Form
    {
        public pais()
        {
            InitializeComponent();
        }

        public delegate void pasar(string dato);
        public event pasar pasado;
        bool mantenimiento = false;
        private void pais_Load(object sender, EventArgs e)
        {
            cargar_pais();
        }
        
        public void cargar_pais()
        {
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select *from pais where estado='1' order by nombre";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select *from pais order by nombre";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los paises");
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select *from pais where nombre like '%" + pais_txt.Text.Trim() + "%' and estado='1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select *from pais where nombre like '%" + pais_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando los paises");
            }
        }

        private void codigo_pais_txt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                    if (e.KeyCode == Keys.Enter)
                    {
                        string sql = "select *from pais where codigo='" + codigo_pais_txt.Text.Trim() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        pais_nuevo_txt.Text = ds.Tables[0].Rows[0]["nombre"].ToString();
                        int estado = 0;
                        //MessageBox.Show(ds.Tables[0].Rows[0]["estado"].ToString());
                        if (ds.Tables[0].Rows[0]["estado"].ToString() == "True")
                            ck_estado.Checked = true;

                        //privatizar el textbox de codigo del pais
                        codigo_pais_txt.ReadOnly = true;
                    }
                
            }catch(Exception)
            {
                MessageBox.Show("Error al traer datos del pais");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea sali?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                limpiar();
            }
        }
        public void limpiar()
        {
            pais_txt.Clear();
            cargar_pais();
            codigo_pais_txt.Clear();
            codigo_pais_txt.ReadOnly = false;
            pais_nuevo_txt.Clear();
            ck_estado.Checked = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pasado(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            this.Close();   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (codigo_pais_txt.Text.Trim() == "")
                {
                    //create proc insert_pais
                    //@nombre varchar(50),@estado bit,@codigo_pais int

                    //guarda
                    if (pais_nuevo_txt.Text.Trim() != "")
                    {
                        int estado = 0;
                        if (ck_estado.Checked == true)
                            estado = 1;
                        else
                            estado = 0;
                        string sql = "exec insert_pais '"+pais_nuevo_txt.Text.Trim()+"','"+estado.ToString()+"','0'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
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
                        MessageBox.Show("Falta el pais");
                    }

                }
                else
                {
                    //create proc insert_pais
                    //@nombre varchar(50),@estado bit,@codigo_pais int

                    //acutaliza
                    int estado = 0;
                    if (ck_estado.Checked == true)
                        estado = 1;
                    else
                        estado = 0;
                    string sql = "exec insert_pais '" + pais_nuevo_txt.Text.Trim() + "','" + estado.ToString() + "','"+codigo_pais_txt.Text.Trim()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Se guardo");
                    }
                    else
                    {
                        MessageBox.Show("No se guardo");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            cargar_pais();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                codigo_pais_txt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                pais_nuevo_txt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[2].Value.ToString() =="True")
                    ck_estado.Checked = true;
                else
                    ck_estado.Checked = false;
            }
            catch(Exception)
            {
                MessageBox.Show("Error seleccionando la fila");
            }
        }
    }
}
