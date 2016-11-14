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
    public partial class reporte_cliente : Form
    {
        public reporte_cliente()
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
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            imprimir();
        }
        public void imprimir()
        {
            DialogResult dr = MessageBox.Show("Desea imprimir?", "Imprimiendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    printDocument1.DefaultPageSettings.Landscape = true;
                    printDocument1.DefaultPageSettings.PaperSize = printDocument1.PrinterSettings.PaperSizes[7];
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No hay elementos para imprimir", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        int items_por_hoja=0;
        int items_impreso_por_hoja = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            s = singleton.obtenerDatos();
            string sql = "";
            DataSet ds = new DataSet();
            string fechaI = registro_desde_txt.Value.ToString("dd-MM-yyyy");
            string fechaF = registro_hasta_txt.Value.ToString("dd-MM-yyyy");
            string codigo_sucursal = codigo_sucursal_txt.Text.Trim();
            string nombre_sucursal = nombre_sucursal_txt.Text.Trim();
            float y = 0;
            string fecha_hoy = DateTime.Today.ToLongDateString();
            string linea = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -";
            e.Graphics.DrawString(nombre_sucursal, new Font("Georgie", 16, FontStyle.Regular), Brushes.Black, 400, 10);
            e.Graphics.DrawString("REPORTE DE CLIENTES", new Font("Georgie", 16, FontStyle.Regular), Brushes.Black, 375, 30);
            sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + s.codigo_usuario.ToString() + "'";
            ds = Utilidades.ejecutarcomando(sql);
            float x = 40;
            float x_temporal = x;
            string nombre_empleado = ds.Tables[0].Rows[0][0].ToString();
            e.Graphics.DrawString("empleado.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x), 90);
            e.Graphics.DrawString(nombre_empleado.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), 90);

            //para poner los parametros que se usaron en el filtro de busqueda que salgan en el reporte
            e.Graphics.DrawString("fecha inicial.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x), 110);
            if (ck_registro_desde.Checked == true)
            {
                e.Graphics.DrawString(fechaI.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), 110);
            }
            e.Graphics.DrawString("fecha final.:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x), 130);
            if (ck_registro_hasta.Checked == true)
            {
                e.Graphics.DrawString(fechaF.ToString(), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 100), 130);
            }

            e.Graphics.DrawString("cred. desde:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 200), 110);
            if (limite_credito_desde_txt.Text.Trim() != "")
            {
                e.Graphics.DrawString(Convert.ToDouble(limite_credito_desde_txt.Text.Trim()).ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 300), 110);
            }
            e.Graphics.DrawString("cred.  hasta:", new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 200), 130);
            if (limite_credito_hasta_txt.Text.Trim() != "")
            {
                e.Graphics.DrawString(Convert.ToDouble(limite_credito_hasta_txt.Text.Trim()).ToString("###,###,###,###.#0"), new Font("Georgie", 12, FontStyle.Regular), Brushes.Black, (x + 300), 130);
            }

            int letra = 9;
            int sumax = 120;
            e.Graphics.DrawString(linea, new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 150);

            e.Graphics.DrawString("ID", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax-50;
            e.Graphics.DrawString("NOMBRE", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("IDENTIFICACION", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("CATEGORIA", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("SUB-CATEGORIA", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("LIMITE CRED.", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            x += sumax;
            e.Graphics.DrawString("CRED. ABIERTO", new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x, 170);
            e.Graphics.DrawString(linea, new Font("Georgie", letra, FontStyle.Regular), Brushes.Black, x_temporal, 177);
            y = y + 50;
            y = 190;
            x = 10;
            int fila = 0;
            for (int f = items_impreso_por_hoja; f < dataGridView1.Rows.Count; f++)
            {
                items_por_hoja++;
               
                if (items_por_hoja <21)//la cantidad de items que quiero mostrar por paginas
                {
                    items_impreso_por_hoja++;

                    if(items_impreso_por_hoja<=dataGridView1.Rows.Count)
                    {
                        x = x_temporal;
                        e.Graphics.DrawString(dataGridView1.Rows[f].Cells[0].Value.ToString(), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax - 50;
                        e.Graphics.DrawString(dataGridView1.Rows[f].Cells[1].Value.ToString(), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, (x), y);
                        x += sumax;
                        e.Graphics.DrawString(dataGridView1.Rows[f].Cells[2].Value.ToString(), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(dataGridView1.Rows[f].Cells[4].Value.ToString(), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(dataGridView1.Rows[f].Cells[6].Value.ToString(), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(Convert.ToDouble(dataGridView1.Rows[f].Cells[7].Value.ToString()).ToString("###,###,###,###.#0"), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
                        x += sumax;
                        e.Graphics.DrawString(dataGridView1.Rows[f].Cells[8].Value.ToString(), new Font("Georgie", letra - 2, FontStyle.Regular), Brushes.Black, x, y);
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
        private void button15_Click(object sender, EventArgs e)
        {
        }
       
       

        private void label19_Click(object sender, EventArgs e)
        {
            codigo_sucursal_txt.Clear();
            nombre_sucursal_txt.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            busqueda_sucursal bs = new busqueda_sucursal();
            bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal);
            cargar_nombre_sucursal();
        }
        public void ejecutar_codigo_sucursal(string dato)
        {
            codigo_sucursal_txt.Text = dato.ToString();
        }
        public void cargar_nombre_sucursal()
        {
            if(codigo_sucursal_txt.Text.Trim()!="")
            {
                string sql = "select t.nombre from tercero t join sucursal s on t.codigo=s.codigo where t.codigo='"+codigo_sucursal_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
        }
        singleton s { get; set; }
        private void reporte_cliente_Load(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            codigo_sucursal_txt.Text = s.codigo_sucursal.ToString();
            cargar_nombre_sucursal();

            DateTime fecha = new DateTime();
            fecha = DateTime.Today;
            registro_hasta_txt.Text = fecha.ToString("dd-MM-yyyy");
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select t.codigo,(t.nombre+' '+p.apellido) as nombre,t.identificacion,cli.cod_categoria,clicat.nombre,cli.cod_subcategoria,clisubcate.nombre,cli.limite_credito,cli.abrir_credito from tercero t join persona p on t.codigo=p.codigo join cliente cli on cli.codigo=t.codigo join cliente_categoria clicat on clicat.codigo=cli.cod_categoria join cliente_subcategoria clisubcate on clisubcate.codigo=cli.cod_subcategoria where t.codigo>'0'";
            if (codigo_sucursal_txt.Text.Trim() != "")
            {
                sql += " and cli.cod_sucursal_creado='" + codigo_sucursal_txt.Text.Trim() + "'";
            }
            if (ck_registro_desde.Checked==true)
            {
                sql += " and cli.fecha_creado >='" + registro_desde_txt.Value.ToString("yyyy-MM-dd") +"'";
            }
            if (ck_registro_hasta.Checked==true)
            {
                sql += " and cli.fecha_creado <='" + registro_hasta_txt.Value.ToString("yyyy-MM-dd") + "'";
            }
            if (limite_credito_desde_txt.Text.Trim() != "")
            {
                sql += " and cli.limite_credito >='" + limite_credito_desde_txt.Text.Trim() + "'";
            }
            if (limite_credito_hasta_txt.Text.Trim() != "")
            {
                sql += " and cli.limite_credito <='" + limite_credito_hasta_txt.Text.Trim() + "'";
            }
            if (ck_clientes_Activos.Checked == true)
            {
                sql += " and cli.estado='1'";
            }
            else
            {
                sql += " and cli.estado='0'";
            }

            dataGridView1.Rows.Clear();
            DataSet ds = Utilidades.ejecutarcomando(sql);
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                dataGridView1.Rows.Add(row[0].ToString(),row[1].ToString(),row[2].ToString(),row[3].ToString(),row[4].ToString(),row[5].ToString(),row[6].ToString(),row[7].ToString(),row[8].ToString());
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if(ck_registro_desde.Checked==true)
            {
                registro_desde_txt.Enabled = true;
            }
            else
            {
                registro_desde_txt.Enabled = false;
            }
        }

        private void ck_registro_desde_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ck_registro_hasta_Click(object sender, EventArgs e)
        {
            if (ck_registro_hasta.Checked == true)
            {
                registro_hasta_txt.Enabled = true;
            }
            else
            {
                registro_hasta_txt.Enabled = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
