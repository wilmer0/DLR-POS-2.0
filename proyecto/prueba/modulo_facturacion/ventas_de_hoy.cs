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
    public partial class ventas : Form
    {
        public ventas()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    codigo_cajero_txt.Clear();
                    nombre_cajero_txt.Clear();
                    dataGridView1.Rows.Clear();
                    cantidad_total_factura_txt.Clear();

                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            busqueda_empleado be = new busqueda_empleado();
            be.pasado += new busqueda_empleado.pasar(ejecutar_Codigo_cajero);
            be.ShowDialog();
            cargar_nombre_cajero();
        }
        double suma = 0;
        double monto_egresos = 0;
        double monto_ingresos = 0;
        public void sumar_facturas()
        {
            suma = 0;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    suma += Convert.ToDouble(row.Cells[7].Value.ToString());
                }
                //cantidad_total_factura_txt.Text= (suma-monto_egresos).ToString("###,###,###,###,###,###.#0");
                cantidad_total_factura_txt.Text= (suma).ToString("###,###,###,###,###,###.#0");
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error sumando el total de facturas");
            }
        }
        public void cargar_facturas()
        {
            try
            {
                s = singleton.obtenerDatos();
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                string sql = "";
                //sql = "select f.codigo,f.num_factura,(t.nombre+' '+p.apellido),f.ncf,f.codigo_tipo_factura,f.rnc,f.fecha from factura f join cliente c on c.codigo=f.codigo_cliente join tercero t on t.codigo=c.codigo join persona p on p.codigo=t.codigo where f.codigo_tipo_factura='CON' and f.fecha='"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+"' and f.codigo_empleado='" + codigo_cajero_txt.ToString() + "'";
                /*
                    ALTER proc ventas_del_dia
                    @cod_cajero int,@fechai date,@fechaf date

                 */

                sql = "update factura_detalle set monto=ROUND(monto,2)";
                Utilidades.ejecutarcomando(sql);

                //sql = "exec ventas_del_dia '" + codigo_cajero_txt.Text.Trim() + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
                sql = "select f.codigo,f.num_factura,(t.nombre+' '+p.apellido),f.ncf,f.codigo_tipo_factura,f.rnc,f.fecha,f.estado from factura f join cliente c on c.codigo=f.codigo_cliente join tercero t on t.codigo=c.codigo join persona p on p.codigo=t.codigo  where (f.fecha>='"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+"' and f.fecha<='"+dateTimePicker2.Value.ToString("yyyy-MM-dd")+"')  and f.estado='1' and f.cuadrado='0'";
                if(codigo_cajero_txt.Text.Trim()!="")
                {
                    sql += " and f.codigo_empleado='"+codigo_cajero_txt.Text.Trim()+"'";
                }
                sql += "  and f.cod_sucursal='"+s.codigo_sucursal.ToString()+"' and f.cuadrado='0' order by f.codigo desc";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    double importe = 0;
                    if (row[4].ToString() == "CRE")
                    {
                        //sumando el importe si fue a credito
                        string cmd = "select sum(vp.monto-vp.devuelta) from venta_vs_pagos vp where vp.estado='1' and vp.cuadrado='0' and vp.cod_factura='" + row[0].ToString() + "' and vp.fecha>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and vp.fecha<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
                        DataSet dx = Utilidades.ejecutarcomando(cmd);
                        if (dx.Tables[0].Rows[0][0].ToString() != "")
                        {
                            importe = Convert.ToDouble(dx.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            importe = 0;
                        }
                    }
                    if (row[4].ToString() == "CON")
                    {
                        //sumando el importe si es al contado
                        string cmd = "select  sum(f.efectivo-f.devuelta) from factura f where f.estado='1' and f.cuadrado='0' and f.fecha>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and f.fecha<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and f.codigo='" + row[0].ToString() + "'";
                        DataSet dx = Utilidades.ejecutarcomando(cmd);
                        if (dx.Tables[0].Rows[0][0].ToString() != "")
                        {
                            importe = Convert.ToDouble(dx.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            importe = 0;
                        }
                    }

                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), importe.ToString("###,###,###,###.#0"), row[7].ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error cargando las facturas: "+ex.ToString());
            }
           
        }
        public void ejecutar_Codigo_cajero(string dato)
        {
            codigo_cajero_txt.Text = dato.ToString();
        }
        public void cargar_nombre_cajero()
        {
            try
            {
                string sql = "select (t.nombre+' '+p.apellido) as nombre from tercero t join persona p on p.codigo=t.codigo where t.codigo='"+codigo_cajero_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_cajero_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error cargando nombre del cajero: "+ex.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea imprimir?", "Imprimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string codigoFactura = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                    Utilidades.imprimirVentaRollo(codigoFactura);
                   
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Debe seleccionar la factura primero");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cantidad_total_factura_txt.Clear();
            dataGridView1.Rows.Clear();
            cargar_facturas();
            sumar_egresos();
            sumar_ingresos();
            sumar_facturas();
            
        }
        public void sumar_ingresos()
        {
            try
            {
                monto_ingresos = 0;
                string sql = "select sum(monto) from ingresos_caja where  afecta_cuadre='1' and estado='1' and cuadrado='0' and fecha>='"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+"' and fecha<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
                if (codigo_cajero_txt.Text.Trim() != "")
                {
                    sql += " and cod_cajero='" + codigo_cajero_txt.Text.Trim() + "'";
                }
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    monto_ingresos = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                }
                monto_total_ingresos_txt.Text = monto_ingresos.ToString("###,###,###,###,####.#0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sumando los ingresos de caja: "+ex.ToString());
            }
        }
        public void sumar_egresos()
        {
            try
            {
                monto_egresos = 0;
                string sql = "select sum(monto) from egresos_caja where  afecta_cuadre='1' and estado='1' and cuadrado='0' and fecha>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd")+ "' and fecha<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
                if(codigo_cajero_txt.Text.Trim()!="")
                {
                    sql+=" and cod_cajero='"+codigo_cajero_txt.Text.Trim()+"'";
                }
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if(ds.Tables[0].Rows[0][0].ToString()!="")
                {
                    monto_egresos=Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                }
                monto_total_egresos_txt.Text = monto_egresos.ToString("###,###,###,###,####.#0");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error sumando los egresos de caja: "+ex.ToString());
            }
        }
        internal singleton s { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                s = singleton.obtenerDatos();
                DialogResult dr = MessageBox.Show("Desea anular la factura?", "Anulando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (s.puede_anular_facturas_venta == true)
                    {
                        if (detalle_anulada_txt.Text.Trim() != "")
                        {
                            int fila = 0;
                            fila = dataGridView1.CurrentRow.Index;
                            string sql = "select  count(*) from venta_vs_pagos vp where vp.estado='1' and vp.cod_factura='" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "'";
                            DataSet ds = Utilidades.ejecutarcomando(sql);
                            double registros = 0;
                            if (ds.Tables[0].Rows[0][0].ToString() == "0")
                            {
                             
                                sql = "update factura set estado ='0',cod_empleado_anular='" + s.codigo_usuario.ToString() + "',motivo_anulada='" + detalle_anulada_txt.Text.Trim() + "' where codigo='" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "'";
                                Utilidades.ejecutarcomando(sql);
                                MessageBox.Show("Factura anulada");
                                cargar_facturas();
                            }
                            else
                            {
                                MessageBox.Show("La factura ya tiene movimientos activos, no se puede eliminar");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe especificar el motivo anular");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No tiene permiso para anular facturas de venta");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error anulando la factura");
            }
        }

        private void ventas_Load(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.Rows.Count>0)
                {
                    int fila=dataGridView1.CurrentRow.Index;
                    detalles_factura df = new detalles_factura();
                    df.codigo_factura_global=dataGridView1.Rows[fila].Cells[0].Value.ToString();
                    df.ShowDialog();
                }
                else
                {
                       MessageBox.Show("Debe seleccionar la factura");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error abriendo detalles de factura");
            }
        }
        
    }
}
