using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using puntoVenta;
namespace puntoVenta
{
    public partial class producto : Form
    {
        public producto()
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

        public void actualiza_permisos()
        {
            try
            {
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    string sql = "delete from producto_vs_permisos where cod_producto ='" + codigo_producto_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        /*
                        create proc insert_permiso_producto
                        @cod_producto int,@cod_permiso int
                        */
                        sql = "exec insert_permiso_producto '" + codigo_producto_txt.Text.Trim() + "','" + row.Cells[0].Value.ToString() + "'";
                        ds = Utilidades.ejecutarcomando(sql);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error actualizando los permisos del producto");
            }
        }
        public void actualiza_codigo_barra()
        {
            try
            {
                /*
                 create proc insert_codigobarra
                @cod_producto int,@cod_unidad int,@barra varchar(15)

                 */
                string sql = "delete from producto_codigobarra where cod_producto='"+codigo_producto_txt.Text.Trim()+"'";
                Utilidades.ejecutarcomando(sql);
                foreach(DataGridViewRow row in dataGridView2.Rows)
                {
                    sql = "exec insert_codigobarra '"+codigo_producto_txt.Text.Trim()+"','"+row.Cells[0].Value.ToString()+"','"+row.Cells[1].Value.ToString()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    //MessageBox.Show("cod_unidad->" + row.Cells[0].Value.ToString() + "- barra-> " + row.Cells[1].Value.ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Erro actualizando codigo de barra");
            }
        }
        public void actualiza_conversion_unidades()
        {
            try
            {
               
                    /*
                     create proc insert_producto_unidad_conversion
                     @cod_prod int,@cod_unidad int,@cantidad float,@precio_venta
                     */
                    string sql = "delete from producto_unidad_conversion where cod_producto='"+codigo_producto_txt.Text.Trim()+"'";
                    Utilidades.ejecutarcomando(sql);
                    foreach (DataGridViewRow row in dataGridView4.Rows)
                    {
                        sql = "exec insert_producto_unidad_conversion '" + codigo_producto_txt.Text.Trim() + "','" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "'";
                        Utilidades.ejecutarcomando(sql);
                    }
                    //para insertarlo en producto_unidad es decir todas las unidades que maneja el producto
                    /*
                     create proc insert_producto_unidad @cod_prod int,@cod_unidad int*/
                    sql = "delete from producto_unidad where cod_producto='" + codigo_producto_txt.Text.Trim() + "'";
                    Utilidades.ejecutarcomando(sql);
                    foreach (DataGridViewRow row in dataGridView4.Rows)
                    {
                        sql = "exec insert_producto_unidad '" + codigo_producto_txt.Text.Trim() + "','" + row.Cells[0].Value.ToString() + "'";
                        Utilidades.ejecutarcomando(sql);
                    }
                
            }
            catch(Exception)
            {
                MessageBox.Show("Error agregando la conversion de las unidades");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (codigo_producto_txt.Text == "")
                    {
                        //guardar
                        if (nombre_producto_txt.Text.Trim() != "")
                        {
                            if (codigo_itebis_txt.Text.Trim() != "")
                            {
                                if (codigo_almacen_txt.Text.Trim() != "")
                                {
                                    if (codigo_unidad_minima_txt.Text.Trim() != "")
                                    {
                                        int estado = 0;
                                        if (ck_activo.Checked == true)
                                            estado = 1;
                                        else
                                            estado = 0;
                                        /*
                                         create proc insert_producto
                                         @nombre varchar(50),@referencia varchar(10),@estado bit,@reorden float,
                                         @punto_maximo float,@cod_itebis int,@cod_categoria int,
                                         @cod_subcategoria int,@cod_almacen int,@imagen varchar(max),@codigo int
                                         */ 
                                        string sql = "exec insert_producto '" + nombre_producto_txt.Text.Trim() + "','" + referencia_txt.Text.Trim() + "','" + estado.ToString() + "','" + reorden_txt.Text.Trim() + "','" + punto_maximo_txt.Text.Trim() + "','" + codigo_itebis_txt.Text.Trim() + "','" + codigo_categoria_producto_txt.Text.Trim() + "','" + codigo_subcategoria_txt.Text.Trim() + "','" + codigo_almacen_txt.Text.Trim() +"','"+nombre_imagen.ToString()+ "','" + codigo_unidad_minima_txt.Text.Trim() + "','0'";
                                        DataSet ds = Utilidades.ejecutarcomando(sql);
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            codigo_producto_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                                            actualiza_permisos();
                                            actualiza_codigo_barra();
                                            actualiza_detalle_productos();
                                            actualiza_conversion_unidades();
                                            actualiza_producto_requisitos();
                                            MessageBox.Show("Se guardo","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se guardo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Falta la unidad minima del producto para la conversion de unidades");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Falta el almacen");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Falta el itbis");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta el nombre");
                            nombre_producto_txt.Focus();
                        }
                    }
                    else
                    {
                        //actualizar
                        if (nombre_producto_txt.Text.Trim() != "")
                        {
                            if (codigo_itebis_txt.Text.Trim() != "")
                            {
                                if (codigo_almacen_txt.Text.Trim() != "")
                                {
                                    int estado = 0;
                                    if (ck_activo.Checked == true)
                                    {
                                        estado = 1;
                                    }
                                    else
                                    {
                                        estado = 0;
                                    }
                                    string imagen = "";
                                    string sql = "exec insert_producto '" + nombre_producto_txt.Text.Trim() + "','" + referencia_txt.Text.Trim() + "','" + estado.ToString() + "','" + reorden_txt.Text.Trim() + "','" + punto_maximo_txt.Text.Trim() + "','" + codigo_itebis_txt.Text.Trim() + "','" + codigo_categoria_producto_txt.Text.Trim() + "','" + codigo_subcategoria_txt.Text.Trim() + "','" + codigo_almacen_txt.Text.Trim() + "','" + nombre_imagen.ToString() + "','" + codigo_unidad_minima_txt.Text.Trim() + "','"+codigo_producto_txt.Text.Trim()+"'";
                                    DataSet ds = Utilidades.ejecutarcomando(sql);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        actualiza_permisos();
                                        actualiza_codigo_barra();
                                        actualiza_detalle_productos();
                                        actualiza_conversion_unidades();
                                        actualiza_producto_requisitos();
                                        MessageBox.Show("Se actualizo", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se actualizo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Falta el almacen");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Falta el itbis");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta el nombre");
                            nombre_producto_txt.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardando el producto: "+ex.ToString());
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        internal singleton s { get; set; }
        
        
        private void producto_Load(object sender, EventArgs e)
        {
           s= singleton.obtenerDatos();
           cargar_nombre_categoria();
           cargar_nombre_subcategoria();
           cargar_todos_permisos();
           primer_almacen();
           primer_itebis();  
        }
        public void primer_almacen()
        {
            string sql = "select top(1)codigo from almacen where estado='1'";
            DataSet ds = Utilidades.ejecutarcomando(sql);
            codigo_almacen_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            cargar_nombre_almacen();
        }
        public void primer_itebis()
        {
            string sql = "select top(1)codigo from itebis where estado='1'";
            DataSet ds = Utilidades.ejecutarcomando(sql);
            codigo_itebis_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            cargar_nombre_itebis();
        }
        public void cargar_todos_permisos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select codigo,nombre from producto_permisos where estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando todos los permisos");
            }
        }
        public void actualiza_detalle_productos()
        {
            try
            {
                /*
                 create proc insert_producto_detalle
                 @cod_producto int,@cod_detalle int,@descripcion varchar(100)
                 */
                string sql = "delete from producto_vs_detalle where codigo_producto='"+codigo_producto_txt.Text.Trim()+"'";
                Utilidades.ejecutarcomando(sql);
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    sql = "exec insert_producto_detalle '"+codigo_producto_txt.Text.Trim()+"','"+row.Cells[0].Value.ToString()+"','"+row.Cells[2].Value.ToString()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando todos los permisos por defecto");
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        string extension = "";
        string ruta = "";
        string nombre_imagen = "";
        string destino = "";
        string imagen = "";
        
        
        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                string sql = "select top(1) ruta_imagen_productos from sistema";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                destino = ds.Tables[0].Rows[0][0].ToString();
                destino += @"\";
                OpenFileDialog file = new OpenFileDialog();
                //file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                file.Filter = "PNG Files (*.png)|*.png|  JPG Files (*.jpg)|*.jpg|     All files (*.*)|*.*";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    ruta = file.FileName;
                    extension = Path.GetExtension(ruta);//me da el nombre con la extension
                    nombre_imagen = Path.GetFileName(ruta);
                    //MessageBox.Show(nombre_imagen.ToString());
                    destino += nombre_imagen;
                    //MessageBox.Show(destino);//la ruta con todo y extencion se guarda en ruta
                    //mostrar la imagen que se va a subir antes de subirla y moverla
                    //a un directorio donde este el programa
                    imagen_ruta_txt.Text = ruta.ToString();
                    //pictureBox1.Image = System.Drawing.Image.FromFile(ruta);//para meter la imagen en un pocture box pero el picture box no la cojia completa
                    //MessageBox.Show(nombre_imagen);
                    panel4.BackgroundImage = Image.FromFile(ruta.ToString());
                    //System.IO.File.Move(ruta, destino);
                    File.Copy(imagen_ruta_txt.Text, destino);//copia la imagen(desde,aqui) y la pega en el destino
                }
                else
                {
                    //imagen_ruta_txt.Clear();
                }
            }
            catch(Exception)
            {
                //MessageBox.Show("Error pasando la imagen al directorio local");
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            busqueda_unidad bu = new busqueda_unidad();
            bu.pasado += new busqueda_unidad.pasar(ejecutar_unidad);
            bu.ShowDialog();
        }
        public void ejecutar_unidad(string dato)
        {
            //unidad_codigo_txt.Text = dato.ToString();
        }

        private void unidad_txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //string sql = "select nombre from unidad where codigo ='"+unidad_codigo_txt.Text.Trim()+"'";
                //DataSet ds = Utilidades.ejecutarcomando(sql);
               // unidad_nombre_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error tomando el nombre de la unidad");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            busqueda_producto bp = new busqueda_producto();
            bp.pasado += new busqueda_producto.pasar(ejecutar_codigo_producto);
            bp.codigo_sucursal = s.codigo_sucursal.ToString();
            bp.mantenimiento = true;
            bp.ShowDialog();
            cargar_datos_producto();
            cargar_codigo_barras();
            cargar_detalles();
            cargar_permisos();
            cargar_unidades_conversion();
            cargar_productos_requisitos();

        }
        public void cargar_productos_requisitos()
        {
            try
            {
                dataGridView5.Rows.Clear();
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    string sql = "select distinct pr.codpro_requisito,p.nombre,uni.codigo,uni.nombre,pr.cantidad from producto_productos_requisitos pr join producto p on pr.codpro_requisito=p.codigo join producto_unidad pu on pr.cod_unidad=pu.cod_unidad join unidad uni on pr.cod_unidad=uni.codigo where pr.codpro_titular='" + codigo_producto_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView5.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(),row[4].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando la conversion de unidades: " + ex.ToString());
            }
        }
        public void cargar_unidades_conversion()
        {
            try
            {
                dataGridView4.Rows.Clear();
                if(codigo_producto_txt.Text.Trim()!="")
                {
                    string sql = "select pc.cod_unidad,un.nombre,pc.cantidad,precio_venta from producto_unidad_conversion pc join unidad un on pc.cod_unidad=un.codigo where pc.cod_producto='"+codigo_producto_txt.Text.Trim()+"' order by pc.cod_unidad";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach(DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView4.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error cargando la conversion de unidades: "+ex.ToString());
            }
        }
        public void cargar_detalles()
        {
            dataGridView3.Rows.Clear();
            try
            {
                string sql = "select pd.codigo_detalle,d.descripcion,pd.descripcion from producto_vs_detalle pd join producto_detalle d on d.codigo=pd.codigo_detalle where codigo_producto='" + codigo_producto_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView3.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los detalles");
            }
        }
        public void cargar_datos_producto()
        {
            try
            {
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    string sql = "select nombre,referencia,estado,reorden,punto_maximo,cod_itebis,cod_categoria,cod_subcategoria,cod_almacen,imagen,cod_unidad_minima from producto where codigo='" + codigo_producto_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_producto_txt.Text = ds.Tables[0].Rows[0]["nombre"].ToString();
                    referencia_txt.Text = ds.Tables[0].Rows[0]["referencia"].ToString();
                    reorden_txt.Text = ds.Tables[0].Rows[0]["reorden"].ToString();
                    if (ds.Tables[0].Rows[0]["estado"].ToString() == "True")
                    {
                        ck_activo.Checked = true;
                    }
                    else
                    {
                        ck_activo.Checked = false;
                    }
                    punto_maximo_txt.Text = ds.Tables[0].Rows[0]["punto_maximo"].ToString();
                    codigo_itebis_txt.Text = ds.Tables[0].Rows[0]["cod_itebis"].ToString();
                    cargar_nombre_itebis();
                    codigo_categoria_producto_txt.Text = ds.Tables[0].Rows[0]["cod_categoria"].ToString();
                    cargar_nombre_categoria();
                    codigo_subcategoria_txt.Text = ds.Tables[0].Rows[0]["cod_subcategoria"].ToString();
                    cargar_nombre_subcategoria();
                    codigo_almacen_txt.Text = ds.Tables[0].Rows[0]["cod_almacen"].ToString();
                    cargar_nombre_almacen();
                    nombre_imagen = ds.Tables[0].Rows[0]["imagen"].ToString();
                    codigo_unidad_minima_txt.Text = ds.Tables[0].Rows[0]["cod_unidad_minima"].ToString();
                    cargar_nombre_unidad_minima();
                    if (nombre_imagen!="")//ds.Tables[0].Rows[0][9].ToString() != "" && ds.Tables[0].Rows[0][9].ToString() != null
                    {
                        sql = "select top(1) ruta_imagen_productos from sistema";
                        ds = Utilidades.ejecutarcomando(sql);
                        ruta = ds.Tables[0].Rows[0][0].ToString();
                        ruta += @"\";
                        ruta += nombre_imagen.ToString(); 
                        imagen_ruta_txt.Text = ruta;
                        //MessageBox.Show(ruta.ToString());
                        panel4.Visible = true;
                        panel4.BackgroundImage = Image.FromFile(ruta.ToString());
                        //MessageBox.Show(nombre_imagen + "----" + ruta.ToString());
                    }
                    else
                    {
                        panel4.BackgroundImage = null;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error cargando los datos del producto: "+ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void cargar_permisos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select p.codigo,p.nombre from producto_vs_permisos pp join producto_permisos p  on p.codigo=pp.cod_permiso where pp.cod_producto='" + codigo_producto_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los permisos de barra de ese producto");
            }
        }
        public void cargar_codigo_barras()
        {
            try
            {
                dataGridView2.Rows.Clear();
                string sql = "select cod_unidad,codigo_barra,u.nombre from producto_codigobarra  p join unidad u on p.cod_unidad=u.codigo where cod_producto='" + codigo_producto_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView2.Rows.Add(row[0].ToString(), row[1].ToString(),row[2].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los codigos de barra de ese producto");
            }
        }
        public void ejecutar_codigo_producto(string dato)
        {
            codigo_producto_txt.Text = dato.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_categoria bc = new busqueda_categoria();
            bc.pasado += new busqueda_categoria.pasar(ejecutar_codigo_categoria);
            bc.ShowDialog();
            codigo_subcategoria_txt.Clear();
            nombre_subcategoria_txt.Clear();
        }
        public void ejecutar_codigo_categoria(string dato)
        {
            codigo_categoria_producto_txt.Text = dato.ToString();
            codigo_categoria_producto_txt.ReadOnly = true;
            cargar_nombre_categoria();
        }
        public void cargar_nombre_categoria()
        {
            try
            {
                string sql = "select nombre from categoria_producto where codigo ='" + codigo_categoria_producto_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_categoria_producto_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                nombre_categoria_producto_txt.ReadOnly = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error tomando el nombre de la categoria de producto");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //limpiar
                limpiar();
            }
        }
        public void limpiar()
        {
            try
            {

                codigo_detalle_producto_txt.Clear();
                nombre_detalle_producto_txt.Clear();
                detalle_producto_descripcion_txt.Clear();
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();
                dataGridView4.Rows.Clear();
                codigo_producto_txt.Clear();
                nombre_producto_txt.Clear();
                referencia_txt.Clear();
                cargar_nombre_categoria();
                reorden_txt.Text = "0";
                punto_maximo_txt.Text = "0";
                panel4.BackgroundImage = Image.FromFile("");
                codigo_permiso_txt.Clear();
                nombre_permiso_txt.Clear();
                codigo_unidad_txt.Clear();
                nombre_unidad_txt.Clear();
                codigo_barra_txt.Clear();
                nombre_producto_txt.Focus();
                codigo_detalle_producto_txt.Clear();
                nombre_detalle_producto_txt.Clear();
                detalle_producto_descripcion_txt.Clear();
                codigo_barra_txt.Clear();
                codigo_unidad_txt.Clear();
                nombre_unidad_txt.Clear();
                codigo_unidad_minima_txt.Clear();
                nombre_unidad_minima_txt.Clear();
                primer_itebis();
                primer_almacen();
                cargar_todos_permisos();
            }
            catch(Exception)
            {
                //MessageBox.Show("Error limpiando");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (codigo_categoria_producto_txt.Text != "")
            {
                busqueda_subcategoria bs = new busqueda_subcategoria();
                bs.pasado += new busqueda_subcategoria.pasar(ejecutar_codigo_subcategoria);
                bs.codigo_categoria_global = codigo_categoria_producto_txt.Text.Trim().ToString();
                bs.ShowDialog();
                cargar_nombre_subcategoria();
            }
            else
            {
                MessageBox.Show("Debe elegir una categoria primero");
            }
        }
        public void ejecutar_codigo_subcategoria(string dato)
        {
            codigo_subcategoria_txt.Text = dato.ToString();
            
        }
        public void cargar_nombre_subcategoria()
        {
            try
            {
                if (codigo_subcategoria_txt.Text.Trim() != "")
                {
                    string sql = "select nombre from subcategoria_producto where codigo ='" + codigo_subcategoria_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_subcategoria_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                    nombre_subcategoria_txt.ReadOnly = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error tomando el nombre de la subcategoria de producto");
            }
        }

        private void codigo_subcategoria_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            //abrir busqueda de unidades
            busqueda_unidad bu = new busqueda_unidad();
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
                string sql = "select nombre from unidad where codigo='"+codigo_unidad_txt.Text+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_unidad_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando nombre de la unidad");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
               
            
                    if (codigo_unidad_txt.Text!="")
                    {
                        int cont = 0;
                        
                        //hacer select para verificar que ese codigo de barra ningun otro producto lo tiene con ninguna otra unidad

                        string sql = "";
                        if (codigo_producto_txt.Text.Trim() != "")
                        {
                           sql = "select *from producto_codigobarra where codigo_barra='" + codigo_barra_txt.Text.Trim() + "' and codigo_barra!='' and cod_producto!='" + codigo_producto_txt.Text.Trim() + "'";
                        } 
                        else
                        {
                            sql = "select *from producto_codigobarra where codigo_barra='" + codigo_barra_txt.Text.Trim() + "' and codigo_barra!=''";
                        }
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                if ((row.Cells[1].Value.ToString() == codigo_barra_txt.Text.Trim() && row.Cells[1].Value.ToString()!="") || codigo_unidad_txt.Text==row.Cells[0].Value.ToString())
                                {
                                    cont++;
                                }
                            }
                            if (cont == 0)
                            {
                                dataGridView2.Rows.Add(codigo_unidad_txt.Text.ToString().Trim(), codigo_barra_txt.Text.Trim(), nombre_unidad_txt.Text.Trim());
                                codigo_barra_txt.Clear();
                                nombre_unidad_txt.Clear();
                                codigo_unidad_txt.Clear();
                                codigo_barra_txt.Focus();
                            }
                            else
                            {
                                MessageBox.Show("La unidad que ha seleccionado o el  codigo de barra ya se encuentran puestos.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ese codigo de barra ya se encuentra en uso por otro producto");
                            codigo_barra_txt.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el codigo de la unidad");
                    }
            }
            catch (Exception)
            {
                MessageBox.Show("Error agregando el numero");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea eliminar la fila seleccionada?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
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
            }
            catch (Exception)
            {
                MessageBox.Show("Error eliminando la fila seleccionada");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            /*
                cuando se esta creando el roducto se agregan todas las unidades que quiera
                pero cuando se esta actualizando como ya tenemos el codigo del producto
                hay que verificar si la unidad que selecciono ya esta en uso para ese producto
            */

        }

        private void button12_Click(object sender, EventArgs e)
        {
            busqueda_itebis bi = new busqueda_itebis();
            bi.pasado += new busqueda_itebis.pasar(ejecutar_codigo_itebis);
            bi.ShowDialog();
            cargar_nombre_itebis();
        }
        public void ejecutar_codigo_itebis(string dato)
        {
            codigo_itebis_txt.Text = dato.ToString();
        }
        public void cargar_nombre_itebis()
        {
            try
            {
                string sql = "select descripcion,it from itebis where codigo='"+codigo_itebis_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_itebis_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                itebis_numero_txt.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando nombre de itebis");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                busqueda_almacen ba = new busqueda_almacen();
                ba.codigo_sucursal = s.codigo_sucursal.ToString();
                ba.pasado += new busqueda_almacen.pasar(ejecutar_codigo_almacen);
                ba.ShowDialog();
                cargar_nombre_almacen();
            }
            catch(Exception)
            {
                MessageBox.Show("Error almacen");
            }
        }
        public void ejecutar_codigo_almacen(string dato)
        {
            codigo_almacen_txt.Text = dato.ToString();
        }
        public void cargar_nombre_almacen()
        {
            try
            {
                if (codigo_almacen_txt.Text.Trim() != "")
                {
                    string sql = "select nombre from almacen where codigo='" + codigo_almacen_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_almacen_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el nombre de la sucursal");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int cont = 0;//contador para saber si un permiso se encuentra mas de una vez
            try
            {
                if (codigo_permiso_txt.Text.Trim() != "")
                {
                    if (nombre_permiso_txt.Text.Trim() != "")
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == codigo_permiso_txt.Text.Trim())
                            {
                                cont++;
                            }
                        }
                        if (cont == 0)
                        {
                            dataGridView1.Rows.Add(codigo_permiso_txt.Text.Trim(), nombre_permiso_txt.Text.ToString().Trim());
                            codigo_permiso_txt.Clear();
                            nombre_permiso_txt.Clear();
                            button4.Focus();
                        }
                        else
                        {
                            MessageBox.Show("El permiso que ha seleccionado ya se encuentra puesto.");
                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error agregando los permisos");
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            busqueda_permiso_producto bp = new busqueda_permiso_producto();
            bp.pasado += new busqueda_permiso_producto.pasar(ejecutar_codigo_permiso);
            bp.ShowDialog();
            cargar_nombre_permiso();
        }
        public void ejecutar_codigo_permiso(string dato)
        {
            codigo_permiso_txt.Text = dato.ToString();
        }
        public void cargar_nombre_permiso()
        {
            try
            {
                if (codigo_permiso_txt.Text.Trim() != "")
                {
                    string sql = "select nombre from producto_permisos where codigo='" + codigo_permiso_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_permiso_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando nombre del permiso");
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea quitar el permmiso?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    }
                    else
                    {
                        dr = MessageBox.Show("No hay elementos para eliminar", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error eliminando la fila seleccionada");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            busqueda_producto_detalle bud = new busqueda_producto_detalle();
            bud.pasado += new busqueda_producto_detalle.pasar(ejecutar_codigo_detalle);
            bud.ShowDialog();
            cargar_nombre_detalle_producto();
        }
        public void ejecutar_codigo_detalle(string dato)
        {
            codigo_detalle_producto_txt.Text = dato.ToString();
        }
        public void cargar_nombre_detalle_producto()
        {
            try
            {
                string sql = "select descripcion from producto_detalle where codigo='"+codigo_detalle_producto_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_detalle_producto_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre del detalle");
            }
        }
        
        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                int cont = 0;
                if(codigo_detalle_producto_txt.Text.Trim()!="")
                {
                    if(nombre_detalle_producto_txt.Text.Trim()!="")
                    {
                        if(detalle_producto_descripcion_txt.Text.Trim()!="")
                        {
                            foreach (DataGridViewRow row in dataGridView3.Rows)
                            {
                                if (row.Cells[0].Value.ToString() == codigo_detalle_producto_txt.Text.Trim())
                                {
                                    cont++;
                                }
                            }
                            if (cont == 0)
                            {
                                dataGridView3.Rows.Add(codigo_detalle_producto_txt.Text.Trim(),nombre_detalle_producto_txt.Text.Trim(),detalle_producto_descripcion_txt.Text.Trim());
                            }
                            else
                            {
                                MessageBox.Show("El detalle producto que ha seleccionado ya se encuentra puesto.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta el detalle del producto");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el nombre del detalle producto");
                    }
                }
                else
                {
                    MessageBox.Show("Falta el codigo del detalle producto");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error agregando el detalle de producto");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea quitar el detalle?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (dataGridView3.Rows.Count > 0)
                    {
                        dataGridView3.Rows.RemoveAt(dataGridView3.CurrentRow.Index);
                    }
                    else
                    {
                        dr = MessageBox.Show("No hay elementos para eliminar", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception)
            {

            }
        }

        private void detalle_producto_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            busqueda_unidad bu = new busqueda_unidad();
            bu.pasado += new busqueda_unidad.pasar(ejecutar_codigo_unidad_minima);
            bu.ShowDialog();
            cargar_nombre_unidad_minima();
        }
        public void cargar_nombre_unidad_minima()
        {
            try
            {
                if(codigo_unidad_minima_txt.Text.Trim()!="")
                {
                    string sql = "select nombre from unidad where codigo='"+codigo_unidad_minima_txt.Text.Trim()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_unidad_minima_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre de la unidad minima");
            }
        }
        public void ejecutar_codigo_unidad_minima(string dato)
        {
            codigo_unidad_minima_txt.Text = dato.ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            
        }
        

        private void button21_Click(object sender, EventArgs e)
        {
            busqueda_unidad bu = new busqueda_unidad();
            bu.pasado += new busqueda_unidad.pasar(ejecutar_codigo_unidad_conversion);
            bu.ShowDialog();
            cargar_nombre_unidad_conversion();
           
        }
        public void ejecutar_codigo_unidad_conversion(string dato)
        {
            codigo_unidad_conversion_txt.Text = dato.ToString();
        }
        public void cargar_nombre_unidad_conversion()
        {
            try
            {
                if (codigo_unidad_conversion_txt.Text.Trim()!="")
                {
                    string sql = "select nombre from unidad where codigo='" + codigo_unidad_conversion_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_unidad_conversion_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el nombre de la unidad maxima");
            }
        }
        public void validar_codigo_unidad_rango()
        {
            try
            {
                double cantidad = 0;
                if (codigo_unidad_minima_txt.Text.Trim() != "")
                {
                    if (codigo_unidad_conversion_txt.Text.Trim() != "")
                    {
                        if (cantidad_txt.Text.Trim() != "")
                        {
                            if (Convert.ToDouble(cantidad_txt.Text.Trim()) > 0)
                            {
                                if (precio_venta_txt.Text.Trim() != "")
                                {
                                    int cont = 0;
                                    foreach (DataGridViewRow row in dataGridView4.Rows)
                                    {
                                        if (row.Cells[0].Value.ToString() == codigo_unidad_conversion_txt.Text.Trim())
                                        {
                                            cont++;
                                        }
                                    }
                                    if (cont == 0)
                                    {
                                        dataGridView4.Rows.Add(codigo_unidad_conversion_txt.Text.Trim(), nombre_unidad_conversion_txt.Text.Trim(), cantidad_txt.Text.Trim(), precio_venta_txt.Text.Trim());
                                    }
                                    else
                                    {
                                        MessageBox.Show("La unidad que ha seleccionado ya se encuentra");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Falta el precio de venta");
                                }
                            }
                            else
                            {
                                MessageBox.Show("La cantidad debe ser mayor que cero");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta la cantidad");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta la unidad que quiere agregar");
                    }
                }
                else
                {
                    MessageBox.Show("Falta la unidad minima");
                    codigo_unidad_conversion_txt.Clear();
                    nombre_unidad_conversion_txt.Clear();
                    cantidad_txt.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error validando el rango de las unidades minima y maxima");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            validar_codigo_unidad_rango();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea quitar el permmiso?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (dataGridView4.Rows.Count > 0)
                    {
                        dataGridView4.Rows.RemoveAt(dataGridView4.CurrentRow.Index);
                    }
                    else
                    {
                        dr = MessageBox.Show("No hay elementos para eliminar", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error eliminando la fila seleccionada");
            }
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int fila = dataGridView4.CurrentRow.Index;
                codigo_unidad_conversion_txt.Text = dataGridView4.Rows[fila].Cells[0].Value.ToString();
                nombre_unidad_conversion_txt.Text = dataGridView4.Rows[fila].Cells[1].Value.ToString();
                cantidad_txt.Text = dataGridView4.Rows[fila].Cells[2].Value.ToString();
                precio_venta_txt.Text = dataGridView4.Rows[fila].Cells[3].Value.ToString();
            }
            catch(Exception)
            {

            }
        }

        private void cantidad_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if(Utilidades.numero_decimal(cantidad_txt.Text.Trim())==false)
            {
                cantidad_txt.Clear();
            }
        }

        private void precio_venta_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (Utilidades.numero_decimal(precio_venta_txt.Text.Trim()) == false)
            {
                precio_venta_txt.Clear();
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            busqueda_producto bp = new busqueda_producto();
            bp.pasado += new busqueda_producto.pasar(ejecutar_codigo_producto_requisito);
            bp.codigo_sucursal = s.codigo_sucursal.ToString();
            bp.ShowDialog();
            cargar_nombre_producto_requisito();
            cargar_unidades_requisitos();
           
        }
        public void ejecutar_codigo_producto_requisito(string dato)
        {
            codigoProductoRequisitoTxt.Text = dato.ToString();
        }
        public void cargar_nombre_producto_requisito()
        {
            try
            {
                if (codigoProductoRequisitoTxt.Text.Trim() != "")
                {
                    string sql = "select nombre from producto where codigo='" + codigoProductoRequisitoTxt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    productoNombreRequisitoTxt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando el nombre del producto requisito: "+ex.ToString());
            }
        }
        public void cargar_unidades_requisitos()
        {
            try
            {
                if (codigoProductoRequisitoTxt.Text.Trim() != "")
                {
                    string sql = "select u.nombre,u.codigo from producto_unidad p join unidad u on p.cod_unidad=u.codigo where p.cod_producto='" + codigoProductoRequisitoTxt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    unidad_combo_txt.ValueMember = "nombre";
                    unidad_combo_txt.DisplayMember = "nombre";
                    unidad_combo_txt.DataSource = ds.Tables[0];
                    codigo_unidad_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando las unidades: "+ex.ToString());
            }
        }

        private void unidad_combo_txt_TextChanged(object sender, EventArgs e)
        {
            cambio_unidad();
        }
        public void cambio_unidad()
        {
            try
            {
                int cont = 0;
                try
                {
                    if (codigo_producto_txt.Text.Trim() != "")
                    {
                        string sql = "select codigo from unidad where nombre='" + unidad_combo_txt.Text.Trim() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        codigo_unidad_requisito_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                       
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error cargando codigo de la unidad");
                }
            }
            catch (Exception)
            {

            }
        }

        private void unidad_combo_txt_KeyUp(object sender, KeyEventArgs e)
        {
            unidad_combo_txt.Text = "";
            cargar_unidades_requisitos();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea quitar el producto?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (dataGridView5.Rows.Count > 0)
                    {
                        dataGridView5.Rows.RemoveAt(dataGridView5.CurrentRow.Index);
                    }
                    else
                    {
                        dr = MessageBox.Show("No hay elementos para eliminar", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error eliminando la fila seleccionada");
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            agregarProductoRequisito();
        }
        public Boolean agregarProductoRequisito()
        {
            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                if (cantidadProductoRequisitoTxt.Text.Trim() == "")
                {
                    MessageBox.Show("Falta la cantidad del producto");
                    return false;
                }
                if (row.Cells[0].Value.ToString() == codigoProductoRequisitoTxt.Text.Trim() && row.Cells[2].Value.ToString() == codigo_unidad_requisito_txt.Text.Trim())
                {
                    MessageBox.Show("El producto ya se encuentra insertado");
                    return false;
                }
            }
            dataGridView5.Rows.Add(codigoProductoRequisitoTxt.Text.Trim(),productoNombreRequisitoTxt.Text.Trim(),codigo_unidad_requisito_txt.Text.Trim(),unidad_combo_txt.Text.Trim(),cantidadProductoRequisitoTxt.Text.Trim());
            return true;
        }

        public void actualiza_producto_requisitos()
        {
            if (codigo_producto_txt.Text.Trim() != "")
            {
                /*create proc insert_producto_productos_requisitos
                  @codpro_titular int,@codpro_requisito int,@cod_unidad int,@cantidad float
                 */

                string sql = "delete from producto_productos_requisitos where codpro_titular = '" + codigo_producto_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    sql = "exec insert_producto_productos_requisitos '" + codigo_producto_txt.Text.Trim() + "','" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "'";
                    Utilidades.ejecutarcomando(sql);
                }
            }
        }

        private void cantidadProductoRequisitoTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if(!Utilidades.numero_decimal(cantidadProductoRequisitoTxt.Text.Trim()))
            {
                cantidadProductoRequisitoTxt.Clear();
                MessageBox.Show("Debe de ser un numero","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
