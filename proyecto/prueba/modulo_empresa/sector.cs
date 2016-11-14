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
    public partial class sector : Form
    {
        public sector()
        {
            InitializeComponent();
        }

        public delegate void pasar(string dato);
        public event pasar pasado;
        public string cod_provincia = "";
        private void sector_Load(object sender, EventArgs e)
        {
            cargar_sectores();
        }

        public void cargar_sectores()
        {
            try
            {
                if (cod_provincia != "")
                {
                    string sql = "select codigo,nombre, estado from sector where cod_provincia='" + cod_provincia.ToString() + "' and estado='1' order by nombre";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select codigo,nombre, estado from sector where estado='1' order by nombre";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los sectores");
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
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    codigo_sector_txt.Clear();
                    nombre_sector_txt.Clear();
                    ck_estado.Checked = true;
                    sector_txt.Clear();
                    dataGridView1.Rows.Clear();
                    sector_txt.Focus();
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
                string sql = "select codigo,nombre, estado from sector where nombre like '%"+sector_txt.Text.Trim()+"%'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando el sector");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (codigo_sector_txt.Text.Trim() == "")
                    {
                        //guardar
                        if (nombre_sector_txt.Text.Trim() != "")
                        {
                            int estado = 0;
                            if (ck_estado.Checked == true)
                                estado = 1;
                            else
                                estado = 0;
                            /*
                             * create proc insert_sector
                               @nombre varchar(50),@cod_provincia int,@estado bit,@codigo int

                              */
                            string sql = "exec insert_sector '"+nombre_sector_txt.Text.Trim()+"','"+cod_provincia.ToString()+"','"+estado.ToString()+"','0'";
                            DataSet ds = Utilidades.ejecutarcomando(sql);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                cargar_sectores();
                                MessageBox.Show("Se agrego");
                            }
                            else
                            {
                                MessageBox.Show("No se agrego");
                            }
                        }
                        else
                        {
                            nombre_sector_txt.Focus();
                            MessageBox.Show("Falta el sector");
                        }
                    }
                    else
                    {
                        //actualizar
                        if (nombre_sector_txt.Text.Trim() != "")
                        {
                            int estado = 0;
                            if (ck_estado.Checked == true)
                                estado = 1;
                            else
                                estado = 0;
                            /*
                             * create proc insert_sector
                               @nombre varchar(50),@cod_provincia int,@estado bit,@codigo int

                              */
                            string sql = "exec insert_sector '" + nombre_sector_txt.Text.Trim() + "','" + cod_provincia.ToString() + "','" + estado.ToString() + "','"+codigo_sector_txt.Text.Trim()+"'";
                            DataSet ds = Utilidades.ejecutarcomando(sql);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                cargar_sectores();
                                MessageBox.Show("Se agrego");
                            }
                            else
                            {
                                MessageBox.Show("No se agrego");
                            }
                        }
                        else
                        {
                            nombre_sector_txt.Focus();
                            MessageBox.Show("Falta el sector");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error guardando");
                }
            }
        }
    }
}
