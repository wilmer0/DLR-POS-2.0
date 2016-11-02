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
    public partial class region : Form
    {
        public region()
        {
            InitializeComponent();
        }
        public string cod_pais = "";
        public delegate void pasar(string dato);
        public event pasar pasado;
        private void region_Load(object sender, EventArgs e)
        {
            cargar_region();
        }
        public void cargar_region()
        {
            try
            {
                if (cod_pais != "")
                {
                    string sql = "select codigo,nombre,estado from region where cod_pais='" + cod_pais.ToString() + "' and estado='1' order by nombre";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select codigo,nombre,estado from region where estado='1' order by nombre";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las regiones");
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pais_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void region_txt_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                if (cod_pais != "")
                {
                    string sql = "select codigo,nombre,estado from region where cod_pais='"+cod_pais.ToString()+"' and  nombre like '%" + region_txt.Text.Trim() + "%' and estado='1' order by nombre";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select codigo,nombre,estado from region where nombre like '%" + region_txt.Text.Trim() + "%' and estado='1' order by nombre";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las regiones");
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

                    codigo_pais_txt.Clear();
                    nombre_pais_txt.Clear();
                    codigo_region_txt.Clear();
                    nombre_region_txt.Clear();
                    nombre_region_nueva_txt.Clear();
                    ck_estado.Checked = true;
                    dataGridView1.Rows.Clear();
                    region_txt.Clear();
                    region_txt.Focus();


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
                codigo_region_txt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                nombre_region_nueva_txt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "True")
                    ck_estado.Checked = true;
                else
                    ck_estado.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error seleccionando la fila");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //guardar
                guardar();
                cargar_region();
            }
        }
        public void guardar()
        {
            try
            {
                //create proc insert_region
                //@nombre varchar(50),@estado bit,@codigo_pais int,@codigo_region int

                string sql = "";
                DataSet ds = new DataSet();
                if (codigo_region_txt.Text.Trim() == "")
                {
                    if (nombre_region_nueva_txt.Text.Trim() != "")
                    {
                        //guarda nuevo
                        int estado = 0;
                        if (ck_estado.Checked == true)
                        {
                            estado = 1;
                        }
                        else
                        {
                            estado = 0;
                        }
                        sql = "";
                        sql = "exec insert_region '" + nombre_region_nueva_txt.Text.Trim() + "','" + estado.ToString() + "','" + codigo_pais_txt.Text.Trim() + "','0'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if(ds.Tables[0].Rows.Count>0)
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
                        MessageBox.Show("Falta nombre de region");
                    }
                }
                else
                {
                    //actualizar
                    if (nombre_region_nueva_txt.Text.Trim() != "")
                    {
                        //guarda nuevo
                        int estado = 0;
                        if (ck_estado.Checked == true)
                        {
                            estado = 1;
                        }
                        else
                        {
                            estado = 0;
                        }
                        sql = "";
                        sql = "exec insert_region '" + nombre_region_nueva_txt.Text.Trim() + "','" + estado.ToString() + "','" + codigo_pais_txt.Text.Trim() + "','"+codigo_region_txt.Text.Trim()+"'";
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
                        MessageBox.Show("Falta nombre de region");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error guardando");
            }
        }

        private void pais_btn_Click(object sender, EventArgs e)
        {
            pais p = new pais();
            p.pasado += new pais.pasar(ejecutar_codigo_pais);
            p.ShowDialog();
            cargar_nombre_pais();
        }
        public void ejecutar_codigo_pais(string dato)
        {
            codigo_pais_txt.Text = dato.ToString();
        }
        public void cargar_nombre_pais()
        {
            try
            {
                string sql = "select nombre from pais where codigo='"+codigo_pais_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_pais_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre del pais");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            region r = new region();
            r.pasado += new region.pasar(ejecutar_codigo_region);
            r.ShowDialog();
            cargar_nombre_region();
        }
        public void ejecutar_codigo_region(string dato)
        {
            codigo_region_txt.Text = dato.ToString();
        }
        public void cargar_nombre_region()
        {
            try
            {
                string sql = "select nombre from region  where codigo='" + codigo_region_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_region_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el nombre de la region");
            }
        }
    }
}
