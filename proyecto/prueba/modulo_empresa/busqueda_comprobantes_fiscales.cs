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
    public partial class busqueda_comprobantes_fiscales : Form
    {
        public busqueda_comprobantes_fiscales()
        {
            InitializeComponent();
        }
        internal singleton s { get; set; }
        private void busqueda_comprobantes_fiscales_Load(object sender, EventArgs e)
        {

        }
        public void buscar_comprobantes()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select cf.codigo,cs.nombre,cs.serie,c.nombre,ct.nombre,ct.secuencia,cf.desde_numero,cf.hasta_numero,cf.contador from comprobante_fiscal cf join comprobante_serie cs on cf.cod_serie=cs.codigo join caja c on cf.cod_caja=c.codigo join tipo_comprobante_fiscal ct on cf.codigo_tipo=ct.codigo join comprobante_ventas cv on cv.cod_caja=c.codigo where cv.cod_tipo_comprobante=ct.codigo and c.cod_sucursal='"+codigo_sucursal_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando los comprobantes fiscales de la sucursal");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            busqueda_empresa be = new busqueda_empresa();
            be.pasado += new busqueda_empresa.pasar(ejecutar_codigo_empresa);
            be.ShowDialog();
            cargar_nombre_empresa();
        }
        public void ejecutar_codigo_empresa(string dato)
        {
            codigo_empresa_txt.Text = dato.ToString();
        }
        public void cargar_nombre_empresa()
        {
            try
            {
                string sql = "select nombre from tercero where codigo='" + codigo_empresa_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_empresa_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el nombre de la empresa");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (codigo_empresa_txt.Text.Trim() != "")
                {
                    s = singleton.obtenerDatos();
                    busqueda_sucursal bs = new busqueda_sucursal();
                    bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal);
                    bs.codigo_empresa_global = codigo_empresa_txt.Text.Trim();
                    bs.ShowDialog();
                    cargar_nombre_sucursal(); 
                }
                else
                {
                    MessageBox.Show("Debe elegir una empresa");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("SU USUARIO NO TIENE NINGUNA EMPRESA");
            }
        }
        public void cargar_nombre_sucursal()
        {
            try
            {
                string sql = "select nombre from tercero where codigo='" + codigo_sucursal_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando nombre de sucursal");
            }
        }
        public void ejecutar_codigo_sucursal(string dato)
        {
            codigo_sucursal_txt.Text = dato.ToString();
            cargar_nombre_sucursal();
            buscar_comprobantes();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
                codigo_empresa_txt.Clear();
                nombre_empresa_txt.Clear();
                codigo_sucursal_txt.Clear();
                nombre_sucursal_txt.Clear();
                dataGridView1.Rows.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea eliminar el comprobante?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int fila = dataGridView1.CurrentRow.Index;
                string sql = "delete from comprobante_ventas where codigo='" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "'";
                Utilidades.ejecutarcomando(sql);
                sql = "delete from comprobante_fiscal where codigo='" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "'";
                Utilidades.ejecutarcomando(sql);
                buscar_comprobantes();
            }
        }
    }
}
