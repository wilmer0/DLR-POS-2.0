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
using System.IO;


namespace puntoVenta
{
    public partial class puntoVenta : Form
    {
        public puntoVenta()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fol = new FolderBrowserDialog();
                if (fol.ShowDialog() == DialogResult.OK)
                {
                    ruta_producto_txt.Text = fol.SelectedPath;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error pasando la imagen al directorio local");
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (ruta_producto_txt.Text.Trim() != "")
                    {
                        if (ruta_backup_sistema_txt.Text.Trim() != "")
                        {
                            if (codigo_moneda_txt.Text.Trim() != "")
                            {
                                string sql = "update sistema set ruta_imagen_productos='" + ruta_producto_txt.Text.Trim() + "', ruta_backup='" + ruta_backup_sistema_txt.Text.Trim() + "',ruta_logo_empresa='" + nombre_imagen.ToString() + "', codigo_moneda='" + codigo_moneda_txt.Text.Trim() + "' where codigo='1'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                datos_sistema_actualizado();
                                MessageBox.Show("Se guardo");
                                cargar_datos_iniciales();
                            }
                            else
                            {
                                MessageBox.Show("Falta la moneda por defecto");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ruta backup esta en blanco");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ruta imagenes de productos esta en blanco");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error guardando la informacion");
            }
        }
            

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
        
        public void cargar_comprobantes()
        {
            try
            {
                //string sql = "select distinct tc.secuencia from tipo_comprobante_fiscal tc join comprobante_fiscal cf on cf.codigo_tipo=tc.codigo where tc.estado='1' and cf.cod_caja='" + codigo_caja_txt.Text.Trim() + "'";
                //DataSet ds = Utilidades.ejecutarcomando(sql);
                //tipo_comprobante_combo_txt.DataSource = ds.Tables[0];
                //tipo_comprobante_combo_txt.DisplayMember = "secuencia";
                //tipo_comprobante_combo_txt.ValueMember = "secuencia";
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando comprobantes");
            }
        }
        singleton s { get; set; }
        private void sistema_Load(object sender, EventArgs e)
        {
            cargar_datos_iniciales();
            
        }
        public void datos_sistema_actualizado()
        {
            try
            {
              
                int ver_imagen_producto = 0;
                int ver_nombre_producto = 0;
                int permisos_por_grupo = 0;
                int usar_comprobantes = 0;

                if(ck_imagen_producto.Checked==true)
                {
                    ver_imagen_producto = 1;
                }
                else
                {
                    ver_imagen_producto = 0;
                }
                if(ck_nombre_producto.Checked==true)
                {
                    ver_nombre_producto = 1;
                }
                else
                {
                    ver_nombre_producto = 0;
                }
                if(ck_permisos_por_grupos_usuarios.Checked==true)
                {
                    permisos_por_grupo = 1;
                }
                else
                {
                    permisos_por_grupo = 0;
                }
                if(ck_usar_comprobantes.Checked==true)
                {
                    usar_comprobantes = 1;
                }
                else
                {
                    usar_comprobantes = 0;
                }
                s = singleton.obtenerDatos();
                DateTime fecha_actual;
                fecha_actual = DateTime.Today;
                //MessageBox.Show(s.codigo_usuario.ToString());
              /*create proc insert_sistema_historial
                @cod_empleado int,@fecha date,@ruta_imagen_productos varchar(max),@ruta_backup varchar(max),
                @ruta_logo_empresa varchar(max),@codigo_moneda int,@permisos_por_grupos_usuarios int,@autorizar_pedidos_apartir float,
                @limite_egreso_caja float,@cod_comprobante_nota_credito int,@usar_comprobantes int,@fecha_vencimiento date,@ip_server varchar(max),
                ,@ver_imagen_fact_Touch int,@ver_nombre_fact_touch int,@porciento_propina float
              */
                string sql = "exec insert_sistema_historial '" + s.codigo_usuario.ToString() + "','" + fecha_actual.ToString("yyyy-MM-dd") + "','" + ruta_producto_txt.Text.Trim() + "','" + ruta_backup_sistema_txt.Text.Trim() + "','" + ruta_logo_empresa_txt.Text.Trim() + "','" + codigo_moneda_txt.Text.Trim() + "','" + permisos_por_grupo.ToString() + "','" + monto_pedido_autorizar_txt.Text.Trim() + "','" + monto_limite_egresos_txt.Text.Trim() + "','" + usar_comprobantes.ToString() + "','" + ver_imagen_producto.ToString() + "','" + ver_nombre_producto.ToString() + "','" + porciento_propina_txt.Text.Trim() + "'";
                //string sql = "exec insert_sistema_historial '5','2016-07-20','klk/','klk/','lol','1','1','0','500','1','1','1','5.45'";
                
                Utilidades.ejecutarcomando(sql);
            }
            catch(Exception)
            {
                MessageBox.Show("Error en el historial del sistema");
            }
        }
        public void cargar_datos_iniciales()
        {
            try
            {
                cargar_comprobantes();
                cargar_nombre_comprobante();
                string sql = "select ruta_imagen_productos,ruta_backup,ruta_logo_empresa,codigo_moneda,permisos_por_grupos_usuarios,autorizar_pedidos_apartir,limite_egreso_caja,cod_comprobante_nota_credito,usar_comprobantes,ver_imagen_fact_touch,ver_nombre_fact_touch,porciento_propina from sistema where codigo='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                ruta_producto_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                ruta_backup_sistema_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                ruta_logo_empresa_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                ruta_logo_empresa_txt.Text += @"\" + ds.Tables[0].Rows[0][2].ToString();
                panel1.BackgroundImage = Image.FromFile(ruta_logo_empresa_txt.Text.Trim());
                codigo_moneda_txt.Text = ds.Tables[0].Rows[0][3].ToString();
                cargar_nombre_moneda();
                if (ds.Tables[0].Rows[0][4].ToString() == "1")
                {
                    ck_permisos_por_grupos_usuarios.Checked = true;
                }
                else
                {
                    ck_permisos_por_grupos_usuarios.Checked = false;
                }
                monto_pedido_autorizar_txt.Text = Convert.ToDouble(ds.Tables[0].Rows[0][5].ToString()).ToString("###,###,###,###,###.#0");
                monto_limite_egresos_txt.Text = Convert.ToDouble(ds.Tables[0].Rows[0][6].ToString()).ToString("###,###,###,###,###.#0");
                codigo_tipo_comprobante_txt.Text = ds.Tables[0].Rows[0][7].ToString();
                if(ds.Tables[0].Rows[0][8].ToString()=="1")
                {
                    ck_usar_comprobantes.Checked = true;
                }
                else 
                {
                    ck_usar_comprobantes.Checked = false;
                }
                if (ds.Tables[0].Rows[0][9].ToString() == "1")
                {
                    ck_imagen_producto.Checked = true;
                }
                else
                {
                    ck_imagen_producto.Checked = false;
                }
                if (ds.Tables[0].Rows[0][10].ToString() == "1")
                {
                    ck_nombre_producto.Checked = true;
                }
                else
                {
                    ck_nombre_producto.Checked = false;
                }
                if(ds.Tables[0].Rows[0][11].ToString()!="")
                {
                    porciento_propina_txt.Text = ds.Tables[0].Rows[0][11].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los datos iniciales");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fol = new FolderBrowserDialog();
                if (fol.ShowDialog() == DialogResult.OK)
                {
                    ruta_backup_sistema_txt.Text = fol.SelectedPath;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error pasando la imagen al directorio local");
            }
        }
        string destino = "";
        string nombre_imagen = "";
        string ruta = "";
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select top(1) ruta_imagen_productos from sistema";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                destino = ds.Tables[0].Rows[0][0].ToString();
                destino += @"\";
                OpenFileDialog file = new OpenFileDialog();
                //file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                file.Filter = "  JPG Files (*.jpg)|*.jpg|  PNG Files (*.png)|*.png|   All files (*.*)|*.*";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    ruta = file.FileName;
                    nombre_imagen = Path.GetFileName(ruta);
                    //MessageBox.Show(nombre_imagen.ToString());
                    destino += nombre_imagen;
                    //MessageBox.Show(destino);//la ruta con todo y extencion se guarda en ruta
                    //mostrar la imagen que se va a subir antes de subirla y moverla
                    //a un directorio donde este el programa
                    ruta_logo_empresa_txt.Text = ruta.ToString();
                    //pictureBox1.Image = System.Drawing.Image.FromFile(ruta);//para meter la imagen en un pocture box pero el picture box no la cojia completa
                    //MessageBox.Show(nombre_imagen);
                    panel1.BackgroundImage = Image.FromFile(ruta.ToString());
                    //System.IO.File.Move(ruta, destino);
                    File.Copy(ruta_logo_empresa_txt.Text, destino);//copia la imagen(desde,aqui) y la pega en el destino
                }
                else
                {
                    //imagen_ruta_txt.Clear();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error pasando la imagen al directorio local");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_moneda bm = new busqueda_moneda();
            bm.pasado += new busqueda_moneda.pasar(ejecutar_codigo_moneda);
            bm.ShowDialog();
            cargar_nombre_moneda();
        }
        public void ejecutar_codigo_moneda(string dato)
        {
            try
            {
                codigo_moneda_txt.Text = dato.ToString();
                
            
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando el nombre de la moneda");
            }
        }
        public void cargar_nombre_moneda()
        {
            try
            {
                string sql = "select nombre from moneda where codigo='" + codigo_moneda_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_moneda_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando nombre de la moneda");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    int permisos_por_grupos = 0;
                    if(ck_permisos_por_grupos_usuarios.Checked==true)
                    {
                        permisos_por_grupos = 1;
                    }
                    else
                    {
                        permisos_por_grupos = 0;
                    }


                    string sql = "update sistema set permisos_por_grupos_usuarios='"+permisos_por_grupos.ToString()+"' where codigo='1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    datos_sistema_actualizado();
                    MessageBox.Show("Finalizado");
                    
                    cargar_datos_iniciales();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error guardando la informacion");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (monto_pedido_autorizar_txt.Text.Trim() != "")
                    {
                        string sql = "update sistema set autorizar_pedidos_apartir='" + monto_pedido_autorizar_txt.Text.Trim() + "' where codigo='1'";
                        Utilidades.ejecutarcomando(sql);
                        datos_sistema_actualizado();
                        MessageBox.Show("Actualizado");
                       
                        cargar_datos_iniciales();
                    }
                    else
                    {
                        MessageBox.Show("No puede dejar vacio el campo de autorizar pedido apartir de xxx,xxx,xxx");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error guardando la informacion");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (monto_limite_egresos_txt.Text.Trim() != "")
                    {
                        string sql = "update sistema set limite_egreso_caja='" + monto_limite_egresos_txt.Text.Trim() + "' where codigo='1'";
                        Utilidades.ejecutarcomando(sql);
                        datos_sistema_actualizado();
                        MessageBox.Show("Actualizado");
                        
                        cargar_datos_iniciales();
                    }
                    else
                    {
                        MessageBox.Show("No puede dejar vacio el campo de monto limite de egreso de xxx,xxx,xxx");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error guardando la informacion");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    datos_sistema_actualizado();
                    cargar_datos_iniciales();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error guardando la informacion");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    int usar = 0;
                    if (ck_usar_comprobantes.Checked == true)
                    {
                        usar = 1;
                    }
                    else
                    {
                        usar = 0;
                    }



                    string sql = "update sistema set usar_comprobantes='" + usar.ToString() + "' where codigo='1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    
                    if(ck_imagen_producto.Checked==true)
                    {
                        sql = "update sistema set ver_imagen_fact_touch='1'";
                        Utilidades.ejecutarcomando(sql);
                    }
                    else
                    {
                        sql = "update sistema set ver_imagen_fact_touch='0'";
                        Utilidades.ejecutarcomando(sql);
                    }


                    if (ck_nombre_producto.Checked == true)
                    {
                        sql = "update sistema set ver_nombre_fact_touch='1'";
                        Utilidades.ejecutarcomando(sql);
                    }
                    else
                    {
                        sql = "update sistema set ver_nombre_fact_touch='0'";
                        Utilidades.ejecutarcomando(sql);
                    }
                    if(porciento_propina_txt.Text.Trim()!="")
                    {
                        sql = "update sistema set porciento_propina='" + porciento_propina_txt.Text.Trim() + "'";
                        Utilidades.ejecutarcomando(sql);
                    }
                    else
                    {
                        MessageBox.Show("El porciento de la propina no puede estar en blanco, si no quiere porciento ponga un '0'");
                    }
                    datos_sistema_actualizado();
                    MessageBox.Show("Finalizado");
                    
                    cargar_datos_iniciales();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error guardando la informacion");
            }
        }

        private void tipo_comprobante_combo_txt_TextChanged(object sender, EventArgs e)
        {
            cargar_nombre_comprobante();
        }
        public void cargar_nombre_comprobante()
        {
            try
            {
                string sql = "select nombre from tipo_comprobante_fiscal where secuencia='" + tipo_comprobante_combo_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_comprobante_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                sql = "select codigo,nombre from tipo_comprobante_fiscal where secuencia='" + tipo_comprobante_combo_txt.Text.Trim() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                codigo_tipo_comprobante_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                // MessageBox.Show("Error cargando nombre del comprobante");
                cargar_comprobantes();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (codigo_tipo_comprobante_txt.Text.Trim() != "")
                    {

                        string sql = "update sistema set cod_comprobante_nota_credito='" + codigo_tipo_comprobante_txt.Text.Trim() + "' where codigo='1'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        datos_sistema_actualizado();
                        MessageBox.Show("Se guardo");
                        cargar_datos_iniciales();
                    }
                    else
                    {
                        MessageBox.Show("Falta el tipo de comprobantes para notas de creditos");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error guardando la informacion");
            }
        }

        private void porciento_propina_txt_TextChanged(object sender, EventArgs e)
        {
            if(porciento_propina_txt.Text.Trim()!="")
            {
                if(Utilidades.numero_decimal(porciento_propina_txt.Text.Trim())==false)
                {
                    porciento_propina_txt.Clear();
                    MessageBox.Show("Debe ser solo numeros en el porciento de la propina");
                    porciento_propina_txt.Focus();
                }
            }
        }
    }
}
