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
    public partial class modificar_factura : Form
    {
        public modificar_factura()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            busqueda_cliente bc = new busqueda_cliente();
            bc.pasado += new busqueda_cliente.pasar(ejecutar_codigo_cliente);
            bc.ShowDialog();
            cargar_nombre_cliente();
            
        }
        public void ejecutar_codigo_cliente(string dato)
        {
            codigo_cliente_txt.Text = dato.ToString();
        }
        public void cargar_nombre_cliente()
        {
            try
            {
                string sql = "select (t.nombre+' '+p.apellido) as nombre,t.identificacion from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + codigo_cliente_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_cliente_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                identificacion_txt.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void modificar_factura_Load(object sender, EventArgs e)
        {

        }
        public void buscar_factura()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select f.codigo,f.num_factura,f.codigo_tipo_factura,fecha,f.fecha_limite,f.ncf,(t.nombre+' '+p.apellido) from factura f  join empleado e on f.codigo_empleado=e.codigo join tercero t on t.codigo=e.codigo join persona p  on p.codigo=t.codigo  where f.estado='1' and f.codigo_cliente='"+codigo_cliente_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando las facturas del cliente");
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
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error guardando");
            }
        }
        double sumatoria = 0;
        public void calcular_total()
        {
            try
            {
                sumatoria = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    sumatoria += Convert.ToDouble(row.Cells[4].Value);
                }
                cantidad_total_factura_txt.Text = sumatoria.ToString("###,###,###,#0");
            }
            catch (Exception)
            {
                MessageBox.Show("Error calculando el total de la factura");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = dataGridView1.CurrentRow.Index;
                cargar_productos(dataGridView1.Rows[fila].Cells[0].Value.ToString());
            }
            catch(Exception)
            {

            }
        }
        public void cargar_productos(string codigo_factura)
        {
            try
            {
                dataGridView2.Rows.Clear();
                string sql = "select p.nombre,u.nombre,fd.cantidad,fd.precio,fd.cantidad,fd.monto from factura_detalle fd  join producto p on p.codigo=fd.cod_producto join unidad u on u.codigo=fd.cod_unidad where fd.estado='1' and fd.cod_factura='"+codigo_factura.ToString()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView2.Rows.Add(row[0].ToString(), row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }
                calcular_total();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los productos de la factura");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
