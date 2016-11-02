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
    public partial class devolucion_venta : Form
    {
        public devolucion_venta()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_cliente bc = new busqueda_cliente();
            bc.pasado += new busqueda_cliente.pasar(ejecutar_codigo_cliente);
            bc.ShowDialog();
            cargar_nombre_cliente();
            cargar_ventas();
        }
        public void cargar_nombre_cliente()
        {
            try
            {
                string sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='"+codigo_cliente_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_cliente_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nomber del cliente");
            }
        }
        public void cargar_ventas()
        {
            dataGridView1.Rows.Clear();
            try
            {
                string sql = "select f.codigo,f.num_factura,f.fecha as hecha,f.ncf,f.rnc,f.fecha_limite,f.codigo_tipo_factura as tipo from factura f where estado=1 and f.codigo_cliente='"+codigo_cliente_txt.Text.Trim()+"' order by f.codigo desc";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
                }
                

            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las compras del suplidor");
            }
        }
        public void ejecutar_codigo_cliente(string dato)
        {
            codigo_cliente_txt.Text = dato.ToString();
        }
        private void cantidad_devolver_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (Utilidades.numero_decimal(cantidad_devolver_txt.Text.Trim()) == false)
            {
                cantidad_devolver_txt.Clear();
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    codigo_cliente_txt.Clear();
                    nombre_cliente_txt.Clear();
                    cantidad_devolver_txt.Clear();
                    cantidad_txt.Clear();
                    dataGridView1.Rows.Clear();
                    dataGridView2.Rows.Clear();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error lmpiando los datos");
            }
        }
        internal singleton s { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {

            s = singleton.obtenerDatos();
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (s.devolucion_venta == true)
                {
                    try
                    {
                        /*
                         create proc devolucion_venta
                         @codigo_factura int,@cod_pro int,@cod_uni int,@cantidad float,@cod_empleado int,@tipo_devolucion varchar(10)
                        */
                        int fila = dataGridView1.CurrentRow.Index;
                        if (ck_efectivo.Checked == true)
                        {
                            //EFE --> se devolvera dinero y debe hacerse un egreso de caja
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                string sql = "exec devolucion_venta '" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "','" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[8].Value.ToString() + "','" + s.codigo_usuario.ToString() + "','EFE'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                            }
                            MessageBox.Show("Se hizo la devolucion, ahora debe hacer un egreso de caja por el monto de la devolucion para que pueda hacer el cuadre de caja correctamente");
                        }
                        if(ck_nota_credito.Checked==true)
                        {
                            //NCR -->nota de credito
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                string sql = "exec devolucion_venta '" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "','" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[8].Value.ToString() + "','" + s.codigo_usuario.ToString() + "','NCR'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                            }
                            MessageBox.Show("Se hizo la devolucion");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error haciendo la devolucion");
                    }
                }
                else
                {
                    MessageBox.Show("No tiene permiso para hacer devolucion de ventas");
                }
                
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int fila = 0;
            fila = dataGridView1.CurrentRow.Index;
            cargar_productos(dataGridView1.Rows[fila].Cells[0].Value.ToString());
        }
        public void cargar_productos(string codigo_venta_txt)
        {

            try
            {
                dataGridView2.Rows.Clear();
                string sql = "select fd.cod_producto,p.nombre as producto,fd.cod_unidad,u.nombre as unidad, fd.precio,fd.cantidad,fd.itebis,fd.monto from factura f join factura_detalle fd on f.codigo=fd.cod_factura  join producto p on p.codigo=fd.cod_producto join unidad u on u.codigo=fd.cod_unidad where f.codigo='" + codigo_venta_txt.ToString() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    double subtotal = Convert.ToDouble(row[7].ToString()) - Convert.ToDouble(row[6].ToString());
                    dataGridView2.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), subtotal.ToString(), "0");
                }
                double total_factura = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    double monto = 0;
                    monto =Convert.ToDouble(row.Cells[4].Value.ToString());
                    row.Cells[4].Value = monto.ToString("###,###,###,###,###.#0");
                    monto = Convert.ToDouble(row.Cells[5].Value.ToString());
                    row.Cells[5].Value = monto.ToString("###,###,###,###,###.#0");
                    monto = Convert.ToDouble(row.Cells[6].Value.ToString());
                    row.Cells[6].Value = monto.ToString("###,###,###,###,###.#0");
                    monto = Convert.ToDouble(row.Cells[7].Value.ToString());
                    row.Cells[7].Value = monto.ToString("###,###,###,###,###.#0");

                    //sumando el itebis y el sub total para tener el total
                    total_factura += Convert.ToDouble(row.Cells[6].Value.ToString());
                    total_factura += Convert.ToDouble(row.Cells[7].Value.ToString());
                }
                monto_total_factura_txt.Text = total_factura.ToString("###,###,###,###,###.#0");
            }
            catch(Exception)
            {
                MessageBox.Show("Error mientras se cargaban los productos");
            }
        }

        private void devolucion_venta_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    int fila = dataGridView2.CurrentRow.Index;
                    dataGridView2.Rows[fila].Cells[7].Value = "0";
                    //dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error eliminando la fila seleccionada");
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = dataGridView2.CurrentRow.Index;
                cantidad_txt.Text = dataGridView2.Rows[fila].Cells[5].Value.ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error subiendo el articulo");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToDouble(cantidad_devolver_txt.Text.Trim())<=Convert.ToDouble(cantidad_txt.Text.Trim()))
                {
                    int fila = dataGridView2.CurrentRow.Index;
                    dataGridView2.Rows[fila].Cells[8].Value= cantidad_devolver_txt.Text.Trim();
                    calcular_efectivo_devuelta();
                }
                else
                {
                    MessageBox.Show("La cantidad a devolver debe ser menor que la facturada");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error aplicando la cantidad a devolver");
            }
        }
        public void calcular_efectivo_devuelta()
        {
            try
            {
                double monto = 0;
                double cantidad = 0;//cantidad a devolver
                double precio = 0;
                foreach(DataGridViewRow row in dataGridView2.Rows)
                {
                    precio = Convert.ToDouble(row.Cells[4].Value.ToString());
                    cantidad = Convert.ToDouble(row.Cells[8].Value.ToString());
                    monto+=cantidad*precio;
                }
                monto_devolver_txt.Text = monto.ToString("###,###,###,###,###.#0");
            }
            catch (Exception)
            {
                MessageBox.Show("Error calculando el efectivo a devolver");
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ck_efectivo_Click(object sender, EventArgs e)
        {
            ck_efectivo.Checked = true;
            ck_nota_credito.Checked = false;
        }

        private void ck_nota_credito_Click(object sender, EventArgs e)
        {

            ck_efectivo.Checked = false;
            ck_nota_credito.Checked = true;
        }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {
            int fila = 0;
            fila = dataGridView1.CurrentRow.Index;
            cargar_productos(dataGridView1.Rows[fila].Cells[0].Value.ToString());
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int fila = 0;
            fila = dataGridView1.CurrentRow.Index;
            cargar_productos(dataGridView1.Rows[fila].Cells[0].Value.ToString());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            caja_egresos ce = new caja_egresos();
            ce.ShowDialog();
        }
    }
}
