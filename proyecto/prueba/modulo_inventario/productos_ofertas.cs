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
    public partial class productos_ofertas : Form
    {
        public productos_ofertas()
        {
            InitializeComponent();
        }
        internal singleton s { get; set; }
        private void button7_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            busqueda_producto bp = new busqueda_producto();
            bp.pasado += new busqueda_producto.pasar(ejecutar_codigo_producto);
            bp.codigo_sucursal = s.codigo_sucursal.ToString();
            bp.mantenimiento = true;
            bp.ShowDialog();
            cargar_nombre_producto();
            
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
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre del producto");
            }
        }
        public void ejecutar_codigo_producto(string dato)
        {
            codigo_producto_txt.Text = dato.ToString();
        }
        public void cargar_datos_producto()
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
                MessageBox.Show("Error cargando el nombre del producto");
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
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                limpiar();
            }
        }
        public void limpiar()
        {
            try
            {
                codigo_oferta_txt.Clear();
                nombre_oferta_txt.Clear();
                ck_activo.Checked = true;
                fecha_inicial.Value = DateTime.Today;
                Fecha_final.Value = DateTime.Today;
                descuento_txt.Text = "0";
                cargar_ofertas();

            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }
        public void cargar_ofertas()
        {
            try
            {
                s = singleton.obtenerDatos();
                dataGridView3.Rows.Clear();
                string sql = "select codigo,nombre,descuento,fecha_inicial,fecha_final,estado from producto_oferta where cod_sucursal='"+s.codigo_sucursal.ToString()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView3.Rows.Add(row[0].ToString(),row[1].ToString(),row[2].ToString(),row[3].ToString(),row[4].ToString(),row[5].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando las ofertas");
            }
        }

        private void productos_ofertas_Load(object sender, EventArgs e)
        {
            cargar_ofertas();
            
        }
        public void cargar_ofertas_productos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                s=singleton.obtenerDatos();
                if(codigo_oferta_producto_txt.Text.Trim()!="")
                {
                    dataGridView1.Rows.Clear();
                    string sql = "select od.cod_oferta,ofe.nombre,pro.codigo,pro.nombre from oferta_producto_detalle od join producto pro on pro.codigo=od.cod_prod join producto_oferta ofe on ofe.codigo=od.cod_oferta where od.cod_oferta='"+codigo_oferta_producto_txt.Text.Trim()+"' and od.estado='1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach(DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(),row[1].ToString(),row[2].ToString(),row[3].ToString());
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los productos de la oferta");
            }
        }

        private void descuento_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if(Utilidades.numero_decimal(descuento_txt.Text.Trim())==false)
            {
                descuento_txt.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                s = singleton.obtenerDatos();
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (nombre_oferta_txt.Text.Trim() != "")
                    {
                        int activo = 0;
                        if (ck_activo.Checked == true)
                        {
                            activo = 1;
                        }
                        else
                        {
                            activo = 0;
                        }
                        if (Convert.ToDouble(descuento_txt.Text.Trim()) >= 0)
                        {
                            if(codigo_oferta_txt.Text.Trim()=="")
                            {
                                //guarda
                                /*
                                 create proc insert_producto_oferta
                                 @nombre varchar(max),@descuento float,@fecha_i date,@fecha_f date,@estado int,@codigo int
                                */
                                string sql = "exec insert_producto_oferta '" + nombre_oferta_txt.Text.Trim() + "','" + descuento_txt.Text.Trim() + "','" + fecha_inicial.Value.ToString("yyyy-MM-dd") + "','" + Fecha_final.Value.ToString("yyyy-MM-dd") +"','"+activo.ToString()+"','"+s.codigo_sucursal.ToString()+ "','0'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show("Se agrego");
                                    cargar_ofertas();
                                }
                                else
                                {
                                    MessageBox.Show("No se agrego");
                                }
                            }
                            else
                            {
                                //actualiza
                                string sql = "exec insert_producto_oferta '" + nombre_oferta_txt.Text.Trim() + "','" + descuento_txt.Text.Trim() + "','" + fecha_inicial.Value.ToString("yyyy-MM-dd") + "','" + Fecha_final.Value.ToString("yyyy-MM-dd") +"','"+activo.ToString()+ "','"+s.codigo_sucursal.ToString()+"','"+codigo_oferta_txt.Text.Trim()+"'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show("Se actualizo");
                                    cargar_ofertas();
                                }
                                else
                                {
                                    MessageBox.Show("No se actualizo");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("El descuento tiene que ser igual o mayor a cero.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el nombre");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error guardando la oferta");
            }
        }
        public void guardar()
        {
           
              
            
        }
        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    string sql = "";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    /*
                     create proc insert_producto_oferta_categoria
                     @cod_oferta int,@cod_categoria int,@cod_subcategoria int,@estado int

                     */
                    sql = "";
                    Utilidades.ejecutarcomando(sql);
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        sql = "exec insert_producto_oferta_categoria '" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "','1'";
                        ds = Utilidades.ejecutarcomando(sql);
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Se agrego");
                    }
                    else
                    {
                        MessageBox.Show("No se agrego");
                    }
                }
            }
            catch(Exception)
            {

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string sql = "";
                DataSet ds = Utilidades.ejecutarcomando(sql);

                if (codigo_oferta_producto_txt.Text.Trim() != "")
                {
                    if (codigo_producto_txt.Text.Trim() != "")
                    {
                        /*
                         create proc insert_producto_oferta_producto
                         @cod_oferta int,@cod_prod int
                         */
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            sql = "exec insert_producto_oferta_producto '" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "'";
                            ds = Utilidades.ejecutarcomando(sql);
                        }
                        MessageBox.Show("Finalizado");

                    }
                    else
                    {
                        MessageBox.Show("Falta el producto");
                    }
                }
                else
                {
                    MessageBox.Show("Falta la oferta");
                }
            }
        }
        
        private void dataGridView3_Click(object sender, EventArgs e)
        {
            seleccion();
        }
        public void seleccion()
        {
            try
            {
                int fila = dataGridView3.CurrentRow.Index;
                codigo_oferta_txt.Text = dataGridView3.Rows[fila].Cells[0].Value.ToString();
                nombre_oferta_txt.Text = dataGridView3.Rows[fila].Cells[1].Value.ToString();
                descuento_txt.Text = dataGridView3.Rows[fila].Cells[2].Value.ToString();
                fecha_inicial.Value = Convert.ToDateTime(dataGridView3.Rows[fila].Cells[3].Value.ToString());
                Fecha_final.Value = Convert.ToDateTime(dataGridView3.Rows[fila].Cells[4].Value.ToString());
                if (dataGridView3.Rows[fila].Cells[5].Value.ToString() == "1")
                {
                    ck_activo.Checked = true;
                }
                else
                {
                    ck_activo.Checked = false;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error seleccionando la oferta");
            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            seleccion();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            busqueda_ofertas_productos bo = new busqueda_ofertas_productos();
            bo.pasado += new busqueda_ofertas_productos.pasar(ejecutar_codigo_oferta);
            bo.codigo_sucursal_global = s.codigo_sucursal.ToString();
            bo.ShowDialog();
            cargar_nombre_oferta();
            cargar_ofertas_productos();
        }
        public void ejecutar_codigo_oferta(string dato)
        {
            codigo_oferta_producto_txt.Text = dato.ToString();
        }
        public void cargar_nombre_oferta()
        {
            try
            {
                if(codigo_oferta_producto_txt.Text.Trim()!="")
                {
                    string sql = "select nombre from producto_oferta where estado='1' and codigo='" + codigo_oferta_producto_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_oferta_producto_txt.Text= ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando nombre de la oferta productos");
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea eliminar el articulo seleccionado?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    }
                    else
                    {
                        dr = MessageBox.Show("No hay elementos para eliminar", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error eliminando la fila seleccionada");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea eliminar la fila seleccionada?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                    }
                    else
                    {
                        dr = MessageBox.Show("No hay elementos para eliminar", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error eliminando la fila seleccionada");
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                if (codigo_oferta_producto_txt.Text.Trim()!="")
                {
                    if(codigo_producto_txt.Text.Trim()!="")
                    {
                        dataGridView1.Rows.Add(codigo_oferta_producto_txt.Text.Trim(), nombre_oferta_producto_txt.Text.Trim(), codigo_producto_txt.Text.Trim(), nombre_producto_txt.Text.Trim());
                    }
                    else
                    {
                        MessageBox.Show("Falta el producto");
                    }
                }
                else
                {
                    MessageBox.Show("Falta la oferta");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error agregando el producto a la oferta");
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (codigo_categoria_txt.Text.Trim() != "")
            {
                busqueda_subcategoria bs = new busqueda_subcategoria();
                bs.codigo_categoria_global = codigo_categoria_txt.Text.Trim();
                bs.pasado += new busqueda_subcategoria.pasar(ejecutar_codigo_subcategoria);
                bs.ShowDialog();
                cargar_nombre_subcategoria();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una categoria");
            }
        }
        public void ejecutar_codigo_subcategoria(string dato)
        {
            codigo_subcategoria_producto_txt.Text = dato.ToString();
        }
        public void cargar_nombre_subcategoria()
        {
            if(codigo_subcategoria_producto_txt.Text.Trim()!="")
            {
                string sql = "select nombre from subcategoria_producto where codigo='"+codigo_subcategoria_producto_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_subcategoria_producto_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int cont = 0;//para saber si se repite
                if (codigo_oferta_categoria_txt.Text.Trim() != "")
                {
                    if (codigo_categoria_txt.Text.Trim() != "")
                    {
                        
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == codigo_oferta_categoria_txt.Text.Trim() && row.Cells[2].Value.ToString() == codigo_categoria_txt.Text.Trim() && row.Cells[4].Value.ToString() == codigo_subcategoria_producto_txt.Text.Trim())
                            {
                                cont++;
                            }
                        }
                        if (cont == 0)
                        {
                            //agregar al grid
                            dataGridView2.Rows.Add(codigo_oferta_categoria_txt.Text.Trim(), nombre_oferta_categoria_txt.Text.Trim(), codigo_categoria_txt.Text.Trim(), nombre_categoria_txt.Text.Trim(), codigo_subcategoria_producto_txt.Text.Trim(), nombre_subcategoria_producto_txt.Text.Trim());
                        }
                        else
                        {
                            MessageBox.Show("La oferta seleccionada con la categoria seleccionada  y la sub-categoria ya se encuentra en uso");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta la categoria");
                    }
                }
                else
                {
                    MessageBox.Show("Falta la oferta");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error seleccionando");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            busqueda_categoria bc = new busqueda_categoria();
            bc.pasado += new busqueda_categoria.pasar(ejecutar_codigo_categoria);
            bc.ShowDialog();
            cargar_nombre_categoria();
        }
        public void cargar_nombre_categoria()
        {
            if(codigo_categoria_txt.Text.Trim()!="")
            {
                string sql = "select nombre from categoria_producto where codigo='"+codigo_categoria_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_categoria_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
        }
        public void ejecutar_codigo_categoria(string dato)
        {
            codigo_categoria_txt.Text = dato.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            busqueda_ofertas_productos bo = new busqueda_ofertas_productos();
            bo.pasado += new busqueda_ofertas_productos.pasar(ejecutar_codigo_oferta_categoria);
            bo.codigo_sucursal_global = s.codigo_sucursal.ToString();
            bo.ShowDialog();
            cargar_nombre_oferta_categoria();
            buscar_categorias_en_ofertas();
        }
        public void buscar_categorias_en_ofertas()
        {
            try
            {
                dataGridView2.Rows.Clear();
                if(codigo_oferta_categoria_txt.Text.Trim()!="")
                {
                    string sql = "select ofe.cod_oferta,po.nombre,ofe.cod_categoria,cp.nombre,ofe.cod_subcategoria,sp.nombre from oferta_producto_subcate_detalle ofe join categoria_producto cp on ofe.cod_categoria=cp.codigo join subcategoria_producto sp on ofe.cod_subcategoria=sp.codigo join producto_oferta po on po.codigo=ofe.cod_oferta where ofe.cod_oferta='" + codigo_oferta_categoria_txt.Text.Trim() + "' and po.cod_sucursal='"+s.codigo_sucursal.ToString()+"' and ofe.estado='1'"; 
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach(DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView2.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando las categorias que estan vinculadas a esta oferta");
            }
        }
        public void ejecutar_codigo_oferta_categoria(string dato)
        {
            codigo_oferta_categoria_txt.Text = dato.ToString();
        }
        public void cargar_nombre_oferta_categoria()
        {
            try
            {
                if (codigo_oferta_categoria_txt.Text.Trim() != "")
                {
                    string sql = "select nombre from producto_oferta where estado='1' and codigo='" + codigo_oferta_categoria_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_oferta_categoria_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando nombre de la oferta productos categoria");
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            codigo_subcategoria_producto_txt.Clear();
            nombre_subcategoria_producto_txt.Clear();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            codigo_categoria_txt.Clear();
            nombre_categoria_txt.Clear();
            codigo_subcategoria_producto_txt.Clear();
            nombre_subcategoria_producto_txt.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            limpiar_oferta_categoria();
        }
        public void limpiar_oferta_categoria()
        {
            dataGridView2.Rows.Clear();
            codigo_oferta_categoria_txt.Clear();
            nombre_oferta_categoria_txt.Clear();
            codigo_categoria_txt.Clear();
            nombre_categoria_txt.Clear();
            codigo_subcategoria_producto_txt.Clear();
            nombre_subcategoria_producto_txt.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            codigo_oferta_txt.Clear();
            nombre_oferta_txt.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            busqueda_ofertas_productos bo = new busqueda_ofertas_productos();
            bo.codigo_sucursal_global = s.codigo_sucursal.ToString();
            bo.pasado += new busqueda_ofertas_productos.pasar(ejecutar_codigo_oferta_oferta);
            bo.ShowDialog();
            
        }
        public void ejecutar_codigo_oferta_oferta(string dato)
        {
           
            try
            {
                codigo_oferta_txt.Text = dato.ToString();
                if (codigo_oferta_txt.Text.Trim() != "")
                {
                    string sql = "select nombre from producto_oferta where estado='1' and codigo='" + codigo_oferta_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_oferta_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando el nombre de la oferta");
            }

        }
       
    }
}
