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
    public partial class entrada_salida_inventario : Form
    {
        public entrada_salida_inventario()
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea dar salida de este producto?", "Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (Convert.ToDouble(cantidad_txt.Text.Trim())<= Convert.ToDouble(existencia_txt.Text.Trim()))
                    {
                        //salida
                        //int fila = dataGridView1.CurrentRow.Index;
                        if (codigo_producto_txt.Text.Trim() != "")
                        {
                            if (codigo_unidad_txt.Text.Trim() != "")
                            {
                                if (cantidad_txt.Text.Trim() != "")
                                {
                                    int fila = dataGridView1.CurrentRow.Index;
                                    //bajando la unidad que se entrara o saldra
                                    dataGridView1.Rows[fila].Cells[2].Value = codigo_unidad_txt.Text.Trim();
                                    dataGridView1.Rows[fila].Cells[3].Value = unidad_combo_txt.Text.Trim();
                                
                                    //bajando la cantidad y que salga
                                    dataGridView1.Rows[fila].Cells[5].Value = cantidad_txt.Text.Trim();
                                    dataGridView1.Rows[fila].Cells[6].Value = "S";
                                }
                                else
                                {
                                    MessageBox.Show("Falta la cantidad");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Falta el codigo de la unidad");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta el producto");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad debe ser mayor o igual al que queda en inventario");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error dando salida");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea dar entrada a este producto?", "Entrada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //entrada
                    
                    //int fila = dataGridView1.CurrentRow.Index;
                    if (codigo_producto_txt.Text.Trim() != "")
                    {
                        if (codigo_unidad_txt.Text.Trim() != "")
                        {
                            if (cantidad_txt.Text.Trim() != "")
                            {
                                int fila = dataGridView1.CurrentRow.Index;
                                //bajando la unidad que se entrara o saldra
                                dataGridView1.Rows[fila].Cells[2].Value = codigo_unidad_txt.Text.Trim();
                                dataGridView1.Rows[fila].Cells[3].Value = unidad_combo_txt.Text.Trim();
                                
                                //poniendo la cantidad y que sea entrada
                                dataGridView1.Rows[fila].Cells[5].Value = cantidad_txt.Text.Trim();
                                dataGridView1.Rows[fila].Cells[6].Value = "E";
                            }
                            else
                            {
                                MessageBox.Show("Falta la cantidad");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta el codigo de la unidad");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el producto");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error dando entrada");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

                s = singleton.obtenerDatos();
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (concepto_txt.Text.Trim() != "")
                    {
                       //guardar
                        /*
                         insert_entrada_salida_inventario
                         @cod_prod int,@cod_unidad int,@cantidad float ,@mov varchar(5),@concepto varchar(200),@cod_empleado int
                         */
                        string sql = "";
                        DataSet ds = new DataSet();
                        if (dataGridView1.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.Cells[6].Value != "")
                                {
                                    sql = "exec insert_entrada_salida_inventario '" + row.Cells[0].Value + "','" + row.Cells[2].Value + "','" + row.Cells[5].Value + "','" + row.Cells[6].Value + "','" + concepto_txt.Text.Trim() + "','" + s.codigo_usuario.ToString() + "'";
                                    Utilidades.ejecutarcomando(sql);
                                }
                            }
                            MessageBox.Show("Finalizado");
                            cargar_productos();
                        }
                        else
                        {
                            MessageBox.Show("No hay productos");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Falta el concepto o motivo por el cual realiza este movimiento");
                   }
                }
            
        }
        private void entrada_salida_inventario_Load(object sender, EventArgs e)
        {
            

        }
        public void cargar_productos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                if (codigo_sucursal_txt.Text.Trim() != "")
                {
                    string sql = "select p.codigo,p.nombre,uni.codigo,uni.nombre,sum(inve.existencia)as existencia from producto p join almacen a on p.cod_almacen=a.codigo join sucursal s on s.codigo=a.cod_sucursal join unidad uni on uni.codigo=p.cod_unidad_minima join inventario inve on inve.codigo_producto=p.codigo and inve.codigo_unidad=p.cod_unidad_minima where p.codigo>'0' and a.cod_sucursal='"+codigo_sucursal_txt.Text.Trim()+"'";
                    if (codigo_almacen_txt.Text.Trim() != "")
                    {
                        sql += " and p.cod_almacen='"+codigo_almacen_txt.Text.Trim()+"'";
                    }
                    if (ck_producto_activo.Checked == true)
                    {
                        sql += " and p.estado='1'";
                    }
                    sql += " group by p.codigo,p.nombre,uni.codigo,uni.nombre";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                    }
                    
                }
                else
                {
                    MessageBox.Show("Falta la sucursal");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el inventario");
            }
        }

        private void ck_producto_activo_Click(object sender, EventArgs e)
        {
            //cargar_productos();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }
        public void cargar_unidades()
        {
            try
            {
                string sql = "select u.nombre,u.codigo from producto_unidad p join unidad u on p.cod_unidad=u.codigo where p.cod_producto='" + codigo_producto_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                unidad_combo_txt.ValueMember = "nombre";
                unidad_combo_txt.DisplayMember = "nombre";
                unidad_combo_txt.DataSource = ds.Tables[0];
                codigo_unidad_txt.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro cargando el codigo de la unidad");
            }
        }

        private void cantidad_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if(Utilidades.numero_decimal(cantidad_txt.Text.Trim())==false)
            {
                cantidad_txt.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    codigo_producto_txt.Clear();
                    nombre_producto_txt.Clear();
                    codigo_unidad_txt.Clear();
                    //nombre_unidad_txt.Clear();
                    existencia_txt.Clear();
                    cantidad_txt.Clear();
                    concepto_txt.Clear();

                    dataGridView1.Rows.Clear();
                    cargar_productos();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            busqueda_sucursal bs = new busqueda_sucursal();
            bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal);
            bs.ShowDialog();
            cargar_productos();
        }
        public void ejecutar_codigo_sucursal(string dato)
        {
            try
            {
                codigo_sucursal_txt.Text = dato.ToString();
                if (codigo_sucursal_txt.Text.Trim() != "")
                {
                    string sql = "select nombre from tercero where codigo='" + codigo_sucursal_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                    codigo_almacen_txt.Clear();
                    nombre_almacen_txt.Clear();
                    dataGridView1.Rows.Clear();
                }
            }
            catch (Exception)
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            busqueda_almacen ba = new busqueda_almacen();
            ba.codigo_sucursal = codigo_sucursal_txt.Text.Trim();
            ba.pasado += new busqueda_almacen.pasar(ejecutar_codigo_almacen);
            ba.ShowDialog();
            cargar_productos();
            
        }
        public void ejecutar_codigo_almacen(string dato)
        {
            try
            {
                codigo_almacen_txt.Text = dato.ToString();
                if (codigo_almacen_txt.Text.Trim() != "")
                {
                    string sql = "select nombre from almacen where codigo='" + codigo_almacen_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_almacen_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.ToString());
            }
        }

        private void codigo_producto_txt_TextChanged(object sender, EventArgs e)
        {
            cargar_unidades();
        }
        public void cargar_existencia_producto()
        {
            try
            {
                /*
                 create proc mostrar_existencia_producto
                 @cod_prod int,@cod_unidad int
                 */
                if (codigo_producto_txt.Text.Trim() != "")
                {
                    if (codigo_unidad_txt.Text.Trim() != "")
                    {
                        string sql = "exec mostrar_existencia_producto '" + codigo_producto_txt.Text.Trim() + "','" + codigo_unidad_txt.Text.Trim() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        //de aqui en adelante es para el control de conversion de inventario
                        double sumatoria_existencia = 0;
                        sql = "select cod_unidad from producto_unidad_conversion where cod_producto='" + codigo_producto_txt.Text.Trim() + "'";
                        ds = Utilidades.ejecutarcomando(sql);
                        //para sumar las existencia de todas las unidades* la unidad minima del mismo producto
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            string cmd = "select sum(i.existencia*pc.cantidad) from inventario i join producto_unidad_conversion pc on i.codigo_unidad=pc.cod_unidad and pc.cod_producto=i.codigo_producto where i.codigo_producto='" + codigo_producto_txt.Text.Trim() + "' and i.codigo_unidad='" + row[0].ToString() + "'";
                            DataSet dx = Utilidades.ejecutarcomando(cmd);
                            if (dx.Tables[0].Rows[0][0].ToString() != "")
                            {
                                sumatoria_existencia += Convert.ToDouble(dx.Tables[0].Rows[0][0].ToString());
                            }
                        }
                        sql = "select cantidad from producto_unidad_conversion where cod_producto='" + codigo_producto_txt.Text.Trim() + "' and cod_unidad='" + codigo_unidad_txt.Text.Trim() + "'";
                        ds = Utilidades.ejecutarcomando(sql);
                        double cantidad_convercion = 1;
                        if (ds.Tables[0].Rows[0][0].ToString() != "")
                        {
                            cantidad_convercion = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                        }
                        existencia_txt.Text = (sumatoria_existencia / cantidad_convercion).ToString("###,###,###,###,###,###.#0");
                        //hasta aqui el control de conversion de unidades
                    }
                }

            }
            catch (Exception)
            {
                //MessageBox.Show("Error cargando la existencia del producto");
                existencia_txt.Text = "0";
            }
        }

        private void unidad_combo_txt_TextChanged(object sender, EventArgs e)
        {
            cambio_unidad();
        }
        public void cambio_unidad()
        {
            try
            {
                int cont = 0;
                try
                {
                    if (codigo_producto_txt.Text.Trim() != "")
                    {
                        string sql = "select codigo from unidad where nombre='" + unidad_combo_txt.Text.Trim() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        codigo_unidad_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                        cargar_existencia_producto();
                       
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error cargando codigo de la unidad");
                }
            }
            catch (Exception)
            {

            }
        }
        public void cargar_precio_unidad()
        {
            try
            {
                //precio_txt.Clear();
                string sql = "select distinct top(1) precio from inventario where codigo_producto='" + codigo_producto_txt.Text.Trim() + "' and codigo_unidad='" + codigo_unidad_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                double precio = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                //precio_txt.Text = precio.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el precio de la unidad");
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            busqueda_producto bp = new busqueda_producto();
            bp.codigo_sucursal = s.codigo_sucursal.ToString();
            bp.pasado += new busqueda_producto.pasar(ejecutar_codigo_producto);
            bp.ShowDialog();
            cargar_nombre_producto();
        }
        public void ejecutar_codigo_producto(string dato)
        {
            codigo_producto_txt.Text = dato.ToString();
        }
        public void cargar_nombre_producto()
        {
            try
            {
                if(codigo_producto_txt.Text.Trim()!="")
                {
                    string sql = "select nombre from producto where codigo='"+codigo_producto_txt.Text.Trim()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_producto_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando el nombre del producto");
            }
        }

        private void ck_producto_activo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int fila = 0;
                fila = dataGridView1.CurrentRow.Index;
                codigo_producto_txt.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                nombre_producto_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                codigo_unidad_txt.Text = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                unidad_combo_txt.Text = dataGridView1.Rows[fila].Cells[3].Value.ToString();
                existencia_txt.Text = dataGridView1.Rows[fila].Cells[4].Value.ToString();
                //exec mostrar_existencia_producto 'cod_producto','cod_unidad'
                string sql ="exec mostrar_existencia_producto '"+codigo_producto_txt.Text.Trim()+"','"+codigo_unidad_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                string exis = ds.Tables[0].Rows[0][0].ToString();
                existencia_txt.Text = exis.ToString();
                cargar_unidades();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro subiendo los datos del inventario");
            }
        }
    }
}
