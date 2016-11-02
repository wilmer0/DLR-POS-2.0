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
    public partial class busqueda_existencia : Form
    {

        //variables
        string codigo_empresa = "";


        public busqueda_existencia()
        {
            InitializeComponent();
        }
        singleton s { get; set; }
        private void busqueda_existencia_Load(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            codigo_empresa = s.codigo_empresa;
            codigo_sucursal_txt.Text = s.codigo_sucursal.ToString();
            cargar_nombre_sucursal();
            cargar_productos();
        }
        public void cargar_productos()
        {
            
            try
            {
                dataGridView1.Rows.Clear();
                if (codigo_sucursal_txt.Text.Trim() != "")
                {
                    string sql = "select distinct pro.codigo,pro.nombre,pro.referencia,uni.codigo,uni.nombre,pro.reorden,pc.costo,pc.precio_venta from producto pro join producto_unidad_conversion pc on pc.cod_producto=pro.codigo join unidad uni on uni.codigo=pc.cod_unidad join inventario i on i.codigo_producto=pro.codigo and i.codigo_unidad=uni.codigo join almacen a on a.codigo=pro.cod_almacen where pro.codigo>'0'";
                    if (codigo_sucursal_txt.Text.Trim() != "")
                    {
                        sql += " and a.cod_sucursal='" + codigo_sucursal_txt.Text.Trim() + "'";
                    }
                    if (codigo_almacen_txt.Text.Trim() != "")
                    {
                        sql += " and a.codigo='" + codigo_almacen_txt.Text.Trim() + "'";
                    }
                    if (nombre_producto_txt.Text.Trim() != "")
                    {
                        sql += " and pro.nombre like '%" + nombre_producto_txt.Text.Trim() + "%'";
                    }
                    if (codigo_categoria_txt.Text.Trim() != "")
                    {
                        sql += " and pro.cod_categoria='" + codigo_categoria_txt.Text.Trim() + "'";
                    }
                    if (codigo_subcategoria_txt.Text.Trim() != "")
                    {
                        sql += " and pro.cod_subcategoria='" + codigo_subcategoria_txt.Text.Trim() + "'";
                    }
                    sql += " order by pro.nombre desc";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        /*
                         create proc mostrar_existencia_unidad_mina
                         @cod_pro int
    
                         */
                        string cmd = "exec mostrar_existencia_unidad_minima '"+row[0].ToString()+"'";
                        DataSet dx = Utilidades.ejecutarcomando(cmd);
                        double existencia = 0;
                        if (dx.Tables[0].Rows[0][0].ToString() != "")
                        {
                            existencia = Convert.ToDouble(dx.Tables[0].Rows[0][0].ToString());
                        }
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), existencia.ToString("N"), row[5].ToString(),row[6].ToString(),row[7].ToString());
                    }


                    //para sombrear si la existencia es menor que el reorden
                    foreach(DataGridViewRow row in dataGridView1.Rows)
                    {
                        if(Convert.ToDouble(row.Cells[5].Value)<=Convert.ToDouble(row.Cells[6].Value))
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                            row.DefaultCellStyle.SelectionBackColor = Color.DarkOrange;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falta la sucursal");
                    nombre_producto_txt.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error cargando productos.:"+ex.ToString());
            }
            
        }

        private void nombre_txt_KeyUp(object sender, KeyEventArgs e)
        {
            cargar_productos();
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
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                limpiar();
            }
        }
        public void limpiar()
        {
            try
            {
               
                codigo_sucursal_txt.Clear();
                nombre_sucursal_txt.Clear();
                codigo_almacen_txt.Clear();
                nombre_almacen_txt.Clear();
                nombre_producto_txt.Clear();
                codigo_categoria_txt.Clear();
                nombre_categoria_txt.Clear();
                codigo_subcategoria_txt.Clear();
                nombre_subcategoria_txt.Clear();
                dataGridView1.Rows.Clear();
            }
            catch(Exception)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_categoria bc = new busqueda_categoria();
            bc.pasado += new busqueda_categoria.pasar(ejecutar_codigo_categoria);
            bc.ShowDialog();
            cargar_nombre_categoria();
            nombre_subcategoria_txt.Clear();
            codigo_subcategoria_txt.Clear();
            cargar_productos();
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
                MessageBox.Show("Error sacando el nombre de la categoria");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            busqueda_subcategoria bs = new busqueda_subcategoria();
            bs.pasado += new busqueda_subcategoria.pasar(ejecutar_codigo_subcategoria);
            bs.codigo_categoria_global = codigo_categoria_txt.Text.Trim();
            bs.ShowDialog();
            cargar_nombre_subcategoria();
            cargar_productos();
        }
        public void ejecutar_codigo_subcategoria(string dato)
        {
            codigo_subcategoria_txt.Text = dato.ToString();
        }
        public void cargar_nombre_subcategoria()
        {
            try
            {
                string sql = "select nombre from subcategoria_producto where codigo='"+codigo_subcategoria_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_subcategoria_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error sacando el nombre de la subcategoria");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea aplicar el valor ponderado?", "Aplicando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    /*
                        create proc inventario_ponderado
                        @cod_producto int,@cod_unidad int
                     */
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string sql = "exec inventario_ponderado '" + row.Cells[0].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "'";
                        Utilidades.ejecutarcomando(sql);
                    }
                    MessageBox.Show("Procesado");
                    cargar_productos();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error aplicando el valor ponderado");
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (codigo_empresa!= "")
            {
                busqueda_sucursal bs = new busqueda_sucursal();
                bs.codigo_empresa_global = codigo_empresa;
                bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal);
                bs.ShowDialog();
                codigo_almacen_txt.Clear();
                nombre_almacen_txt.Clear();
                cargar_productos();
            }
            else
            {
                MessageBox.Show("Falta el codigo de la empresa");
            }
        }
        public void ejecutar_codigo_sucursal(string dato)
        {
            try
            {
                codigo_sucursal_txt.Text = dato.ToString();
                cargar_nombre_sucursal();
            }
            catch(Exception)
            {

            }
        }
        public void cargar_nombre_sucursal()
        {
            if (codigo_sucursal_txt.Text.Trim() != "")
            {
                string sql = "select nombre from tercero where codigo='" + codigo_sucursal_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(codigo_sucursal_txt.Text.Trim()!="")
            {
                busqueda_almacen ba = new busqueda_almacen();
                ba.codigo_sucursal = codigo_sucursal_txt.Text.Trim();
                ba.pasado += new busqueda_almacen.pasar(ejecutar_codigo_almacen);
                ba.ShowDialog();
                cargar_productos();
            }
            else
            {
                MessageBox.Show("Falta la sucursal");
            }
        }
        public void ejecutar_codigo_almacen(string dato)
        {
            try
            {
                codigo_almacen_txt.Text = dato.ToString();
                string sql = "select nombre from almacen where codigo='" + codigo_almacen_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_almacen_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {

            }
        }

        private void nombre_txt_TextChanged(object sender, EventArgs e)
        {
            cargar_productos();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                busqueda_empresa be = new busqueda_empresa();
                be.pasado += new busqueda_empresa.pasar(ejecutar_codigo_empresa);
                be.ShowDialog();
                dataGridView1.Rows.Clear();
            }
            catch(Exception)
            {

            }
        }
        public void ejecutar_codigo_empresa(string dato)
        {
            try
            {
                //codigo_empresa_txt.Text = dato.ToString();
                //string sql = "select nombre from tercero where codigo='" + codigo_empresa_txt.Text.Trim() + "'";
                //DataSet ds = Utilidades.ejecutarcomando(sql);
                //nombre_empresa_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                //codigo_sucursal_txt.Clear();
                //nombre_sucursal_txt.Clear();
                //codigo_almacen_txt.Clear();
                //nombre_almacen_txt.Clear();
                
            }
            catch(Exception)
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            codigo_sucursal_txt.Clear();
            nombre_sucursal_txt.Clear();
            cargar_productos();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            codigo_almacen_txt.Clear();
            nombre_almacen_txt.Clear();
            cargar_productos();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            codigo_categoria_txt.Clear();
            nombre_categoria_txt.Clear();
            cargar_productos();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            codigo_subcategoria_txt.Clear();
            nombre_subcategoria_txt.Clear();
            cargar_productos();
        }
    }
}
