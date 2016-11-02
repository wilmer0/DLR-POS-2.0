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
    public partial class cuenta_por_pagar_suplidores : Form
    {

        //variables
        public Boolean ExistePagos = false;





        public cuenta_por_pagar_suplidores()
        {
            InitializeComponent();
        }
        internal singleton s { get; set; }
        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    codigo_suplidor_txt.Clear();
                    nombre_suplidor_txt.Clear();
                   
                    detalle_txt.Clear();
                    dataGridView1.Rows.Clear();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }
        public void cargar_nombre_suplidor()
        {
            try
            {
                string sql="select t.nombre from tercero t where t.codigo='"+codigo_suplidor_txt.Text.Trim()+"'";
                DataSet ds=Utilidades.ejecutarcomando(sql);
                nombre_suplidor_txt.Text=ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando el nombre del suplidor");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_suplidor bs = new busqueda_suplidor();
            bs.pasado += new busqueda_suplidor.pasar(ejecutar_codigo_suplidor);
            bs.ShowDialog();
            cargar_nombre_suplidor();
            cargar_facturas();
        }
        public void ejecutar_codigo_suplidor(string dato)
        {
            codigo_suplidor_txt.Text = dato.ToString();
        }

        private void codigo_suplidor_txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "select t.nombre from tercero t join persona p on t.codigo=p.codigo join suplidor s on p.codigo=s.codigo where s.codigo='"+codigo_suplidor_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_suplidor_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando nombre suplidor");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            busqueda_factura bf = new busqueda_factura();
            bf.ShowDialog();
        }
        public void ejecutar_codigo_factura(string dato)
        {
            try
            {
                //numero_factura_txt.Text = dato.ToString();    
            }
            catch(Exception)
            {
                MessageBox.Show("Error pasando el codigo");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("No hay elementos para eliminar", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error eliminando la fila seleccionada");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            procesar();
        }
        public Boolean validarCampos()
        {

            try
            {
                bool existeAbono = false;
                if (s.puede_hacer_pagos_suplidores != true)
                {
                    MessageBox.Show("Usted no tiene permiso para hacer pagos", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch (Exception ex)
            {
                MessageBox.Show("Error validando: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

        }
        public Boolean procesar()
        {
            try
            {
                bool validar = validarCampos();

                if (!validar)
                    return false;

                s = singleton.obtenerDatos();
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    /*
                       create proc insert_pago
                     @fecha date,@detalle varchar(max),@cod_empleado int,@cod_empleado_anular int,@motivo_anular varchar(max),@estado bit,@codigo_pago int 
                     * */


                    string sql = "exec insert_pago '" + fecha.Value.ToString("yyyy-MM-dd") + "','" + detalle_txt.Text.Trim() + "','" + s.codigo_usuario + "','','','1','0'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Error.: No se completo el pago", "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return false;
                    }

                    string codigopago = ds.Tables[0].Rows[0][0].ToString();
                    string codigoMetodoPago = Utilidades.GetIdMetodoPagoByNombre(tipoPagoText.Text);
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        /*
                           create proc insert_pago_detalle
                           @cod_pago int,@cod_metodo_pago int,@monto float,@monto_descuento float,@estado bit,@codigo int
                        exec insert_pago_detalle '1','14','1','10','0','1','0'

                         */
                        if (double.Parse(row.Cells[9].Value.ToString()) > 0)
                        {
                            sql = "exec insert_pago_detalle '" + codigopago.ToString() + "','" + row.Cells[0].Value.ToString() + "','" + codigoMetodoPago.ToString() + "','" + row.Cells[9].Value.ToString() + "','" + row.Cells[10].Value.ToString() + "','1','0'";
                            Utilidades.ejecutarcomando(sql);
                            //MessageBox.Show(sql);
                        }
                    }

                    cargar_facturas();
                    MessageBox.Show("Se agrego el pago", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return false;
            }
        }

        public void cargar_facturas()
        {
            try
            {
                dataGridView1.Rows.Clear();
                if (codigo_suplidor_txt.Text.Trim() == "")
                {
                    return;
                }
                    string sql = "select c.codigo,(t.nombre+' '+p.apellido) as nombre_suplidor,c.ncf,c.rnc,c.cod_tipo,c.fecha,c.fecha_limite,c.codigo_empleado from compra c  join suplidor s on c.cod_suplidor=s.codigo join tercero t on t.codigo=s.codigo join persona p on p.codigo=s.codigo where c.estado='1' and c.pagada='0' and c.codigo>'0'";
                    if (codigo_suplidor_txt.Text.Trim() != "")
                    {
                        sql += " and c.cod_suplidor='" + codigo_suplidor_txt.Text.Trim() + "'";
                    }
                    if (codigo_cajero_txt.Text.Trim() != "")
                    {
                        sql += " and c.codigo_empleado='" + codigo_cajero_txt.Text.Trim() + "'";
                    }
                    if (ck_registro_desde.Checked == true)
                    {
                        sql += " and c.fecha>='" + fecha_desde_txt.Value.ToString("yyyy-MM-dd") + "'";
                    }
                    if (ck_registro_hasta.Checked == true)
                    {
                        sql += " and c.fecha<='" + fecha_hasta_txt.Value.ToString("yyyy-MM-dd") + "'";
                    }
                    sql += " order by c.codigo desc";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string nombre_empleado = "";
                        nombre_empleado = Utilidades.getNombreByTercero(row[7].ToString());
                        //monto_facura,pagado,pendiente
                        sql = "exec monto_pendiente_factura '" + row[0].ToString() + "'";
                        ds = Utilidades.ejecutarcomando(sql);
                        double pendiente = 0;
                        if (ds.Tables[0].Rows[0][2].ToString() != "")
                        {
                            pendiente = double.Parse(ds.Tables[0].Rows[0][2].ToString());
                        }
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), DateTime.Parse(row[5].ToString()).ToString("d"), DateTime.Parse(row[6].ToString()).ToString("d"), nombre_empleado.ToString(), pendiente.ToString("N"), "0", "0");
                    }

                calcular_total();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando las facturas: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                MessageBox.Show("Error calculando el total de la factura: " + ex.ToString());
            }
        }

        private void cuenta_por_pagar_suplidores_Load(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            codigo_cajero_txt.Text = s.codigo_usuario.ToString();
            cargar_nombre_cajero();
            validar_caja_abierta();
        }
        

        private void dataGridView1_Click(object sender, EventArgs e)
        {
           
        }

        private void monto_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (Utilidades.numero_decimal(MontoAbonoText.Text.Trim()) == true)
            {

            }
            else
            {
                MontoAbonoText.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            busqueda_cajero bc = new busqueda_cajero();
            bc.pasado += new busqueda_cajero.pasar(ejecutar_codigo_cajero);
            bc.codigo_sucursal_global = s.codigo_sucursal.ToString();
            bc.ShowDialog();
            cargar_nombre_cajero();
            validar_caja_abierta();
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
            catch (Exception ex)
            {
                MessageBox.Show("Error validando la caja abierta.: "+ex.ToString());
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
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando el nombre del cajero.: "+ex.ToString());
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int fila = dataGridView1.CurrentRow.Index;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error subiendo el monto pendiente.: "+ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

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
                    MessageBox.Show("Falta el monto del abono", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                montoPendiente = double.Parse(dataGridView1.Rows[fila].Cells[8].Value.ToString());
                montoAbono = double.Parse(MontoAbonoText.Text.Trim());

                if (montoAbono > montoPendiente)
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
            catch (Exception ex)
            {
                MessageBox.Show("Error marcando factura: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void label8_Click(object sender, EventArgs e)
        {
            marcar();
        }

        private void descuentoPorCientoText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Utilidades.numero_decimal(this.Text.Trim());
                double descuentoPorciento = double.Parse(MontoAbonoText.Text.Trim());
                montoDescuentoText.Text = (double.Parse(MontoAbonoText.Text.Trim()) - (descuentoPorciento * double.Parse(MontoAbonoText.Text.Trim()))).ToString("N");
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
                    (double.Parse(montoDescuentoText.Text.Trim()) / double.Parse(MontoAbonoText.Text.Trim())).ToString("N");
                int fila = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows[fila].Cells[10].Value = montoDescuento.ToString("N");
            }
            catch (Exception)
            {
                MessageBox.Show("Error obteniendo el monto descuento", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
