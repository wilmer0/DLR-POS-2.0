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
    public partial class categoria_subcategoria_producto : Form
    {
        public categoria_subcategoria_producto()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
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

        private void categoria_subcategoria_Load(object sender, EventArgs e)
        {
            cargar_categorias();
        }
        public string codigo_categoria_global = "";
        public string codigo_subcategoria_global = "";
        public void cargar_categorias()
        {
            try
            {
                string sql = "select  codigo,nombre,estado from categoria_producto where estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando las categorias");
            }
        }
        public void cargar_subcategoria()
        {
            try
            {
                string sql = "select codigo,nombre,cod_categoria,estado from subcategoria_producto where estado='1' and cod_categoria='"+codigo_categoria_global.ToString()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView2.DataSource = ds.Tables[0];
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando las subcategorias");
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentRow.Index;
            codigo_categoria_global = dataGridView1.Rows[fila].Cells[0].Value.ToString();
            //MessageBox.Show(codigo_categoria_global.ToString());
            codigo_categoria_txt.Text = codigo_categoria_global.ToString();
            nombre_categoria_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
            string sql = "select codigo,nombre,cod_categoria,estado from subcategoria_producto where estado='1' and cod_categoria='" + codigo_categoria_global.ToString() + "'";
            DataSet ds = Utilidades.ejecutarcomando(sql);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int fila = dataGridView1.CurrentRow.Index;
            codigo_categoria_global = dataGridView1.Rows[fila].Cells[0].Value.ToString();
            //MessageBox.Show(codigo_categoria_global.ToString());
            codigo_categoria_txt.Text = codigo_categoria_global.ToString();
            nombre_categoria_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
            if (dataGridView1.Rows[fila].Cells[2].Value.ToString() == "True")
            {
                ck_activo_categoria.Checked = true;     
            }
            else
            {
                ck_activo_categoria.Checked = false;
            }
            string sql = "select codigo,nombre,cod_categoria,estado from subcategoria_producto where estado='1' and cod_categoria='" + codigo_categoria_global.ToString() + "'";
            DataSet ds = Utilidades.ejecutarcomando(sql);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            int fila = dataGridView2.CurrentRow.Index;
            codigo_subcategoria_global = dataGridView2.Rows[fila].Cells[0].Value.ToString();
            //MessageBox.Show(codigo_categoria_global.ToString());
            codigo_subcategoria_txt.Text = codigo_subcategoria_global.ToString();
            nombre_subcategoria_txt.Text = dataGridView2.Rows[fila].Cells[1].Value.ToString();
            if (dataGridView2.Rows[fila].Cells[3].Value.ToString() == "True")
            {
                ck_activo_subcategoria.Checked = true;
            }
            else
            {
                ck_activo_subcategoria.Checked = false;
            }
        }

        private void dataGridView2_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView2.CurrentRow.Index;
            codigo_subcategoria_global = dataGridView2.Rows[fila].Cells[0].Value.ToString();
            //MessageBox.Show(codigo_categoria_global.ToString());
            codigo_subcategoria_txt.Text = codigo_subcategoria_global.ToString();
            nombre_subcategoria_txt.Text = dataGridView2.Rows[fila].Cells[1].Value.ToString();
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
                ck_activo_categoria.Checked = true;
            }
            catch(Exception)
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
                ck_activo_subcategoria.Checked = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error limpiando la subcategoria");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*
             create proc insert_subcategoria_producto
             @nombre varchar(50),@cod_categoria int,@estado bit,@codigo int
            */
            
            try
            {
                int estado=0;
                if (codigo_subcategoria_txt.Text.Trim() == "")
                {
                    if(nombre_subcategoria_txt.Text.Trim()!="")
                    {
                        if (ck_activo_subcategoria.Checked == true)
                            estado = 1;
                        else
                            estado = 0;

                        //guardar
                        string sql = "exec insert_subcategoria_producto '"+nombre_subcategoria_txt.Text.Trim()+"','"+codigo_categoria_txt.Text.Trim()+"','"+estado.ToString()+"','0'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if(ds.Tables[0].Rows.Count>0)
                        {
                            MessageBox.Show("Se guardo!");
                            cargar_subcategoria();
                            codigo_subcategoria_txt.Clear();
                            nombre_subcategoria_txt.Clear();
                            ck_activo_subcategoria.Checked = true;
                            nombre_subcategoria_txt.Focus();
                        }
                        else
                        {
                            MessageBox.Show("No se guardo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el nombre de la subcategoria");
                    }
                }
                else
                {
                    //actualiza
                    if (nombre_subcategoria_txt.Text.Trim() != "")
                    {
                        if (ck_activo_subcategoria.Checked == true)
                            estado = 1;
                        else
                            estado = 0;

                        //guardar
                        string sql = "exec insert_subcategoria_producto '" + nombre_subcategoria_txt.Text.Trim() + "','" + codigo_categoria_txt.Text.Trim() + "','" + estado.ToString() + "','"+codigo_subcategoria_txt.Text.Trim()+"'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Se actualizo!");
                            cargar_subcategoria();
                        }
                        else
                        {
                            MessageBox.Show("No se actualizo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el nombre de la subcategoria");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error guardando");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if(codigo_categoria_txt.Text.Trim()=="")
                {
                    //guarda
                    //create proc insert_categoria_producto
                    //@nombre varchar(50),@estado bit,@codigo_categoria int
                    int estado=0;
                    if(ck_activo_categoria.Checked==true)
                        estado=1;
                    else
                        estado=0;
                    string sql = "exec insert_categoria_producto '"+nombre_categoria_txt.Text.Trim()+"','"+estado.ToString()+"','0'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    if(ds.Tables[0].Rows.Count>0)
                    {
                        MessageBox.Show("Se guardo!");
                        cargar_categorias();
                        cargar_subcategoria();
                        codigo_categoria_txt.Clear();
                        codigo_subcategoria_txt.Clear();
                        ck_activo_categoria.Checked = true;
                        nombre_categoria_txt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No se guardo");
                    }
                }
                else
                {
                    //actualiza
                    //create proc insert_categoria_producto
                    //@nombre varchar(50),@estado bit,@codigo_categoria int
                    int estado=0;
                    if(ck_activo_categoria.Checked==true)
                        estado=1;
                    else
                        estado=0;
                    string sql = "exec insert_categoria_producto '" + nombre_categoria_txt.Text.Trim() + "','" + estado.ToString() + "','"+codigo_categoria_txt.Text.Trim()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Se actualizo!");
                        cargar_categorias();
                        cargar_subcategoria();
                    }
                    else
                    {
                        MessageBox.Show("No se actualizo");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error guardando");
            }
        }
        public void cargar_datos_categoria()
        {
            try
            {
                if (codigo_categoria_txt.Text.Trim() != "")
                {
                    string sql = "select nombre,estado from categoria_producto where codigo='" + codigo_categoria_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_categoria_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                    if (ds.Tables[0].Rows[0][1].ToString() == "True")
                    {
                        ck_activo_categoria.Checked = true;
                    }
                    else
                    {
                        ck_activo_categoria.Checked = false;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los datos de la categoria");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_categoria bc = new busqueda_categoria();
            bc.pasado += new busqueda_categoria.pasar(ejecutar_codigo_categoria);
            bc.mantenimiento = true;
            bc.ShowDialog();
            cargar_datos_categoria();
        }
        public void ejecutar_codigo_categoria(string dato)
        {
            codigo_categoria_txt.Text = dato.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            busqueda_subcategoria bs = new busqueda_subcategoria();
            bs.mantenimiento = true;
            bs.pasado += new busqueda_subcategoria.pasar(ejecutar_codigo_subcategoria);
            bs.codigo_categoria_global = codigo_categoria_txt.Text.Trim();
            bs.ShowDialog();
            cargar_datos_subcategoria();
        }
        public void ejecutar_codigo_subcategoria(string dato)
        {
            codigo_subcategoria_txt.Text = dato.ToString();
        }
        public void cargar_datos_subcategoria()
        {
            try
            {
                if (codigo_subcategoria_txt.Text.Trim() != "")
                {
                    string sql = "select nombre,estado from subcategoria_producto where codigo='" + codigo_subcategoria_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_subcategoria_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                    if (ds.Tables[0].Rows[0][1].ToString() == "True")
                    {
                        ck_activo_subcategoria.Checked = true;
                    }
                    else
                    {
                        ck_activo_subcategoria.Checked = false;
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Erro cargando los datos de la subcategoria");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                limpiar();
            }
        }
        public void limpiar()
        {
            try
            {
                cargar_categorias();
                cargar_datos_subcategoria();
                limpiar_categoria();
                limpiar_subCategoria();
            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
