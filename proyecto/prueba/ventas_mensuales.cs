using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prueba;
namespace proyecto
{
    public partial class ventas_mensuales : Form
    {
        public ventas_mensuales()
        {
            InitializeComponent();
        }
        internal singleton s { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
            }
        }
        int items_impreso_por_hoja = 0;
        int items_por_hoja = 0;


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            s = singleton.obtenerDatos();
            string sql = "";
            DataSet ds = new DataSet();
            string fechaI = anioI_txt.Text.Trim();
            string fechaF = anioF_txt.Text.Trim();
            string codigo_sucursal = codigo_sucursal_txt.Text.Trim();
            string nombre_sucursal = nombre_sucursal_txt.Text.Trim();
            float y = 0;
            string fecha_hoy = DateTime.Today.ToLongDateString();
            string linea = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -";
            e.Graphics.DrawString(nombre_sucursal, new Font("Georgie", 16, FontStyle.Regular), Brushes.Black, 400, 10);
            e.Graphics.DrawString("REPORTE DE FACTURACIÓN MENSUALES", new Font("Georgie", 16, FontStyle.Regular), Brushes.Black, 300, 30);
            sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + s.codigo_usuario.ToString() + "'";
            ds = Utilidades.ejecutarcomando(sql);
            float x = 40;
            float x_temporal = x;
            string nombre_empleado = ds.Tables[0].Rows[0][0].ToString();
            e.Graphics.DrawString("empleado.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x), 90);
            e.Graphics.DrawString(nombre_empleado.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), 90);

            e.Graphics.DrawString("año inicial.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x), 110);
            e.Graphics.DrawString(fechaI.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), 110);

            e.Graphics.DrawString("año final.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x), 130);
            e.Graphics.DrawString(fechaF.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), 130);


            int letra = 9;
            int sumax = 65;
            e.Graphics.DrawString(linea, new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 150);
            e.Graphics.DrawString("AÑO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("ENERO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("FEBRERO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax + 10;
            e.Graphics.DrawString("MARZO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("ABRIL", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("MAYO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("JUNIO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("JULIO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("AGOSTO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("SEPTIEMBRE", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax + 40;
            e.Graphics.DrawString("OCTUBRE", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax + 20;
            e.Graphics.DrawString("NOVIEMBRE", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax + 20;
            e.Graphics.DrawString("DICIEMBRE", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            e.Graphics.DrawString(linea, new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x_temporal, 177);

            y = y + 50;
            y = 190;
            x = 10;
            int fila = 0;
            for (int f = items_impreso_por_hoja; f < dataGridView1.Rows.Count; f++)
            {
                items_por_hoja++;

                if (items_por_hoja < 20)//la cantidad de items que quiero mostrar por paginas
                {
                    items_impreso_por_hoja++;

                    if (items_impreso_por_hoja <= dataGridView1.Rows.Count)
                    {
                        x = x_temporal;
                        e.Graphics.DrawString(dataGridView1.Rows[f].Cells[0].Value.ToString(), new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView1.Rows[f].Cells[1].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView1.Rows[f].Cells[2].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax + 10;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView1.Rows[f].Cells[3].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView1.Rows[f].Cells[4].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView1.Rows[f].Cells[5].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView1.Rows[f].Cells[6].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView1.Rows[f].Cells[7].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView1.Rows[f].Cells[8].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView1.Rows[f].Cells[9].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax + 40;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView1.Rows[f].Cells[10].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax + 20;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView1.Rows[f].Cells[11].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax + 20;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView1.Rows[f].Cells[12].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
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
            
            string autorizado_line = "-------------------------------------------------";
            y += 50;
            items_por_hoja = 0;
            items_impreso_por_hoja = 0;

        }
        private void imprimir_cobros(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (codigo_sucursal_txt.Text.Trim() != "")
                {
                    if (anioI_txt.Text.Trim() != "")
                    {
                        if (anioF_txt.Text.Trim() != "")
                        {
                            buscar_facturado();
                            buscar_cobrado();
                        }
                        else
                        {
                            MessageBox.Show("Falta el año final");
                            anioF_txt.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el año inicial");
                        anioI_txt.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Falta la sucursal");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando las ventas");
            }
            
        }
        public void buscar_facturado()
        {
            try
            {
                dataGridView1.Rows.Clear();
                //mes1 =Convert.ToInt16(dateTimePicker1.Value.ToString("MM"));
                //mes2 =Convert.ToInt16(dateTimePicker2.Value.ToString("MM"));
                Double anio1 = Convert.ToDouble(anioI_txt.Text.Trim());
                Double anio2 = Convert.ToDouble(anioF_txt.Text.Trim());
                Double registros = 0;
                registros = (anio2 - anio1);
                if (registros > 0)
                {
                    for (double i = 0; i <=registros; i++)
                    {
                        dataGridView1.Rows.Add();
                    }
                    int mes = 0;
                    int fila = 0;
                    for (double a = anio1; a <=anio2; a++)
                    {
                        mes = 1;
                        dataGridView1.Rows[fila].Cells[0].Value = a.ToString();
                        for (Int16 f = 0; f < 12; f++)
                        {
                            //f es cada mes
                            //el monto que se facturo
                            string sql = "select sum(fd.monto) as facturado from factura_detalle fd join factura f on f.codigo=fd.cod_factura where  fd.estado='1' and MONTH(f.fecha)='" + mes.ToString() + "' and YEAR(f.fecha) ='" + a.ToString() + "'";
                            if (codigo_sucursal_txt.Text.Trim() != "")
                            {
                                sql += " and f.cod_sucursal='" + codigo_sucursal_txt.Text.Trim() + "'";
                            }
                            DataSet ds = Utilidades.ejecutarcomando(sql);
                            double facturado = 0;
                            if (ds.Tables[0].Rows[0][0].ToString() != "")
                            {
                                facturado = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                                dataGridView1.Rows[fila].Cells[mes].Value = facturado.ToString("###,###,###,###.#0");
                            }
                            if (ds.Tables[0].Rows[0][0].ToString() == "")
                            {
                                dataGridView1.Rows[fila].Cells[mes].Value = 0;
                            }
                            //monto cobrado
                            //sql = "select sum(vp.monto) as cobrado from venta_vs_pagos vp  where vp.estado='1'  and month(vp.fecha)='" + f.ToString() + "' and YEAR(vp.fecha)='"+anio_txt.Text.Trim()+"'";
                            //ds = Utilidades.ejecutarcomando(sql);
                            //double cobrado = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                            //dataGridView1.Rows[fila + 1].Cells[columna].Value = cobrado.ToString("###,###,###,#0");
                            mes++;
                        }
                        fila++;
                    }
                    //MessageBox.Show("Finalizado");
                }
                else
                {
                    MessageBox.Show("El año final debe ser mayor que el inicial");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando las ventas de los meses");
            }
        }

        public void buscar_cobrado()
        {
            try
            {
                dataGridView2.Rows.Clear();
                //mes1 =Convert.ToInt16(dateTimePicker1.Value.ToString("MM"));
                //mes2 =Convert.ToInt16(dateTimePicker2.Value.ToString("MM"));
                Double anio1 = Convert.ToDouble(anioI_txt.Text.Trim());
                Double anio2 = Convert.ToDouble(anioF_txt.Text.Trim());
                Double registros = 0;
                registros = (anio2 - anio1);
                if (registros > 0)
                {
                    for (double i = 0; i <=registros; i++)
                    {
                        dataGridView2.Rows.Add();
                    }
                    int mes = 0;
                    int fila = 0;
                    for (double a = anio1; a <=anio2; a++)
                    {
                        mes = 1;
                        dataGridView2.Rows[fila].Cells[0].Value = a.ToString();
                        for (Int16 f = 0; f < 12; f++)
                        {
                            //f es cada mes
                            //el monto que se facturo
                            string sql = "select sum((vp.monto+vp.tarjeta+vp.cheque+vp.transferencia+vp.monto_orden_compra)-vp.devuelta) from venta_vs_pagos vp join factura f on f.codigo=vp.cod_factura  where vp.estado='1' and f.codigo_tipo_factura='CRE' and month(vp.fecha)='" + mes.ToString() + "' and year(vp.fecha)='" + a.ToString() + "'";
                            if (codigo_sucursal_txt.Text.Trim() != "")
                            {
                                sql += " and f.cod_sucursal='" + codigo_sucursal_txt.Text.Trim() + "'";
                            }
                            DataSet ds = Utilidades.ejecutarcomando(sql);
                            double cobrado = 0;
                            if (ds.Tables[0].Rows[0][0].ToString() != "")
                            {
                                cobrado+= Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                            }
                            sql = "select sum((f.efectivo+f.cheque+f.deposito+f.tarjeta+f.monto_orden_compra)-f.devuelta)  from factura f where f.estado='1' and f.codigo_tipo_factura='CON' and  month(f.fecha)='" + mes.ToString() + "' and year(f.fecha)='" + a.ToString() + "'";
                            ds = Utilidades.ejecutarcomando(sql);
                            if (ds.Tables[0].Rows[0][0].ToString() != "")
                            {
                                cobrado += Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                            }
                            dataGridView2.Rows[fila].Cells[mes].Value = cobrado.ToString("###,###,###,###.#0");
                            if (ds.Tables[0].Rows[0][0].ToString() == "")
                            {
                                dataGridView2.Rows[fila].Cells[mes].Value = 0;
                            }
                            mes++;
                        }
                        fila++;
                    }
                    //MessageBox.Show("Finalizado");
                }
                else
                {
                    MessageBox.Show("El año final debe ser mayor que el inicial");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando los cobros de los meses");
            }
        }
        private void ventas_mensuales_Load(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            codigo_sucursal_txt.Text = s.codigo_sucursal.ToString();
            cargar_nombre_sucursal();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                busqueda_sucursal bs = new busqueda_sucursal();
                bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal);
                bs.ShowDialog();
                cargar_nombre_sucursal();
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando las sucursales");
            }
        }
        public void ejecutar_codigo_sucursal(string dato)
        {
            codigo_sucursal_txt.Text = dato.ToString();
        }
        public void cargar_nombre_sucursal()
        {
            try
            {
                string sql = "select t.nombre from tercero t where t.codigo='"+codigo_sucursal_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre de la sucursal");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea imprimir?", "Imprimiendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (dataGridView1.Rows.Count > 0)//si tiene ventas
                {
                    printDocument1.DefaultPageSettings.Landscape = true;
                    printDocument1.DefaultPageSettings.PaperSize = printDocument1.PrinterSettings.PaperSizes[7];
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                   
                }
                else
                {
                    MessageBox.Show("No hay elementos en ventas");
                }
                if(dataGridView2.Rows.Count>0)
                {
                    printDocument2.DefaultPageSettings.Landscape = true;
                    printDocument2.DefaultPageSettings.PaperSize = printDocument2.PrinterSettings.PaperSizes[7];
                    printPreviewDialog2.Document = printDocument2;
                    printPreviewDialog2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No hay elementos en cobros");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void anioI_txt_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void anioI_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void anioF_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

         int items_impreso_por_hoja2 = 0;
         int items_por_hoja2 = 0;
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            s = singleton.obtenerDatos();
            string sql = "";
            DataSet ds = new DataSet();
            string fechaI = anioI_txt.Text.Trim();
            string fechaF = anioF_txt.Text.Trim();
            string codigo_sucursal = codigo_sucursal_txt.Text.Trim();
            string nombre_sucursal = nombre_sucursal_txt.Text.Trim();
            float y = 0;
            string fecha_hoy = DateTime.Today.ToLongDateString();
            string linea = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -";
            e.Graphics.DrawString(nombre_sucursal, new Font("Georgie", 16, FontStyle.Regular), Brushes.Black, 400, 10);
            e.Graphics.DrawString("REPORTE DE COBROS MENSUALES", new Font("Georgie", 16, FontStyle.Regular), Brushes.Black, 300, 30);
            sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + s.codigo_usuario.ToString() + "'";
            ds = Utilidades.ejecutarcomando(sql);
            float x = 40;
            float x_temporal = x;
            string nombre_empleado = ds.Tables[0].Rows[0][0].ToString();
            e.Graphics.DrawString("empleado.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x), 90);
            e.Graphics.DrawString(nombre_empleado.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), 90);

            e.Graphics.DrawString("año inicial.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x), 110);
            e.Graphics.DrawString(fechaI.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), 110);

            e.Graphics.DrawString("año final.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x), 130);
            e.Graphics.DrawString(fechaF.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), 130);


            int letra = 9;
            int sumax = 65;
            e.Graphics.DrawString(linea, new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 150);
            e.Graphics.DrawString("AÑO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("ENERO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("FEBRERO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax + 10;
            e.Graphics.DrawString("MARZO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("ABRIL", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("MAYO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("JUNIO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("JULIO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("AGOSTO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("SEPTIEMBRE", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax + 40;
            e.Graphics.DrawString("OCTUBRE", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax + 20;
            e.Graphics.DrawString("NOVIEMBRE", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax + 20;
            e.Graphics.DrawString("DICIEMBRE", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            e.Graphics.DrawString(linea, new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x_temporal, 177);

            y = y + 50;
            y = 190;
            x = 10;
            int fila = 0;
            for (int f = items_impreso_por_hoja2; f < dataGridView2.Rows.Count; f++)
            {
                items_por_hoja2++;

                if (items_por_hoja2 < 20)//la cantidad de items que quiero mostrar por paginas
                {
                    items_impreso_por_hoja2++;

                    if (items_impreso_por_hoja2 <= dataGridView2.Rows.Count)
                    {
                        x = x_temporal;
                        e.Graphics.DrawString(dataGridView2.Rows[f].Cells[0].Value.ToString(), new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView2.Rows[f].Cells[1].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView2.Rows[f].Cells[2].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax + 10;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView2.Rows[f].Cells[3].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView2.Rows[f].Cells[4].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView2.Rows[f].Cells[5].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView2.Rows[f].Cells[6].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView2.Rows[f].Cells[7].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView2.Rows[f].Cells[8].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView2.Rows[f].Cells[9].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax + 40;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView2.Rows[f].Cells[10].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax + 20;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView2.Rows[f].Cells[11].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax + 20;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView2.Rows[f].Cells[12].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        y += 25;
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }
                }
                else
                {
                    items_por_hoja2 = 0;
                    e.HasMorePages = true;
                    return;
                }
            }

            string autorizado_line = "-------------------------------------------------";
            y += 50;
            items_impreso_por_hoja2 = 0;
            items_por_hoja2 = 0;
        }
    }
}
