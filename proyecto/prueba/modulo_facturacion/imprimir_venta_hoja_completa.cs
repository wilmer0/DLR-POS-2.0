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
using puntoVenta;
namespace puntoVenta
{
    public partial class imprimir_venta_hoja_completa : Form
    {
        public imprimir_venta_hoja_completa()
        {
            InitializeComponent();
        }
        public string codigo_factura = "";
        string numero_de_hojas = "0";
        private void imprimir_Load(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.DefaultPageSettings.PaperSize = printDocument1.PrinterSettings.PaperSizes[7];
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            this.Close();
        }
        int items_por_hoja = 0;
        int items_impreso_por_hoja = 0;
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();
                sql = "select ncf,num_factura,cod_sucursal,codigo_tipo_factura,convert(date,fecha,112),efectivo,devuelta,itebis,tarjeta,deposito,cheque,monto_orden_compra,descuento from factura where codigo='" + codigo_factura.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                string numero_comprobante = "";
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    numero_comprobante = ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    numero_comprobante = ".";
                }
                string codigo_sucursal = ds.Tables[0].Rows[0][2].ToString();
                string tipo_venta = ds.Tables[0].Rows[0][3].ToString();
                string fecha = ds.Tables[0].Rows[0][4].ToString();
                double efectivo = Convert.ToDouble(ds.Tables[0].Rows[0][5].ToString());
                double devuelta = Convert.ToDouble(ds.Tables[0].Rows[0][6].ToString());
                double itebis = Convert.ToDouble(ds.Tables[0].Rows[0][7].ToString());
                double tarjeta = Convert.ToDouble(ds.Tables[0].Rows[0][8].ToString());
                double deposito = Convert.ToDouble(ds.Tables[0].Rows[0][9].ToString());
                double cheque = Convert.ToDouble(ds.Tables[0].Rows[0][10].ToString());
                double monto_orden_compra = Convert.ToDouble(ds.Tables[0].Rows[0][11].ToString());
                double monto_descuento = Convert.ToDouble(ds.Tables[0].Rows[0][12].ToString());
                double sumatoria_descuento = 0;
                sql = "select t.identificacion,t.nombre from tercero t join sucursal s on t.codigo=s.codigo_empresa where s.codigo='" + codigo_sucursal.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                string rnc_empresa = ds.Tables[0].Rows[0][0].ToString();
                string titulo = ds.Tables[0].Rows[0][1].ToString();
                sql = "select top(1) d.detalle from direccion d join tercero_vs_direccion td on td.cod_direccion=d.codigo and td.cod_tercero='" + codigo_sucursal.ToString() + "' where d.estado='1' and td.estado='1'";
                ds = Utilidades.ejecutarcomando(sql);
                string direccion = ds.Tables[0].Rows[0][0].ToString();
                sql = "select top(1) td.telefono from tercero_vs_telefono td where td.cod_tercero='" + codigo_sucursal.ToString() + "' and td.tipo_entidad='SUC' and td.tipo_telefono='TEL'";
                ds = Utilidades.ejecutarcomando(sql);
                string telefono = ds.Tables[0].Rows[0][0].ToString();
                //para sacar la imagen del logo de la empresa
                sql = "select top(1) ruta_imagen_productos,ruta_logo_empresa from sistema";
                ds = Utilidades.ejecutarcomando(sql);
                string logo_empresa = ds.Tables[0].Rows[0][0].ToString();
                logo_empresa += @"\" + ds.Tables[0].Rows[0][1].ToString();
                numero_de_hojas = printDocument1.PrinterSettings.PrintRange.ToString();
                
                int y = 0;
                int x = 0;
                string linea = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -";
                string separador = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -";
                //nombre de la empresa
                e.Graphics.DrawString(titulo, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, 0);
                //numero de hojas
                //e.Graphics.DrawString(numero_de_hojas.ToString(), new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, x, 0);
                //imprimiendo el logo de la empresa
                Image logo = Image.FromFile(logo_empresa.ToString());
                e.Graphics.DrawImage(logo, 450, 0, 200, 150);


                e.Graphics.DrawString("RNC", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, 15);
                e.Graphics.DrawString(rnc_empresa, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x+40, 15);

                e.Graphics.DrawString("Fact:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, 45);
                e.Graphics.DrawString(tipo_venta.ToString() + "-" + codigo_factura, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x+50, 45);

                //para saber si buscara el comprobante en la factura porq si busca y no encuentra da error la impresion 
                sql = "select  *from sistema where codigo='1' and usar_comprobantes='1'";
                ds = Utilidades.ejecutarcomando(sql);
                string nombre_comprobante = "";
                
                    if (numero_comprobante.ToString() != ".")
                    {
                        sql = "select tc.nombre from tipo_comprobante_fiscal tc join factura f on (select SUBSTRING(f.ncf,10,2) from factura f where f.codigo='" + codigo_factura.ToString() + "')=tc.secuencia where f.codigo='" + codigo_factura.ToString() + "'";
                        ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows[0][0].ToString() != "")
                        {
                            nombre_comprobante = ds.Tables[0].Rows[0][0].ToString();
                        }
                        else
                        {
                            nombre_comprobante = ".";
                        }
                    }
                    e.Graphics.DrawString("NCF.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, 70);
                    e.Graphics.DrawString(numero_comprobante, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x+50, 70);
                    e.Graphics.DrawString("comprobante valido para " + nombre_comprobante, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, 90);
                    
                sql = "select (t.nombre +' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo join factura f on f.codigo_cliente=t.codigo where f.codigo='" + codigo_factura.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                string nombre_cliente = ds.Tables[0].Rows[0][0].ToString();
                e.Graphics.DrawString("Cliente.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, 110);
                e.Graphics.DrawString(nombre_cliente, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x+70, 110);

                e.Graphics.DrawString(fecha, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, 130);

                e.Graphics.DrawString("Telefono.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, 150);
                e.Graphics.DrawString(telefono.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x+80, 150);

                e.Graphics.DrawString("Direccion.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, 170);
                e.Graphics.DrawString(direccion.ToString(), new Font("Georgie", 9, FontStyle.Regular), Brushes.Black, x+80, 170);
                
                e.Graphics.DrawString(linea, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, 183);




                y = 200;
                e.Graphics.DrawString("Cod", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                x+=50;
                e.Graphics.DrawString("Producto", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                x += 150; 
                e.Graphics.DrawString("Unidad", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                x += 70; 
                e.Graphics.DrawString("Cantidad", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                x += 90; 
                e.Graphics.DrawString("Itbis", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                x += 100; 
                e.Graphics.DrawString("Precio", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                x += 100; 
                e.Graphics.DrawString("Desc", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                x += 75; 
                e.Graphics.DrawString("Importe", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                x = 0;
                e.Graphics.DrawString(linea, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, (y + 20));

                y = y + 50;
                sql = "select p.codigo,p.nombre,u.unidad_abreviada,fd.cantidad,fd.itebis,fd.precio,fd.monto,fd.descuento from factura_detalle fd  join factura f on f.codigo=fd.cod_factura join producto p on p.codigo=fd.cod_producto join unidad u on u.codigo=fd.cod_unidad where f.codigo='" + codigo_factura.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                y += 0;
                x = 0;
                double total_factura = 0;

                StringFormat formato = new StringFormat();
                formato.Alignment = StringAlignment.Far;
                formato.LineAlignment = StringAlignment.Far;

                //foreach (DataRow row in ds.Tables[0].Rows)
                for (int f = items_impreso_por_hoja; f < ds.Tables[0].Rows.Count; f++)
                {
                    x = 0;
                    items_por_hoja++;
                    if (items_por_hoja < 15)//la cantidad de items que quiero mostrar por paginas
                    {
                        items_impreso_por_hoja++;

                        if (items_impreso_por_hoja <= ds.Tables[0].Rows.Count)
                        {

                            string codigo_producto = ds.Tables[0].Rows[f][0].ToString();
                            string producto = ds.Tables[0].Rows[f][1].ToString();
                            string unidad = ds.Tables[0].Rows[f][2].ToString();
                            double cantidad = Convert.ToDouble(ds.Tables[0].Rows[f][3].ToString());
                            double itebis_ = Convert.ToDouble(ds.Tables[0].Rows[f][4].ToString());
                            double costo = Convert.ToDouble(ds.Tables[0].Rows[f][5].ToString());
                            double monto = Convert.ToDouble(ds.Tables[0].Rows[f][6].ToString());
                            double descuento = Convert.ToDouble(ds.Tables[0].Rows[f][7].ToString());


                            e.Graphics.DrawString(codigo_producto, new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, x, y);
                            x += 50; 
                            e.Graphics.DrawString(producto, new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, x, y);
                            x += 150; 
                            e.Graphics.DrawString(unidad, new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, x, y);
                            x += 70; 
                            e.Graphics.DrawString(cantidad.ToString("###,###,###,###.#0"), new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, x, y);
                            x += 90; 
                            e.Graphics.DrawString(itebis_.ToString("###,###,###,###.#0"), new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, x, y);
                            x += 100; 
                            e.Graphics.DrawString(costo.ToString("###,###,###,###.#0"), new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, x, y);
                            x += 100; 
                            e.Graphics.DrawString(descuento.ToString("###,###,###,###.#0"), new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, x, y);
                            x += 75; 
                            e.Graphics.DrawString(monto.ToString("###,###,###,###.#0"), new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, x, y);
                            y += 40;
                            sumatoria_descuento += descuento;
                            total_factura += monto;
                        }
                        else
                        {
                            e.HasMorePages = false;
                        }
                    }
                    else
                    {
                        items_por_hoja = 0;
                        e.HasMorePages = true;
                        return;
                    }
                }

                x = 0;
                e.Graphics.DrawString(separador, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y + 20);
                double total = Convert.ToDouble(total_factura.ToString("###,###,###,###.#0"));
                y += 40;
               
                x = 430;
                e.Graphics.DrawString("Subtotal:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                e.Graphics.DrawString((total - itebis).ToString("###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x + 100, y);
                y += 30;
                e.Graphics.DrawString("Itbis:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                e.Graphics.DrawString(itebis.ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x + 100, y);
                y += 30;
                e.Graphics.DrawString("Efectivo:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                e.Graphics.DrawString(efectivo.ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x + 100, y);
                y += 30;
                e.Graphics.DrawString("Devuelta:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                e.Graphics.DrawString(devuelta.ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x + 100, y);
                y += 30;

                e.Graphics.DrawString("Tarjeta:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                e.Graphics.DrawString(tarjeta.ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x + 100, y);
                y += 30;

                e.Graphics.DrawString("Deposito:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                e.Graphics.DrawString(deposito.ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x + 100, y);
                y += 30;

                e.Graphics.DrawString("Cheque:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                e.Graphics.DrawString(cheque.ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x + 100, y);
                y += 30;

                e.Graphics.DrawString("Ord. comp.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                e.Graphics.DrawString(monto_orden_compra.ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x + 100, y);
                y += 30;
                e.Graphics.DrawString("Desc:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                e.Graphics.DrawString((sumatoria_descuento).ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x + 100, y);
                y += 30;

                e.Graphics.DrawString("Total:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
                e.Graphics.DrawString((total - sumatoria_descuento).ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x+100, y);

                y += 90;
                string autorizado_line = "-------------------------------------------------";
                e.Graphics.DrawString(autorizado_line, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 240, y);
                y += 10;
                e.Graphics.DrawString("Autorizado por", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 310, y);
                y += 40;
                e.Graphics.DrawString("GRACIAS POR PREFERIRNOS", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 260, y);
                //printDocument1.EndPrint += new PrintEventHandler();
            }
            catch (Exception)
            {
                MessageBox.Show("Error imprimiendo la factura");
                this.Close();
            }
        }

    }
}
