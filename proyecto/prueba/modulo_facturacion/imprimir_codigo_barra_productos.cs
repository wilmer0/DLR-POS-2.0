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
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
//using BarcodeLib;

namespace puntoVenta.modulo_facturacion
{
    public partial class imprimir_codigo_barra_productos : Form
    {
        public imprimir_codigo_barra_productos()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
      
        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea imprimir el codigo de barra?","", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                imprimir();
            }
        }
        private void imprimir()
        {
            PaperSize tamanoPapel = new PaperSize("Zebra", 200, 125); 
            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.DefaultPageSettings.PaperSize = tamanoPapel;
            printPreviewDialog1.Document = printDocument1;
            //printDocument1.Print();
            printPreviewDialog1.ShowDialog();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                //BarcodeLib.Barcode codigo = new Barcode();
                //codigo.IncludeLabel = true;//para mostrar text en el codigo de barra
                //panelCodigo.BackgroundImage = codigo.Encode(BarcodeLib.TYPE.CODE128, "123456789", Color.Black, Color.White, 200, 125);
                string codigoBarra = "123456789";

                string sql = "select nombre from producto where estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string nombre_producto = "";
                    if (row[0].ToString()!="")
                    {
                        nombre_producto = row[0].ToString();
                    }
                    //MessageBox.Show(nombre_producto);
                    if (nombre_producto.Length > 60)
                    {
                        nombre_producto = nombre_producto.Substring(0, 60);
                    }
                    string ruta = @"D:\wilmer\proyecto\punto de venta\proyecto\prueba\Resources\código-de-barras.jpg";
                    Image imagen = Image.FromFile(ruta);
                    RectangleF rectangulo = new RectangleF(0, 0, 200, 30);
                    var font = new Font("Arial", 8, FontStyle.Bold);
                    var myBrush = new LinearGradientBrush(ClientRectangle, Color.Black, Color.White, LinearGradientMode.Horizontal);

                    //imprimir nombre producto
                    e.Graphics.DrawString(nombre_producto, font, myBrush, rectangulo);
                    //imprimir codigo barra
                    e.Graphics.DrawImage(imagen, 0, 30, 170, 90);
                    return;    
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error evento print: "+ex.ToString());
            }

        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            busqueda_producto bp = new busqueda_producto();
            bp.pasado += new busqueda_producto.pasar(ejecutar_codigo_producto);
            bp.codigo_sucursal = s.codigo_sucursal.ToString();
            bp.ShowDialog();
            cargar_datos_producto();
           
        }
        public void ejecutar_codigo_producto(string dato)
        {
            codigo_producto_txt.Text = dato.ToString();
        }
        public void cargar_datos_producto()
        {
            try
            {
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    string sql = "select nombre,from producto where codigo='" + codigo_producto_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_producto_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
            }
        }
        singleton s { get; set; }
        private void imprimir_codigo_barra_productos_Load(object sender, EventArgs e)
        {

        }
    }
}
