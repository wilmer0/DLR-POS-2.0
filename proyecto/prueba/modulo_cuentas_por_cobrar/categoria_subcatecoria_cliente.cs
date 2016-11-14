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
    public partial class categoria_subcatecoria_cliente : Form
    {
        public categoria_subcatecoria_cliente()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            limpiar_categoria();
        }
        public void limpiar_categoria()
        {
            try
            {
                codigo_categoria_txt.Clear();
                nombre_categoria_txt.Clear();
                ck_activo_categoria.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error limpiando la categoria");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            limpiar_subCategoria();
        }
        public void limpiar_subCategoria()
        {
            try
            {
                codigo_subcategoria_txt.Clear();
                nombre_subcategoria_txt.Clear();
                ck_activo_subcategoria.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error limpiando la subcategoria");
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void categoria_subcatecoria_cliente_Load(object sender, EventArgs e)
        {
            cargar_categoria();
        }
        public void cargar_categoria()
        {
            try
            {
                string sql="select codigo,nombre,estado from cliente_categoria where estado='1'";
                DataSet ds=Utilidades.ejecutarcomando(sql);
                dataGridView1.DataSource=ds.Tables[0];
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando las categorias'");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_cliente_categoria b = new busqueda_cliente_categoria();
            b.mantenimiento = true;
            b.pasado += new busqueda_cliente_categoria.pasar(ejecutar_codigo_categoria);
            b.mantenimiento = true;
            b.ShowDialog();
            cargar_datos_categoria();
            limpiar_subcategoria();
        }
        public void limpiar_subcategoria()
        {
            try
            {
                codigo_subcategoria_txt.Clear();
                nombre_subcategoria_txt.Clear();
                ck_activo_subcategoria.Checked = false;
            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando la subcategoria");
            }
        }
        public void ejecutar_codigo_categoria(string dato)
        {
            codigo_categoria_txt.Text = dato.ToString();
        }
        public void cargar_datos_categoria()
        {
            try
            {
                string sql = "select nombre,estado from cliente_categoria where codigo='"+codigo_categoria_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_categoria_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                if (ds.Tables[0].Rows[0][1].ToString() == "True")
                    ck_activo_categoria.Checked = true;
                else
                    ck_activo_categoria.Checked = false;
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargarndo los datos de la categoria");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (codigo_categoria_txt.Text.Trim() != "")
            {
                busqueda_cliente_subcategoria bs = new busqueda_cliente_subcategoria();
                bs.codigo_categoria = codigo_categoria_txt.Text.Trim();
                bs.pasado += new busqueda_cliente_subcategoria.pasar(ejecutar_codigo_subcategoria);
                bs.mantenimiento = true;
                bs.ShowDialog();
                cargar_datos_subcategoria();
            }
            else
            {
                MessageBox.Show("Debe elegir la categoria primero");
            }
        }
        public  void ejecutar_codigo_subcategoria(string dato)
        {
            codigo_subcategoria_txt.Text = dato.ToString();
        }
        public void cargar_datos_subcategoria()
        {
            try
            {
                string sql = "select nombre,estado from cliente_subcategoria where codigo='"+codigo_subcategoria_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_subcategoria_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                if(ds.Tables[0].Rows[0][1].ToString()=="True")
                {
                    ck_activo_subcategoria.Checked = true;
                }
                else
                {
                    ck_activo_subcategoria.Checked = false;
                }

            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los datos de la subcategoria");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select codigo,nombre,estado from cliente_subcategoria where cod_categoria='"+dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView2.DataSource = ds.Tables[0];
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando las subcategoria del grid de categoria");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if(codigo_categoria_txt.Text.Trim()=="")
                {
                    //guarda
                    if(nombre_categoria_txt.Text.Trim()!="")
                    {
                        int estado = 0;
                        if (ck_activo_categoria.Checked == true)
                            estado = 1;
                        else
                            estado = 0;

                        /*
                         create proc insert_cliente_categoria
                         @nombre varchar(50),@estado bit,@codigo int
                         */
                        string sql = "exec insert_cliente_categoria '"+nombre_categoria_txt.Text.Trim()+"','"+estado.ToString()+"','0'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if(ds.Tables[0].Rows.Count>0)
                        {
                            cargar_categoria();
                            MessageBox.Show("Se guardo");
                        }
                        else
                        {
                            MessageBox.Show("No se guardo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el nombre");
                        nombre_categoria_txt.Focus();
                    }
                }
                else
                {
                    //actualiza
                    if (nombre_categoria_txt.Text.Trim() != "")
                    {
                        int estado = 0;
                        if (ck_activo_categoria.Checked == true)
                            estado = 1;
                        else
                            estado = 0;

                        /*
                         create proc insert_cliente_categoria
                         @nombre varchar(50),@estado bit,@codigo int
                         */
                        string sql = "exec insert_cliente_categoria '" + nombre_categoria_txt.Text.Trim() + "','" + estado.ToString() + "','"+codigo_categoria_txt.Text.Trim()+"'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            cargar_categoria();
                            MessageBox.Show("Se actualizo");
                        }
                        else
                        {
                            MessageBox.Show("No se actualizo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el nombre");
                        nombre_categoria_txt.Focus();
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error guardando la categoria");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if(codigo_categoria_txt.Text.Trim()!="")
                {
                    if(codigo_subcategoria_txt.Text.Trim()=="")
                    {
                        //guardar
                        if(nombre_subcategoria_txt.Text.Trim()!="")
                        {
                            int estado = 0;
                            if (ck_activo_subcategoria.Checked == true)
                                estado = 1;
                            else
                                estado = 0;

                            /*
                             create proc insert_cliente_subcategoria
                             @nombre varchar(50),@cod_categoria int,@estado bit,@codigo int
                             */
                            string sql = "exec insert_cliente_subcategoria '"+nombre_subcategoria_txt.Text.Trim()+"','"+codigo_categoria_txt.Text.Trim()+"','"+estado.ToString()+"','0'";
                            DataSet ds = Utilidades.ejecutarcomando(sql);
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
                            nombre_subcategoria_txt.Focus();
                            MessageBox.Show("Falta el nombre de lca subcategoria");
                        }
                    }
                    else
                    {
                        //actualizar
                        if (nombre_subcategoria_txt.Text.Trim() != "")
                        {
                            int estado = 0;
                            if (ck_activo_subcategoria.Checked == true)
                                estado = 1;
                            else
                                estado = 0;

                            /*
                             create proc insert_cliente_subcategoria
                             @nombre varchar(50),@cod_categoria int,@estado bit,@codigo int
                             */
                            string sql = "exec insert_cliente_subcategoria '" + nombre_subcategoria_txt.Text.Trim() + "','" + codigo_categoria_txt.Text.Trim() + "','" + estado.ToString() + "','"+codigo_subcategoria_txt.Text.Trim()+"'";
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
                            nombre_subcategoria_txt.Focus();
                            MessageBox.Show("Falta el nombre de lca subcategoria");
                        }
                    }
                }
                else
                {
                        MessageBox.Show("Debe elegir una categoria");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error guardando la subcategoria");
            }
        }
    }
}
