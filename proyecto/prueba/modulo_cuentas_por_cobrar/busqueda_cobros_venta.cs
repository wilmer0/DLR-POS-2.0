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
    public partial class busqueda_cobros_venta : Form
    {
        public busqueda_cobros_venta()
        {
            InitializeComponent();
        }
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
            DialogResult dr = MessageBox.Show("Desea Limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                limpiar();
            }
        }
        public void limpiar()
        {
            try
            {
                codigo_cajero_txt.Clear();
                nombre_cajero_txt.Clear();
                codigo_cliente_txt.Clear();
                nombre_cliente_txt.Clear();
                dataGridView1.Rows.Clear();
            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }
        internal singleton s { get; set; }
        private void button8_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea anular el cobro?", "Anulando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    s = singleton.obtenerDatos();
                    if (s.anular_cobros == true)
                    {
                        if (detalle_txt.Text.Trim() != "")
                        {
                            int fila = dataGridView1.CurrentRow.Index;
                            string sql = "update cobros_detalles set estado='0',cod_empleado_anular='" + s.codigo_usuario.ToString() + "',motivo_anulado='" + detalle_txt.Text.Trim() + "' where  codigo='" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "'";
                            Utilidades.ejecutarcomando(sql);
                            dataGridView1.Rows.Clear();
                            cargar_cobros();
                            MessageBox.Show("Se anulo el pago");
                            MessageBox.Show("Si el metodo de pago es en efectivo debe realizar un egreso de caja por el monto anulado","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Falta el motivo por el cual anular el documento");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usted no tiene permisos para anular cobros");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error anulando el pago.: "+ex.ToString());
                }
            }
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                busqueda_cliente bc = new busqueda_cliente();
                bc.pasado += new busqueda_cliente.pasar(ejecutar_codigo_cliente);
                bc.ShowDialog();
                cargar_nombre_cliente();
                
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el cliente");
            }
        }
        public void ejecutar_codigo_cliente(string dato)
        {
            codigo_cliente_txt.Text = dato.ToString();
        }
        public void cargar_nombre_cliente()
        {
            try
            {
                string sql = "select (t.nombre+' '+p.apellido) as nombre from tercero t join persona p on p.codigo=t.codigo where t.codigo='"+codigo_cliente_txt.Text.Trim()+"'";
                DataSet ds=Utilidades.ejecutarcomando(sql);
                nombre_cliente_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre del cliente");
            }
        }
       
        
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea imprimir?", "Imprimiendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int fila = dataGridView1.CurrentRow.Index;
                string codigo_cobro = dataGridView1.Rows[fila].Cells[0].Value.ToString();       
                //imprimir_cobros ic = new imprimir_cobros();
                //ic.codigo_cobro = codigo_cobro.ToString();
                //ic.ShowDialog();
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string codigo_cobro = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            s = singleton.obtenerDatos();
            string sql = "select t.nombre from venta_vs_pagos vp join factura f on vp.cod_factura=f.codigo join sucursal s on f.cod_sucursal=s.codigo join tercero t on t.codigo=s.codigo where vp.codigo='"+codigo_cobro.ToString()+"'";
            DataSet ds = Utilidades.ejecutarcomando(sql);
            string nombre_sucursal = ds.Tables[0].Rows[0][0].ToString();
            sql = "select vp.codigo,vp.cod_factura,f.codigo_tipo_factura,vp.fecha,vp.detalle,vp.monto,(t.nombre+' '+p.apellido)as nombre from factura f join venta_vs_pagos vp on f.codigo=vp.cod_factura join cliente c on c.codigo=f.codigo_cliente join tercero t on t.codigo=c.codigo join persona p on p.codigo=t.codigo where vp.codigo='" + codigo_cobro.ToString() + "'";
            ds = Utilidades.ejecutarcomando(sql);
            string codigo_factura = ds.Tables[0].Rows[0][1].ToString();
            string tipo_factura = ds.Tables[0].Rows[0][2].ToString();
            string detalle = ds.Tables[0].Rows[0][4].ToString();
            double monto = Convert.ToDouble(ds.Tables[0].Rows[0][5].ToString());
            string nombre_cliente = ds.Tables[0].Rows[0][6].ToString();
            sql = "select t.nombre from venta_vs_pagos vp join factura f on vp.cod_factura=f.codigo join sucursal s on f.cod_sucursal=s.codigo join empresa e on e.codigo=s.codigo_empresa join tercero t on t.codigo=s.codigo_empresa where vp.codigo='" + codigo_cobro.ToString() + "'";
            ds = Utilidades.ejecutarcomando(sql);
            string nombre_empresa = ds.Tables[0].Rows[0][0].ToString();
            sql = "select (t.nombre+' '+p.apellido) from factura f join venta_vs_pagos vp on f.codigo=vp.codigo join tercero t on t.codigo=vp.cod_empleado join persona p on p.codigo=t.codigo where vp.codigo='" + codigo_cobro.ToString() + "'";
            ds = Utilidades.ejecutarcomando(sql);
            string nombre_empleado = ds.Tables[0].Rows[0][0].ToString();
            DateTime fecha = new DateTime();
            string numero_factura = "";
            printPreviewDialog1.Document = printDocument1;
            //printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.DefaultPageSettings.PaperSize = printDocument1.PrinterSettings.PaperSizes[7];
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            float y = 0;
            string fecha_hoy = DateTime.Today.ToLongDateString();
            string linea = "*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*";
            e.Graphics.DrawString(nombre_empresa.ToString(), new Font("Georgie", 16, FontStyle.Regular), Brushes.Black, 100, 10);

            e.Graphics.DrawString(nombre_sucursal, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 100, 30);
            e.Graphics.DrawString("RECIVO DE COBRO", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 40, 60);
            e.Graphics.DrawString("COBRO.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 40, 80);
            e.Graphics.DrawString(codigo_cobro.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 150, 80);

            e.Graphics.DrawString("Empleado.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 40, 100);
            e.Graphics.DrawString(nombre_empleado.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 150, 100);

            e.Graphics.DrawString("Fecha .:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 40, 120);
            e.Graphics.DrawString(fecha_hoy, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 150, 120);

            e.Graphics.DrawString("Cliente .:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 40, 140);
            e.Graphics.DrawString(nombre_cliente.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 150, 140);

            e.Graphics.DrawString(linea.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 40, 165);

            e.Graphics.DrawString("Descripcion", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 40, 200);
            e.Graphics.DrawString(detalle.ToString(), new Font("Georgie", 9, FontStyle.Regular), Brushes.Black, 40, 240);

            e.Graphics.DrawString("Monto", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 40, 280);
            e.Graphics.DrawString(monto.ToString("###,###,###,#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 150, 280);

            string autorizado_line = "-------------------------------------------------";
            y += 30;
            //e.Graphics.DrawString(linea.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 30, y);
            //y += 30;
            //e.Graphics.DrawString("Total", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 600, y);
            //e.Graphics.DrawString(importe_total.ToString("###,###,###,#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 660, y);
            //y += 100;
            e.Graphics.DrawString(autorizado_line, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 40, 500);
            y += 50;
            e.Graphics.DrawString("Autorizado por", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 80, 550);
            //y += 40;
            //e.Graphics.DrawString("GRACIAS POR PREFERIRNOS", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 260, y);
        }
        private void busqueda_cobros_venta_Load(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            codigo_cajero_txt.Text = s.codigo_usuario.ToString();
            cargar_nombre_cajero();
            validar_cajero();
           
        }
        public void validar_cajero()
        {
            try
            {
                string sql = "select caj.cod_caja,ca.nombre from cajero caj join caja ca on ca.codigo=caj.cod_caja where caj.cod_empleado='" + codigo_cajero_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                cargar_cobros();
            }
            catch (Exception)
            {
                MessageBox.Show("Este usuario no tiene cajero asignado'");
                codigo_cajero_txt.Clear();
                nombre_cajero_txt.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            busqueda_cajero bc = new busqueda_cajero();
            bc.pasado += new busqueda_cajero.pasar(ejecutar_codigo_cajero);
            bc.ShowDialog();
            cargar_nombre_cajero();
            validar_cajero();
        }
        public void ejecutar_codigo_cajero(string dato)
        {
            codigo_cajero_txt.Text = dato.ToString();
        }
        public void cargar_nombre_cajero()
        {
            try
            {
               string sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on t.codigo=p.codigo where t.codigo='"+codigo_cajero_txt.Text.Trim()+"'";
               DataSet ds = Utilidades.ejecutarcomando(sql);
               nombre_cajero_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando el nombre del cajero");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cargar_cobros();
        }
      
        public void cargar_cobros()
        {
            try
            {
                if (codigo_cajero_txt.Text.Trim() != "")
                {
                    dataGridView1.Rows.Clear();
                    //--codigo cobro,factura,cliente,metodo pago,monto,fecha,cod_empleado
                    string sql = "select cd.codigo,cd.cod_factura,ter.nombre,mp.descripcion,(cd.monto_pagado-cd.monto_descontado) as monto_pagado,c.fecha,c.cod_empleado from cobros_detalles cd join cobros c on c.codigo=cd.cod_cobro join factura f on cd.cod_factura=f.codigo join tercero ter on ter.codigo=f.codigo_cliente join metodo_pago mp on mp.codigo=cd.cod_metodo_pago where c.codigo>0 and c.estado='1' and c.fecha>='"+fecha_inicial.Value.ToString("yyyy-MM-dd")+"' and c.fecha<='"+fecha_final.Value.ToString("yyyy-MM-dd")+"'";                   
                    if(codigo_cajero_txt.Text.Trim()!="")
                    {
                        sql += " and c.cod_empleado='" + codigo_cajero_txt.Text.Trim() + "'";
                    }
                    if(codigo_cliente_txt.Text.Trim()!="")
                    {
                        sql += "and f.codigo_cliente='" + codigo_cliente_txt.Text.Trim() + "'";
                    }
                    sql += " order by c.codigo desc";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string empleado = Utilidades.getNombreByTercero(row[6].ToString());
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(),empleado);
                    }
                    double montoTotal = 0;
                    foreach(DataGridViewRow row in dataGridView1.Rows)
                    {

                        montoTotal += Convert.ToDouble(row.Cells[4].Value.ToString());
                    }
                    total_txt.Text = (montoTotal).ToString("N");
                }
                else
                {
                    MessageBox.Show("Falta el cajero");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando los cobros.: "+ex.ToString());
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

