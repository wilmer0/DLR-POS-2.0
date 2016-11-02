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
using System.Drawing.Printing;

namespace puntoVenta
{
    public partial class compra : Form
    {
        public compra()
        {
            InitializeComponent();
        }

        private void compra_Load(object sender, EventArgs e)
        {
            puede_hacer_compra();
        }
        internal singleton s { get; set; }
        public void puede_hacer_compra()
        {
            try
            {
                s = singleton.obtenerDatos();
                if(s.hacer_compra!=true)
                {
                    MessageBox.Show("No tiene permiso para hacer compras");
                    this.Close();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando permisos");
            }
        }

        private void label5_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    codigo_suplidor_txt.Clear();
                    nombre_suplidor_txt.Clear();
                    rnc_txt.Clear();
                    numero_compra_txt.Clear();
                    numero_comprobante_fiscal_txt.Clear();
                    codigo_producto_txt.Clear();
                    nombre_producto_txt.Clear();
                    codigo_unidad_txt.Clear();
                    unidad_combo_txt.Text = "";
                    existecia_txt.Clear();
                    costo_txt.Clear();
                    cantidad_txt.Clear();
                    precio_txt.Clear();
                    monto_txt.Clear();
                    dataGridView1.Rows.Clear();
                    dataGridView2.Rows.Clear();
                    total_importe_txt.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }
        public void cargar_datos_factura()
        {

        }
        public void actualiza_producto()
        {
            /*
             create proc insert_compra_detalle
             @num_compra,@cod_prod int,@cod_unidad int,@costo float,@cantidad float,@estado bit,@venta float,@monto float
             */
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string sql = "exec insert_compra_detalle '"+numero_compra_txt.Text.Trim()+"','"+row.Cells[0].Value.ToString()+"','"+row.Cells[2].Value.ToString()+"','"+row.Cells[4].Value.ToString()+"','"+row.Cells[5].Value.ToString()+"','1','"+row.Cells[6].Value.ToString()+"','"+row.Cells[7].Value.ToString()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error aztualizando los productos");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //guardar
                try
                {
                    string sql = "select *from compra where num_factura='" + numero_compra_txt.Text.Trim() + "' and cod_suplidor='"+codigo_suplidor_txt.Text.Trim()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                            if (codigo_suplidor_txt.Text.Trim() != "")
                            {
                                sql = "";
                                string tipo_compra = "";
                                if (ck_contado.Checked == true)
                                {
                                    tipo_compra = "CON";
                                }
                                if (ck_credito.Checked = true)
                                {
                                    tipo_compra = "CRE";
                                }
                                    /*
                                     alter proc insert_compra
                                     @numero_factura varchar(10),@cod_suplidor int,@ncf varchar(20),@rnc varchar(20),
                                     @cod_tipo varchar(5),@fecha date,@fecha_limite date,@cod_sucursal,@cod_usuario
                                    */
                                    //MessageBox.Show(dateTimePicker1.Value.ToString("yyyy-mm-dd")+"---"+dateTimePicker2.Value.ToString("yyyy-mm-dd"));
                                s = singleton.obtenerDatos();
                                if (s.codigo_sucursal.ToString() != "")
                                {

                                    if (numero_comprobante_fiscal_txt.TextLength == 19 || numero_comprobante_fiscal_txt.Text.Trim()=="")
                                    {
                                        sql = "select *from compra where ncf !='' and ncf='" + numero_comprobante_fiscal_txt.Text.Trim() + "'";
                                        ds = Utilidades.ejecutarcomando(sql);
                                        if (ds.Tables[0].Rows.Count == 0)
                                        {
                                            sql = "exec insert_compra '" + numero_compra_txt.Text.Trim() + "','" + codigo_suplidor_txt.Text.Trim() + "','" + numero_comprobante_fiscal_txt.Text.Trim() + "','" + rnc_txt.Text.Trim() + "','" + tipo_compra.ToString() + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "','" + s.codigo_sucursal.ToString() + "','"+s.codigo_usuario.ToString()+"'";
                                            ds = Utilidades.ejecutarcomando(sql);
                                            if (ds.Tables[0].Rows.Count > 0)
                                            {
                                                ck_orden.Checked = false;
                                                ck_contado.Checked = false;
                                                ck_credito.Checked = true;
                                                actualiza_producto();
                                                MessageBox.Show("Se agrego");
                                            }
                                            else
                                            {
                                                MessageBox.Show("No se agrego");
                                                ck_orden.Checked = false;
                                                ck_contado.Checked = false;
                                                ck_credito.Checked = true;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Ese comprobante ya esta en uso en otra compra, digitelo correctamente");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El numero de comprobante no esta completo");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Su usuario no pertenece a ninguna sucursal, no puedes realizar compras");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Falta el suplidor");
                            }
                    }
                    else
                    {
                        MessageBox.Show("Existe una factura con esa secuencia");
                    }
                }
                catch (Exception ex)
                {
                    ck_orden.Checked = false;
                    ck_contado.Checked = false;
                    ck_credito.Checked = true;
                    MessageBox.Show("Error guardando la compra: "+ex.ToString());
                }
            }
            cargar_compras_suplidor();
        }

        private void ck_credito_Click(object sender, EventArgs e)
        {
            ck_credito.Checked = true;
            ck_contado.Checked = false;
            ck_orden.Checked = false;
            dateTimePicker2.Enabled = true;
        }

        private void ck_contado_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Enabled = false;
            ck_credito.Checked = false;
            ck_contado.Checked = true;
            ck_orden.Checked = false;
            //dias_txt.Clear();
            //dias_txt.Text = "0";
            //dias_txt.ReadOnly = true;
        }

        private void ck_orden_Click(object sender, EventArgs e)
        {

            ck_credito.Checked = false;
            ck_contado.Checked = false;
            ck_orden.Checked = true;
            //dias_txt.ReadOnly = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            busqueda_producto bp = new busqueda_producto();
            bp.codigo_sucursal = s.codigo_sucursal.ToString();
            bp.pasado += new busqueda_producto.pasar(ejecutar_codigo_producto);
            bp.ShowDialog();
            cargar_unidades();
            cargar_existencia_producto();
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
            catch(Exception ex)
            {
                MessageBox.Show("Error cargando las unidades del producto .:"+ex.ToString());
            }
        }
        public void ejecutar_codigo_producto(string dato)
        {
                codigo_producto_txt.Text = dato.ToString();
                string sql = "select nombre from producto where codigo='" + codigo_producto_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_producto_txt.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            busqueda_unidad bu = new busqueda_unidad();
            bu.pasado += new busqueda_unidad.pasar(ejecutar_codigo_unidad);
            //bu.codigo_producto = codigo_producto_txt.Text;//si quiero filtrar las unidades de un producto en especifico
            bu.ShowDialog();
        }
        public void ejecutar_codigo_unidad(string dato)
        {
            try
            {
                codigo_unidad_txt.Text = dato.ToString();
                string sql = "select nombre from unidad where codigo='" + codigo_unidad_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
            }
            catch(Exception)
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            busqueda_suplidor bs = new busqueda_suplidor();
            bs.pasado += new busqueda_suplidor.pasar(ejecutar_codigo_suplidor);
            bs.ShowDialog();
            cargar_compras_suplidor();
        }
        public void cargar_compras_suplidor()
        {
            try
            {
                if (codigo_suplidor_txt.Text.Trim() != "")
                {
                    s = singleton.obtenerDatos();
                    dataGridView2.Rows.Clear();
                    /*
                        create proc compras_suplidor
                        @codigo_suplidor int,@cod_sucursal int
                     */
                    string sql = "exec compras_suplidor '" + codigo_suplidor_txt.Text.Trim() + "','" + s.codigo_sucursal.ToString() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView2.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("No hay compras de este suplidor");
            }
        }
        public void cargar_facturas_suplidor()
        {
            try
            {
                if (codigo_suplidor_txt.Text.Trim() != "")
                {
                    string sql = "select c.codigo,c.num_factura,c.fecha,c.ncf,c.rnc, (select sum(cd.monto) from compra_detalle cd where cd.cod_compra=c.codigo and cd.estado='1' )as monto,c.fecha_limite from compra c where c.cod_suplidor='"+codigo_suplidor_txt.Text.Trim()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando las facturas con el suplidor: "+ex.ToString());
            }
        }
        public void ejecutar_codigo_suplidor(string dato)
        {

            try
            {
                codigo_suplidor_txt.Text = dato.ToString();
                string sql = "select nombre from tercero where codigo='" + codigo_suplidor_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_suplidor_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                cargar_datos_suplidor();
            }
            catch (Exception)
            {
                MessageBox.Show("Error carganado codigo suplidor");
            }
        }
        public void cargar_datos_suplidor()
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();
                sql = "select apellido from persona where codigo='" + codigo_suplidor_txt.Text.Trim() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                nombre_suplidor_txt.Text += " " + ds.Tables[0].Rows[0][0].ToString();

                sql = "select identificacion from tercero where codigo='" + codigo_suplidor_txt.Text.Trim() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                rnc_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los datos del suplidor");
            }
        }
        private void codigo_unidad_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void rnc_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            busqueda_compras bc = new busqueda_compras();
            bc.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea eliminar el articulo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (dr == DialogResult.Yes)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                        total_importe();
                    }
                }
                else
                {
                    //DialogResult dr = MessageBox.Show("No hay elementos para eliminar", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error eliminando la fila seleccionada");
            }
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            unidad_combo_txt.Text = "";
            codigo_unidad_txt.Clear();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            int cont = 0;
            try
            {
                string sql = "select codigo from unidad where nombre='" + unidad_combo_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                codigo_unidad_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                cargar_existencia_producto();
            }
            catch(Exception)
            {
                //MessageBox.Show("Error cargando codigo de la unidad");
            }
        }
        public void cargar_existencia_producto()
        {
            try
            {
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    if (codigo_unidad_txt.Text.Trim() != "")
                    {
                        string sql = "exec mostrar_existencia_producto '" + codigo_producto_txt.Text.Trim() + "','" + codigo_unidad_txt.Text.Trim() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);

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
                        existecia_txt.Text = (sumatoria_existencia / cantidad_convercion).ToString("###,###,###,###,###,###.#0");


                        //ahora a cargar el precio de venta dependiendo de la unidad que se haya seleccionado
                        sql = "select precio_venta from producto_unidad_conversion where cod_producto='" + codigo_producto_txt.Text.Trim() + "' and cod_unidad='" + codigo_unidad_txt.Text.Trim() + "'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows[0][0].ToString() != "")
                        {
                            precio_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                        }
                        else
                        {
                            precio_txt.Clear();
                        }



                    }
                }
            }
            catch (Exception)
            {
                existecia_txt.Text = "0";
            }
        }

        private void costo_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
               //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
              */
            try
            {
                if (Utilidades.numero_decimal(costo_txt.Text.Trim()) == true)
                {

                }
                else
                {
                    costo_txt.Clear();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error reciviendo el costo");
            }
        }

        private void cantidad_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if(Utilidades.numero_decimal(cantidad_txt.Text.Trim())==true)
                {
                    double monto = Convert.ToDouble(costo_txt.Text.Trim()) * Convert.ToDouble(cantidad_txt.Text.Trim());
                    monto_txt.Text = monto.ToString();
                }
                else
                {
                    cantidad_txt.Clear();
                    monto_txt.Text = "0";
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error reciviendo la cantidad");
            }
        }

        private void precio_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Utilidades.numero_decimal(precio_txt.Text.Trim()) == true)
                {
                    
                }
                else
                {
                    precio_txt.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error reciviendo el precio");
            }
        }
        public void limpiar()
        {
            try
            {
                codigo_producto_txt.Clear();
                nombre_producto_txt.Clear();
                codigo_unidad_txt.Clear();
                unidad_combo_txt.Text = "";
                existecia_txt.Clear();
                costo_txt.Clear();
                cantidad_txt.Clear();
                precio_txt.Clear();
                monto_txt.Clear();
            }
            catch(Exception)
            {
                MessageBox.Show("Error lipiando");
            }
        }
        double suma = 0;
        public void total_importe()
        {
            suma = 0;
            try
            {
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    suma +=Convert.ToDouble(row.Cells[7].Value.ToString());
                }
                total_importe_txt.Text =Convert.ToString(suma.ToString());
            }
            catch(Exception)
            {
                MessageBox.Show("Error sumando los importes");
            }
        }
        //public void validar_secuencia()
        //{
        //    try
        //    {
        //        string sql = "select *from compra where secuencia='" + numero_compra_txt.Text.Trim() + "'";
        //        DataSet ds = Utilidades.ejecutarcomando(sql);
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            numero_compra_txt.Clear();
        //        }
        //    }
        //    catch(Exception)
        //    {
        //        MessageBox.Show("Error validando la secuencia");
        //    }
        //}
        private void button5_Click(object sender, EventArgs e)
        {
           
                validar_secuencia();
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    if (codigo_unidad_txt.Text.Trim() != "")
                    {
                        if (costo_txt.Text.Trim() != "")
                        {
                            if (cantidad_txt.Text.Trim() != "")
                            {
                                if (precio_txt.Text.Trim() != "")
                                {
                                    double _costo = 0;
                                    double _cantidad = 0;
                                    _costo = Convert.ToDouble(costo_txt.Text.Trim().ToString());
                                    _cantidad = Convert.ToDouble(cantidad_txt.Text.Trim().ToString());
                                    double _monto = 0;
                                    _monto = Convert.ToDouble((_costo) * (_cantidad));
                                    monto_txt.Text = _monto.ToString();
                                    if (monto_txt.Text.Trim() != "")
                                    {
                                        if (Convert.ToDouble(costo_txt.Text.Trim()) < Convert.ToDouble(precio_txt.Text.Trim()))
                                        {
                                            agregar_producto();
                                            codigo_producto_txt.Focus();
                                            costo_txt.Clear();
                                            cantidad_txt.Clear();
                                            precio_txt.Clear();
                                            monto_txt.Clear();
                                            existecia_txt.Clear();
                                        }
                                        else
                                        {
                                            MessageBox.Show("El precio de compra es mayor que el precio de venta");
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
                            MessageBox.Show("Falta el costo");
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
        public void agregar_producto()
        {
                suma = 0;
                int cont = 0;
                int f = -1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    f++;
                    if (codigo_producto_txt.Text == row.Cells[0].Value.ToString() && codigo_unidad_txt.Text.Trim() == row.Cells[2].Value.ToString())
                    {
                        cont++;
                        //MessageBox.Show("repite fila-->" + f.ToString());

                        //sacando los datos del articulo que se repitio y se encuentra en el grid
                        string cantidadd = dataGridView1.Rows[f].Cells[5].Value.ToString();
                        //recalculando
                        double costo = Convert.ToDouble(costo_txt.Text.Trim());
                        //sumando la cantidad que quiere entrar + la cantidad que ya estaba insertada en el grid
                        double cantidad = Convert.ToDouble(cantidad_txt.Text.Trim()) + (Convert.ToDouble(cantidadd));
                        //sacando el importe del costo por la cantidad total(nuevas + la insertada)
                        double importe = cantidad * costo;
                        //dataGridView1.Rows.RemoveAt(cont);
                        string sql = "select punto_maximo from producto where codigo='" + codigo_producto_txt.Text.Trim() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        double punto_maximo = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                        sql = "select sum(existencia) from inventario where codigo_producto='" + codigo_producto_txt.Text.Trim() + "' and codigo_unidad='" + codigo_unidad_txt.Text.Trim() + "'";
                        ds = Utilidades.ejecutarcomando(sql);
                        double existencia=0;
                        if(ds.Tables[0].Rows[0][0].ToString()!="")
                        {
                            existencia = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                        } 
                        if (punto_maximo > 0)
                        {
                            if ((existencia + cantidad) <= punto_maximo)
                            {

                                dataGridView1.Rows[f].Cells[5].Value = cantidad.ToString();
                                dataGridView1.Rows[f].Cells[7].Value = importe.ToString();
                                dataGridView1.Rows.Add(codigo_producto_txt.Text.Trim(), nombre_producto_txt.Text.Trim(), codigo_unidad_txt.Text.Trim(), unidad_combo_txt.Text.Trim(), costo.ToString("###,###,###.#0"), cantidad.ToString("###,###,###.#0"), importe.ToString("###,###,###,#0"));
                            }
                            else
                            {
                                MessageBox.Show("Esta sobrepasando el punto maximo de este producto-->" + nombre_producto_txt.Text.Trim());
                            }
                        }
                        else
                        {
                            //se agrega normal ya que tiene como punto maximo 0, osea no lo maneja
                            dataGridView1.Rows[f].Cells[5].Value = cantidad.ToString();
                            dataGridView1.Rows[f].Cells[7].Value = importe.ToString();
                            //dataGridView1.Rows.Add(codigo_producto_txt.Text.Trim(), nombre_producto_txt.Text.Trim(), codigo_unidad_txt.Text.Trim(), unidad_combo_txt.Text.Trim(), costo.ToString("###,###,###.#0"), cantidad.ToString("###,###,###.#0"), importe.ToString("###,###,###.#0"));
                        }
                        
                        calcular_total();
                    }
                }
                if (cont ==0)
                {
                    double cantidad = Convert.ToDouble(cantidad_txt.Text.Trim());
                    string sql = "select punto_maximo from producto where codigo='" + codigo_producto_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    double punto_maximo = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                    sql = "select sum(existencia) from inventario where codigo_producto='" + codigo_producto_txt.Text.Trim() + "' and codigo_unidad='" + codigo_unidad_txt.Text.Trim() + "'";
                    ds = Utilidades.ejecutarcomando(sql);
                    double existencia = 0;
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                        existencia = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        existencia = 0;
                    }
                    //si punto maximo >0 ya que 0 es por defecto
                    if (punto_maximo > 0)
                    {
                        if ((existencia + cantidad) <= punto_maximo)
                        {
                            dataGridView1.Rows.Add(codigo_producto_txt.Text.Trim(), nombre_producto_txt.Text.Trim(), codigo_unidad_txt.Text.Trim(), unidad_combo_txt.Text.Trim(), costo_txt.Text.Trim(), cantidad_txt.Text.Trim(), precio_txt.Text.Trim(), monto_txt.Text.Trim());
                            calcular_total();
                        }
                        else
                        {
                            MessageBox.Show("Esta sobrepasando el punto maximo de este producto-->" + nombre_producto_txt.Text.Trim());
                        }
                    }
                    else
                    {
                        //se agregan los produtos normales ya que el punto maximo es cero, osea no se hace nada
                        dataGridView1.Rows.Add(codigo_producto_txt.Text.Trim(), nombre_producto_txt.Text.Trim(), codigo_unidad_txt.Text.Trim(), unidad_combo_txt.Text.Trim(), costo_txt.Text.Trim(), cantidad_txt.Text.Trim(), precio_txt.Text.Trim(), monto_txt.Text.Trim());
                        calcular_total();
                    }
                }
               
                //limpiar();
                monto_txt.Clear();
                cantidad_txt.Clear();
           
        }
        double sumatoria=0;
        public void calcular_total()
        {
            try
            {
                sumatoria = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    sumatoria += Convert.ToDouble(row.Cells[7].Value);
                }
                total_importe_txt.Text = sumatoria.ToString("###,###,###.#0");
            }
            catch (Exception)
            {
                MessageBox.Show("Error calculando el total de la factura");
            }
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(Utilidades.numero_entero(numero_compra_txt.Text.Trim())==true)
            {

            }
            else
            {
                numero_compra_txt.Clear();
            }
        }

        private void numero_compra_txt_Leave(object sender, EventArgs e)
        {
            validar_secuencia();
        }
        public void validar_comprobante()
        {
            try
            {
                if(numero_comprobante_fiscal_txt.Text.Trim()!="")
                {
                    if (numero_comprobante_fiscal_txt.TextLength == 19)
                    {
                        string sql = "select *from compra where ncf='" + numero_comprobante_fiscal_txt.Text.Trim() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Ya existe una compra con ese comprobante");
                            numero_comprobante_fiscal_txt.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El comprobante no esta completo, por favor revisar");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error validando el comprobante");
                numero_comprobante_fiscal_txt.Clear();
            }
        }
        public void validar_secuencia()
        {
            try
            {
                
                string sql="select c.cod_suplidor,t.nombre,c.ncf,c.dias,c.cod_tipo from compra c join tercero t  on t.codigo=c.cod_suplidor where num_factura='"+numero_compra_txt.Text.Trim()+"'";
                DataSet ds=Utilidades.ejecutarcomando(sql);
                codigo_suplidor_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                nombre_suplidor_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                numero_comprobante_fiscal_txt.Text = ds.Tables[0].Rows[0][2].ToString();
                //dias_txt.Text = ds.Tables[0].Rows[0][3].ToString();
                if(ds.Tables[0].Rows[0][4].ToString()=="CRE")
                {
                    ck_credito.Checked = true;
                    ck_contado.Checked = false;
                    ck_orden.Checked = false;
                }
                if (ds.Tables[0].Rows[0][4].ToString() == "CON")
                {
                    ck_credito.Checked =false;
                    ck_contado.Checked = true;
                    ck_orden.Checked = false;
                }
                //ds.Tables[0].Rows[0][3].ToString();
            }
            catch(Exception)
            {
                //MessageBox.Show("Error validando la secuencia");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void precio_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            subir_articulo();
        }
        public void subir_articulo()
        {
            try
            {
                int fila = 0;
                fila = dataGridView1.CurrentRow.Index;
                codigo_producto_txt.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                nombre_producto_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                codigo_unidad_txt.Text = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                unidad_combo_txt.Text = dataGridView1.Rows[fila].Cells[3].Value.ToString();
                costo_txt.Text = dataGridView1.Rows[fila].Cells[4].Value.ToString();
                cantidad_txt.Text = dataGridView1.Rows[fila].Cells[5].Value.ToString();
                precio_txt.Text = dataGridView1.Rows[fila].Cells[6].Value.ToString();
                monto_txt.Text = dataGridView1.Rows[fila].Cells[7].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error subiendo el articulo");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void imprimir()
        {

        }
        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea imprimir?", "Imprimiendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    imprimir_compra ic = new imprimir_compra();
                    ic.codigo_compra = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();
                    ic.ShowDialog();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error imprimiendo la compra");
            }
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea anular la compra?", "Anulando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    s = singleton.obtenerDatos();
                    string sql = "";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    int fila = dataGridView2.CurrentRow.Index;
                    sql = "select count(*) from compra_vs_pagos cp where cp.estado='1' and cod_compra='"+dataGridView2.Rows[fila].Cells[0].Value.ToString()+"'";
                    ds = Utilidades.ejecutarcomando(sql);
                    double registros = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                    if(registros==0)
                    {
                        sql = "update compra set estado ='0' where codigo='"+dataGridView2.Rows[fila].Cells[0].Value.ToString()+"'";
                        Utilidades.ejecutarcomando(sql);
                    }
                    else
                    {
                        MessageBox.Show("La compra tiene pagos activos");
                    }
                    MessageBox.Show("Compra anulada");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error anulando la compra");
            }
        }

        
    }
}
