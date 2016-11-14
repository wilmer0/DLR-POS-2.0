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
    public partial class imprimir_compra : Form
    {
        public imprimir_compra()
        {
            InitializeComponent();
        }
        public string codigo_compra = "";

        private void imprimir_compra_Load(object sender, EventArgs e)
        {
            PaperSize tamanoPapel = new PaperSize("Hoja", 850, 1050);
            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.DefaultPageSettings.PaperSize = tamanoPapel;
            //printDocument1.DefaultPageSettings.PaperSize = printDocument1.PrinterSettings.PaperSizes[7];
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            this.Close();
        }

        singleton s { get; set; }
        int items_por_hoja = 0;
        int items_impreso_por_hoja = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            try
            {

                s = singleton.obtenerDatos();
                int letra = 12;
                int tamanoLetra = 12;
                string tipoLetra = "Arial";
                int x = 0;
                int y = 0;
                string sql = "";
                DataSet ds = new DataSet();
                sql = "select ncf,codigo,cod_tipo,convert(date,fecha,112),convert(date,fecha_limite,112),cod_sucursal from compra where codigo='" + codigo_compra.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                string numero_comprobante = ds.Tables[0].Rows[0][0].ToString();
                string codigo_factura = ds.Tables[0].Rows[0][1].ToString();
                string tipo_compra = ds.Tables[0].Rows[0][2].ToString();
                DateTime fechaI = Convert.ToDateTime(ds.Tables[0].Rows[0][3].ToString());
                DateTime fechaF = Convert.ToDateTime(ds.Tables[0].Rows[0][4].ToString());
                string codigo_sucursal = ds.Tables[0].Rows[0][5].ToString();


                e.Graphics.DrawString("Reporte de compra", new Font("Georgie", 16, FontStyle.Regular), Brushes.Black, 375, 30);
                sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);


                string linea = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -";


                e.Graphics.DrawString(linea, new Font(tipoLetra, tamanoLetra, FontStyle.Regular), Brushes.Black, 30, 150);

                x = 0;
                e.Graphics.DrawString("cod.", new Font(tipoLetra, letra, FontStyle.Regular), Brushes.Black, x, 170);
                x += 100;
                e.Graphics.DrawString("producto", new Font(tipoLetra, tamanoLetra, FontStyle.Regular), Brushes.Black, x, 170);
                x += 150;
                e.Graphics.DrawString("unidad", new Font(tipoLetra, tamanoLetra, FontStyle.Regular), Brushes.Black, x, 170);
                x += 150;
                e.Graphics.DrawString("cant.", new Font(tipoLetra, tamanoLetra, FontStyle.Regular), Brushes.Black, x, 170);
                x += 150;
                e.Graphics.DrawString("costo", new Font(tipoLetra, tamanoLetra, FontStyle.Regular), Brushes.Black, x, 170);
                x += 150;
                e.Graphics.DrawString("importe", new Font(tipoLetra, tamanoLetra, FontStyle.Regular), Brushes.Black, x, 170);
                e.Graphics.DrawString(linea, new Font(tipoLetra, tamanoLetra, FontStyle.Regular), Brushes.Black, x, 170);
                y += 10;
                sql = "";
                sql = "select p.codigo,p.nombre,u.unidad_abreviada,cd.cantidad,cd.costo,cd.monto from compra_detalle cd join compra c on c.codigo=cd.cod_compra join producto p on p.codigo=cd.cod_producto join unidad u on u.codigo=cd.cod_unidad where c.codigo='" + codigo_compra.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                y += 160;
                x = 0;
                int x_temporal = x;
                double importe_total = 0;
                sql = "select p.codigo,p.nombre,u.unidad_abreviada,cd.cantidad,cd.costo,cd.monto from compra_detalle cd join compra c on c.codigo=cd.cod_compra join producto p on p.codigo=cd.cod_producto join unidad u on u.codigo=cd.cod_unidad where c.codigo='" + codigo_compra.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                for (int f = items_impreso_por_hoja; f < ds.Tables[0].Rows.Count; f++)
                {
                    items_por_hoja++;
                    if (items_por_hoja < 20)//la cantidad de items que quiero mostrar por paginas
                    {
                        items_impreso_por_hoja++;

                        if (items_impreso_por_hoja <= ds.Tables[0].Rows.Count)
                        {
                            x = x_temporal; 
                            e.Graphics.DrawString(ds.Tables[0].Rows[f][0].ToString(), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                            x += 60;
                            e.Graphics.DrawString(ds.Tables[0].Rows[f][1].ToString(), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, (x), y);
                            x += 200;
                            e.Graphics.DrawString(ds.Tables[0].Rows[f][2].ToString(), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                            x += 150;
                            e.Graphics.DrawString(Convert.ToDouble(ds.Tables[0].Rows[f][3].ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                            x += 150;
                            e.Graphics.DrawString(Convert.ToDouble(ds.Tables[0].Rows[f][4].ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                            x += 150;
                            e.Graphics.DrawString(Convert.ToDouble(ds.Tables[0].Rows[f][5].ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                            x += 150;
                            y += 25;
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
                string autorizado_line = "---------------------------------------------------------------------------------------------";
                y += 30;
                x = 10;
                y += 30;
                e.Graphics.DrawString(linea.ToString(), new Font(tipoLetra, tamanoLetra, FontStyle.Regular), Brushes.Black, 30, y);
                y += 30;
                e.Graphics.DrawString("Total", new Font(tipoLetra, tamanoLetra, FontStyle.Regular), Brushes.Black, 600, y);
                e.Graphics.DrawString(importe_total.ToString("###,###,###,###,###.#0"), new Font(tipoLetra, tamanoLetra, FontStyle.Regular), Brushes.Black, 660, y);
                y += 100;
                e.Graphics.DrawString(autorizado_line, new Font(tipoLetra, tamanoLetra, FontStyle.Regular), Brushes.Black, 240, y);
                y += 50;
                e.Graphics.DrawString("Autorizado por", new Font(tipoLetra, tamanoLetra, FontStyle.Regular), Brushes.Black, 310, y);
                y += 40;
                items_por_hoja = 0;
                items_impreso_por_hoja = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimiendo la compra: "+ex.ToString() );
            }
        }
    }
}
