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
    public partial class cuenta_por_cobrar : Form
    {

        //variables
        public Boolean ExistePagos = false;




        public cuenta_por_cobrar()
        {
            InitializeComponent();
            cargar_facturas();
        }

        private void cuenta_por_cobrar_Load(object sender, EventArgs e)
        {
            try
            {
                s = singleton.obtenerDatos();
                codigo_cajero_txt.Text = s.codigo_usuario;
                cargar_nombre_cajero();
                validar_caja_abierta();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error :"+ex.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            salir();
        }

        public void salir()
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (codigo_cliente_txt.Text.Trim() != "")
                {
                    busqueda_factura_cliente bc = new busqueda_factura_cliente();
                    bc.pasado += new busqueda_factura_cliente.pasar(ejecutarfactura);
                    bc.codigo_cliente = codigo_cliente_txt.Text.Trim();
                    bc.ShowDialog();
                    calcular_total();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un cliente para cargar sus facturas");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error abriendo el form de buscar facturas del cliente");
            }
        }
        public void ejecutarfactura(string dato)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
                busqueda_cliente bc = new busqueda_cliente();
                bc.pasado += new busqueda_cliente.pasar(ejecutarcliente);
                bc.ShowDialog();
                cargar_nombre_cliente();
                cargar_facturas();
                
        }
        public void cargar_facturas()
        {
            try
            {
                dataGridView1.Rows.Clear();
                if (codigo_cliente_txt.Text.Trim() != "")
                {
                    string sql = "select f.codigo,(t.nombre+' '+p.apellido) as nombre_cliente,f.ncf,f.rnc,f.codigo_tipo_factura,f.fecha,f.fecha_limite,f.codigo_empleado from factura f  join cliente c on c.codigo=f.codigo_cliente join tercero t on t.codigo=c.codigo join persona p on p.codigo=c.codigo where f.estado='1' and f.pagada='0' and f.codigo>'0' ";
                    if (codigo_cliente_txt.Text.Trim() != "")
                    {
                        sql += " and f.codigo_cliente='" + codigo_cliente_txt.Text.Trim() + "'";
                    }
                    if (codigo_cajero_txt.Text.Trim() != "")
                    {
                        sql += " and f.codigo_empleado='" + codigo_cajero_txt.Text.Trim() + "'";
                    }
                    if (ck_registro_desde.Checked == true)
                    {
                        sql += " and f.fecha>='" + fecha_desde_txt.Value.ToString("yyyy-MM-dd") + "'";
                    }
                    if (ck_registro_hasta.Checked == true)
                    {
                        sql += " and f.fecha<='" + fecha_hasta_txt.Value.ToString("yyyy-MM-dd") + "'";
                    }
                    sql += " order by f.codigo desc";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string nombre_empleado = "";
                        //sacando el nombre del empleado de la factura
                        sql = "select (t.nombre+' '+p.apellido) as nombre from tercero t join empleado e on e.codigo=t.codigo join persona p on p.codigo=e.codigo where e.codigo='" + row[7].ToString() + "'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows[0][0].ToString() != "")
                        {
                            nombre_empleado = ds.Tables[0].Rows[0][0].ToString();
                        }
                        //pendiente
                        //total,pendiente,pagado
                        sql = "exec pendiente_factura_venta '" + row[0].ToString() + "'";
                        ds = Utilidades.ejecutarcomando(sql);
                        double faltante =double.Parse(ds.Tables[0].Rows[0][1].ToString());
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(),DateTime.Parse(row[5].ToString()).ToString("d"),DateTime.Parse(row[6].ToString()).ToString("d"), nombre_empleado.ToString(), faltante.ToString("N"),"0","0");
                    }
                    
                    calcular_total();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error cargando las facturas: "+ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        public void ejecutarcliente(string dato)
        {
            codigo_cliente_txt.Text = dato.ToString();
        }
        public void cargar_nombre_cliente()
        {
            try
            {
                if (codigo_cliente_txt.Text.Trim() != "")
                {
                    string sql = "select (t.nombre+' '+p.apellido) as nombre from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + codigo_cliente_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_cliente_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando el nombre del cliente: "+ex.ToString());
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    codigo_cliente_txt.Clear();
                    nombre_cliente_txt.Clear();
                    codigo_cajero_txt.Text = s.codigo_usuario;
                    cargar_nombre_cajero();
                    //monto_txt.Clear();
                    detalle_txt.Clear();
                    dataGridView1.Rows.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }

        private void monto_txt_KeyUp(object sender, KeyEventArgs e)
        {
            //if(Utilidades.numero_decimal(monto_txt.Text.Trim())==false)
            //{
            //    monto_txt.Clear();
            //}
           
        }
        private void button5_Click(object sender, EventArgs e)
        {
        }
        internal singleton s { get; set; }
       
        public Boolean validarCampos()
        {

            try
            {
                bool existeAbono = false;


                if (s.cobros_cxc != true)
                {
                    MessageBox.Show("Usted no tiene permiso para hacer cobros", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No hay facturas", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (tipoPagoText.Text.Trim() == "")
                {
                    MessageBox.Show("Debe establecer el metodo de pago", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tipoPagoText.Focus();
                    return false;
                }
               
                 
                 foreach (DataGridViewRow row in dataGridView1.Rows)
                 {
                     if (double.Parse(row.Cells[9].Value.ToString()) > 0)
                     {
                         //MessageBox.Show("El monto de abono debe ser igual o mayor que cero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         //dataGridView1.CurrentCell = dataGridView1.Rows[row.Index].Cells[0];
                         //return false;
                         existeAbono = true;
                     }
                 }
                 if (!existeAbono)
                 {
                     MessageBox.Show("No existe ningun abono", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return false;
                 }
                
                

               
                ExistePagos = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //if (row.Cells[10].Value.ToString() == "" && ExistePagos == true)
                    //{
                    //    MessageBox.Show("Existe un abono, pero no tiene el metodo de pago", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    //dataGridView1.Rows[row.Index].Selected = true;
                    //    return false;
                    //}
                    if (row.Cells[9].Value.ToString() == "")
                    {
                        MessageBox.Show("El abono no tiene valor, debe especificar un monto", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //dataGridView1.Rows[row.Index].Selected = true;   
                        return false;
                    }
                    else
                    {
                        ExistePagos = true;
                    }
                    
                }
                return true;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error validando: "+ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
           
        }





        public Boolean validar()
        {
            s = singleton.obtenerDatos();
            if (Utilidades.validarPermisoEmpleado(s.codigo_usuario.ToString(), "29") == true)
            {
                s.cobros_cxc = true;
            }
            else
            {
                s.cobros_cxc = false;
                MessageBox.Show("No tiene permisos para cobrar","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }


            if(codigo_cliente_txt.Text.Trim()=="")
            {
                MessageBox.Show("Falta el cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(codigo_cajero_txt.Text.Trim()=="")
            {
                MessageBox.Show("Falta el cajero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(dataGridView1.Rows.Count==0)
            {
                MessageBox.Show("Falta las facturas", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        public Boolean procesar()
        {
            try
            {
                bool validar = validarCampos();
                
                if (!validar)
                    return false;

                s=singleton.obtenerDatos();
                 DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (dr == DialogResult.Yes)
                 {
                     /*
                        create proc insert_cobro
                      @fecha date,@detalle varchar(max),@cod_empleado int,@cod_empleado_anular int,@motivo_anular varchar(max),@estado bit,@codigo_cobro int 
                      * */


                     string sql = "exec insert_cobro '"+fecha.Value.ToString("yyyy-MM-dd")+"','"+detalle_txt.Text.Trim()+"','"+s.codigo_usuario+"','','','1','0'";
                     DataSet ds = Utilidades.ejecutarcomando(sql);
                     if (ds.Tables[0].Rows.Count == 0)
                     {
                         MessageBox.Show("Error.: No se completo el cobro", "", MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                         return false;
                     }

                     string codigoCobro = ds.Tables[0].Rows[0][0].ToString();
                     string codigoMetodoPago = Utilidades.GetIdMetodoPagoByNombre(tipoPagoText.Text);
                     foreach (DataGridViewRow row in dataGridView1.Rows)
                     {
                         /*
                            create proc insert_cobro_detalle
                            @cod_cobro int,@cod_metodo_pago int,@monto float,@monto_descuento float,@estado bit,@codigo int
                         exec insert_cobro_detalle '1','14','1','10','0','1','0'

                          */
                         if (double.Parse(row.Cells[9].Value.ToString())>0)
                         {
                             sql = "exec insert_cobro_detalle '"+codigoCobro.ToString() + "','"+row.Cells[0].Value.ToString() +"','"+ codigoMetodoPago.ToString() + "','" + row.Cells[9].Value.ToString() + "','" + row.Cells[10].Value.ToString() + "','1','0'";
                             Utilidades.ejecutarcomando(sql);
                             //MessageBox.Show(sql);
                         }
                     }

                     cargar_facturas();
                     MessageBox.Show("Se agrego el cobro","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                     
                 }

                 return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return false;
            }
        }

        public string montoPendiente()
        {
            try
            {
                double pendiente = 0;
                if(dataGridView1.Rows.Count>0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[8].Value.ToString() != "")
                        {
                            pendiente += double.Parse(row.Cells[8].Value.ToString());
                        }
                    }
                    return pendiente.ToString();
                }
                return null;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error sacando el monto pendiente: "+ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }


       
        private void button8_Click(object sender, EventArgs e)
        {
            procesar();
        }
        //public double efectivo_global = 0;
        //public double devuelta_global = 0;
        //public double cheque_global = 0;
        //public double deposito_global = 0;
        //public double tarjeta_global = 0;
        //public Int16 cod_orden_compra_global = 0;
        //public double monto_orden_compra_global = 0;
        //public void guardar(string efectivo, string devuelta, string cheque, string deposito, string tarjeta, string cod_orden_compra, string monto_orden_compra)
        //{
        //    try
        //    {
        //        /*
        //          create proc cobrar_factura
        //          @codigo_factura int,@efectivo float,@devuelta float,@tarjeta float,@cheque float,@transferencia float,@detalle varchar(300),@fecha,@cod_empleado int
        //        */
        //        efectivo_global = Convert.ToDouble(efectivo.ToString());
        //        devuelta_global = Convert.ToDouble(devuelta.ToString());
        //        cheque_global = Convert.ToDouble(cheque.ToString());
        //        deposito_global = Convert.ToDouble(deposito.ToString());
        //        tarjeta_global = Convert.ToDouble(tarjeta.ToString());
        //        cod_orden_compra_global = Convert.ToInt16(cod_orden_compra.ToString());
        //        monto_orden_compra_global = Convert.ToDouble(monto_orden_compra.ToString());
        //        DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //        if (dr == DialogResult.Yes)
        //        {
        //            if (dataGridView1.Rows.Count > 0)
        //            {
        //                foreach (DataGridViewRow row in dataGridView1.Rows)
        //                {
        //                    string sql = "exec cobrar_factura '" + row.Cells[0].Value.ToString() + "','" + efectivo_global.ToString() + "','" + devuelta_global.ToString() + "','" + tarjeta_global.ToString() + "','" + cheque_global.ToString() + "','" + deposito_global.ToString() + "','" + detalle_txt.Text.Trim() + "','" + fecha.Value.ToString("yyyy-MM-dd") + "','" + s.codigo_usuario.ToString() + "'";
        //                    DataSet ds = Utilidades.ejecutarcomando(sql);
        //                    codigo_cobro = ds.Tables[0].Rows[0][0].ToString();
                       

        //                    cargar_facturas();
        //                    MessageBox.Show("Se aplico el cobro");
        //                    dr = MessageBox.Show("Desea imprimir?", "Imprimiendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //                    if (dr == DialogResult.Yes)
        //                    {
        //                        imprimir_cobros ic = new imprimir_cobros();
        //                        ic.codigo_cobro = codigo_cobro.ToString();
        //                        ic.ShowDialog();
        //                    }
        //                    cargar_facturas();
        //                    //monto_txt.Clear();
        //                    calcular_total();
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("no hay facturas","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Error guardando, por favor intentelo nuevamente, si el problema persiste contacte a soporte tecnico");
        //    }
          
        //}
        private void button2_Click(object sender, EventArgs e)
        {

        }
        double sumatoria = 0;
        public void calcular_total()
        {
            try
            {
                sumatoria = 0;
                if (dataGridView1.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[8].Value != "")
                        {
                            sumatoria += Convert.ToDouble(row.Cells[8].Value);
                        }
                    }
                    MontoTotalPendienteText.Text = sumatoria.ToString("N");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculando el total de la factura: "+ex.ToString());
            }
        }

        private void monto_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                button8.PerformClick();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }

        private void ck_aplicar_todo_Click(object sender, EventArgs e)
        {
            if(ck_aplicar_todo.Checked==true)
            {
                //monto_txt.ReadOnly = false;
            }
            else
            {
                //monto_txt.ReadOnly = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            busqueda_cajero bc = new busqueda_cajero();
            bc.pasado += new busqueda_cajero.pasar(ejecutar_codigo_cajero);
            bc.ShowDialog();
            cargar_nombre_cajero();
            validar_caja_abierta();
        }
        public bool validar_caja_abierta()
        {
            string sql = "select max(codigo) from cuadre_caja where cod_cajero='" + codigo_cajero_txt.Text.Trim() + "' and fecha<='" + fecha.Value.ToString("yyyy-MM-dd") + "' and abierta_cerrada='A' and estado='1'";
            DataSet ds = Utilidades.ejecutarcomando(sql);
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                sql = "select max(codigo)from cuadre_caja where cod_cajero='" + codigo_cajero_txt.Text.Trim() + "' and fecha<='" + fecha.Value.ToString("yyyy-MM-dd") + "' and abierta_cerrada='A' and estado='1'";
                ds = Utilidades.ejecutarcomando(sql);
                return true;
            }
            else
            {
                MessageBox.Show("Su cajero no tiene caja abierta");
                codigo_cajero_txt.Clear();
                nombre_cajero_txt.Clear();
                return false;
            }
        }
        public void ejecutar_codigo_cajero(string dato)
        {
            codigo_cajero_txt.Text = dato.ToString();
        }
        public void cargar_nombre_cajero()
        {
            try
            {
                if (codigo_cajero_txt.Text.Trim() != "")
                {
                    string sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + codigo_cajero_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_cajero_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                codigo_cajero_txt.Clear();
                nombre_cajero_txt.Clear();
                MessageBox.Show("Error buscando el nombre del cajero");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            codigo_cliente_txt.Clear();
            nombre_cliente_txt.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cargar_facturas();
        }

        private void ck_registro_desde_Click(object sender, EventArgs e)
        {
            if (ck_registro_desde.Checked == true)
            {
                fecha_desde_txt.Enabled = true;
            }
            else
            {
                fecha_desde_txt.Enabled = false;
            }
        }

        private void ck_registro_hasta_Click(object sender, EventArgs e)
        {
            if (ck_registro_hasta.Checked == true)
            {
                fecha_hasta_txt.Enabled = true;
            }
            else
            {
                fecha_hasta_txt.Enabled = false;
            }
        }

        public void montoAbonado()
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    double montoAbono = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        montoAbono += double.Parse(row.Cells[9].Value.ToString());
                    }
                    MontoTotalAbonarText.Text = montoAbono.ToString("N");
                }
            }
            catch (Exception)
            {
                
            }
        }
        public void marcar()
        {
            try
            {
                double montoAbono = 0;
                double montoPendiente = 0;
                int fila = dataGridView1.CurrentRow.Index;
                if (MontoAbonoText.Text.Trim() == "")
                {
                    MessageBox.Show("Falta el monto del abono","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    MontoAbonoText.Focus();
                    MontoAbonoText.SelectAll();
                    return;
                }

                if (double.Parse(MontoAbonoText.Text.Trim()) < 0)
                {
                    MessageBox.Show("El monto del abono debe ser igual o mayor que cero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MontoAbonoText.Focus();
                    MontoAbonoText.SelectAll();
                    return;
                }
                montoPendiente =double.Parse(dataGridView1.Rows[fila].Cells[8].Value.ToString());
                montoAbono = double.Parse(MontoAbonoText.Text.Trim());
                
                if(montoAbono>montoPendiente)
                {
                    MessageBox.Show("El monto de abono es mayor que el monto pendiente", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MontoAbonoText.Focus();
                    MontoAbonoText.SelectAll();
                    return;
                }

                
                dataGridView1.Rows[fila].Cells[9].Value = montoAbono.ToString();
                dataGridView1.Rows[fila].Cells[10].Value = montoDescuentoText.Text.Trim();
                
                //para presentar todo lo que se ha abonado
                montoAbonado();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error marcando factura: "+ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void pendiente_txt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //marcar();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Utilidades.numero_decimal(this.Text.Trim());
                double descuentoPorciento = double.Parse(MontoAbonoText.Text.Trim());
                montoDescuentoText.Text = (double.Parse(MontoAbonoText.Text.Trim())-(descuentoPorciento*double.Parse(MontoAbonoText.Text.Trim()))).ToString("N");
                int fila = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows[fila].Cells[10].Value = montoDescuentoText.Text.Trim();
            }
            catch (Exception)
            {
                MessageBox.Show("Error obteniendo el % descuento", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void montoDescuentoText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Utilidades.numero_decimal(this.Text.Trim());
                double montoDescuento = double.Parse(montoDescuentoText.Text.Trim());
                descuentoPorCientoText.Text =
                    (double.Parse(montoDescuentoText.Text.Trim())/double.Parse(MontoAbonoText.Text.Trim())).ToString("N");
                int fila = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows[fila].Cells[10].Value = montoDescuento.ToString("N");
            }
            catch (Exception)
            {
                MessageBox.Show("Error obteniendo el monto descuento", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void cuenta_por_cobrar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                marcar();
            }

            if (e.KeyCode == Keys.Escape)
            {
                salir();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            marcar();
        }
    }
}
