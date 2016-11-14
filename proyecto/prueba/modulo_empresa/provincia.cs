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
    public partial class provincia : Form
    {
        public provincia()
        {
            InitializeComponent();
        }

        public delegate void pasar(string dato);
        public event pasar pasado;
        public string cod_region = "";
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void provincia_Load(object sender, EventArgs e)
        {
            cargar_provincias();
        }
        public void cargar_provincias()
        {
            try
            {
                if (cod_region != "")
                {
                    string sql = "select codigo,nombre,estado from provincia where cod_region='" + cod_region.ToString() + "' and estado='1' order by nombre";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select codigo,nombre,estado from provincia where estado='1' order by nombre";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las provincias");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                pasado(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Error pasando variable hacia atras");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    codigo_pronvincia_txt.Clear();
                    nombre_provincia_txt.Clear();
                    ck_estado.Checked = true;
                    provincia_txt.Clear();
                    dataGridView1.Rows.Clear();
                    provincia_txt.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }

        private void pais_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (cod_region != "")
                {
                    string sql = "select codigo,nombre,estado from provincia where cod_region='" + cod_region.ToString() + "' and  nombre like '%" + provincia_txt.Text.Trim() + "%' and estado='1' order by nombre";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select codigo,nombre,estado from provincia where nombre like '%" + provincia_txt.Text.Trim() + "%' and estado='1' order by nombre";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las provincia");
            }
        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if(codigo_pronvincia_txt.Text.Trim()=="")
                {
                    if(nombre_provincia_txt.Text.Trim()!="")
                    {
                        int estado = 0;
                        if (ck_estado.Checked == true)
                            estado = 1;
                        else
                            estado = 0;
                        /*
                            create proc insert_provincia
                            @nombre varchar(50),@cod_region int,@estado bit,@codigo int

                         */
                        string sql = "exec insert_provincia '"+nombre_provincia_txt.Text.Trim()+"','"+cod_region.ToString()+"','"+estado.ToString()+"','0'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if(ds.Tables[0].Rows.Count>0)
                        {
                            cargar_provincias();
                            MessageBox.Show("Se guardo");
                        }
                        else
                        {
                            MessageBox.Show("no se guardo");
                        }
                    }
                    else
                    {
                        nombre_provincia_txt.Focus();
                        MessageBox.Show("Falta el nombre");
                    }
                }
                else
                {
                    if (nombre_provincia_txt.Text.Trim() != "")
                    {
                        int estado = 0;
                        if (ck_estado.Checked == true)
                            estado = 1;
                        else
                            estado = 0;
                        /*
                            create proc insert_provincia
                            @nombre varchar(50),@cod_region int,@estado bit,@codigo int

                         */
                        string sql = "exec insert_provincia '" + nombre_provincia_txt.Text.Trim() + "','" + cod_region.ToString() + "','" + estado.ToString() + "','"+codigo_pronvincia_txt.Text.Trim()+"'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            cargar_provincias();
                            MessageBox.Show("Se actualizo");
                        }
                        else
                        {
                            MessageBox.Show("no se actualizo");
                        }
                    }
                    else
                    {
                        nombre_provincia_txt.Focus();
                        MessageBox.Show("Falta el nombre");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Erro guardando la pronvincia");
            }
        }
    }
}
