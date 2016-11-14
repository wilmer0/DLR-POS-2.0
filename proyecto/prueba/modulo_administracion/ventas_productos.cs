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
using System.Windows.Forms.DataVisualization.Charting;

namespace puntoVenta
{
    public partial class ventas_productos : Form
    {
        public ventas_productos()
        {
            InitializeComponent();
        }
        internal singleton s { get; set; }
        private void ventas_productos_Load(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            codigo_sucursal_txt.Text = s.codigo_sucursal.ToString();
            cargar_nombre_sucursal();
        }
        public void llenar_grafico()
        {
            try
            {
                //vectores con los datos para el grafico
                string[] series = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
                int[] puntos = { 10, 40, 80 };
                //para cambiar la peleta de colores
                //grafico1.Palette = ChartColorPalette.Pastel;

                //titulo
                //grafico1.Titles.Add("Meses");
                //para agregar valores al grafico
                int f = 0;
                double monto = 0;
                Series ser = new Series();
                for (int c = 1; c <=12; c++)
                {
                    monto = 0;
                    //titulos que salen en la derecha
                    ser = grafico1.Series.Add(series[f]);
                    f++;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        monto += Convert.ToDouble(row.Cells[c].Value.ToString());
                    }
                    ser.Points.Add(monto);

                    //para que aparezca encima de cada barra el monto que tiene
                    if (monto > 0)
                    {
                        ser.Label = monto.ToString("###,###,###,#0");
                    }

                }
            }
            catch(Exception)
            {

            }
           
        }
        public void buscar()
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();

                dataGridView1.Rows.Clear();
                grafico1.Series.Clear();
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
                        //a es el anio
                        mes = 1;
                        dataGridView1.Rows[fila].Cells[0].Value = a.ToString();
                        for (Int16 f = 1; f <= 12; f++)
                        {
                            //f es cada mes
                            sql = "select p.nombre,sum(fd.monto) from factura f join factura_detalle fd on f.codigo=fd.cod_factura join producto p on p.codigo=fd.cod_producto join categoria_producto cp on cp.codigo=p.cod_categoria   where f.estado='1' and fd.estado='1' and year(f.fecha)='"+a.ToString()+"' and month(f.fecha)='"+f.ToString()+"'";
                            if(codigo_producto_txt.Text.Trim()!="")
                            {
                                sql += " and p.codigo='"+codigo_producto_txt.Text.Trim()+"'";
                            }
                            if (codigo_sucursal_txt.Text.Trim() != "")
                            {
                                sql += " and f.cod_sucursal='" + codigo_sucursal_txt.Text.Trim() + "'";
                            }
                            if (codigo_categoria_txt.Text.Trim() != "")
                            {
                                sql += " and p.cod_categoria='" + codigo_categoria_txt.Text.Trim() + "'";
                            }
                            sql += " group by p.nombre";
                            ds = Utilidades.ejecutarcomando(sql);
                            double monto = 0;
                            string nombre_producto = "";
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                //este ciclo es para cuando encuentre mas de un producto 
                                //que sea por categoria sume todo los monto que encuentre
                                foreach(DataRow r in ds.Tables[0].Rows)
                                {
                                    nombre_producto = r[0].ToString();
                                    monto += Convert.ToDouble(r[1].ToString());
                                    //MessageBox.Show("prod->"+r[0].ToString()+" monto->"+r[1].ToString());
                                    
                                    //dataGridView1.Rows[fila].Cells[1].Value = nombre_producto.ToString();
                                    dataGridView1.Rows[fila].Cells[mes].Value = monto.ToString("N");
                                }
                            }
                            if (ds.Tables[0].Rows.Count == 0)
                            {
                                dataGridView1.Rows[fila].Cells[mes].Value = "0";
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
            catch(Exception)
            {
                MessageBox.Show("Error buscando las ventas");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (codigo_sucursal_txt.Text.Trim() != "")
            {
                if (anioI_txt.Text.Trim() != "")
                {
                    if (anioF_txt.Text.Trim() != "")
                    {
                        buscar();
                        llenar_grafico();
                    }
                    else
                    {
                        MessageBox.Show("Falta el año final");
                    }
                }
                else
                {
                    MessageBox.Show("Falta el año inicial");
                }
            }
            else
            {
                MessageBox.Show("Falta la sucursal");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            busqueda_sucursal bs = new busqueda_sucursal();
            bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal);
            bs.ShowDialog();
            cargar_nombre_sucursal();
        }
        public void ejecutar_codigo_sucursal(string dato)
        {
            codigo_sucursal_txt.Text = dato.ToString();
            codigo_producto_txt.Clear();
            nombre_producto_txt.Clear();
        }
        public void cargar_nombre_sucursal()
        {
            try
            {
                string sql = "select nombre from tercero where codigo='"+codigo_sucursal_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            busqueda_producto bp = new busqueda_producto();
            bp.codigo_sucursal = s.codigo_sucursal.ToString();
            bp.pasado += new busqueda_producto.pasar(ejecutar_codigo_producto);
            bp.ShowDialog();
            cargar_nombre_producto();
            codigo_categoria_txt.Clear();
            nombre_categoria_txt.Clear();
        }
        public void ejecutar_codigo_producto(string dato)
        {
            codigo_producto_txt.Text = dato.ToString();
        }
        public void cargar_nombre_producto()
        {
            try
            {
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    string sql = "select nombre from producto where codigo='" + codigo_producto_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_producto_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando nombre del producto");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_categoria bc = new busqueda_categoria();
            bc.pasado += new busqueda_categoria.pasar(ejecutar_codigo_categoria);
            bc.ShowDialog();
            cargar_nombre_categoria();
        }
        public void ejecutar_codigo_categoria(string dato)
        {
            codigo_categoria_txt.Text = dato.ToString();
        }
        public void cargar_nombre_categoria()
        {
            try
            {
                string sql = "select nombre from categoria_producto where codigo='"+codigo_categoria_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_categoria_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                limpiar();
            }
        }
        public void limpiar()
        {
            try
            {
                //codigo_sucursal_txt.Clear();
                //nombre_sucursal_txt.Clear();
                codigo_producto_txt.Clear();
                nombre_producto_txt.Clear();
                codigo_categoria_txt.Clear();
                nombre_categoria_txt.Clear();
                foreach (var series in grafico1.Series)
                {
                    series.Points.Clear();
                    
                }
                grafico1.Series.Clear();
                dataGridView1.Rows.Clear();
            }
            catch (Exception)
            {

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            foreach (var series in grafico1.Series)
            {
                series.Points.Clear();
            }
            grafico1.Series.Clear();

            codigo_producto_txt.Clear();
            nombre_producto_txt.Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            foreach (var series in grafico1.Series)
            {
                series.Points.Clear();
            }
            grafico1.Series.Clear();
            codigo_categoria_txt.Clear();
            nombre_categoria_txt.Clear();
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
    }
}
