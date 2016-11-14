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
    public partial class compras_devolucion : Form
    {
        public compras_devolucion()
        {
            InitializeComponent();
        }
        internal singleton s { get; set; }
        private void compras_devolucion_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_compras_Click(object sender, EventArgs e)
        {
            int fila = 0;
            fila = dataGridView2.CurrentRow.Index;
            cargar_productos(dataGridView2.Rows[fila].Cells[0].Value.ToString());
        }
        public void cargar_productos(string codigo_compra_txt)
        {
            dataGridView1.Rows.Clear();
            try
            {
                try
                {

                    if (ck_devueltas.Checked == true)
                    {
                        productos_devueltos();
                    }
                    else
                    {
                        string sql = "select cd.cod_producto,p.nombre as producto,cd.cod_unidad,u.nombre as unidad,cd.costo,cd.cantidad,cd.monto from compra c join compra_detalle cd on c.codigo=cd.cod_compra join producto p on p.codigo=cd.cod_producto join unidad u on u.codigo=cd.cod_unidad where c.codigo='" + codigo_compra_txt.ToString().Trim() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            
                            dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), "0");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error cargando los productos de la com");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los productos de la compra");
            }
        }

        private void pais_btn_Click(object sender, EventArgs e)
        {
            busqueda_suplidor bs = new busqueda_suplidor();
            bs.pasado += new busqueda_suplidor.pasar(ejecutar_codigo_suplidor);
            bs.ShowDialog();
            cargar_compras_suplidor();
            
        }
        public void cargar_compras_suplidor()
        {
            dataGridView2.Rows.Clear();
            try
            {
                string sql = "select codigo,num_factura,fecha as hecha,ncf,rnc,fecha_limite,cod_tipo as tipo from compra where estado=1 and cod_suplidor='"+codigo_suplidor_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView2.DataSource = ds.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las compras del suplidor");
            }
        }
        public void ejecutar_codigo_suplidor(string dato)
        {
            try
            {
                codigo_suplidor_txt.Text = dato.ToString();
                string sql = "select nombre from tercero where codigo='" + codigo_suplidor_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_suplidor_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error sacando el codigo del suplidor");
            }
        }

        private void cantidad_devolver_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if(Utilidades.numero_decimal(cantidad_devolver_txt.Text)==true)
            {

            }
            else
            {
                cantidad_devolver_txt.Text = "";
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

                    codigo_suplidor_txt.Clear();
                    nombre_suplidor_txt.Clear();
                    cantidad_devolver_txt.Clear();
                    Cantidad_grid_txt.Clear();
                    dataGridView1.Rows.Clear();
                    dataGridView2.Rows.Clear();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ck_devueltas.Checked != true)
            {
                s = singleton.obtenerDatos();
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (s.devolucion_compra == true)
                    {
                        try
                        {
                            /*
                                ALTER proc [dbo].[devolucion_compra]
                                @codigo_compra int,@cod_pro int,@cod_uni int,@cantidad float,@costo float,@cod_empleado int
                             */
                            int filacompra = dataGridView2.CurrentRow.Index;
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                string sql = "exec devolucion_compra '" + dataGridView2.Rows[filacompra].Cells[0].Value.ToString() + "','" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[7].Value.ToString() + "','"+row.Cells[4].Value.ToString()+"','" + s.codigo_usuario.ToString() + "'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                            }
                            MessageBox.Show("Se hizo la devolucion");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error haciendo la devolucion");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No tiene permiso para hacer devolucion de compras");
                    }
                }
            }
            else
            {
                MessageBox.Show("No puede aplicar una devolucion, debe desactivar la opcion de productos devueltos");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = dataGridView1.CurrentRow.Index;
                Cantidad_grid_txt.Text = dataGridView1.Rows[fila].Cells[5].Value.ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando la cantidad desde el grid");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    int fila = dataGridView1.CurrentRow.Index;
                    dataGridView1.Rows[fila].Cells[7].Value="0";
                    //dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error eliminando la fila seleccionada");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(cantidad_devolver_txt.Text) < Convert.ToDouble(Cantidad_grid_txt.Text))
                {
                    if (Cantidad_grid_txt.Text.Trim() != "")
                    {
                        if (cantidad_devolver_txt.Text.Trim() != "")
                        {
                            int fila = 0;
                            fila = dataGridView1.CurrentRow.Index;
                            dataGridView1.Rows[fila].Cells[7].Value = cantidad_devolver_txt.Text.Trim();
                            cantidad_devolver_txt.Clear();
                            Cantidad_grid_txt.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Falta la cantidad a devolver");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta que seleccione la fila que quiere afectar");
                    }
                }
                else
                {
                    MessageBox.Show("Cantidad mayor que la disponible en l compra");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error agregando la cantidad a devolver al grid");
            }
        }

        private void dataGridView2_compras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void ck_devueltas_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
        public void productos_devueltos()
        {
            dataGridView1.Rows.Clear();
            if (dataGridView2.Rows.Count > 0)
            {
                if (ck_devueltas.Checked == true)
                {
                    int fila = 0;
                    fila = dataGridView2.CurrentRow.Index;
                    dataGridView1.Rows.Clear();
                    string sql = "select  h.codigo_producto,p.nombre,h.codigo_unidad,u.nombre,h.costo,h.cantidad,(h.cantidad*h.costo)as importe from historial_devolucion_compras h join compra c on c.codigo=h.codigo_compra join producto p on p.codigo=h.codigo_producto join unidad u on u.codigo=h.codigo_unidad where c.codigo='" + dataGridView2.Rows[fila].Cells[0].Value.ToString() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe haber seleccionado una compra");
            }
        }

        private void ck_devueltas_Click(object sender, EventArgs e)
        {
            productos_devueltos();
        }
    }
}
