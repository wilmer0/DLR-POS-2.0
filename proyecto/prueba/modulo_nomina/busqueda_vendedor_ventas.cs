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
    public partial class busqueda_vendedor_pedidos : Form
    {
        public busqueda_vendedor_pedidos()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
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
                codigo_vendedor_txt.Clear();
                nombre_vendedor_txt.Clear();
                codigo_cliente_txt.Clear();
                nombre_cliente_txt.Clear();
                fecha_inicial.Value = DateTime.Today;
                fecha_final.Value = DateTime.Today;
                dataGridView1.Rows.Clear();
            }
            catch(Exception)
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                guardar();
            }
        }
        public void guardar()
        {
            try
            {

            }
            catch(Exception)
            {

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            busqueda_vendedores bv = new busqueda_vendedores();
            bv.pasado += new busqueda_vendedores.pasar(ejecutar_codigo_vendedor);
            bv.ShowDialog();
            
        }
        public void ejecutar_codigo_vendedor(string dato)
        {
            codigo_vendedor_txt.Text = dato.ToString();
        }
        public void cargar_nombre_vendedor()
        {
            try
            {
                if(codigo_vendedor_txt.Text.Trim()!="")
                {
                    string sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='"+codigo_vendedor_txt.Text.Trim()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_vendedor_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre del empleado");
            }
        }
        internal singleton s { get; set; }
        private void busqueda_vendedor_pedidos_Load(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
           
        }
       

        private void button2_Click(object sender, EventArgs e)
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
                if(codigo_cliente_txt.Text.Trim()!="")
                {
                    string sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='"+codigo_cliente_txt.Text.Trim()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_cliente_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre del cliente");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select f.codigo,(f.efectivo-f.devuelta) as efectivo,f.tarjeta,f.cheque,f.deposito,f.cod_vendedor,f.fecha from factura f join tercero t on t.codigo=f.cod_vendedor join persona p on p.codigo=t.codigo where f.estado='1' and f.cod_vendedor!='0' and f.despachado='1' and f.fecha>='"+fecha_inicial.Value.ToString("yyyy-MM-dd")+"' and f.fecha<='"+fecha_final.Value.ToString("yyyy-MM-dd")+"'";
                if(codigo_vendedor_txt.Text.Trim()!="")
                {
                    sql+=" and f.cod_vendedor='"+codigo_vendedor_txt.Text.Trim()+"'";
                }
                if(codigo_cliente_txt.Text.Trim()!="")
                {
                    sql += " and f.codigo_cliente='"+codigo_cliente_txt.Text.Trim()+"'";
                }
                sql += " order by f.codigo desc";
                
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    string cmd = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='"+row[5].ToString()+"'";
                    DataSet dx = Utilidades.ejecutarcomando(cmd);
                    string nombre_vendedor = dx.Tables[0].Rows[0][0].ToString();
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(),nombre_vendedor.ToString(), row[6].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando");
            }
        }
    }
}
