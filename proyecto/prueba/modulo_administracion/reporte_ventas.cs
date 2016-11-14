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
    public partial class reporte_ventas : Form
    {
        public reporte_ventas()
        {
            InitializeComponent();
        }

        private void ck_credito_Click(object sender, EventArgs e)
        {
            ck_tipo_venta_todas.Checked = true;
            ck_cotizacion.Checked = false;
            ck_contado.Checked = false;
            ck_credito.Checked = false;
        }

        private void ck_contado_Click(object sender, EventArgs e)
        {

            ck_tipo_venta_todas.Checked = false;
            ck_cotizacion.Checked = false;
            ck_contado.Checked = true;
            ck_credito.Checked = false;
        }

        private void ck_cotizacion_Click(object sender, EventArgs e)
        {

            ck_tipo_venta_todas.Checked = false;
            ck_cotizacion.Checked = true;
            ck_contado.Checked = false;
            ck_credito.Checked = false;
        }

        private void ck_deuda_Click(object sender, EventArgs e)
        {
            ck_deuda.Checked = true;
            ck_saldada.Checked = false;
            ck_estado_venta_todas.Checked = false;
        }

        private void ck_saldada_Click(object sender, EventArgs e)
        {

            ck_deuda.Checked = false;
            ck_saldada.Checked = true;
            ck_estado_venta_todas.Checked = false;
        }

        private void ck_todas_Click(object sender, EventArgs e)
        {

            ck_deuda.Checked = false;
            ck_saldada.Checked = false;
            ck_estado_venta_todas.Checked = true;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
           
        }
        internal singleton s { get; set; }
        private void reporte_ventas_Load(object sender, EventArgs e)
        {
            try
            {
                s = singleton.obtenerDatos();
                if (s.codigo_sucursal.ToString() != "")
                {
                    codigo_sucursal_txt.Text = s.codigo_sucursal.ToString();
                    cargar_nombre_sucursal();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Su usuario no tiene sucursal activa");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            busqueda_sucursal bs = new busqueda_sucursal();
            bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal);
            bs.ShowDialog();
            cargar_nombre_sucursal();   
        }
        public void ejecutar_codigo_sucursal(string dato)
        {
            codigo_sucursal_txt.Text = dato.ToString();
        }
        public void cargar_nombre_sucursal()
        {
            try
            {
                if (codigo_sucursal_txt.Text.Trim() != "")
                {
                    string sql = "select nombre from tercero where codigo='" + codigo_sucursal_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando nombre de la sucursal");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            busqueda_cliente bc = new busqueda_cliente();
            bc.pasado += new busqueda_cliente.pasar(ejecutar_codigo_cliente);
            bc.ShowDialog();
            cargar_nombre_cliente();
        }
        public void ejecutar_codigo_cliente(string dato)
        {
            codigo_cliente_txt.Text = dato.ToString();
        }
        public void cargar_nombre_cliente()
        {
            try
            {
                string sql = "select t.nombre + p.apellido from tercero t join persona p on p.codigo=t.codigo join cliente c on p.codigo = c.codigo where c.codigo='"+codigo_cliente_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_cliente_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando nombre de cliente");
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

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                limpiar();
            }
        }
        public void limpiar()
        {
            try
            {
                dataGridView1.Rows.Clear();
                codigo_cliente_txt.Clear();
                nombre_cliente_txt.Clear();
                fecha_desde.Value = DateTime.Today;
                fecha_desde.Value = DateTime.Today;
                monto_pendiente_desde_txt.Clear();
                monto_pendiente_hasta_txt.Clear();
                monto_saldo_desde_txt.Clear();
                monto_saldo_hasta_txt.Clear();


            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea imprimir?","Imprimiendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //imprimir
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                
                    dataGridView1.Rows.Clear();
                    /*
                     exec pendiente_factura_venta 'codigo_factura'
                     total,pendiente,pagado
                    */
                    string sql = "select t.codigo,(t.nombre+' '+p.apellido)as nombre,fac.codigo_tipo_factura,fac.codigo,fac.fecha,fac.fecha_limite,fac.cod_sucursal from tercero t join persona p on t.codigo=p.codigo join factura fac on t.codigo=fac.codigo_cliente join sucursal suc on fac.cod_sucursal=suc.codigo where fac.codigo>0";
                    if (codigo_cliente_txt.Text.Trim() != "")
                    {
                        sql += " and fac.codigo_cliente='" + codigo_cliente_txt.Text.Trim() + "'";
                    }
                    //para saber el tipo de venta si fue credito,contado,cotizacion o todas
                    if (ck_contado.Checked == true)
                    {
                        sql += " and fac.codigo_tipo_factura='CON'";
                    }
                    if (ck_credito.Checked == true)
                    {
                        sql += " and fac.codigo_tipo_factura='CRE'";
                    }
                    if (ck_cotizacion.Checked == true)
                    {
                        sql += " and fac.codigo_tipo_factura='COT'";
                    }
                    //para saber la fecha desde y fecha hasta
                    if (fecha_desde.Text != "")
                    {
                        sql += " and fac.fecha>='" + fecha_desde.Value.ToString("yyyy-MM-dd") + "'";
                    }
                    if (fecha_hasta.Text != "")
                    {

                        sql += " and fac.fecha<='" + fecha_hasta.Value.ToString("yyyy-MM-dd") + "'";
                    }


                    //para saber si todas las sucursales o solo la del usuario
                    if (codigo_sucursal_txt.Text.Trim() != "")
                    {
                        sql += " and fac.cod_sucursal='" + codigo_sucursal_txt.Text.Trim() + "'";
                    }
                    sql += " order by fac.codigo desc";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    double pendiente = 0;
                    double pagado = 0;
                    string nombre_empresa = "";
                    /*
                     total,pendiente,pagado
                     exec pendiente_factura_venta '12'
                     */
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string cmd = "exec pendiente_factura_venta '" + row[3].ToString() + "'";
                        DataSet dx = Utilidades.ejecutarcomando(cmd);
                        pendiente = 0;
                        pagado = 0;
                        nombre_empresa = "";
                        if (dx.Tables[0].Rows[0][1].ToString() != "")
                        {
                            pendiente = Convert.ToDouble(dx.Tables[0].Rows[0][1].ToString());
                        }
                        if (dx.Tables[0].Rows[0][2].ToString() != "")
                        {
                            pagado = Convert.ToDouble(dx.Tables[0].Rows[0][2].ToString());
                        }
                        cmd = "select nombre from tercero where codigo='" + row[6].ToString() + "'";
                        dx = Utilidades.ejecutarcomando(cmd);
                        if (dx.Tables[0].Rows[0][0].ToString() != "")
                        {
                            nombre_empresa = dx.Tables[0].Rows[0][0].ToString();
                        }
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), pendiente.ToString("###,###,###,###,###,###.#0"), pagado.ToString("###,###,###,###,###,###.#0"), row[6].ToString(), nombre_empresa.ToString());
                    }

                    //para saber el estado de venta en deuda, saldadas, o todas
                    if (ck_saldada.Checked == true)
                    {
                        double f2 = dataGridView1.Rows.Count;
                        for (int f = 0; f < f2; f++)
                        {
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (Convert.ToDouble(row.Cells[6].Value.ToString()) == .00)
                                {
                                    //se queda
                                }
                                else
                                {
                                    //dataGridView1.Rows.RemoveAt(row.Index);
                                    int fila = row.Index;
                                    dataGridView1.Rows.RemoveAt(fila);
                                }
                            }
                        }
                    }
                    if (ck_deuda.Checked == true)
                    {
                        double f2 = dataGridView1.Rows.Count;
                        for (int f = 0; f < f2; f++)
                        {
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (Convert.ToDouble(row.Cells[6].Value.ToString()) > 0.00)
                                {
                                    //se queda
                                }
                                else
                                {
                                    //dataGridView1.Rows.RemoveAt(row.Index);
                                    int fila = row.Index;
                                    dataGridView1.Rows.RemoveAt(fila);
                                }
                            }
                        }
                    }

                    //par saber el monto pendiente desde y monto hasta
                    if (monto_pendiente_desde_txt.Text.Trim() != "" && monto_pendiente_hasta_txt.Text.Trim() != "")
                    {
                        //rrecorre el grid eliminando todo el monto desde que sea menor que este
                        double f2 = dataGridView1.Rows.Count;
                        for (int f = 0; f < f2; f++)
                        {
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if ((Convert.ToDouble(row.Cells[6].Value.ToString()) >= Convert.ToDouble(monto_pendiente_desde_txt.Text.Trim())) && (Convert.ToDouble(row.Cells[6].Value.ToString()) <= Convert.ToDouble(monto_pendiente_hasta_txt.Text.Trim())))
                                {
                                    //se queda
                                    //row.DefaultCellStyle.BackColor = Color.Green;
                                }
                                else
                                {
                                    //se elimina
                                    //dataGridView1.Rows.RemoveAt(row.Index);
                                    //row.DefaultCellStyle.BackColor = Color.Orange;
                                    int fila = row.Index;
                                    dataGridView1.Rows.RemoveAt(fila);

                                }
                            }
                        }
                    }

                    //par saber el monto saldo desde y monto hasta
                    if (monto_saldo_desde_txt.Text.Trim() != "" && monto_saldo_hasta_txt.Text.Trim() != "")
                    {
                        double f2 = dataGridView1.Rows.Count;
                        for (int f = 0; f < f2; f++)
                        {
                            //rrecorre el grid eliminando todo el monto desde que sea menor que este
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if ((Convert.ToDouble(row.Cells[7].Value.ToString()) >= Convert.ToDouble(monto_saldo_desde_txt.Text.Trim())) && (Convert.ToDouble(row.Cells[7].Value.ToString()) <= Convert.ToDouble(monto_saldo_hasta_txt.Text.Trim())))
                                {
                                    //se queda
                                    //row.DefaultCellStyle.BackColor = Color.Green;
                                }
                                else
                                {
                                    //se elimina
                                    int fila = row.Index;
                                    dataGridView1.Rows.RemoveAt(fila);

                                }
                            }
                        }
                    }
                
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando");
            }
        }

        private void ck_credito_Click_1(object sender, EventArgs e)
        {
            ck_tipo_venta_todas.Checked = false;
            ck_contado.Checked = false;
            ck_cotizacion.Checked = false;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            codigo_cliente_txt.Clear();
            nombre_cliente_txt.Clear();
        }
    }
}
