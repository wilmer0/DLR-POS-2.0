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
    public partial class busqueda_entrada_salida_inventario : Form
    {
        public busqueda_entrada_salida_inventario()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            busqueda_empleado be = new busqueda_empleado();
            be.pasado += new busqueda_empleado.pasar(ejecutar_codigo_empleado);
            be.ShowDialog();
        }
        public void ejecutar_codigo_empleado(string dato)
        {
            try
            {
                codigo_empleado_txt.Text = dato.ToString();
                string sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + codigo_empleado_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_empleado_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {

            }
        }
        internal singleton s { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            busqueda_sucursal bs = new busqueda_sucursal();
            bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal);
            bs.ShowDialog();
        }
        public void ejecutar_codigo_sucursal(string dato)
        {
            codigo_sucursal_txt.Text = dato.ToString();
            string sql = "select nombre from tercero where codigo='"+codigo_sucursal_txt.Text.Trim()+"'";
            DataSet ds = Utilidades.ejecutarcomando(sql);
            nombre_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscar();
        }
        public void buscar()
        {
            
                dataGridView1.Rows.Clear();
                string sql = "select es.codigo,es.cod_producto,p.nombre,es.cod_unidad,uni.nombre,es.cantidad,es.tipo_movimiento,es.motivo,es.fecha,(t.nombre+' '+per.apellido) as empleado from entrada_salida_inventario es join producto p on p.codigo=es.cod_producto join unidad uni on uni.codigo=es.cod_unidad join almacen a on a.codigo=p.cod_almacen join sucursal s on s.codigo=a.cod_sucursal join tercero t on t.codigo=es.cod_empleado_cambio join persona per on per.codigo=t.codigo where es.codigo>0 ";
                if (codigo_sucursal_txt.Text.Trim() != "")
                {
                    sql += " and s.codigo='" + codigo_sucursal_txt.Text.Trim() + "'";
                }
                if (codigo_almacen_txt.Text.Trim() != "")
                {
                    sql += " and p.cod_almacen='" + codigo_almacen_txt.Text.Trim() + "'";
                }
                if (codigo_empleado_txt.Text.Trim() != "")
                {
                    sql += " and es.cod_empleado_cambio='" + codigo_empleado_txt.Text.Trim() + "'";
                }
                sql += " and es.fecha>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and es.fecha<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
                sql += " order by es.codigo desc";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString());
                }
            
        }
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void busqueda_entrada_salida_inventario_Load(object sender, EventArgs e)
        {

        }

        private void codigo_almacen_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(codigo_sucursal_txt.Text.Trim()!="")
            {
                busqueda_almacen ba = new busqueda_almacen();
                ba.codigo_sucursal = codigo_sucursal_txt.Text.Trim();
                ba.pasado += new busqueda_almacen.pasar(ejecutar_codigo_almacen);
                ba.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe elegir la sucursal");
            }
        }
        public void ejecutar_codigo_almacen(string dato)
        {
            codigo_almacen_txt.Text = dato.ToString();
            string sql = "select nombre from almacen where codigo='" + codigo_almacen_txt.Text.Trim() + "'";
            DataSet ds = Utilidades.ejecutarcomando(sql);
            nombre_almacen_txt.Text = ds.Tables[0].Rows[0][0].ToString();
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void nombre_sucursal_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void codigo_sucursal_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void codigo_empleado_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void nombre_empleado_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void nombre_almacen_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            codigo_sucursal_txt.Clear();
            nombre_sucursal_txt.Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            codigo_empleado_txt.Clear();
            nombre_empleado_txt.Clear();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            codigo_almacen_txt.Clear();
            nombre_almacen_txt.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
