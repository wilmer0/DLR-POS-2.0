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
    public partial class busqueda_unidad : Form
    {
        public busqueda_unidad()
        {
            InitializeComponent();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        public string codigo_producto = "";
        public bool mantenimiento = false;
        private void busqueda_unidad_Load(object sender, EventArgs e)
        {
            cargar_unidad();
        }
        public void cargar_unidad()
        {
                string sql = "";
                try
                {
                    dataGridView1.Rows.Clear();
                    if (codigo_producto == "")
                    {
                        if (mantenimiento == false)
                        {
                            sql = "select codigo,nombre,unidad_abreviada,estado from unidad where estado='1' order by codigo desc";
                            DataSet ds = Utilidades.ejecutarcomando(sql);
                            //dataGridView1.DataSource = ds.Tables[0];
                            foreach(DataRow row in ds.Tables[0].Rows)
                            {
                                dataGridView1.Rows.Add(row[0].ToString(),row[1].ToString(),row[2].ToString(),row[3].ToString());
                            }
                        }
                        else
                        {
                            sql = "select codigo,nombre,unidad_abreviada,estado from unidad order by codigo desc";
                            DataSet ds = Utilidades.ejecutarcomando(sql);
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                            }
                            
                        }
                    }
                    else
                    {

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error cargando unidad");
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
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                limpiar();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //guardar
                    /*create proc insert_unidad  @nombre varchar(50),@estado bit,@codigo int
                    */
                    int estado = 0;
                    if (ck_activo.Checked == true)
                        estado = 1;
                    else
                        estado = 0;
                    
                    if(nombre_unidad_txt.Text.Trim() != "")
                    {
                        if (abreviacion_txt.Text.Trim() != "")
                        {
                            if (codigo_unidad_txt.Text.Trim() =="")
                            { 
                                //guarda
                                string sql = "select *from unidad where nombre='" + nombre_unidad_txt.Text.Trim() + "' or unidad_abreviada='" + abreviacion_txt.Text.Trim() + "'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                if (ds.Tables[0].Rows.Count == 0)
                                {
                                    sql = "exec insert_unidad '" + nombre_unidad_txt.Text.Trim() + "','" + estado.ToString() + "','" + abreviacion_txt.Text.Trim() + "','0'";
                                    ds = Utilidades.ejecutarcomando(sql);
                                    if (ds.Tables[0].Rows.Count> 0)
                                    {
                                            MessageBox.Show("Se guardo");
                                            cargar_unidad();   
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se guardo");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ya existe una unidad con el mismo nombre o el mismo nombre abreviado");
                                }
                            }
                            else
                            {
                                //actualiza
                                string sql = "select *from unidad where (nombre='" + nombre_unidad_txt.Text.Trim() + "' or unidad_abreviada='" + abreviacion_txt.Text.Trim() + "') and codigo!='" + codigo_unidad_txt.Text.Trim() + "'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                if (ds.Tables[0].Rows.Count == 0)
                                {
                                    sql = "exec insert_unidad '" + nombre_unidad_txt.Text.Trim() + "','" + estado.ToString() + "','" + abreviacion_txt.Text.Trim() + "','" + codigo_unidad_txt.Text.Trim() + "'";
                                    ds = Utilidades.ejecutarcomando(sql);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        MessageBox.Show("Se actualizo");
                                        cargar_unidad();
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se actualizo");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ya existe una unidad con el mismo nombre o el nombre abreviado");
                                }
                            }
                        }
                        else
                        {
                             MessageBox.Show("Falta el nombre abreviado");
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
                MessageBox.Show("Error");
            }
        }

        private void unidad_txt_KeyUp(object sender, KeyEventArgs e)
        {
            string sql = "";
            try
            {
                dataGridView1.Rows.Clear();
                if (mantenimiento == false)
                {
                    
                    sql = "select codigo,nombre,unidad_abreviada,estado from unidad where estado='1' and nombre like '%" + unidad_txt.Text.Trim() + "%' order by codigo desc ";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                    }
                }
                else
                {
                   
                    sql = "select codigo,nombre,unidad_abreviada,estado from unidad where  nombre like '%" + unidad_txt.Text.Trim() + "%' order by codigo desc ";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando unidad");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = "";
                codigo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                pasado(codigo.ToString());
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error pasando variable hacia atras");
            }
        }
        public void llenar_datos_unidad()
        {
            try
            {
                string sql = "select codigo,nombre,estado from unidad where codigo ='"+codigo_unidad_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_unidad_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                if (ds.Tables[0].Rows[0][2].ToString().ToString() == "True")
                    ck_activo.Checked = true;
            }
            catch(Exception)
            {
                MessageBox.Show("Error llenando los datos de la unidad");
                limpiar();
            }
        }
        private void codigo_unidad_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (codigo_unidad_txt.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    llenar_datos_unidad();
                }
            }
        }
        public void limpiar()
        {
            nombre_unidad_txt.Clear();
            abreviacion_txt.Clear();
            ck_activo.Checked =true;
            unidad_txt.Clear();
            cargar_unidad();
            codigo_unidad_txt.Clear();
            nombre_unidad_txt.Focus();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = dataGridView1.CurrentRow.Index;
                codigo_unidad_txt.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString(); 
                nombre_unidad_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                abreviacion_txt.Text = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                if (dataGridView1.Rows[fila].Cells[3].Value.ToString() == "True")
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
                MessageBox.Show("Error seleccinando la fila");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            busqueda_unidad bu = new busqueda_unidad();
            bu.mantenimiento = true;
            bu.pasado += new busqueda_unidad.pasar(ejecutar_codigo_unidad);
            bu.ShowDialog();
            cargar_nombre_unidad();
        }
        public void ejecutar_codigo_unidad(string dato)
        {
            codigo_unidad_txt.Text = dato.ToString();
        }
        public void cargar_nombre_unidad()
        {
            try
            {
                if (codigo_unidad_txt.Text.Trim() != "")
                {
                    string sql = "select codigo,nombre,unidad_abreviada,estado from unidad where codigo='" + codigo_unidad_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_unidad_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                    abreviacion_txt.Text = ds.Tables[0].Rows[0][2].ToString();
                    if(ds.Tables[0].Rows[0][3].ToString()=="True")
                    {
                        ck_activo.Checked = true;
                    }
                    else
                    {
                        ck_activo.Checked = false;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando datos de la unidad");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int fila = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows[fila].Cells[0].Value.ToString();
                //MessageBox.Show(codigo_categoria_global.ToString());
                codigo_unidad_txt.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                nombre_unidad_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                abreviacion_txt.Text = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                if (dataGridView1.Rows[fila].Cells[3].Value.ToString() == "True")
                {
                    ck_activo.Checked = true;
                }
                else
                {
                    ck_activo.Checked = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error seleccinando la fila");
            }
        }
    }
}
