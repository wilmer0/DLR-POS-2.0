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
    public partial class estado_resultado : Form
    {
        public estado_resultado()
        {
            InitializeComponent();
        }
        internal singleton s { get; set; }
        private void estado_resultado_Load(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            codigo_sucursal_txt.Text = s.codigo_sucursal.ToString();
            cargar_nombre_sucursal();
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
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //limpiar
                dataGridView1.Rows.Clear();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea imprimir?", "Imprimiendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if(dataGridView1.Rows.Count>0)
                {
                    printDocument1.DefaultPageSettings.Landscape = false;
                    printDocument1.DefaultPageSettings.PaperSize = printDocument1.PrinterSettings.PaperSizes[7];
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No hay elementos para imprimir");
                }
            }
        }
        int items_impreso_por_hoja = 0;
        int items_por_hoja = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
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
                e.Graphics.DrawString(nombre_sucursal, new Font("Georgie", 16, FontStyle.Regular), Brushes.Black, 250, 10);
                e.Graphics.DrawString("REPORTE DE UTILIDAD BRUTA", new Font("Georgie", 16, FontStyle.Regular), Brushes.Black, 240, 30);
                sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + s.codigo_usuario.ToString() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                float x = 20;
                float x_temporal = x;
                string nombre_empleado = ds.Tables[0].Rows[0][0].ToString();
                e.Graphics.DrawString("empleado.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x), 90);
                e.Graphics.DrawString(nombre_empleado.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), 90);

                //para poner los parametros que se usaron en el filtro de busqueda que salgan en el reporte
                e.Graphics.DrawString("fecha inicial.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x), 110);
                if (anioI_txt.Text.Trim() != "")
                {
                    e.Graphics.DrawString(fechaI.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), 110);
                }
                e.Graphics.DrawString("fecha final.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x), 130);
                if (anioF_txt.Text.Trim() != "")
                {
                    e.Graphics.DrawString(fechaF.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), 130);
                }

                //e.Graphics.DrawString("cred. desde:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 200), 110);
                //if (limite_credito_desde_txt.Text.Trim() != "")
                //{
                //    e.Graphics.DrawString(Convert.ToDouble(limite_credito_desde_txt.Text.Trim()).ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 300), 110);
                //}
                //e.Graphics.DrawString("cred.  hasta:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 200), 130);
                //if (limite_credito_hasta_txt.Text.Trim() != "")
                //{
                //    e.Graphics.DrawString(Convert.ToDouble(limite_credito_hasta_txt.Text.Trim()).ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 300), 130);
                //}

                int letra = 10;
                int sumax = 120;
                e.Graphics.DrawString(linea, new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 150);

                e.Graphics.DrawString("año", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
                x += sumax - 50;
                e.Graphics.DrawString("ventas netas", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
                x += sumax;
                e.Graphics.DrawString("costo de ventas", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
                x += sumax;
                e.Graphics.DrawString("utilidad bruta", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
                x += sumax;
                e.Graphics.DrawString("cobrado de ventas", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
                x += sumax+20;
                e.Graphics.DrawString("pagado a supl.", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
                e.Graphics.DrawString(linea, new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x_temporal, 177);

                y = y + 50;
                y = 190;
                x = 10;
                int fila = 0;
                for (int f = items_impreso_por_hoja; f < dataGridView1.Rows.Count; f++)
                {
                    items_por_hoja++;

                    if (items_por_hoja < 30)//la cantidad de items que quiero mostrar por paginas
                    {
                        items_impreso_por_hoja++;

                        if (items_impreso_por_hoja <= dataGridView1.Rows.Count)
                        {
                            x = x_temporal;
                            e.Graphics.DrawString(dataGridView1.Rows[f].Cells[0].Value.ToString(), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                            x += sumax - 50;
                            e.Graphics.DrawString(dataGridView1.Rows[f].Cells[1].Value.ToString(), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, (x), y);
                            x += sumax;
                            e.Graphics.DrawString(dataGridView1.Rows[f].Cells[2].Value.ToString(), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                            x += sumax;
                            e.Graphics.DrawString(dataGridView1.Rows[f].Cells[3].Value.ToString(), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                            x += sumax;
                            e.Graphics.DrawString(dataGridView1.Rows[f].Cells[4].Value.ToString(), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                            x += sumax+20;
                            e.Graphics.DrawString(Convert.ToDouble(dataGridView1.Rows[f].Cells[5].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                            x += sumax;
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


                items_por_hoja = 0;
                items_impreso_por_hoja = 0;
            }
            catch(Exception)
            {
                MessageBox.Show("Error imprimiendo el reporte");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                s = singleton.obtenerDatos();
                busqueda_sucursal bs = new busqueda_sucursal();
                bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal);
                bs.codigo_empresa_global = s.codigo_empresa.ToString();
                bs.ShowDialog();
                cargar_nombre_sucursal();
            }
            catch(Exception)
            {
                MessageBox.Show("Su usuario no pertenece a ninguna sucursal");
            }
        }
        public void ejecutar_codigo_sucursal(string dato)
        {
            try
            {
                codigo_sucursal_txt.Text = dato.ToString();
            }
            catch(Exception)
            {

            }
        }
        public void cargar_nombre_sucursal()
        {
            try
            {
                string sql = "select nombre from tercero where codigo='" + codigo_sucursal_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando el nombre de la sucursal");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(codigo_sucursal_txt.Text.Trim()!="")
            {
                if(anioI_txt.Text.Trim()!="")
                {
                    if(anioF_txt.Text.Trim()!="")
                    {
                        buscar();
                    }
                    else
                    {
                        MessageBox.Show("Falta el año final");
                    }
                }
                else 
                { 
                    MessageBox.Show("Falta al año inicial"); 
                }
            }
            else
            {
                MessageBox.Show("Falta la sucursal");
            }
        }
        public void buscar()
        {
            string sql = "";
            DataSet ds = new DataSet();
            dataGridView1.Rows.Clear();
            Double anio1 = Convert.ToDouble(anioI_txt.Text.Trim());
            Double anio2 = Convert.ToDouble(anioF_txt.Text.Trim());
            Double registros = 0;
            registros = (anio2 - anio1);
            if (registros > 0)
            {
                int fila = 0;
                for (double a = anio1; a <=anio2; a++)
                {
                    //dataGridView1.Rows[fila].Cells[0].Value = a.ToString();
                    
                            //a es el año
                            //x es para llenar la columnas correspondiente
                            /*create proc estado_resultado
                              @codigo_sucursal int,@anio varchar(max)
                            */
                    sql = "exec estado_resultado '" + codigo_sucursal_txt.Text.Trim() + "','" + a.ToString() + "'";
                    ds = Utilidades.ejecutarcomando(sql);
                    double ventas_netas = 0;
                    double costo_ventas = 0;
                    double utilidad_bruta = 0;
                    double cobrado = 0;
                    double pagado = 0;
                    ventas_netas = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                    costo_ventas = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                    utilidad_bruta = Convert.ToDouble(ds.Tables[0].Rows[0][2].ToString());
                    cobrado = Convert.ToDouble(ds.Tables[0].Rows[0][3].ToString());
                    pagado = Convert.ToDouble(ds.Tables[0].Rows[0][4].ToString());
                    dataGridView1.Rows.Add(a.ToString(), ventas_netas.ToString("###,###,###,###,#0"), costo_ventas.ToString("###,###,###,###,#0"), utilidad_bruta.ToString("###,###,###,###,#0"), cobrado.ToString("###,###,###,###,#0"), pagado.ToString("###,###,###,###,#0"));
                    fila++;
                }
                MessageBox.Show("Finalizado");
            }
            else
            {
                MessageBox.Show("El año final debe ser mayor que el inicial");
            }
        }
    }
}
