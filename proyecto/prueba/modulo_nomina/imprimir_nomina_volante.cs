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
    public partial class imprimir_nomina_volante : Form
    {
        public imprimir_nomina_volante()
        {
            InitializeComponent();
        }
        public string codigo_nomina="0";
        public string codigo_empleado = "0";
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();
                sql = "";
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
                //el tamano 7 es el tamano de una hoja normal
                printDocument1.DefaultPageSettings.PaperSize = printDocument1.PrinterSettings.PaperSizes[7];
                printPreviewDialog1.Document = printDocument1;
                printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                printPreviewDialog1.Document = printDocument1;
                

                float y = 0;

                string linea = "*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*";
                string separador = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -";
                //nombre de la empresa
                e.Graphics.DrawString(titulo, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 50, 0);
                //imprimiendo el logo de la empresa
                Image logo = Image.FromFile(logo_empresa.ToString());
                e.Graphics.DrawImage(logo, 500, 0, 220, 150);


                e.Graphics.DrawString("RNC", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 50, 15);
                e.Graphics.DrawString(rnc_empresa, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 100, 15);

                
                //para saber si buscara el comprobante en la factura porq si busca y no encuentra da error la impresion 
                sql = "select  *from sistema where codigo='1' and usar_comprobantes='1'";
                ds = Utilidades.ejecutarcomando(sql);
                string nombre_comprobante = "";

                if (numero_comprobante.ToString() != ".")
                {
                    sql = "";
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
                e.Graphics.DrawString("NCF.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 50, 70);
                e.Graphics.DrawString(numero_comprobante, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 150, 70);
                e.Graphics.DrawString("comprobante valido para " + nombre_comprobante, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 50, 90);

                sql = "";
                ds = Utilidades.ejecutarcomando(sql);
                string nombre_cliente = ds.Tables[0].Rows[0][0].ToString();
                e.Graphics.DrawString("Cliente.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 50, 110);
                e.Graphics.DrawString(nombre_cliente, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 150, 110);

                e.Graphics.DrawString(fecha, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 50, 130);

                e.Graphics.DrawString("Telefono.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 50, 150);
                e.Graphics.DrawString(telefono.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 150, 150);

                e.Graphics.DrawString("Direccion.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 50, 170);
                e.Graphics.DrawString(direccion.ToString(), new Font("Georgie", 9, FontStyle.Regular), Brushes.Black, 150, 170);
                e.Graphics.DrawString(linea, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 50, 183);




                y = 200;
                e.Graphics.DrawString("Codigo", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 50, y);

                e.Graphics.DrawString("Producto", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 130, y);

                e.Graphics.DrawString("Unidad", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 300, y);

                e.Graphics.DrawString("Cantidad", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 400, y);

                e.Graphics.DrawString("Itbis", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 500, y);

                e.Graphics.DrawString("Precio", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 600, y);

                e.Graphics.DrawString("Desc", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 700, y);

                e.Graphics.DrawString("Importe", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 800, y);
                e.Graphics.DrawString(linea, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 50, (y + 30));

                y = y + 50;
                sql = "";
                ds = Utilidades.ejecutarcomando(sql);
                y += 0;
                float x = 50;
                double total_factura = 0;

                StringFormat formato = new StringFormat();
                formato.Alignment = StringAlignment.Far;
                formato.LineAlignment = StringAlignment.Far;

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string codigo_producto = row[0].ToString();
                    string producto = row[1].ToString();
                    string unidad = row[2].ToString();
                    double cantidad = Convert.ToDouble(row[3].ToString());
                    double itebis_ = Convert.ToDouble(row[4].ToString());
                    double costo = Convert.ToDouble(row[5].ToString());
                    double monto = Convert.ToDouble(row[6].ToString());
                    double descuento = Convert.ToDouble(row[7].ToString());

                    e.Graphics.DrawString(codigo_producto, new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, 50, y);
                    e.Graphics.DrawString(producto, new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, 130, y);
                    e.Graphics.DrawString(unidad, new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, 300, y);
                    e.Graphics.DrawString(cantidad.ToString("###,###,###,###.#0"), new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, 400, y);
                    e.Graphics.DrawString(itebis_.ToString("###,###,###,###.#0"), new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, 500, y);
                    e.Graphics.DrawString(costo.ToString("###,###,###,###.#0"), new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, 600, y);
                    e.Graphics.DrawString(descuento.ToString("###,###,###,###.#0"), new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, 700, y);
                    e.Graphics.DrawString(monto.ToString("###,###,###,###.#0"), new Font("Georgie", 10, FontStyle.Regular), Brushes.Black, 800, y);
                    y += 40;
                    sumatoria_descuento += descuento;
                    total_factura += monto;
                }

                e.Graphics.DrawString(separador, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 50, y + 20);
                double total = Convert.ToDouble(total_factura.ToString("###,###,###,###.#0"));
                y += 40;
                e.Graphics.DrawString("Subtotal:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 560, y);
                e.Graphics.DrawString((total - itebis).ToString("###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 650, y);
                y += 30;
                e.Graphics.DrawString("Itbis:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 560, y);
                e.Graphics.DrawString(itebis.ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 650, y);
                y += 30;
                e.Graphics.DrawString("Efectivo:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 560, y);
                e.Graphics.DrawString(efectivo.ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 650, y);
                y += 30;
                e.Graphics.DrawString("Devuelta:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 560, y);
                e.Graphics.DrawString(devuelta.ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 650, y);
                y += 30;

                e.Graphics.DrawString("Tarjeta:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 560, y);
                e.Graphics.DrawString(tarjeta.ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 650, y);
                y += 30;

                e.Graphics.DrawString("Deposito:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 560, y);
                e.Graphics.DrawString(deposito.ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 650, y);
                y += 30;

                e.Graphics.DrawString("Cheque:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 560, y);
                e.Graphics.DrawString(cheque.ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 650, y);
                y += 30;

                e.Graphics.DrawString("Ord. comp.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 560, y);
                e.Graphics.DrawString(monto_orden_compra.ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 650, y);
                y += 30;
                e.Graphics.DrawString("Desc:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 560, y);
                e.Graphics.DrawString((sumatoria_descuento).ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 650, y);
                y += 30;

                e.Graphics.DrawString("Total:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 560, y);
                e.Graphics.DrawString((total - sumatoria_descuento).ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 650, y);

                //e.Graphics.DrawString("Efectivo:" +efectivo.ToString("###,###,###,###,#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 500, y);
                y += 30;
                //e.Graphics.DrawString("Devuelta:" + devuelta.ToString("###,###,###,###,#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 500,y);
                y += 60;
                string autorizado_line = "-------------------------------------------------";
                e.Graphics.DrawString(autorizado_line, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 240, y);
                y += 10;
                e.Graphics.DrawString("Autorizado por", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 310, y);
                y += 40;
                e.Graphics.DrawString("GRACIAS POR PREFERIRNOS", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 260, y);
            }
            catch (Exception)
            {
                MessageBox.Show("Error imprimiendo la factura");
                this.Close();
            }
        }

        private void imprimir_nomina_volante_Load(object sender, EventArgs e)
        {
            printDocument1.Print();
            this.Close();
        }
    }
}
