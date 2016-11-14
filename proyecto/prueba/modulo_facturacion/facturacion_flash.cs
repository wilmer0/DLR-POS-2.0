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
    public partial class facturacion_flash : Form
    {
        public facturacion_flash()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Desea eliminar el articulo seleccionado?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                        calcular_total();
                    }
                    else
                    {
                        dr = MessageBox.Show("No hay elementos para eliminar", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error eliminando la fila seleccionada");
                }
            } 
        }
        double sumatoria_total = 0;
        double sumatoria_itebis = 0;
        double sumatoria_descuento = 0;
        public void calcular_total()
        {
            //try
            //{
                sumatoria_total = 0;
                sumatoria_itebis = 0;
                sumatoria_descuento = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[8].Value != "")
                    {
                        sumatoria_total += Convert.ToDouble(row.Cells[8].Value);
                    }
                    if (row.Cells[4].Value != "")
                    {
                        sumatoria_itebis += Convert.ToDouble(row.Cells[4].Value);

                    }
                    if (row.Cells[7].Value != "")
                    {
                        sumatoria_descuento += Convert.ToDouble(row.Cells[7].Value);
                    }
                }
                cantidad_total_itebis_txt.Text = sumatoria_itebis.ToString("###,###,###,###.#0");

                cantidad_total_factura_txt.Text = (sumatoria_total - sumatoria_descuento).ToString("###,###,###,###.#0");
                //monto propina
                double monto_propina = Convert.ToDouble(cantidad_total_factura_txt.Text.Trim()) * (Convert.ToDouble(porciento_propina_txt.Text.Trim()) / 100);
                cantidad_total_factura_txt.Text = (Convert.ToDouble(cantidad_total_factura_txt.Text.Trim()) + monto_propina).ToString("###,###,###,###.#0");
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Error calculando el total e itbis de la factura");
            //}
               
        }
        internal singleton s { get; set; }
        private void facturacion_touch_Load(object sender, EventArgs e)
        {
            try
            {
                s = singleton.obtenerDatos();
                if (s.cambiar_fecha_facturacion == true)
                {
                    fecha.Enabled = true;
                }
                if (s.puede_crear_pedidos == false)
                {
                    pedidoCheck.Checked = false;
                    pedidoCheck.Enabled = false;
                    button13.Enabled = false;
                    button13.BackColor = Color.Black;
                }
                creditoCheck.Checked = true;
               
                cargar_cajero();
                cargar_comprobantes();
                cargar_nombre_comprobante();
                cargar_primer_cliente();
                cargar_nombre_cliente();
                cargar_limite_credito();
                //para sacar la imagen del logo de la empresa
                string sql = "select top(1) ruta_imagen_productos,ruta_logo_empresa from sistema";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                string logo_empresa = ds.Tables[0].Rows[0][0].ToString();
                logo_empresa += @"\" + ds.Tables[0].Rows[0][1].ToString();
                //panel5.BackgroundImage = Image.FromFile(logo_empresa.ToString());
                validar_caja_abierta();
            }
            catch (Exception)
            {
                MessageBox.Show("Error abriendo la facturacion");
            }
            //ck_productos.Checked = true;
            cargar_categorias();
            cargar_primer_cliente();
        }
        public void cargar_nombre_cliente()
        {
            try
            {
                string sql = "select (t.nombre+' '+p.apellido) as nombre,t.identificacion from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + codigo_cliente_txt.Text.Trim() + "' and c.cliente_contado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_cliente_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                identificacion_txt.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            catch (Exception)
            {

            }
        }
        public void cargar_nombre_comprobante()
        {
            try
            {
                string sql = "select usar_comprobantes from sistema";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    sql = "select nombre from tipo_comprobante_fiscal where secuencia='" + tipo_comprobante_combo_txt.Text.Trim() + "'";
                    ds = Utilidades.ejecutarcomando(sql);
                    nombre_comprobante_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                    sql = "select codigo,nombre from tipo_comprobante_fiscal where secuencia='" + tipo_comprobante_combo_txt.Text.Trim() + "'";
                    ds = Utilidades.ejecutarcomando(sql);
                    codigo_tipo_comprobante_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                // MessageBox.Show("Error cargando nombre del comprobante");
                cargar_comprobantes();
            }
        }
        public bool validar_caja_abierta()
        {
            try
            {
                string sql = "select max(codigo) from cuadre_caja where cod_cajero='" + codigo_cajero_txt.Text.Trim() + "' and fecha<='" + fecha.Value.ToString("yyyy-MM-dd") + "' and abierta_cerrada='A' and estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {

                    return true;
                }
                else
                {
                    MessageBox.Show("Su cajero no tiene caja abierta");
                    codigo_cajero_txt.Clear();
                    nombre_cajero_txt.Clear();
                    this.Close();
                    return false;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error validando la caja abierta");
                return false;
            }
        }
        public void cargar_nombre_cajero()
        {
            try
            {
                string sql = "select (nombre+' '+p.apellido) from tercero t join persona p on t.codigo=p.codigo where t.codigo='" + codigo_cajero_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_cajero_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el nombre del cajero");
            }
        }


        public void cargar_nombre_caja()
        {
            try
            {
                string sql = "select nombre from caja where codigo='" + codigo_caja_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_caja_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {

            }
        }


        public void cargar_cajero()
        {
            s = singleton.obtenerDatos();
            try
            {
                string sql = "select cod_empleado,cod_caja from cajero where estado='1' and cod_empleado='" + s.codigo_usuario.ToString() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                codigo_cajero_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                cargar_nombre_cajero();
                codigo_caja_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                cargar_nombre_caja();
            }
            catch (Exception)
            {
                MessageBox.Show("Este usuario no tiene cajero asiganado");
                this.Close();
            }
        }
         
        public void cargar_comprobantes()
        {
            try
            {
                string sql = "select usar_comprobantes from sistema";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    sql = "select distinct tc.secuencia from tipo_comprobante_fiscal tc join comprobante_fiscal cf on cf.codigo_tipo=tc.codigo where tc.estado='1' and cf.cod_caja='" + codigo_caja_txt.Text.Trim() + "'";
                    ds = Utilidades.ejecutarcomando(sql);
                    tipo_comprobante_combo_txt.DataSource = ds.Tables[0];
                    tipo_comprobante_combo_txt.DisplayMember = "secuencia";
                    tipo_comprobante_combo_txt.ValueMember = "secuencia";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando comprobantes");
            }
        }
        public void cargar_primer_cliente()
        {
            try
            {
                string sql = "select top(1) codigo from cliente where estado='1' and cliente_contado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                codigo_cliente_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='"+codigo_cliente_txt.Text.Trim()+"'";
                ds = Utilidades.ejecutarcomando(sql);
                nombre_cliente_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el primer cliente");
            }
        }


        public void cargar_productos()
        {
            maximo_producto = 0;
            string sql = "select count(*) from producto p join categoria_producto cp on p.cod_categoria=cp.codigo where cp.estado='1' and p.estado='1' and cp.codigo='"+codigo_categoria_presionada.ToString()+"'";
            DataSet ds = Utilidades.ejecutarcomando(sql);
            maximo_producto = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());

            flowLayoutPanel1.Controls.Clear();//para limpiar el flow layaout

            sql = "select ruta_imagen_productos from sistema";
            ds = Utilidades.ejecutarcomando(sql);
            string ruta_imagen_productos = "";
            if(ds.Tables[0].Rows[0][0].ToString()!="")
            {
                ruta_imagen_productos = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("No se encontro la ruta de las imagenes");
            }

            int contador = 0;
            int top = 10;
            int left = 0;
            bool ver_imagen = false;//para saber si mostrar imagen en botones
            bool ver_nombre = false;//para saber si mostrar nombre en botones
            sql = "select ver_imagen_fact_touch,ver_nombre_fact_touch from sistema";
            ds = Utilidades.ejecutarcomando(sql);
            if (ds.Tables[0].Rows[0][0].ToString() == "1")
                ver_imagen = true;
            else
                ver_imagen = false;

            if (ds.Tables[0].Rows[0][1].ToString() == "1")
                ver_nombre = true;
            else
                ver_nombre = false;


            


            sql = "select p.codigo,p.nombre,p.imagen from producto p join categoria_producto cp on p.cod_categoria=cp.codigo where cp.estado='1' and p.estado='1' and cp.codigo='"+codigo_categoria_presionada.ToString()+"'";
            ds = Utilidades.ejecutarcomando(sql);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Button boton = new Button();
                boton.Tag = row[0].ToString();
                boton.Top = top;
                boton.Left = left;
                boton.Width = 95;//ancho
                boton.Height += 70;//alto
                boton.BackColor = Color.White;
                if (ver_nombre == true)
                {
                    boton.Text = row[1].ToString() + "-" + row[0].ToString();
                    boton.ForeColor = Color.Tomato;
                    
                }
                if (row[2].ToString() != "")
                {
                    if (ver_imagen == true)
                    {
                        boton.BackgroundImage = Image.FromFile(ruta_imagen_productos + @"\" + row[2].ToString());
                        boton.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
                boton.Click += boton_producto_click;//para cuando haga click en los botones de productos generados
                flowLayoutPanel1.Controls.Add(boton);
                contador++;
                left += 100;
            }
        }
        public string codigo_producto_presionado = "";
        void boton_producto_click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                //MessageBox.Show(btn.Tag.ToString());
                codigo_producto_presionado = btn.Tag.ToString(); //para tener el codigo
                codigo_producto_txt.Text = codigo_producto_presionado.ToString();
                cargar_nombre_producto();
                cargar_existencia_producto();
                cargar_unidades();
                cargar_itebis();
                activar_permisos();
                cantidad_txt.Clear();
                importe_txt.Clear();
                cargar_descuentos();
            }
            catch(Exception)
            {
                MessageBox.Show("Error en el evento click de producto");
            }
        }
        public void cargar_nombre_producto()
        {
            try
            {
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    string sql = "select nombre from producto where codigo='" + codigo_producto_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_producto_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el nombre del producto");
            }
        }
        public void cargar_existencia_producto()
        {
            try
            {
                /*
                 create proc mostrar_existencia_producto
                 @cod_prod int,@cod_unidad int
                 */
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    if (codigo_unidad_txt.Text.Trim() != "")
                    {
                        string sql = "exec mostrar_existencia_producto '" + codigo_producto_txt.Text.Trim() + "','" + codigo_unidad_txt.Text.Trim() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        //if (ds.Tables[0].Rows[0][0].ToString() != "")
                        //{
                        //    existencia_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                        //}
                        //else
                        //{
                        //    existencia_txt.Text = "0";
                        //}

                        //de aqui en adelante es para el control de conversion de inventario
                        double sumatoria_existencia = 0;
                        sql = "select cod_unidad from producto_unidad_conversion where cod_producto='" + codigo_producto_txt.Text.Trim() + "'";
                        ds = Utilidades.ejecutarcomando(sql);
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            string cmd = "select sum(i.existencia*pc.cantidad) from inventario i join producto_unidad_conversion pc on i.codigo_unidad=pc.cod_unidad and pc.cod_producto=i.codigo_producto where i.codigo_producto='" + codigo_producto_txt.Text.Trim() + "' and i.codigo_unidad='" + row[0].ToString() + "'";
                            DataSet dx = Utilidades.ejecutarcomando(cmd);
                            if (dx.Tables[0].Rows[0][0].ToString() != "")
                            {
                                sumatoria_existencia += Convert.ToDouble(dx.Tables[0].Rows[0][0].ToString());
                            }
                        }
                        sql = "select cantidad from producto_unidad_conversion where cod_producto='" + codigo_producto_txt.Text.Trim() + "' and cod_unidad='" + codigo_unidad_txt.Text.Trim() + "'";
                        ds = Utilidades.ejecutarcomando(sql);
                        double cantidad_convercion = 1;
                        if (ds.Tables[0].Rows[0][0].ToString() != "")
                        {
                            cantidad_convercion = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                        }
                        existencia_txt.Text = (sumatoria_existencia / cantidad_convercion).ToString("###,###,###,###,###,###.#0");
                        //hasta aqui el control de conversion de unidades
                    }
                }

            }
            catch (Exception)
            {
                //MessageBox.Show("Error cargando la existencia del producto");
                existencia_txt.Text = "0";
            }
        }
        public void cargar_unidades()
        {
            try
            {
                string sql = "select u.nombre,u.codigo from producto_unidad p join unidad u on p.cod_unidad=u.codigo where p.cod_producto='" + codigo_producto_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                unidad_combo_txt.ValueMember = "nombre";
                unidad_combo_txt.DisplayMember = "nombre";
                unidad_combo_txt.DataSource = ds.Tables[0];
                codigo_unidad_txt.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el codigo de la unidad");
            }
        }
        public void cargar_itebis()
        {
            try
            {
                string sql = "select i.it from producto p join itebis i on p.cod_itebis=i.codigo where p.codigo='" + codigo_producto_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                itebis_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                //MessageBox.Show("Error cargando el itbis del producto");
            }
        }
        public bool controla_inventario = false;
        public void activar_permisos()
        {
            try
            {
                s = singleton.obtenerDatos();
                if (s.puede_Cambiar_precio_facturacion == true)
                {
                    //vender a precio diferente
                    string sql = "select *from producto_vs_permisos where cod_producto='" + codigo_producto_txt.Text.Trim() + "' and cod_permiso='1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        precio_txt.ReadOnly = false;
                    }
                    else
                    {
                        precio_txt.ReadOnly = true;
                    }

                    //no controla inventario
                    sql = "select *from producto_vs_permisos where cod_producto='" + codigo_producto_txt.Text.Trim() + "' and cod_permiso='2'";
                    ds = Utilidades.ejecutarcomando(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        controla_inventario = false;
                    }
                    else
                    {
                        controla_inventario = true;
                    }
                }
                else
                {
                    MessageBox.Show("Su usuario no tiene permiso para cambiar precio en facturacion");
                }

            }
            catch (Exception)
            {

            }
        }
        public void cargar_descuentos()
        {
            try
            {
                s = singleton.obtenerDatos();
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    //if (s.puede_Cambiar_precio_facturacion == true)
                    //{
                    //me retorna el porciento descuento
                    string sql = "select po.descuento from producto_oferta po join oferta_producto_detalle pd on po.codigo=pd.cod_oferta where pd.cod_prod='" + codigo_producto_txt.Text.Trim() + "' and pd.estado='1' and (('" + fecha.Value.ToString("yyyy-MM-dd") + "' between fecha_inicial and fecha_final)) and po.estado='1' and po.cod_sucursal='" + s.codigo_sucursal.ToString() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                        double descuento = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                        monto_descuento_txt.Text = descuento.ToString("###,###,###,###,###.#0");
                    }
                    else
                    {
                        monto_descuento_txt.Text = "0.00";
                        //no tiene descuento por produto solo entonces se busca si tiene descuento por categoria/sub-categoria
                        sql = "select top(1) po.descuento from oferta_producto_subcate_detalle ofe join producto p on p.cod_categoria=ofe.cod_categoria or p.cod_subcategoria=ofe.cod_subcategoria join producto_oferta po on po.codigo=ofe.cod_oferta and po.cod_sucursal='" + s.codigo_sucursal.ToString() + "' where p.codigo='" + codigo_producto_txt.Text.Trim() + "' and (('" + fecha.Value.ToString("yyyy-MM-dd") + "' between fecha_inicial and fecha_final)) and po.estado='1'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows[0][0].ToString() != "")
                        {
                            double descuento = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                            monto_descuento_txt.Text = descuento.ToString("###,###,###,###,###.#0");
                        }
                    }
                    //}
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un producto");
                }
            }
            catch (Exception)
            {
                monto_descuento_txt.Text = "0";
            }
        }
        int maximo_producto = 0;
       
        int maximo_categoria = 0;
       
        int desde_categoria = 1;//para saber desde donde va iniciar el item
        int hasta_categoria = 5;//para saber hasta donde va el item
        public void cargar_categorias()
        {
            try
            {
                string sql = "select count (*) from categoria_producto where estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                maximo_categoria = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                if (desde_categoria == 1)
                {
                    anterior.Enabled = false;
                    //si variable =1 entonces no puede seguir retrocediendo
                }
                else
                {
                    anterior.Enabled = true;
                }
                if (hasta_categoria > maximo_categoria)
                {
                    siguiente.Enabled = false;
                    //si hasta > que el numero de registros en bd no puede seguir avanzando
                }
                else
                {
                    siguiente.Enabled = true;
                }
                sql = "select codigo,nombre from categoria_producto where estado='1' and codigo>='" + desde_categoria.ToString() + "' and codigo<='" + hasta_categoria.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                int contador = 0;
                int top = 100;
                int left = 0;
                for (int c = 1; c < 5; c++)
                {
                    foreach (Button b in panel5.Controls)
                    {
                        for (int f = 0; f <= 5; f++)
                        {
                            if (b.Name.ToString() == "textboxx" + f.ToString())
                            {
                                panel5.Controls.Remove(b);
                            }
                        }
                    }
                }
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    left = 0;
                    Button boton = new Button();
                    boton.Text = row[0].ToString() + "-" + row[1].ToString();
                    boton.Name = "textboxx" + contador.ToString();
                    boton.Tag = row[0].ToString();
                    boton.Top = top;
                    boton.Left = left;
                    boton.Width = 130;
                    boton.Height = 64;
                    boton.Tag = row[0].ToString();
                    //crear el evento click del boton
                    boton.Click += boton_categoria_Click;
                    panel5.Controls.Add(boton);
                    contador++;
                    top += 66;
                    
                }
                // MessageBox.Show("Desde "+desde.ToString()+" hasta "+hasta.ToString());
                

            }
            catch (Exception)
            {
                //System.Windows.MessageBox.Show("Error cargando las categorias");
            }
        }
        Button boton;//el boton objeto
        string codigo_categoria_presionada = "1";

        //el evento click del objeto boton de las categorias

        void boton_categoria_Click(object sender, EventArgs e)
        {
            codigo_categoria_presionada = sender.ToString().Substring(35, 1);//para tener el codigo
            //substring(comienza a los tantos digitos,corta despues de tantas letras)
            //MessageBox.Show(nombre.Substring(35,1));
            //MessageBox.Show(sender.ToString());
            cargar_productos();
           
        }
       
        
        
        public void  cargar_articulos()
        {
            try
            {
                MessageBox.Show("El boton es el-->"+codigo.ToString());
                string sql = "";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                
            }
            catch(Exception)
            {
                
                MessageBox.Show("Error cargando los articulos");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //limpiar ventana
                limpiar();
                cargar_primer_cliente();
                cargar_nombre_cliente();
                cargar_comprobantes();
                cargar_nombre_comprobante();
            }
        }
        public void limpiar()
        {
            try
            {
                codigo_factura_txt.Clear();
                //codigo_cliente_txt.Clear();
                //nombre_cliente_txt.Clear();
                //identificacion_txt.Clear();
                codigo_producto_txt.Clear();
                nombre_producto_txt.Clear();
                monto_descuento_txt.Clear();
                codigo_unidad_txt.Clear();
                unidad_combo_txt.Text = "";
                itebis_txt.Clear();
                precio_txt.Clear();
                existencia_txt.Clear();
                monto_descuento_txt.Clear();
                cantidad_txt.Clear();
                importe_txt.Clear();
                dataGridView1.Rows.Clear();
                fecha.Value = DateTime.Today;
                dateTimePicker2.Value = DateTime.Today;
            }
            catch (Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    if (cantidad_total_factura_txt.Text.Trim() != "")
                    {
                        if (s.facturacion == true)
                        {
                            if (contadoCheck.Checked == true)
                            {
                                /*
                                 ALTER proc [dbo].[insert_factura]
                                 @fecha1 date,@fecha2 date,@cod_empleado int,@cod_caja int,@cod_cliente int,
                                 @rnc varchar(20),@tipo_factura varchar(5),@cod_sucursal int,@cod_tipo_comprobante int  
                                 codigo,numero_factura,NCF 
                                 */
                                //recivir pago de efectivo
                                pago_desglose p = new pago_desglose();
                                p.total_esperado = cantidad_total_factura_txt.Text.Trim();
                                p.efectivo_txt.Text = cantidad_total_factura_txt.Text.Trim();
                                p.pasado += new pago_desglose.pasar(guardar);
                                p.ShowDialog();
                                cargar_existencia_producto();
                                validar_cantidad_comprobantes();
                            }
                            else
                            {
                                //es a credito se van a ir haciendo pagos
                                /*
                                 ALTER proc [dbo].[insert_factura]
                                 @fecha1 date,@fecha2 date,@cod_empleado int,@cod_caja int,@cod_cliente int,
                                 @rnc varchar(20),@tipo_factura varchar(5),@cod_sucursal int,@cod_tipo_comprobante int  
                                 codigo,numero_factura,NCF 
                                 */
                                string efectivo = "0";
                                string devuelta = "0";
                                string cheque = "0";
                                string deposito = "0";
                                string tarjeta = "0";
                                string cod_orden_compra = "0";
                                string monto_orden_compra = "0";
                                string monto_descuento = "0";
                                guardar(efectivo, devuelta.ToString(), cheque.ToString(), deposito.ToString(), tarjeta.ToString(), cod_orden_compra.ToString(), monto_orden_compra.ToString());
                                cargar_existencia_producto();
                                validar_cantidad_comprobantes();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No tiene permiso para facturar");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe elegir algun producto");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error facturando");
            }
        }
        public double efectivo_global = 0;
        public double devuelta_global = 0;
        public double cheque_global = 0;
        public double deposito_global = 0;
        public double tarjeta_global = 0;
        public int cod_orden_compra_global = 0;
        public double monto_orden_compra_global = 0;
        public double descuento_global = 0;
        public void guardar(string efectivo, string devuelta, string cheque, string deposito, string tarjeta, string cod_orden_compra, string monto_orden_compra)
        {
            try
            {
                efectivo_global = Convert.ToDouble(efectivo.ToString());
                devuelta_global = Convert.ToDouble(devuelta.ToString());
                cheque_global = Convert.ToDouble(cheque.ToString());
                deposito_global = Convert.ToDouble(deposito.ToString());
                tarjeta_global = Convert.ToDouble(tarjeta.ToString());
                cod_orden_compra_global = Convert.ToInt16(cod_orden_compra.ToString());
                monto_orden_compra_global = Convert.ToDouble(monto_orden_compra.ToString());
                //MessageBox.Show("efectivo->"+efectivo_global.ToString()+"- devuelta->"+devuelta_global.ToString());

                if (codigo_cliente_txt.Text.Trim() != "")
                {
                    if (codigo_caja_txt.Text.Trim() != "")
                    {
                        if (codigo_cajero_txt.Text.Trim() != "")
                        {
                            if (dataGridView1.Rows.Count > 0)
                            {
                                if (codigo_factura_txt.Text.Trim() == "")
                                {
                                    if (credito_abierto.ToString() == "1")//eso quiere decir que el cliente tiene el credito abierto y se busca las deudas que tenga a ver si sobrepasa el limite de credito
                                    {
                                        string x = "select limite_credito from cliente where codigo='" + codigo_cliente_txt.Text.Trim() + "'";
                                        DataSet df = Utilidades.ejecutarcomando(x);
                                        string limite_credito = df.Tables[0].Rows[0][0].ToString();

                                        //se buscara sus deudas siempre y cuando la factura sea a credito
                                        //si es al contado no se busca si debe ya que pagara en efectivo
                                        string tipo_venta = "";
                                        if (creditoCheck.Checked == true)
                                        {
                                            tipo_venta = "CRE";
                                            if (limite_credito.ToString() != "0")//para saber que el limite no esta por default
                                            {
                                                if (Convert.ToDouble(monto_permitido.ToString()) >= Convert.ToDouble(cantidad_total_factura_txt.Text.Trim()))
                                                {
                                                    string sql = "exec insert_factura '" + fecha.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "','" + codigo_cajero_txt.Text.Trim() + "','" + codigo_caja_txt.Text.Trim() + "','" + codigo_cliente_txt.Text.Trim() + "','" + identificacion_txt.Text.Trim() + "','" + tipo_venta.ToString() + "','" + s.codigo_sucursal.ToString() + "','" + codigo_tipo_comprobante_txt.Text.Trim() + "','" + sumatoria_itebis.ToString() + "'";
                                                    DataSet ds = Utilidades.ejecutarcomando(sql);
                                                    if (ds.Tables[0].Rows.Count > 0)
                                                    {
                                                        codigo_factura_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                                                        numero_comprobante_fiscal_txt.Text = ds.Tables[0].Rows[0][2].ToString();

                                                        //entrar los productos al detalle de la factura
                                                        actualiza_factura_producto();

                                                        MessageBox.Show("Factura generada con exito");
                                                        DialogResult dr = MessageBox.Show("Desea Imprimir?", "Imprimiento", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                                                        if (dr == DialogResult.Yes)
                                                        {
                                                            //imprimir_venta_hoja_completa iv = new imprimir_venta_hoja_completa();
                                                            //iv.codigo_factura = codigo_factura_txt.Text.Trim();
                                                            //iv.ShowDialog();

                                                            imprimir_venta_rollo ih = new imprimir_venta_rollo();
                                                            ih.codigo_factura = codigo_factura_txt.Text.Trim();
                                                            ih.ShowDialog();
                                                        }
                                                        if (dr == DialogResult.No)
                                                        {
                                                            //imprimir_venta_hoja_completa iv = new imprimir_venta_hoja_completa();
                                                            //iv.codigo_factura = codigo_factura_txt.Text.Trim();
                                                            //iv.ShowDialog();

                                                            //imprimir_venta_hoja_completa ih = new imprimir_venta_hoja_completa();
                                                            //ih.codigo_factura = codigo_factura_txt.Text.Trim();
                                                            //ih.ShowDialog();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("No se genero la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("El monto de la factura excede el limite de credito permitido de este cliente");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("El limite de credito del cliente esta en '0' por default, para venderle a credito debe establecer un limite que no sea '0'.");
                                            }
                                        }
                                        else
                                        {
                                            facturar_contado();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El ciente tiene el credito cerrado, por ese motivo no se le puede facturar");
                                    }
                                }
                                else
                                {
                                    //el codigo de la factura esta lleno es decir hay un pedido seleccionado
                                    //donde se puede modificar el pedido
                                    if (codigo_factura_txt.Text.Trim() != "")
                                    {
                                        if (pedidoCheck.Checked == true)
                                        {
                                            string sql = "delete from factura_detalle where cod_factura='" + codigo_factura_txt.Text.Trim() + "'";
                                            DataSet ds = Utilidades.ejecutarcomando(sql);
                                            //para que inserte los productos seleccionado en el grid con el codigo de factura del pedido actual
                                            sql = "update factura set codigo_cliente='" + codigo_cliente_txt.Text.Trim() + "' where codigo='" + codigo_factura_txt.Text.Trim() + "'";
                                            Utilidades.ejecutarcomando(sql);
                                            actualiza_factura_producto();
                                            MessageBox.Show("Pedido actualizado");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("No hay articulos para facturar");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta el cajero");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta la caja");
                    }
                }
                else
                {
                    MessageBox.Show("Falta el cliente");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error guardando la factura");
            }
        }
        public void facturar_contado()
        {

            //no se le calcula el limite de credito
            string tipo_venta = "";
            if (contadoCheck.Checked == true)
            {
                tipo_venta = "CON";
            }
            if (creditoCheck.Checked == true)
            {
                tipo_venta = "CRE";
            }
            if (pedidoCheck.Checked == true)
            {
                tipo_venta = "PED";
            }
            s = singleton.obtenerDatos();
            string sql = "exec insert_factura '" + fecha.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "','" + codigo_cajero_txt.Text.Trim() + "','" + codigo_caja_txt.Text.Trim() + "','" + codigo_cliente_txt.Text.Trim() + "','" + identificacion_txt.Text.Trim() + "','" + tipo_venta.ToString() + "','" + s.codigo_sucursal.ToString() + "','" + codigo_tipo_comprobante_txt.Text.Trim() + "','" + sumatoria_itebis.ToString() + "'";
            DataSet ds = Utilidades.ejecutarcomando(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                codigo_factura_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                numero_comprobante_fiscal_txt.Text = ds.Tables[0].Rows[0][2].ToString();
                //entrar los productos al detalle de la factura
                actualiza_factura_producto();
                if (contadoCheck.Checked == true)
                {
                    sql = "update factura set efectivo='" + efectivo_global.ToString() + "', devuelta ='" + devuelta_global.ToString() + "',cheque='" + cheque_global.ToString() + "',deposito='" + deposito_global.ToString() + "',tarjeta='" + tarjeta_global.ToString() + "',cod_orden_compra='" + cod_orden_compra_global.ToString() + "',monto_orden_compra='" + monto_orden_compra_global.ToString() + "',descuento='" + descuento_global.ToString() + "' where codigo='" + codigo_factura_txt.Text.Trim() + "'";
                    Utilidades.ejecutarcomando(sql);
                }
                if (pedidoCheck.Checked == true)
                {
                    double total = Convert.ToDouble(cantidad_total_factura_txt.Text.Trim());
                    sql = "update factura set efectivo='0', devuelta ='0',cheque='0',deposito='0',tarjeta='0',cod_orden_compra='0',monto_orden_compra='0',cod_vendedor='" + s.codigo_usuario.ToString() + "',descuento='0' where codigo='" + codigo_factura_txt.Text.Trim() + "'";
                    Utilidades.ejecutarcomando(sql);

                    //para saber el monto apartir del cual se debe autorizar un pedido
                    sql = "select autorizar_pedidos_apartir from sistema where codigo='1'";
                    ds = Utilidades.ejecutarcomando(sql);
                    double monto_autorizar = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());

                    if (monto_autorizar > 0)
                    {
                        if (total >= monto_autorizar)
                        {
                            sql = "update factura set autorizar_pedido='1' where codigo='" + codigo_factura_txt.Text.Trim() + "'";
                            Utilidades.ejecutarcomando(sql);
                        }
                    }
                }
                MessageBox.Show("Factura generada con exito");
                DialogResult dr = MessageBox.Show("Desea Imprimir?", "Imprimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //imprimir_venta_hoja_completa iv = new imprimir_venta_hoja_completa();
                    //iv.codigo_factura = codigo_factura_txt.Text.Trim();
                    //iv.ShowDialog();

                    imprimir_venta_rollo ih = new imprimir_venta_rollo();
                    ih.codigo_factura = codigo_factura_txt.Text.Trim();
                    ih.ShowDialog();
                }
                //limpiar la pantalla para la proxima venta

                //codigo_factura_txt.Clear();
                //codigo_cliente_txt.Clear();
                //nombre_cliente_txt.Clear();
                //identificacion_txt.Clear();
                //cantidad_total_factura_txt.Clear();
                //cambio_unidad();
                dataGridView1.Rows.Clear();
                //ck_contado.Checked = false;
                //ck_cotizacion.Checked = false;
                //ck_credito.Checked = true;
            }
        }
        //public void actualiza_factura_producto()v1
        //{
        //    try
        //    {
        //        /*
        //           ALTER proc [dbo].[insert_factura_detalle]
        //           @codigo_factura int,@cod_prod int,@cod_unidad int,@precio float,@cantidad float,@itebis float,@monto float,@descuento float
        //           */
        //        if (dataGridView1.Rows.Count > 0)
        //        {
        //            foreach (DataGridViewRow row in dataGridView1.Rows)
        //            {
        //                string sql = "";
        //                //sql = "exec insert_factura_detalle '" + codigo_factura_txt.Text.Trim() + "','" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[5].Value.ToString() + "','" + row.Cells[6].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "','" + row.Cells[8].Value.ToString() + "','" + row.Cells[7].Value.ToString() + "'";
        //                //MessageBox.Show("exec insert_factura_detalle '" + codigo_factura_txt.Text.Trim() + "','" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[5].Value.ToString() + "','" + row.Cells[6].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "','" + row.Cells[8].Value.ToString() + "','" + row.Cells[7].Value.ToString() + "'");
        //                sql = "exec insert_factura_detalle '" + codigo_factura_txt.Text.Trim() + "','" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[5].Value.ToString() + "','" + row.Cells[6].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "','" + row.Cells[8].Value.ToString() + "','" + row.Cells[7].Value.ToString() + "'";
        //                Utilidades.ejecutarcomando(sql);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Error haciendo el detalle de la factura");
        //    }

        //}
        public void actualiza_factura_producto()
        {
            try
            {
                /*
                   ALTER proc [dbo].[insert_factura_detalle]
                   @codigo_factura int,@cod_prod int,@cod_unidad int,@precio float,@cantidad float,@itebis float,@monto float,@descuento float
                   */
                if (dataGridView1.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string sql = "select codpro_requisito,cod_unidad,cantidad from producto_productos_requisitos where codpro_titular='" + row.Cells[0].Value.ToString() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        //MessageBox.Show(ds.Tables[0].Rows.Count.ToString());
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //es porque de este producto dependen mas productos
                            //hay que sacar de inventario cada requisito con el que fue creado
                            foreach (DataRow requisito in ds.Tables[0].Rows)
                            {
                                /*
                                  alter proc reducir_inventario
                                  @codpro int,@cod_unidad int, @cantidad float
                                */
                                double cantidad = Convert.ToDouble(requisito[2].ToString());
                                cantidad = cantidad * Convert.ToDouble(row.Cells[6].Value.ToString());
                                string cmd = "exec reducir_inventario '" + requisito[0].ToString() + "','" + requisito[1].ToString() + "','" + cantidad.ToString() + "'";
                                Utilidades.ejecutarcomando(cmd);
                            }

                        }
                        sql = "";
                        //de este producto no depende mas producto
                        //sql = "exec insert_factura_detalle '" + codigo_factura_txt.Text.Trim() + "','" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[5].Value.ToString() + "','" + row.Cells[6].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "','" + row.Cells[8].Value.ToString() + "','" + row.Cells[7].Value.ToString() + "'";
                        //MessageBox.Show("exec insert_factura_detalle '" + codigo_factura_txt.Text.Trim() + "','" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[5].Value.ToString() + "','" + row.Cells[6].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "','" + row.Cells[8].Value.ToString() + "','" + row.Cells[7].Value.ToString() + "'");
                        sql = "exec insert_factura_detalle '" + codigo_factura_txt.Text.Trim() + "','" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[5].Value.ToString() + "','" + row.Cells[6].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "','" + row.Cells[8].Value.ToString() + "','" + row.Cells[7].Value.ToString() + "'";
                        Utilidades.ejecutarcomando(sql);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error haciendo el detalle de la factura: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void validar_cantidad_comprobantes()
        {
            try
            {
                /*
                 alter PROC validar_comprobantes
                 @codigo_tipo_comprobante int,@cod_caja int
                */
                string sql = "exec validar_comprobantes '" + codigo_tipo_comprobante_txt.Text.Trim() + "','" + codigo_caja_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Importante, solo tiene " + ds.Tables[0].Rows[0][0].ToString() + " comprobantes disponibles de " + nombre_comprobante_txt.Text.Trim());
                }
            }
            catch (Exception)
            {

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            cantidad_txt.Text += "1";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            cantidad_txt.Text += "2";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cantidad_txt.Text += "3";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cantidad_txt.Text += "4";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cantidad_txt.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cantidad_txt.Text += "6";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cantidad_txt.Text += "7";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cantidad_txt.Text += "8";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cantidad_txt.Text += "9";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            cantidad_txt.Text += "0";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            cantidad_txt.Clear();
        }

        private void ck_productos_Click(object sender, EventArgs e)
        {
            //ck_productos.Checked = true;
            //ck_combos.Checked = false;
        }

        private void ck_combos_Click(object sender, EventArgs e)
        {
            //ck_combos.Checked = true;
            //ck_productos.Checked = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                cargar_limite_credito();
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    if (codigo_unidad_txt.Text.Trim() != "")
                    {
                        if (cantidad_txt.Text.Trim() != "")
                        {
                            if (precio_txt.Text.Trim() != "")
                            {
                                if (importe_txt.Text.Trim() != "")
                                {
                                    if (controla_inventario == true)
                                    {
                                        if (Convert.ToDouble(cantidad_txt.Text.Trim()) <= Convert.ToDouble(existencia_txt.Text.Trim()))
                                        {
                                            agregar_producto();
                                            cargar_existencia_producto();
                                        }
                                        else
                                        {
                                            MessageBox.Show("La cantidad es mayor que la existencia");
                                        }
                                    }
                                    else
                                    {
                                        agregar_producto();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Falta el monto del importe");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Falta el precio de venta");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta la cantidad");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta la unidad");
                    }
                }
                else
                {
                    MessageBox.Show("Falta el producto");
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error agregando el producto");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            busqueda_producto bp = new busqueda_producto();
            bp.pasado += new busqueda_producto.pasar(ejecutar_codigo_producto);
            bp.codigo_sucursal = s.codigo_sucursal.ToString();
            bp.ShowDialog();
            cargar_nombre_producto();
            cargar_existencia_producto();
            cargar_unidades();
            cargar_itebis();
            activar_permisos();
            cantidad_txt.Clear();
            importe_txt.Clear();
            cargar_descuentos();
        }
        public void ejecutar_codigo_producto(string dato)
        {
            codigo_producto_txt.Text = dato.ToString();
        }
        public void ejecutar_codigo_combo(string dato)
        {
            codigo_producto_txt.Text = dato.ToString();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            if (desde_categoria - (5) >= 0)
            {
                //hasta
                hasta_categoria = desde_categoria;
                hasta_categoria--;

                //desde
                desde_categoria = desde_categoria - 4;
                desde_categoria--;
                cargar_categorias();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siguiente_Click(object sender, EventArgs e)
        {

            desde_categoria = hasta_categoria + 1;
            hasta_categoria = desde_categoria + 5;
            hasta_categoria--;
            cargar_categorias();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button32_Click(object sender, EventArgs e)
        {
           
        }

        private void button26_Click(object sender, EventArgs e)
        {
            cantidad_txt.Text += ".";
        }

        private void monto_descuento_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    busqueda_oferta_producto_descuento bo = new busqueda_oferta_producto_descuento();
                    bo.codigo_producto_global = codigo_producto_txt.Text.Trim();
                    bo.fecha_global = fecha.Value.ToString("yyyy-MM-dd");
                    bo.pasado += new busqueda_oferta_producto_descuento.pasar(ejecutar_descuento_por_ofertas);
                    bo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Falta el producto");
                }
            }
        }
        public void ejecutar_descuento_por_ofertas(string dato)
        {
            monto_descuento_txt.Text = dato.ToString();
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
                        codigo_unidad_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                        cargar_existencia_producto();
                        cargar_precio_unidad();
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
        public void cargar_precio_unidad()
        {
            try
            {
                precio_txt.Clear();
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    if (codigo_unidad_txt.Text.Trim() != "")
                    {
                        string sql = "select precio_venta from producto_unidad_conversion where cod_producto='" + codigo_producto_txt.Text.Trim() + "' and cod_unidad='" + codigo_unidad_txt.Text.Trim() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        double precio = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                        precio_txt.Text = precio.ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el precio de la unidad");
            }
        }

        private void cantidad_txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double cantidad = Convert.ToDouble(cantidad_txt.Text.Trim());
                double precio = Convert.ToDouble(precio_txt.Text.Trim());
                double importe = (cantidad * precio);
                importe_txt.Text = importe.ToString();
            }
            catch (Exception)
            {
                importe_txt.Text = "0";
            }
        }
        string monto_permitido = "0";
        string credito_abierto = "0";
        public void cargar_limite_credito()
        {
            try
            {
                string sql = "exec credito_venta_cliente '" + codigo_cliente_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    monto_permitido = (Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString())).ToString();
                    credito_abierto = ds.Tables[0].Rows[0][1].ToString();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error cargando el limite de credito");
            }
        }
        private void button12_Click_2(object sender, EventArgs e)
        {
            try
            {
                cargar_limite_credito();
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    if (codigo_unidad_txt.Text.Trim() != "")
                    {
                        if (cantidad_txt.Text.Trim() != "")
                        {
                            if (precio_txt.Text.Trim() != "")
                            {
                                if (importe_txt.Text.Trim() != "")
                                {
                                    if (controla_inventario == true)
                                    {
                                        if (Convert.ToDouble(cantidad_txt.Text.Trim()) <= Convert.ToDouble(existencia_txt.Text.Trim()))
                                        {
                                            agregar_producto();
                                            cargar_existencia_producto();
                                        }
                                        else
                                        {
                                            MessageBox.Show("La cantidad es mayor que la existencia");
                                        }
                                    }
                                    else
                                    {
                                        agregar_producto();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Falta el monto del importe");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Falta el precio de venta");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta la cantidad");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta la unidad");
                    }
                }
                else
                {
                    MessageBox.Show("Falta el producto");
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error agregando el producto");
            }
        }
             public void agregar_producto()
        {
            int suma = 0;
            int cont = 0;
            int f = -1;
            double subtotal = 0;
            double itebis=0;
            double precio = 0;
            double cantidad = 0;
            double importe = 0;
            double descuento = 0;
            double monto_descuento = 0;
            string cantidadd = "";
            double monto_credito_permitido = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
               f++;
               if (codigo_producto_txt.Text == row.Cells[0].Value.ToString() && codigo_unidad_txt.Text.Trim() == row.Cells[2].Value.ToString())
               {
                   precio = 0;
                   cantidad = 0;
                   importe = 0;
                   subtotal = 0;
                   itebis = 0;
                   monto_descuento = 0;
                   descuento = 0;//es el monto del descuento que tiene el grid
                   cantidadd = "";//esta cantidad es la que tiene el grid cuando el producto se repite
                   cont++;
                 //MessageBox.Show("repite fila-->" + f.ToString());

                 //sacando los datos del articulo que se repitio y se encuentra en el grid
                 cantidadd = dataGridView1.Rows[f].Cells[6].Value.ToString();
                 //recalculando
                 descuento = Convert.ToDouble(monto_descuento_txt.Text.Trim());//descuento que tiene el txt
                 descuento = descuento / 100;
                 precio = Convert.ToDouble(precio_txt.Text.Trim());
                 cantidad = Convert.ToDouble(cantidad_txt.Text.Trim()) + (Convert.ToDouble(cantidadd));//cantidad que tenia + la que pusieron
                 importe = cantidad * precio;//importe de las cantidades * precio
                 monto_descuento=(importe*descuento);
                 itebis = Convert.ToDouble(itebis_txt.Text.Trim());
                 itebis = Math.Round(((itebis * importe) / 100), 2);
                 monto_credito_permitido = Convert.ToDouble(monto_permitido.ToString());//contiende el monto permitido para el limite de credito
               

                
                 dataGridView1.Rows[f].Cells[4].Value = itebis.ToString();
                 dataGridView1.Rows[f].Cells[6].Value = cantidad.ToString();
                 dataGridView1.Rows[f].Cells[7].Value = monto_descuento.ToString();
                 dataGridView1.Rows[f].Cells[8].Value = importe.ToString();
                 calcular_total();                               
               }
             }
             if (cont == 0)
             {
                //no hay productos repetidos en el datagrid
                //se agrega lo que esta en los textbox normales
                descuento = Convert.ToDouble(monto_descuento_txt.Text.Trim());
                descuento = descuento / 100;//si tiene 30% entonces saldra un 0.30 como descuento
                cantidad = Convert.ToDouble(cantidad_txt.Text.Trim());
                importe = Convert.ToDouble(importe_txt.Text.Trim());
                precio = Convert.ToDouble(precio_txt.Text.Trim());
                subtotal = (Convert.ToDouble(itebis_txt.Text.Trim()) * Convert.ToDouble(importe_txt.Text.Trim()))/100;
                itebis = Convert.ToDouble(itebis_txt.Text.Trim());
                monto_descuento=importe * (descuento);
                importe = importe- monto_descuento;
                //MessageBox.Show("descuento->"+(monto_descuento.ToString("###,###,###.#0")));
                itebis = Math.Round(((itebis * importe) / 100), 2);
                monto_credito_permitido = Convert.ToDouble(monto_permitido.ToString());//contiende el monto permitido para el limite de credito
                dataGridView1.Rows.Add(codigo_producto_txt.Text.Trim(), nombre_producto_txt.Text.Trim(), codigo_unidad_txt.Text.Trim(), unidad_combo_txt.Text.Trim(), itebis.ToString(), precio_txt.Text.Trim(), cantidad_txt.Text.Trim(), monto_descuento.ToString(), importe_txt.Text.Trim());
                calcular_total();
             }
             //limpiar();
             importe_txt.Clear();
             cantidad_txt.Clear();
        }

             private void unidad_combo_txt_KeyUp(object sender, KeyEventArgs e)
             {
                 unidad_combo_txt.Text = "";
             }

             private void button19_Click(object sender, EventArgs e)
             {

             }

             private void codigo_producto_txt_KeyDown(object sender, KeyEventArgs e)
             {
                 if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                 {
                     try
                     {
                         if (codigo_producto_txt.Text.Trim() != "")
                         {
                             string sql = "select codigo from producto where referencia='" + codigo_producto_txt.Text.Trim() + "'";
                             DataSet ds = Utilidades.ejecutarcomando(sql);
                             if (ds.Tables[0].Rows.Count > 0)
                             {
                                 codigo_producto_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                                 cargar_nombre_producto();
                                 cargar_unidades();
                                 cargar_itebis();
                                 activar_permisos();
                                 cargar_descuentos();
                             }
                             else
                             {
                                 sql = "select p.codigo as producto,u.nombre as unidad from producto p join producto_codigobarra pc on p.codigo=pc.cod_producto join unidad u on u.codigo=pc.cod_unidad where pc.codigo_barra='" + codigo_producto_txt.Text.Trim() + "'";
                                 ds = Utilidades.ejecutarcomando(sql);
                                 codigo_producto_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                                 cargar_nombre_producto();
                                 unidad_combo_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                                 cargar_itebis();
                                 activar_permisos();
                             }
                         }
                     }
                     catch (Exception)
                     {
                         codigo_producto_txt.Clear();
                         precio_txt.Clear();
                         existencia_txt.Clear();
                         activar_permisos();
                     }
                 }
             }

             

             private void ck_cliente_generico_CheckedChanged(object sender, EventArgs e)
             {

             }
             public void cargar_porciento_propina()
             {
                 try
                 {
                     string sql = "select porciento_propina from sistema";
                     DataSet ds = Utilidades.ejecutarcomando(sql);
                     if (ds.Tables[0].Rows[0][0].ToString() != "")
                     {
                         porciento_propina_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                     }
                     else
                     {
                         MessageBox.Show("Por favor ingrese un porciento de propina, ya que actualmente no existe ninguno");
                     }
                 }
                 catch (Exception)
                 {
                     MessageBox.Show("Error cargando el porciento de la propina");
                 }
             }

             private void ck_propina_Click(object sender, EventArgs e)
             {
                 if (ck_propina.Checked == false)
                 {
                     //se le quita la propina
                     porciento_propina_txt.Text = "0";
                     calcular_total();
                 }
                 if (ck_propina.Checked == true)
                 {
                     // se aplica la propina
                     cargar_porciento_propina();
                     calcular_total();
                 }
             }

             private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
             {
                 
             }

             private void tipo_comprobante_combo_txt_TextChanged(object sender, EventArgs e)
             {
                 cargar_nombre_comprobante();
             }
    }
}
