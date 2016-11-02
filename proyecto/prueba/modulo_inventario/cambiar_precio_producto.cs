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
    public partial class cambiar_precio_producto : Form
    {
        public cambiar_precio_producto()
        {
            InitializeComponent();
        }
        internal singleton s { get; set; }
        private void button11_Click(object sender, EventArgs e)
        {
            s=singleton.obtenerDatos();
            busqueda_producto bp = new busqueda_producto();
            bp.codigo_sucursal = s.codigo_sucursal.ToString();
            bp.pasado += new busqueda_producto.pasar(ejecutar_codigo_producto);
            bp.ShowDialog();
            cargar_nombre_producto();
            cargar_unidades();
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
                    nombre_producto.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el nombre del producto");
            }
        }
        public void cargar_unidades()
        {
            try
            {
                dataGridView1.Rows.Clear();
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    string sql = "select pro.codigo,pro.nombre,uni.codigo,uni.nombre,pc.costo,pc.precio_venta from  producto_unidad_conversion pc join producto pro on pc.cod_producto=pro.codigo join unidad uni on uni.codigo=pc.cod_unidad where pro.codigo='" + codigo_producto_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando las unidades del producto");
            }
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
                cargar_unidades();
                Precio_txt.Clear();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    /*
                       alter proc insert_precio_unidad
                       @precio float,@codigo int

                     */
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string sql = "update producto_unidad_conversion set precio_venta= '" + row.Cells[5].Value.ToString() + "' where cod_producto='" + row.Cells[0].Value.ToString() + "' and cod_unidad='" + row.Cells[2].Value.ToString() + "'";
                        Utilidades.ejecutarcomando(sql);
                    }
                    MessageBox.Show("Se actualizaron los precios");
                }
                catch(Exception)
                {
                    MessageBox.Show("Error guardando");
                }
            }
        }

        private void cambiar_precio_producto_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    if (Precio_txt.Text.Trim() != "")
                    {
                        int fila = dataGridView1.CurrentRow.Index;
                        dataGridView1.Rows[fila].Cells[5].Value = Precio_txt.Text.Trim().ToString();
                    }
                    else
                    {
                        Precio_txt.Focus();
                        MessageBox.Show("El precio no puede estar vacio");
                    }
                }
                else
                {
                    MessageBox.Show("Falta el producto");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error aplicando el precio");
            }
        }

        private void Precio_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Utilidades.numero_decimal(Precio_txt.Text) == false)
                Precio_txt.Clear();
        }
        double precio_prom = 0;
        double costo_prom = 0;
        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                precio_prom = 0;
                costo_prom = 0;
                DialogResult dr = MessageBox.Show("Desea aplicar el valor ponderado?", "Aplicando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    /*
                        ALTER proc [dbo].[inventario_ponderado]
                        @cod_producto int,@cod_unidad int
                        -->select @precio_prom as precio_promedio,@costo_prom as costo_promedio
                     */
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string sql = "exec inventario_ponderado '" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        precio_prom = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                        costo_prom = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                        if (precio_prom != 0)
                        {
                            sql = "update inventario set precio='" + precio_prom.ToString() + "' where codigo_producto='" + codigo_producto_txt.Text.Trim() + "' and codigo_unidad='" + row.Cells[2].Value.ToString() + "' ";
                            Utilidades.ejecutarcomando(sql);
                        }
                    }
                    MessageBox.Show("Procesado");
                    cargar_unidades();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error aplicando el valor ponderado");
            }
        }
    }
}
