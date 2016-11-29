using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.IO.Compression;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows;
using BarcodeLib;
using FontStyle = System.Drawing.FontStyle;
using MessageBox = System.Windows.Forms.MessageBox;
using Ionic.Zip;
using CompressionLevel = Ionic.Zlib.CompressionLevel;

namespace puntoVenta
{

    public  class Utilidades
    {

        //variables fijas
        private string smtpGmail = "smtp.gmail.com";
        private int puertoGmail = 587;

        private string smtpHotmail = "smtp.live.com";
        private int puertoHotmail = 587;

        private string smtpSevenSoft = "smtpout.asia.secureserver.net";
        private int puertoSevenSoft = 3535;

        private string smtpYahoo = "smtp.mail.yahoo.com";
        private int PuertoYahoo = 465;

        public string nombreArchivo = "";



        //variables
        private string archivoDestino = "";
        private string nombreProducto = "";
        private string numeroCodigo = "";


        //variables
        static string codigoFactura = "";
        double numero_de_hojas = 0;
        //PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
        PrintDialog printDialog = new PrintDialog();
        private  string CodigoCobro;
        Utilidades utilidades = new Utilidades();


        public  bool primo(Int64 n)
        {

            
            Int64 cont = 0;
            for (Int64 f = 1; f <= n; f++)
            {
                if (n % f == 0)
                {
                    cont++;
                }
            }
            if (cont == 2)
                return true;
            else
                return false;
        }



        public  string conv999(Int64 n)
        {
            if (n == 0) return "";
            string[] unidad = new string[] { null, "uno", "dos", "tres", "cuatro", "cinco", "seis","siete", "ocho", "nueve", "diez", "once", "doce", "trece", "catorce","quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve", "veinte","veintiuno", "veintidos", "veintitres", "veinticuatro", "veinticinco", "veintiseis","veintisiete", "veintiocho", "veintinueve", "trenta" };
            string[] decena = new string[] { null, "diez", "veinte", "treinta", "cuarenta", "cincuenta", 
                "sesenta", "setenta", "ochenta", "noventa" };
            string cn = n.ToString().PadLeft(3, '0');
            int c = Convert.ToInt16(cn.Substring(0, 1));
            int d = Convert.ToInt16(cn.Substring(1, 1));
            int u = Convert.ToInt16(cn.Substring(2, 1));
            int u2 = Convert.ToInt16(cn.Substring(1, 2));
            if (n == 100) return " cien ";
            string letras = "";
            if (c > 0) letras += unidad[c] + " cientos ";
            if (u2 > 0)
            {
                if (u2 < 30) letras += unidad[u2];
                else
                {
                    letras += decena[d];
                    if (u > 0) letras += " y " + unidad[u];
                }
            }
            //arreglos
            letras = letras.ToLower();
            letras = letras.Replace("uno cientos", "cientos");
            letras = letras.Replace("cinco cientos", "quinientos");
            letras = letras.Replace("siete cientos", "setecientos");
            letras = letras.Replace("nueve cientos", "novecientos");
            return letras;
        }



        public  string conv15digitos(Int64 n)
        {
            string cn = n.ToString().PadLeft(18, '0');
            int n1 = Convert.ToInt16(cn.Substring(0, 3));
            int n2 = Convert.ToInt16(cn.Substring(3, 3));
            int n3 = Convert.ToInt16(cn.Substring(6, 3));
            int n4 = Convert.ToInt16(cn.Substring(9, 3));
            int n5 = Convert.ToInt16(cn.Substring(12, 3));
            int n6 = Convert.ToInt16(cn.Substring(15, 3));
            string Letras = "";
            if (n1 > 0)
                Letras += conv999(n1) + " trillones ";
            if (n2 > 0)
                Letras += conv999(n2) + " billones ";
            if (n3 > 0)
                Letras += conv999(n3) + " mil millones ";
            if (n4 > 0)
                Letras += conv999(n4) + " millones ";
            if (n5 > 0)
                Letras += conv999(n5) + " mil ";
            if (n6 > 0)
                Letras += conv999(n6) + " ";
            //arreglitos   
            Letras = Letras.ToLower();
            Letras = Letras.Replace("uno trillones", "un trillon ");
            Letras = Letras.Replace("uno billones", "un billon ");
            Letras = Letras.Replace("uno mil", "mil");
            Letras = Letras.Replace("uno  millones", "un millon  ");
            if (Letras == "millones")
            Letras = Letras.Replace(" millones", "un millon");
            //+arreglitos
            return Letras;
        }



        public  void hablar(string letras)
        {
            string[] v = letras.Split();
            for (int f = 0; f < v.Length; f++)
            {
                if (string.IsNullOrEmpty(v[f]) == false)
                { 
                    System.Media.SoundPlayer sonar = new System.Media.SoundPlayer();
                    sonar.SoundLocation = @"C:\Users\wilmer\Desktop\numeros\" + v[f] + ".wav";
                    sonar.PlaySync(); 
                }
            }
        }



        public  void escribir(string ruta, string contenido)
        {
            StreamWriter escribir = new StreamWriter(ruta);
            escribir.WriteLine(contenido);
            escribir.Close();
        }



        public  static DataSet ejecutarcomando(string query)
        {
            try
            {
                //string cmd = "select ip_server,base_datos,base_datos_usuario,base_datos_clave from sistema where ip_server!='' ";
                //DataSet dx = Utilidades.ejecutarcomando(cmd);
                //if(dx.Tables[0].Rows[0][0].ToString()!="")
                //{
                //    MessageBox.Show("Ip server tiene dato");
                //}
                    
                //funaciona nitido para conecciones desde otra maquina porq se especifica el user y password de la bd
                //SqlConnection conn = new SqlConnection("Data Source=dlr-laptop.ddns.net,31164;" + "Initial Catalog=punto_venta;" + "User id=dextroyex;" + "Password=wilmerlomas1;");
                SqlConnection conn = new SqlConnection("Data Source=.;" + "Initial Catalog=punto_venta;" + "User id=dextroyex;" + "Password=123456;");
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch(Exception)
            {
                //MessageBox.Show("Fallo conectando al server:"+ex.ToString());
                return null;
            }
        }



        //public static DataSet ejecutarcomando_mysql(string query)
        //{
        //    try
        //    {
        //        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;" +"pwd=wilmerlomas1;database=punto_venta;");
        //        MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);
        //        return ds;
        //    }
        //    catch(Exception)
        //    {
        //        return null;
        //        MessageBox.Show("Fallo conectando al server");
        //    }
        //}



        public  static string encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }



        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string desencriptar(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }



        public  static bool numero_entero(string cadena )
        {
            try
            {
                Convert.ToInt64(cadena.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public  static bool numero_decimal(string cadena)
        {
            try
            {
                Convert.ToDecimal(cadena.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public  string numero_miles(double numero)
        {
            try
            {
                numero.ToString("###,###,N");
                return numero.ToString();
            }
            catch(Exception)
            {
                return "Error";
            }
        }



        public  bool solo_letras(string cadena)
        {
            try
            {
                double x = 0;
                x=Convert.ToDouble(cadena);
                return false;
            }
            catch(Exception)
            {
                return true;
            }
        }




        public  string CadenaEliminarPalabra(string cadena,string palabra)
        {
            char[] partes = cadena.ToCharArray();
            string nuevaCadena = "";
            bool pegar = true;
            int cont = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                if (partes[i] == '|')
                {
                    pegar = false;
                }
                if (partes[i] == '|')
                {
                    pegar = true;
                    i++;
                    cont++;
                }
                 
                if (pegar)
                {
                    nuevaCadena += partes[i].ToString();
                }
                nuevaCadena.Remove(0, cont);
            }

            return nuevaCadena;
        }




        public  string getNombreTercero(string codigo)
        {
            string cmd = "";
            DataSet ds;
            cmd = "select (t.nombre+' '+p.apellido) as nombre from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + codigo.ToString()+ "'";
            Utilidades utilidades = new Utilidades();
            ds = Utilidades.ejecutarcomando(cmd);
            return ds.Tables[0].Rows[0][0].ToString();
        }



        public static Boolean enviarCoreeoElectronico(string emisor,string destinatario,string asunto,string mensaje)
        {
            try
            {

                //datos necesarios y dinamicos
                Boolean ssl = false;
                string host = "";
                string puerto = "";
                string clave = "";



                //sacar los datos del correo emisor con la tabla correos electronicos
                string sql = "select correo,clave,ssl_activo,host,puerto from correo_electronicos where correo='"+emisor.ToString()+"'";

                DataSet ds = Utilidades.ejecutarcomando(sql);
                if(ds.Tables[0].Rows[0][0].ToString()!="")
                {
                    clave = host = ds.Tables[0].Rows[0][1].ToString();
                    ssl = Convert.ToBoolean(ds.Tables[0].Rows[0][2].ToString());
                    host = ds.Tables[0].Rows[0][3].ToString();
                    puerto = ds.Tables[0].Rows[0][4].ToString();
                }
                               

                //construyendo el mensaje con datos de envio
                MailMessage email = new MailMessage();
                email.To.Add(new MailAddress(destinatario));
                email.From = new MailAddress(emisor);
                email.Subject = asunto;
                email.Body = mensaje;
                email.IsBodyHtml = true;
                email.Priority = MailPriority.High;

                //configurando la conexion con host y abriendo sesion de correo
                SmtpClient smtp = new SmtpClient(host,int.Parse(puerto));
                smtp.Host = host;
                smtp.Port = int.Parse(puerto);
                smtp.EnableSsl = ssl;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(emisor, clave);

                string output = null;

                //envio de correo
                smtp.Send(email);
                email.Dispose();
                //MessageBox.Show("Corre electrónico fue enviado satisfactoriamente.");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enviando correo electrónico: " + ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }





        public  Boolean comprimirArchivo(string rutaArchivo)
        {
            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    MessageBox.Show("Archivo no existe", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                DirectoryInfo directorio = new DirectoryInfo(rutaArchivo);
                foreach (FileInfo di in directorio.GetFiles())
                {
                    Compress(di.ToString());
                }

                //comprimir
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }





        public  Boolean Compress(string rutaArchivo)
        {
            try
            {
                // Get the stream of the source file.
                FileInfo fi = new FileInfo(rutaArchivo);
                using (FileStream inFile = fi.OpenRead())
                {
                    // Prevent compressing hidden and
                    // already compressed files.
                    if ((File.GetAttributes(fi.FullName)& FileAttributes.Hidden)!= FileAttributes.Hidden & fi.Extension != ".gz")
                    {
                        // Create the compressed file.
                        using (FileStream outFile =File.Create(fi.FullName + ".gz"))
                        {
                            using (GZipStream Compress = new GZipStream(outFile, CompressionMode.Compress))
                            {
                                // Copy the source file into
                                // the compression stream.
                                inFile.CopyTo(Compress);

                                //Console.WriteLine("Compressed {0} from {1} to {2} bytes.",fi.Name, fi.Length.ToString(), outFile.Length.ToString());
                            }
                        }
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }






        public  Boolean Decompress(string rutaArchivo)
        {
            try
            {
                FileInfo fi = new FileInfo(rutaArchivo);
                // Get the stream of the source file.
                using (FileStream inFile = fi.OpenRead())
                {
                    // Get original file extension, for example
                    // "doc" from report.doc.gz.
                    string curFile = fi.FullName;
                    string origName = curFile.Remove(curFile.Length - fi.Extension.Length);
                    //Create the decompressed file.
                    using (FileStream outFile = File.Create(origName))
                    {
                        using (GZipStream Decompress = new GZipStream(inFile, CompressionMode.Decompress))
                        {
                            // Copy the decompression stream
                            // into the output file.
                            Decompress.CopyTo(outFile);
                            //Console.WriteLine("Decompressed: {0}", fi.Name);
                        }
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: "+ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }





        //imprimir venta rollor
        public static Boolean imprimirVentaRollo(string CodigoVenta)
        {
            try
            {
                if (CodigoVenta == null)
                    return false;



                codigoFactura = CodigoVenta;
                int alto = 400;
                int ancho = 200;
                PaperSize tamano = new PaperSize("Factura", ancho, alto);
                PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                PrintDialog printDialog = new PrintDialog();
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                string sql = "select count (*) from factura_detalle where cod_factura='" + codigoFactura.ToString() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    int articulos = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    alto=(articulos*30)+alto;
                    tamano = new PaperSize("Factura", ancho, alto);
                }
                printDocument.DefaultPageSettings.PaperSize = tamano;
                printDocument.DefaultPageSettings.Landscape = false;
                printDocument.PrintPage +=printDocument1_PrintPage;
                printPreviewDialog.Document = printDocument;
                printPreviewDialog.ShowDialog();

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error imprimiendo rollo: "+ex.ToString());
                return false;
            }
        }

        private  static void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {

                /*
                  --cliente,total_descuento,nombre_empresa,rnc_empresa,telefono_empresa,secuencia_factura,tipo_venta,direccion_sucursal,cajero,monto_total,monto_itebis,codig_empresa,subtotal
                     exec reporte_factura_encabezado '1'
                     
                   --nombre,unidad,cantidad,precio,descuento,monto
                     exec reporte_factura_detalle '1'

                 */

                Rectangle rectangulo = new Rectangle();
                string sql = "";
                DataSet ds = new DataSet();
                sql = " exec reporte_factura_encabezado '" + codigoFactura.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                //cliente,total_descuento,nombre_empresa,rnc_empresa,telefono_empresa,secuencia_factura,tipo_venta,
                //direccion_sucursal,cajero,monto_total,monto_itebis,codigo_empresa,subtotal,comprobante_fiscal,fecha,
                //detalles_factura,efectivo,devuelta,tarjeta,cheque
                //datos encabezado factura
                string cliente = ds.Tables[0].Rows[0][0].ToString();
                double totalDecuento = double.Parse(ds.Tables[0].Rows[0][1].ToString());
                string nombreEmpresa = ds.Tables[0].Rows[0][2].ToString();
                string rnc = ds.Tables[0].Rows[0][3].ToString();
                string telefonoEmpresa = ds.Tables[0].Rows[0][4].ToString();
                string numeroFactura = ds.Tables[0].Rows[0][5].ToString();
                string tipoVenta = ds.Tables[0].Rows[0][6].ToString();
                string direccionSucursal = ds.Tables[0].Rows[0][7].ToString();
                string nombreCajero = ds.Tables[0].Rows[0][8].ToString();
                double montoTotal = double.Parse(ds.Tables[0].Rows[0][9].ToString());
                double montoItebis = double.Parse(ds.Tables[0].Rows[0][10].ToString());
                string codigoEmpresa = ds.Tables[0].Rows[0][11].ToString();
                double subTotal = double.Parse(ds.Tables[0].Rows[0][12].ToString());
                string numeroComprobante = ds.Tables[0].Rows[0][13].ToString();
                DateTime fecha = Convert.ToDateTime(ds.Tables[0].Rows[0][14].ToString());
                string detallesFactura = ds.Tables[0].Rows[0][15].ToString();
                double efectivo = double.Parse(ds.Tables[0].Rows[0][16].ToString());
                double devuelta = double.Parse(ds.Tables[0].Rows[0][17].ToString());
                double tarjeta = double.Parse(ds.Tables[0].Rows[0][18].ToString());
                double cheque = Convert.ToDouble(ds.Tables[0].Rows[0][19].ToString());
                string codigoTipocomprobante=ds.Tables[0].Rows[0][20].ToString();
                double deposito = Convert.ToDouble(ds.Tables[0].Rows[0][9].ToString());


                if (direccionSucursal.Length > 150)
                    direccionSucursal = direccionSucursal.Substring(0, 150);
                
                //formato texto en centro
                StringFormat formatoTextoCentro = new StringFormat();
                formatoTextoCentro.Alignment = StringAlignment.Center;
                formatoTextoCentro.LineAlignment = StringAlignment.Center;
                //frmato texto izquierda
                StringFormat formatoTextoIzquierda = new StringFormat();
                formatoTextoIzquierda.Alignment = StringAlignment.Near;
                formatoTextoCentro.LineAlignment = StringAlignment.Near;
                //formato texto derecha
                StringFormat formatoTextoDerecha = new StringFormat();
                formatoTextoIzquierda.Alignment = StringAlignment.Far;
                formatoTextoCentro.LineAlignment = StringAlignment.Far;



                string nombreTipoComprobante = getNombreComprobanteFiscalById(codigoTipocomprobante.ToString());
                Font pf5 = new Font("arial unicode ms", 5);
                Font pf6 = new Font("arial unicode ms", 6);
                Font pf7 = new Font("arial unicode ms", 7);
                Font pf8 = new Font("arial unicode ms", 8);
                Font pf9 = new Font("arial unicode ms", 9);
                Font pf10 = new Font("arial unicode ms", 10);
                
                double sumatoria_descuento = 0;


                //para sacar la imagen del logo de la empresa
                sql = "select top(1) ruta_imagen_productos,ruta_logo_empresa from sistema";
                ds = Utilidades.ejecutarcomando(sql);
                string logo_empresa = ds.Tables[0].Rows[0][0].ToString();
                logo_empresa += @"\" + ds.Tables[0].Rows[0][1].ToString();


                string linea = "---------------------------------------------";
                string separador = "---------------------------------------------";
                //nombre de la empresa
                int letras_size = 7;
                int x = 20;
                int y = 0;

                e.Graphics.DrawString(nombreEmpresa, pf7, Brushes.Black, x, y);
                y += 10;
                //Rectangle RectanguloDireccion = new Rectangle(x, y, ancho, alto);
                Rectangle RectanguloDireccion = new Rectangle(x,y, 180, 30);
                e.Graphics.DrawString(direccionSucursal.ToString(),pf5,Brushes.Black, RectanguloDireccion);
                y += 40;
                e.Graphics.DrawString("RNC:", pf7, Brushes.Black, x, y);
                e.Graphics.DrawString(rnc, pf7, Brushes.Black, (x + 50), y);
                y += 10;
                e.Graphics.DrawString("Tel.:  "+telefonoEmpresa.ToString(), pf7, Brushes.Black, x, y);
                y += 10;
                e.Graphics.DrawString("Fact:", pf7, Brushes.Black, x, y);
                e.Graphics.DrawString(tipoVenta.ToString() + "-" + codigoFactura, pf7, Brushes.Black, (x + 50), y);
                y += 10;
                if (numeroComprobante != "")
                {
                    e.Graphics.DrawString("NCF", pf7, Brushes.Black, x, y);
                    e.Graphics.DrawString(numeroComprobante, new Font("Georgie", letras_size - 2, FontStyle.Regular), Brushes.Black, (x + 50), y);
                    y += 10;
                }
                if (nombreTipoComprobante != "")
                {
                    //MessageBox.Show(numeroComprobante + "-" + nombreTipoComprobante);
                    e.Graphics.DrawString("Factura " + nombreTipoComprobante, pf7, Brushes.Black, x, y);
                    y += 10;
                } 
                //para saber si buscara el comprobante en la factura porq si busca y no encuentra da error la impresion 
               
                sql = "select (t.nombre +' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo join factura f on f.codigo_cliente=t.codigo where f.codigo='" + codigoFactura.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                string nombre_cliente = ds.Tables[0].Rows[0][0].ToString();
                e.Graphics.DrawString("Cliente", pf7, Brushes.Black, x, y);
                e.Graphics.DrawString(".:" + nombre_cliente, new Font("Georgie", 7, FontStyle.Regular), Brushes.Black, (x + 50), y);
                y += 10;
                e.Graphics.DrawString(fecha.ToString(), pf7, Brushes.Black, x, y);
               
                x = 20;
                y += 10;
                e.Graphics.DrawString(linea, pf7, Brushes.Black, x, y);
                y += 10;
                e.Graphics.DrawString("Descripción", new Font("Georgie", 5, FontStyle.Regular), Brushes.Black, x, y);
                x += 60;
                e.Graphics.DrawString("Precio", new Font("Georgie", 5, FontStyle.Regular), Brushes.Black, x, y);
                x += 50;
                e.Graphics.DrawString("Importe", new Font("Georgie", 5, FontStyle.Regular), Brushes.Black, x, y);
                x += 40;
                x = 20;
                y += 7;
                e.Graphics.DrawString(linea, pf7, Brushes.Black, x, y);
                y += 10;
                int fila = 100;


                //detalles factura
                //--nombre,unidad,cantidad,precio,descuento,monto
                sql = " exec reporte_factura_detalle '" + codigoFactura.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    //datos detalle facturas

                    letras_size = 5;

                    string producto = row[0].ToString();
                    string unidad = row[1].ToString();
                    double cantidad = Convert.ToDouble(row[2].ToString());
                    //double itebis_ = Convert.ToDouble(row[4].ToString());
                    double costo = Convert.ToDouble(row[3].ToString());
                    double descuento = Convert.ToDouble(row[4].ToString());
                    double monto = Convert.ToDouble(row[5].ToString());

                    x = 20;
                    e.Graphics.DrawString(cantidad.ToString("N"), pf7, Brushes.Black, x, y);
                    y += 10;
                    e.Graphics.DrawString(producto.ToString(), pf7, Brushes.Black, x, y);
                    y += 10;
                    e.Graphics.DrawString(unidad.ToString(), pf7, Brushes.Black, x, y);
                    x += 60;
                    e.Graphics.DrawString(costo.ToString("N"), pf7, Brushes.Black, x, y);
                    x += 50;
                    e.Graphics.DrawString((monto).ToString("N"), pf7, Brushes.Black, x, y);

                    x = 20;
                    letras_size = 7;
                    y += 5;
                    e.Graphics.DrawString(linea.ToString(), pf7, Brushes.Black, x, y);
                    y += 10;

                }
                y += 10;

                //linea que separa los produtos del desglose pago
                e.Graphics.DrawString(linea.ToString(), pf7, Brushes.Black, x, y);
                double total = Convert.ToDouble((montoTotal.ToString("N")));
                //para imprimir el detalle de la factura si lo tiene
                y += 10;
                if (detallesFactura.ToString() != "")
                {
                    e.Graphics.DrawString("Detalles:", pf7, Brushes.Black, x, y);
                    y += 10;
                    x = 20;
                    //Rectangle rec=new Rectangle(izquierda margen,altura,anchura,largo);
                    RectanguloDireccion = new Rectangle(x, Convert.ToInt16(y), 150, 150); e.Graphics.DrawString(detallesFactura.ToString(), pf7, Brushes.Black, RectanguloDireccion);
                    y += 50;
                    e.Graphics.DrawString(linea.ToString(), pf7, Brushes.Black, x, y);
                }
                x = 20;
                y += 10;
                letras_size = 5;
                e.Graphics.DrawString("Efectivo:", pf7, Brushes.Black, x, y);
                e.Graphics.DrawString(efectivo.ToString("N"), pf7, Brushes.Black, (x + 50), y);
                y += 10;
                e.Graphics.DrawString("Devuelta:", pf7, Brushes.Black, x, y);
                e.Graphics.DrawString(devuelta.ToString("N"), pf7, Brushes.Black, (x + 50), y);
                y += 10;
                e.Graphics.DrawString("Tarjeta:", pf7, Brushes.Black, x, y);
                e.Graphics.DrawString(tarjeta.ToString("N"), pf7, Brushes.Black, (x + 50), y);
                y += 10;
                e.Graphics.DrawString("Deposito:", pf7, Brushes.Black, x, y);
                e.Graphics.DrawString(deposito.ToString("N"), pf7, Brushes.Black, (x + 50), y);
                y += 10;
                e.Graphics.DrawString("Cheque:", pf7, Brushes.Black, x, y);
                e.Graphics.DrawString(cheque.ToString("N"), pf7, Brushes.Black, (x + 50), y);
                y += 10;

                e.Graphics.DrawString("Subtotal:", pf7, Brushes.Black, x, y);
                e.Graphics.DrawString((subTotal).ToString("N"), pf7, Brushes.Black, (x + 50), y);
                y += 10;
                e.Graphics.DrawString("Desc:", pf7, Brushes.Black, x, y);
                e.Graphics.DrawString((totalDecuento).ToString("N"), pf7, Brushes.Black, (x + 50), y);
                y += 10;

                e.Graphics.DrawString("Itbis:", pf7, Brushes.Black, x, y);
                e.Graphics.DrawString(montoItebis.ToString("N"), pf7, Brushes.Black, (x + 50), y);
                y += 10;
                e.Graphics.DrawString("Total:", pf7, Brushes.Black, x, y);
                e.Graphics.DrawString((montoTotal).ToString("N"), pf7, Brushes.Black, (x + 50), y);
                string autorizado_line = "-------------------------------------------------";
                y += 20;
                e.Graphics.DrawString(autorizado_line, pf7, Brushes.Black, (x + 15), y);
                y += 10;
                e.Graphics.DrawString("Autorizado por", pf7, Brushes.Black, (x + 50), y);
                y += 10;
                e.Graphics.DrawString("GRACIAS POR PREFERIRNOS", pf7, Brushes.Black, (x + 20), y);
                y += 40;
                e.PageSettings.PaperSize.Width += 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimiendo la factura: " + ex.ToString());
            }
        }
        

        public  static Boolean validarPermisoEmpleado(string codigoUsuario,string codigoPermiso)
        {

           try
           {
               string sql = "select permisos_por_grupos_usuarios from sistema";
               DataSet ds = Utilidades.ejecutarcomando(sql);

               if (ds.Tables[0].Rows[0][0].ToString() == "")
               {
                   MessageBox.Show("Error: no tiene permisos marcado", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return false;
               }
               if(ds.Tables[0].Rows[0][0].ToString()=="1")
               {
                   //permisos por grupo
                   sql = "select gu.cod_permiso from empleado e join grupo_usuarios_permisos gu on e.cod_grupo_usuario=gu.cod_grupo where gu.cod_permiso='1' and e.codigo='" + codigoUsuario.ToString()+ "'";
                   ds = Utilidades.ejecutarcomando(sql);
                   if (ds.Tables[0].Rows.Count > 0)
                   {
                       return true;
                   }

               }
               if (ds.Tables[0].Rows[0][0].ToString() == "0")
               {
                   //permisos por usuario
                   sql = "select *from tercero_vs_permiso where cod_tercero='" + codigoUsuario.ToString() + "' and cod_permiso='1' and tipo_entidad='EMP' and estado='1'";
                   ds = Utilidades.ejecutarcomando(sql);
                   if (ds.Tables[0].Rows.Count > 0)
                   {
                      return true;
                   }
               }
               return false;
           }
            catch(Exception ex)
           {
               MessageBox.Show("Error validando permiso: "+ex.ToString());
               return false;
            }
        }




        public static string getNombreComprobanteFiscalById(string codigoTipoComprobante)
        {
            string NombreTipoComprobante = "";
            string sql = "select nombre from tipo_comprobante_fiscal where codigo='" + codigoTipoComprobante.ToString() + "'";
            DataSet ds = Utilidades.ejecutarcomando(sql);
            if (ds.Tables[0].Rows[0][0] == "")
                return null;

            NombreTipoComprobante = ds.Tables[0].Rows[0][0].ToString();
            return NombreTipoComprobante;
        }

        //imprimir factura en hoja normales 8.50 x 11


        public static string getNombreByTercero(string codigo)
        {
            try
            {
                string sql = "select (t.nombre +' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='"+codigo+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows[0][0].ToString() == "")
                    return null;


                    return ds.Tables[0].Rows[0][0].ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error obteniendo el nombre.: " + ex.ToString(), "", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return null;
            }
        }
        public static string GetIdMetodoPagoByNombre(string metodo)
        {
            try
            {
                string sql = "select codigo from metodo_pago where metodo='"+metodo+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows[0][0] =="")
                    return null;

                return ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error obteniendo metodo de pago.: " + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return null;
            }
        }





        //imprimir cobros papel rollo

        public  Boolean ImprimirCobroRollo(string codigo)
        {

            try
            {
                if (codigo == null)
                    return false;



                CodigoCobro = codigo;
                int alto = 400;
                int ancho = 200;
                PaperSize tamano = new PaperSize("Factura", ancho, alto);
                PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                PrintDialog printDialog = new PrintDialog();
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                string sql = "select count (*) from factura_detalle where cod_factura='" + CodigoCobro.ToString() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    int articulos = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    alto = (articulos * 30) + alto;
                    tamano = new PaperSize("Factura", ancho, alto);
                }
                printDocument.DefaultPageSettings.PaperSize = tamano;
                printDocument.DefaultPageSettings.Landscape = false;
                printDocument.PrintPage += ImrpimirCobroPrintPage;
                printPreviewDialog.Document = printDocument;
                printPreviewDialog.ShowDialog();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimiendo rollo: " + ex.ToString());
                return false;
            }
        }
        private  void ImrpimirCobroPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
            string sql = "";
            DataSet ds = Utilidades.ejecutarcomando(sql);
            string nombre_sucursal = ds.Tables[0].Rows[0][0].ToString();


           
            //printDocument1.DefaultPageSettings.Landscape = true;
          
            float y = 0;
            string fecha_hoy = DateTime.Today.ToLongDateString();
            string linea = "----------------------------------------";



            /*float x = 0;
            x = 50;
            y = 50;
            e.Graphics.DrawString(nombre_empresa.ToString(), new Font("Georgie", 16, FontStyle.Regular), Brushes.Black, 100, 10);
            e.Graphics.DrawString(nombre_sucursal, new Font("Georgie", letra_encabezado, FontStyle.Regular), Brushes.Black, 90, 30);
            e.Graphics.DrawString("RECIBO DE COBRO", new Font("Georgie", letra_encabezado, FontStyle.Regular), Brushes.Black, x, y);
            y += 20;
            e.Graphics.DrawString("COBRO", new Font("Georgie", letra_encabezado, FontStyle.Regular), Brushes.Black, x, y);
            e.Graphics.DrawString(".:" + codigo_cobro.ToString(), new Font("Georgie", letra_encabezado, FontStyle.Regular), Brushes.Black, (x + 60), y);
            y += 20;
            e.Graphics.DrawString("Empl", new Font("Georgie", letra_encabezado, FontStyle.Regular), Brushes.Black, x, y);
            e.Graphics.DrawString(".:" + nombre_empleado.ToString(), new Font("Georgie", letra_encabezado, FontStyle.Regular), Brushes.Black, (x + 60), y);
            y += 20;
            e.Graphics.DrawString("Fecha", new Font("Georgie", letra_encabezado, FontStyle.Regular), Brushes.Black, x, y);
            e.Graphics.DrawString(".:" + fecha_hoy, new Font("Georgie", letra_encabezado, FontStyle.Regular), Brushes.Black, (x + 60), y);
            y += 20;
            e.Graphics.DrawString("Cliente", new Font("Georgie", letra_encabezado, FontStyle.Regular), Brushes.Black, x, y);
            e.Graphics.DrawString(".:" + nombre_cliente.ToString(), new Font("Georgie", letra_encabezado, FontStyle.Regular), Brushes.Black, (x + 60), y);
            y += 20;
            e.Graphics.DrawString(linea.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
            //e.Graphics.DrawString(detalle.ToString(), new Font("Georgie", 9, FontStyle.Regular), Brushes.Black, (x), y);

            y += 20;
            e.Graphics.DrawString("Factura->" + codigo_factura.ToString(), new Font("Georgie", 9, FontStyle.Regular), Brushes.Black, x, y);
            y += 30;
            //efectivo
            e.Graphics.DrawString("Efectivo", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
            e.Graphics.DrawString(monto.ToString("N"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), y);
            y += 20;
            //devuelta
            e.Graphics.DrawString("Devuelta", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
            e.Graphics.DrawString(devuelta.ToString("N"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), y);
            y += 20;
            //tarjeta
            e.Graphics.DrawString("Tarjeta", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
            e.Graphics.DrawString(tarjeta.ToString("N"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), y);
            y += 20;
            //cheque
            e.Graphics.DrawString("Cheque", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
            e.Graphics.DrawString(cheque.ToString("N"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), y);
            y += 20;
            //deposito/transferencia
            e.Graphics.DrawString("Deposito", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
            e.Graphics.DrawString(deposito.ToString("N"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), y);
            y += 20;
            string autorizado_line = "----------------------------------------";
            y += 30;
            // Rectangle rec=new Rectangle(izquierda margen,altura margen,largo,ancho);
            //imprimir la descripcion del cobro
            e.Graphics.DrawString("Detalles", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, x, y);
            y += 15;
            //imprimir el rectangulo con el detalle del cobro
            Rectangle rec = new Rectangle(50, Convert.ToInt16(y), 300, 500);
            e.Graphics.DrawString(detalle.ToString(), new Font("Georgie", 10), Brushes.Black, rec);
            y += 325;
            //ultima linea para poner cobro revivido y firmado
            e.Graphics.DrawString(linea, new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 40, y);
            y += 15;
            e.Graphics.DrawString("Autorizado por", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, 80, y);
            */
        }


        //public  Boolean limpiarDatosTodasTablasMysql()
        //{
        //    try
        //    {
        //        string sql = "select CONCAT(' SET FOREIGN_KEY_CHECKS=0; SET SQL_SAFE_UPDATES = 0; truncate table ',table_name) from information_schema.tables where table_schema='punto_venta';";
        //        DataSet ds = Utilidades.ejecutarcomando_mysql(sql);
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            //MessageBox.Show(row[0].ToString());
        //            utilidades.ejecutarcomando_mysql(row[0].ToString());
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.ToString());
        //        return false;
        //    }
        //}

        public  string getFormaFechaNormal(DateTime fecha)
        {
            return fecha.ToString("dd/MM/yyyy");
        }



        public Boolean ValidarCorreo(string correo)
        {
            try
            {
                try
                {
                    Regex.IsMatch(correo,
                        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                    return true;
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validando el correo: " + correo + " -->" + ex.ToString());
                return false;
            }
        }




        public Boolean EnviarCorreo(string emisor, string password, string destinatario, string asunto, string mensaje,
            string ruta_archivo, int opcionCorreo)
        {
            try
            {
                MailMessage correo = new MailMessage();
                SmtpClient envios = new SmtpClient();
                correo.Body = "";
                correo.Subject = "";
                if (mensaje.ToString() != "")
                {
                    correo.Body = mensaje;
                }
                correo.Subject = asunto;
                correo.IsBodyHtml = true;
                char[] delimitador = { ',' };
                string[] destinatariosArray = destinatario.Split(delimitador);
                //para agregar cada destinatario al mail
                foreach (string desti in destinatariosArray)
                {
                    try
                    {
                        if (ValidarCorreo(desti.ToString().Trim()))
                        {
                            correo.To.Add(desti.ToString());
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error, correo no valido: " + desti.ToString());
                        return false;
                    }
                }
                if (ruta_archivo.ToString() != "")
                {
                    //Microsoft.Office.Interop.Word.System.Net.Mail.Attachment archivo = new Microsoft.Office.Interop.Word.System.Net.Mail.Attachment(ruta_archivo.ToString());
                    //correo.Attachments.Add(archivo);
                }
                correo.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);
                if (opcionCorreo == 1)
                {
                    //es gmail
                    envios.Host = smtpGmail;
                    envios.Port = puertoGmail;
                    envios.EnableSsl = true;
                }
                if (opcionCorreo == 2)
                {
                    //es hotmail
                    envios.Host = smtpHotmail;
                    envios.Port = puertoHotmail;
                    envios.EnableSsl = true;
                }
                if (opcionCorreo == 3)
                {
                    //es sevenSoft
                    envios.Host = smtpSevenSoft;
                    envios.Port = puertoSevenSoft;
                    envios.EnableSsl = false;
                }
                if (opcionCorreo == 4)
                {
                    //es yahoo
                    //smtp.mail.yahoo.com	587	Yes
                    envios.Host = smtpYahoo;
                    envios.Port = PuertoYahoo;
                    envios.EnableSsl = true;
                }
                correo.Priority = MailPriority.High;

                envios.Send(correo);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("El mensaje no en envio correctamente: " + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }



        //public Boolean ImprimirCodigoBarra(string NombreProducto, string numero)
        //{
        //    try
        //    {

        //        string directorio = @"C:\Users\7SOFTCASA\Documents\GitHub\7ERP-1.0\7ADMFIC-1.0\7ADMFIC-1.0\bin\Release";
        //        directorio = Path.GetDirectoryName(directorio);//bin
        //        directorio = Path.GetDirectoryName(directorio);//7adfic-1.0
        //        directorio += @"\Temporales\";
        //        MessageBox.Show(directorio);
        //        this.nombreProducto = NombreProducto;

        //        this.numeroCodigo = numero;

        //        //generando el codigo de barra
        //        Barcode barra = new Barcode();

        //        barra.IncludeLabel = true;

        //        barra.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;

        //        barra.Encode(BarcodeLib.TYPE.CODE128, numero.ToString(), Color.Black, Color.White, 300, 100);

        //        string rutaDestino = @"C:\Users\7SOFTCASA\Desktop\Nueva carpeta-\";

        //        archivoDestino = rutaDestino + NombreProducto;

        //        barra.EncodedType = BarcodeLib.TYPE.CODE128B;

        //        barra.SaveImage(archivoDestino + ".jpg", BarcodeLib.SaveTypes.JPG);


        //        //imprimiendo la imagen generada
        //        PrintDocument pd = new PrintDocument();
        //        PaperSize paperSize = new PaperSize("Ticket Codido Barra", 110, 80);
        //        pd.DefaultPageSettings.PaperSize = paperSize;

        //        pd.PrintPage += new PrintPageEventHandler(this.ImprimirCodigoBarra_PrintEvent);
        //        PrintPreviewDialog pv = new PrintPreviewDialog();
        //        pv.Document = pd;
        //        //pd.Print();
        //        pv.ShowDialog();

        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show("Error imprimiendo codigo barra ImprimirCodigoBarra.: " + ex.ToString());
        //        return false;
        //    }
        //}

        private void ImprimirCodigoBarra_PrintEvent(object sender, PrintPageEventArgs ev)
        {

            int x = 0;

            int y = 0;

            int count = 0;

            String LineaCompletaRec1 = "";

            Font pf = new Font("arial unicode ms", 8);

            //cargando  imagen
            archivoDestino += ".jpg";

            Image imagen = System.Drawing.Image.FromFile(archivoDestino);

            //MessageBox.Show(archivoDestino);

            //x-y-ancho-alto

            Rectangle rec1 = new Rectangle(0, 0, 120, 150);

            Rectangle rec2 = new Rectangle(0, 40, 101, 30);

            if (this.nombreProducto.Length > 37)
            {
                this.nombreProducto = this.nombreProducto.Substring(0, 37);
            }

            ev.Graphics.DrawString(this.nombreProducto, pf, System.Drawing.Brushes.Black, rec1, new StringFormat());

            ev.Graphics.DrawImage(imagen, rec2);

            //If more lines exist, print another page.

            ev.HasMorePages = false;


        }


        public void CopiarArchivosRecursivo(DirectoryInfo Origen, DirectoryInfo Destino)
        {
            foreach (DirectoryInfo dir in Origen.GetDirectories())
            {
                CopiarArchivosRecursivo(dir, Destino.CreateSubdirectory(dir.Name));
            }
            foreach (FileInfo file in Origen.GetFiles())
            {
                file.CopyTo(Path.Combine(Destino.FullName, file.Name));
            }
        }



        public string GetSHA1(string str)
        {
            try
            {
                SHA1 sha1 = SHA1Managed.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = sha1.ComputeHash(encoding.GetBytes(str));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.: " + ex.ToString());
                return "";
            }
        }

        public static string GetMd5(string texto)
        {
            try
            {
                byte[] keyArray;
                byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);
                //Se utilizan las clases de encriptación MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes("1")); //Aqui se toma la llave que debe ser igual para encriptar y descencriptar
                hashmd5.Clear();
                //Algoritmo TripleDES
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
                tdes.Clear();
                //se regresa el resultado en forma de una cadena
                texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
            }
            catch (Exception)
            {

            }
            return texto;
        }


        public static string GetBase64Encriptar(string cadena)
        {
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(cadena);
            return Convert.ToBase64String(byt);
        }

        public static string GetBase64Desencriptar(string cadena)
        {
            byte[] b = Convert.FromBase64String(cadena);
            b = Convert.FromBase64String(cadena);
            return System.Text.Encoding.UTF8.GetString(b);
        }

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static string GetSHA512(string str)
        {
            SHA512 sha512 = SHA512Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha512.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }



        public Boolean comprimirArchivos(List<string> rutaArchivos, string rutaDestino, string password)
        {
            try
            {
                ZipFile zip = new ZipFile();

                zip.CompressionLevel = (CompressionLevel) System.IO.Compression.CompressionLevel.Optimal;

                zip.Comment = "Compresion de jemplo";

                if (password != "")
                {
                    zip.Password = password;
                }

                rutaArchivos.ForEach(x =>
                {
                    zip.AddFile(x.ToString(), "");
                    //MessageBox.Show(x.ToString(),rutaDestino);
                });

                zip.Save(rutaDestino + "Archivo" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Millisecond + ".zip");
                zip.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error comprimirArchivos.: " + ex.ToString());
                return false;
            }
        }

        public Boolean descomprimirArchivo(string rutaArchivo, string rutaDestino, string password = null)
        {
            try
            {
                //para leer cada archivo
                ZipFile zip = ZipFile.Read(rutaArchivo);

                //si el archivo tiene password
                if (password != null)
                {
                    zip.Password = password;
                }

                //si el archivo tiene ruta especifica para descomprimir
                if (rutaDestino != "")
                {
                    zip.ExtractAll(rutaDestino);
                }

                zip.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error descomprimirArchivo.: " + ex.ToString());
                return false;
            }
        }

        public string GetTituloVentana(string usuario, string tituloVentana)
        {
            try
            {
                string titulo = "BC-POS";

                titulo = titulo + "-" + tituloVentana.ToString().ToUpper() + "-" + usuario.ToString().ToUpper();

                return titulo.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetTituloVentana.: " + ex.ToString());
                return null;
            }
        }


        public String getNombreMaquina()
        {
            String nombre = "";
            nombre = System.Environment.MachineName;

            return nombre;


        }

        public Boolean isNumeric(String cadena)
        {
            if (cadena == null)
            {

                return false;
            }
            Boolean respuesta = false;
            Decimal i = 0;
            respuesta = Decimal.TryParse(cadena, out i);

            return respuesta;
        }


        public Boolean isDecimal(String Cadena)
        {
            decimal resul;
            return decimal.TryParse(Cadena, out resul);
        }

        public String getRellenarConCarracter(int longitud, Boolean derecha, string caracter, String cadena)
        {
            String caracteres = "";


            for (int i = cadena.Length; i < longitud; i++)
            {
                caracteres = caracteres + caracter;


            }
            if (derecha)
            {
                cadena = cadena + caracteres;

            }
            else
            {
                cadena = caracteres + cadena;

            }





            return cadena;

        }



        public Boolean getValidarNCF(Boolean activarMensaje, String ncf)
        {
            Boolean respuesta = false;
            if (ncf.Length == 19)
            {
                return true;

            }
            else
            {
                respuesta = false;
               
            }
            return false;
        }



        public string getFormaFechaYYYYMMdd(DateTime fecha)
        {

            return fecha.ToString("yyyyMMdd");

        }

        public string getFormaFechaddMMYYY(DateTime fecha)
        {

            return fecha.ToString("ddMMyyyy");

        }

        public string getFormaFechaYYYYMM(DateTime fecha)
        {

            return fecha.ToString("yyyyMM");

        }

        public string getFormaFechaddMMyyyyHHmmss(DateTime fecha)
        {

            return fecha.ToString("dd-MM-dd-HH-mm-ss");

        }

        public string getFormaFechadd(DateTime fecha)
        {

            return fecha.ToString("dd");

        }

        public string getFormaFecha(DateTime fecha, string formato)
        {

            return fecha.ToString(formato);

        }

        public int GetNUmeroDiasRangoFechas(DateTime FechaInicio, DateTime FechaFin)
        {

            try
            {

                TimeSpan ts = FechaFin - FechaInicio;


                return ts.Days;
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return 0;

            }
            finally
            {
                //  Entity = null;

            }

        }
        public int GetRandon(int tamano)
        {
            var seed = Convert.ToInt32(Regex.Match(Guid.NewGuid().ToString(), @"\d+").Value);
            return new Random(seed).Next(0, tamano);

        }
        public String GetNumeroRandon(int tamano)
        {
            String Trama = "";
            int j = 0;
            for (int i = 0; i < 1000; i++)
            {
                int numero = GetRandon(9);

                if (j == 0)
                {
                    if (numero != 0)
                    {
                        Trama = Trama + numero;
                        j++;
                    }
                }

                else
                {
                    Trama = Trama + numero;
                    j++;
                }

                if (j == 6)
                {
                    break;
                }
            }

            return Trama;

        }

        public Boolean validarCorreoElectronico(string correo)
        {
            try
            {

                String sFormato;
                sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (Regex.IsMatch(correo, sFormato))
                {
                    if (Regex.Replace(correo, sFormato, String.Empty).Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarCorreoElectronico.:" + ex.ToString());
                return false;
            }
        }

    }
}