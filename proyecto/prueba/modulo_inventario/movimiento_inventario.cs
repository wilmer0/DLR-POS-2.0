using puntoVenta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puntoVenta
{
    public partial class movimiento_inventario : Form
    {
        public movimiento_inventario()
        {
            InitializeComponent();
        }
        internal singleton s { get; set; }
        
        private void inventario_Load(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();    
            codigo_sucursal_origen_txt.Text = s.codigo_sucursal.ToString();
            codigo_sucursal_destino_txt.Text = s.codigo_sucursal.ToString();
            
            panel_transferir.Enabled = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
             *  para hacer los movimineot usar tipo movimiento string es decir una sola letra
             *  entrada E
             *  salida S
             *  tranferencia T, y listo
             */
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                s = singleton.obtenerDatos();
                if(codigo_producto_txt.Text.Trim()!="")
                {
                    if(codigo_unidad_txt.Text.Trim()!="")
                    {
                        if(Convert.ToDouble(existecia_txt.Text.Trim())>0)
                        {
                            string sql = "";
                            DataSet ds = Utilidades.ejecutarcomando(sql);
                            if(ds.Tables[0].Rows.Count>0)
                            {
                                MessageBox.Show("Se guardo");
                            }
                            else
                            {
                                MessageBox.Show("No se guardo");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay suficiente existencia");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta la unidad");
                    }
                }
                else
                {
                    MessageBox.Show("Falta el producto");
                }
            }
        }

        private void ck_entrada_Click(object sender, EventArgs e)
        {
            try
            {
                ck_entrada.Checked = true;
                ck_salida.Checked = false;
                ck_transferir.Checked = false;
                panel_transferir.Enabled = false;
                panel1.Enabled = true;
            }
            catch(Exception)
            {
                MessageBox.Show("Error en check entrada");
            }
        }

        private void ck_salida_Click(object sender, EventArgs e)
        {
            try
            {
                ck_entrada.Checked = false;
                ck_salida.Checked = true;
                ck_transferir.Checked = false;
                panel_transferir.Enabled = false;
                panel1.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error en check salida");
            }
        }

        private void ck_transferir_Click(object sender, EventArgs e)
        {
            try
            {
                ck_entrada.Checked = false;
                ck_salida.Checked = false;
                ck_transferir.Checked = true;
                panel_transferir.Enabled = true;
                panel1.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error en check tranferencia");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            producto p = new producto();
            p.ShowDialog();
        }

        private void ck_transferir_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            facturacion f = new facturacion();
            f.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_producto p = new busqueda_producto();
            p.pasado += new busqueda_producto.pasar(ejecutar_codigo_producto);
            p.ShowDialog();
            cargar_nombre_producto();
            cargar_unidades();
            cargar_existencia_producto();
        }
        public void cargar_existencia_producto()
        {
            try
            {
                string sql = "select p.existencia from inventario p where p.codigo_producto='" + codigo_producto_txt.Text.Trim() + "' and p.codigo_unidad='" + codigo_unidad_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows[0][0].ToString() == "")
                {
                    existecia_txt.Text = "0";
                }
                else
                {
                    existecia_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }

            }
            catch (Exception)
            {
                //MessageBox.Show("Error cargando la existencia del producto");
                existecia_txt.Text = "0";
            }
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
        public void ejecutar_codigo_producto(string dato)
        {
            codigo_producto_txt.Text = dato.ToString();
        }
        public void cargar_nombre_producto()
        {
            try
            {
                string sql = "select nombre from producto where codigo='" + codigo_producto_txt.Text.Trim() +"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_producto_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                MessageBox.Show("Error sacando el nombre del producto");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //limpiar ventana
                cantidad_txt.Clear();
                codigo_unidad_txt.Clear();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //limpiar ventana
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                s = singleton.obtenerDatos();

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("Desea anular el movimiento seleccionado?", "Anulando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int fila = dataGridView1.CurrentRow.Index;
                        //dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    }
                }
                else
                {
                    DialogResult dr = MessageBox.Show("No hay elementos para eliminar", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error eliminando la fila seleccionada");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            busqueda_sucursal bs = new busqueda_sucursal();
            bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal_origen);
            bs.ShowDialog();
            
        }
        public void ejecutar_codigo_sucursal_origen(string dato)
        {
            codigo_sucursal_origen_txt.Text = dato.ToString();
        }
        public void cargar_nombre_unidad()
        {
            try
            {
                /*
                string sql = "select nombre from unidad where estado='1' and codigo='"+codigo_unidad_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                unidad_combo_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                nombre_unidad_transferir_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                */
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando nombre de la unidad");
            }
        }
        public void cargar_existencia()
        {
            try
            {
                string sql = "select cantidad from existencia_vs_unidad where cod_producto='"+codigo_producto_txt.Text.Trim()+"' and cod_unidad='"+codigo_unidad_txt.Text.Trim()+"'";
                DataSet ds= Utilidades.ejecutarcomando(sql);
               existecia_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                existencia_transferir_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando exitencia");
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            busqueda_unidad bu = new busqueda_unidad();
            bu.codigo_producto = codigo_producto_txt.Text.Trim();
            bu.pasado += new busqueda_unidad.pasar(ejecutar_codigo_unidad);
            bu.ShowDialog();
            cargar_nombre_unidad();
            cargar_existencia();
        }
        public void ejecutar_codigo_unidad(string dato)
        {
            codigo_unidad_transferir_txt.Text = dato.ToString();
            codigo_unidad_txt.Text = dato.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            busqueda_unidad bu = new busqueda_unidad();
            bu.codigo_producto = codigo_producto_txt.Text.Trim();
            bu.pasado += new busqueda_unidad.pasar(ejecutar_codigo_unidad);
            bu.ShowDialog();
            cargar_nombre_unidad();
            cargar_existencia();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            busqueda_almacen ba = new busqueda_almacen();
            ba.codigo_sucursal = codigo_sucursal_origen_txt.Text.Trim();
            ba.pasado += new busqueda_almacen.pasar(ejecutar_codigo_almacen_origen);
            ba.ShowDialog();
        }
        public void ejecutar_codigo_almacen_origen(string dato)
        {
            codigo_almacen_origen_txt.Text = dato.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            busqueda_sucursal bs = new busqueda_sucursal();
            bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal_destino);
            bs.ShowDialog();
        }
        public void ejecutar_codigo_sucursal_destino(string dato)
        {
            codigo_sucursal_destino_txt.Text = dato.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            busqueda_almacen ba = new busqueda_almacen();
            ba.codigo_sucursal = codigo_almacen_destino_txt.Text.Trim();
            ba.pasado += new busqueda_almacen.pasar(ejecutar_codigo_almacen_destino);
            ba.ShowDialog();
        }
        public void ejecutar_codigo_almacen_destino(string dato)
        {
            codigo_almacen_destino_txt.Text = dato.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cantidad_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if(Utilidades.numero_decimal(cantidad_txt.Text.Trim())==false)
            {
                cantidad_txt.Clear();
            }
        }

        private void unidad_combo_txt_TextChanged(object sender, EventArgs e)
        {
            int cont = 0;
            try
            {
                string sql = "select codigo from unidad where nombre='" + unidad_combo_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                codigo_unidad_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                cargar_existencia_producto();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando codigo de la unidad");
            }
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            s=singleton.obtenerDatos();
            busqueda_almacen ba = new busqueda_almacen();
            ba.pasado += new busqueda_almacen.pasar(ejecutar_codigo_almacen);
            ba.codigo_sucursal = s.codigo_sucursal.ToString();
            ba.ShowDialog();
            cargar_nombre_almacen();
        }

        public void ejecutar_codigo_almacen(string dato)
        {
            codigo_almacen_txt.Text = dato.ToString();
        }
        public void cargar_nombre_almacen()
        {
            try
            {
                string sql = "select nombre from almacen where codigo='"+codigo_almacen_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_almacen_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre del almacen");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea quitar?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //limpiar ventana
                cantidad_txt.Clear();
                codigo_unidad_txt.Clear();
            }
        }
    }
}
