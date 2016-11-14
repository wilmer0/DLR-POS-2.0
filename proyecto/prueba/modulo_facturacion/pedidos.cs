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
    public partial class pedidos : Form
    {
        public pedidos()
        {
            InitializeComponent();
        }
        string monto_permitido = "0";
        private void button1_Click(object sender, EventArgs e)
        {
            busqueda_cliente bc = new busqueda_cliente();
            bc.pasado += new busqueda_cliente.pasar(ejecutar_codigo_cliente);
            bc.ShowDialog();
            cargar_nombre_cliente();
            cargar_limite_credito();
        }
        public void cargar_limite_credito()
        {
            try
            {
                string sql = "exec credito_venta_cliente '" + codigo_cliente_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    monto_permitido = (Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString())).ToString();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error cargando el limite de credito");
            }
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
        public void ejecutar_codigo_cliente(string dato)
        {
            codigo_cliente_txt.Text = dato.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buscar();
        }
        public void buscar()
        {

            dataGridView1.Rows.Clear();
            string sql = "select f.codigo,f.codigo_cliente,f.fecha,f.estado,f.autorizar_pedido,f.despachado from factura f where f.fecha>='" + fecha_inicial.Value.ToString("yyyy-MM-dd") + "' and f.fecha<='" + fecha_final.Value.ToString("yyyy-MM-dd") + "' and f.cod_vendedor>'0'";
            if (codigo_cliente_txt.Text.Trim() != "")
            {
                sql += " and f.codigo_cliente='" + codigo_cliente_txt.Text.Trim() + "'";
            }
            sql += " order by f.codigo desc";
            DataSet ds = Utilidades.ejecutarcomando(sql);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string codigo_cliente = row[1].ToString();
                string cmd = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + codigo_cliente.ToString() + "'";
                DataSet dx = Utilidades.ejecutarcomando(cmd);
                string nombre = dx.Tables[0].Rows[0][0].ToString();
                dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), nombre.ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                //activo
                if (row.Cells[4].Value.ToString() == "1")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.White;

                }
                //anulado
                if (row.Cells[4].Value.ToString() == "0")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                }
                //despachado
                if (row.Cells[6].Value.ToString() == "1")
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                }
                //falta autorizar
                if (row.Cells[5].Value.ToString() == "1")
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }

        }
        public void cargar_productos()
        {
            try
            {
                dataGridView2.Rows.Clear();
                int fila = dataGridView1.CurrentRow.Index;
                string sql = "select fd.cod_producto,p.nombre,fd.cod_unidad,u.nombre,fd.itebis,fd.precio,fd.cantidad,fd.monto from factura_detalle fd join producto p on fd.cod_producto=p.codigo join unidad u on u.codigo=fd.cod_unidad where fd.estado='1' and fd.cod_factura='" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView2.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString());
                }
                double total = 0;
                foreach(DataGridViewRow row in dataGridView2.Rows)
                {
                    total += Convert.ToDouble(row.Cells[7].Value.ToString());
                }
                cantidad_total_pedido_txt.Text = total.ToString("###,###,###,###,###,###.#0");
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando los productos del pedido");
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
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                limpiar();
            }
        }
        public void limpiar()
        {
            try
            {
                codigo_cliente_txt.Clear();
                nombre_cliente_txt.Clear();
                identificacion_txt.Clear();
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                fecha_inicial.Value = DateTime.Today;
                fecha_final.Value = DateTime.Today;
                buscar();
            }
            catch (Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }
        internal singleton s { get; set; }
        public delegate void pasar(string dato);
        public event pasar pasado;
       
        private void pedidos_Load(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            if (s.puede_despachar_pedidos == false)
            {
                button7.Enabled = false;
                button7.BackColor = Color.Black;
            }
            if (s.puede_autorizar_pedidos == false)
            {
                button6.Enabled = false;
                button6.BackColor = Color.Black;
            }
            buscar();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            cargar_productos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Desea editar el pedido?", "Editando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if(dataGridView1.Rows.Count>0)
                    {
                        int fila = dataGridView1.CurrentRow.Index;
                        if (dataGridView1.Rows[fila].Cells[4].Value.ToString() == "1")
                        {
                            string codigo = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                            pasado(codigo.ToString());
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El pedido seleccionado no esta activo, fue cancelado");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay pedidos que seleccionar");
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Error devolviendo el valor a la facturacion");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            DialogResult dr = MessageBox.Show("Desea anular el pedido?", "Anulando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                
                if (s.puede_anular_pedidos == true)
                {

                    int fila = dataGridView1.CurrentRow.Index;
                    if (dataGridView1.Rows[fila].Cells[4].Value.ToString() == "1")
                    {
                        if (detalles_txt.Text.Trim() != "")
                        {
                            
                            string sql = "update factura set estado='0',cod_empleado_anular='" + s.codigo_usuario.ToString() + "',motivo_anulada='" + detalles_txt.Text.Trim() + "' where codigo='" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "'";
                            DataSet ds = Utilidades.ejecutarcomando(sql);
                            foreach (DataGridViewRow row in dataGridView2.Rows)
                            {
                                //exec insert_entrada_salida_inventario 'pro','uni','can','mov','convepto','empl'
                                sql = "exec insert_entrada_salida_inventario '" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[6].Value.ToString() + "','E','Entrada directa por devolucion de pedidos','"+s.codigo_usuario.ToString()+"'";
                                Utilidades.ejecutarcomando(sql);
                            }
                            
                            MessageBox.Show("Pedido anulado");
                            buscar();
                        }
                        else
                        {
                            MessageBox.Show("Falta especificar el motivo para anular");
                        }

                    }
                    else
                    {
                        MessageBox.Show("El pedido no esta habilitado para cancelarlo, ya ha sido cancelado");
                    }   
                }
                else
                {
                     MessageBox.Show("No tienes permisos para anular pedidos");
                    
                }
            }
        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea autorizar el pedido?", "Autorizando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    s = singleton.obtenerDatos();
                    if (s.puede_autorizar_pedidos == true)
                    {
                        int fila = dataGridView1.CurrentRow.Index;
                        if (dataGridView1.Rows[fila].Cells[5].Value.ToString() == "1")
                        {

                            string sql = "update factura set autorizar_pedido='0' where codigo='" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "'";
                            DataSet ds = Utilidades.ejecutarcomando(sql);

                            MessageBox.Show("Pedido autorizado");
                            buscar();
                        }
                        else
                        {
                            MessageBox.Show("Este pedido no hay que autorizarlo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No tienes permisos para autorizar pedidos");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error autorizando el pedido");
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int fila=dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[fila].Cells[6].Value.ToString() == "0" && dataGridView1.Rows[fila].Cells[4].Value.ToString() == "1")
                {
                    DialogResult dr = MessageBox.Show("Desea facturar pedido?", "Facturando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        pago_desglose p = new pago_desglose();
                        p.total_esperado = cantidad_total_pedido_txt.Text.Trim();
                        p.efectivo_txt.Text = cantidad_total_pedido_txt.Text.Trim();
                        p.pasado += new pago_desglose.pasar(guardar);
                        p.ShowDialog();
                        buscar();
                        MessageBox.Show("Facturado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("Este pedido ya fue despachado o no esta habilitado, por favor revise su estado.");
                }
                buscar();
            }
            catch (Exception)
            {
                MessageBox.Show("Error facturando el pedido");
            }
        }
        public double efectivo_global = 0;
        public double devuelta_global = 0;
        public double cheque_global = 0;
        public double deposito_global = 0;
        public double tarjeta_global = 0;
        public int cod_orden_compra_global = 0;
        public double monto_orden_compra_global = 0;
        public void guardar(string efectivo, string devuelta, string cheque, string deposito, string tarjeta, string cod_orden_compra, string monto_orden_compra)
        {
            try
            {
                efectivo_global = Convert.ToDouble(efectivo.ToString());
                devuelta_global = Convert.ToDouble(devuelta.ToString());
                cheque_global = Convert.ToDouble(cheque.ToString());
                deposito_global = Convert.ToDouble(deposito.ToString());
                tarjeta_global = Convert.ToDouble(tarjeta.ToString());
                cod_orden_compra_global = Convert.ToInt16(cod_orden_compra.ToString());
                monto_orden_compra_global = Convert.ToDouble(monto_orden_compra.ToString());

                int fila = dataGridView1.CurrentRow.Index;
                string sql = "update factura set efectivo='" + efectivo_global.ToString() + "', devuelta ='" + devuelta_global.ToString() + "',cheque='" + cheque_global.ToString() + "',deposito='" + deposito_global.ToString() + "',tarjeta='" + tarjeta_global.ToString() + "',cod_orden_compra='" + cod_orden_compra_global.ToString() + "',monto_orden_compra='" + monto_orden_compra_global.ToString() + "',codigo_empleado='"+s.codigo_usuario.ToString()+"',pagada='1',despachado='1' where codigo='" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "'";
                Utilidades.ejecutarcomando(sql);
                MessageBox.Show("Facturado");
                buscar();
            }
            catch (Exception)
            {
                MessageBox.Show("Error facturando el pedido");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try 
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    int fila = dataGridView1.CurrentRow.Index;
                    DialogResult dr = MessageBox.Show("Desea imprimir el pedido en rollo?", "Imprimiendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        imprimir_venta_rollo iv = new imprimir_venta_rollo();
                        iv.codigo_factura = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                        iv.ShowDialog();
                    }
                    else
                    {
                        imprimir_venta_hoja_completa iv = new imprimir_venta_hoja_completa();
                        iv.codigo_factura = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                        iv.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("No hay elementos");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error imprimiendo el pedido");
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            codigo_cliente_txt.Clear();
            nombre_cliente_txt.Clear();
            identificacion_txt.Clear();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            cargar_productos();
        }
    }
}
