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
using System.Data.Sql;

namespace puntoVenta
{
    public partial class busqueda_caja : Form
    {
        public busqueda_caja()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
        
        public delegate void pasar(string dato);
        public event pasar pasado;
        public bool mantenimiento = false;
        internal singleton s { get; set; }
        public string codigo_sucursal = null;
        
        private void busqueda_caja_Load(object sender, EventArgs e)
        {
            cargar_caja();
        }
        public void cargar_caja()
        {
            try
            {
                if(codigo_sucursal != null && mantenimiento==false)
                {
                    s = singleton.obtenerDatos();
                    string sql = "select c.codigo,c.nombre,c.estado from caja c join sucursal s on s.codigo=c.cod_sucursal where s.codigo='"+codigo_sucursal.ToString()+"' and c.estado='1'";
                    //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (codigo_sucursal != null && mantenimiento == true)
                {
                    s = singleton.obtenerDatos();
                    string sql = "select c.codigo,c.nombre,c.estado from caja c where c.cod_sucursal='" + codigo_sucursal.ToString() + "'";
                    //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if(codigo_sucursal==null && mantenimiento==false)
                {
                    s = singleton.obtenerDatos();
                    string sql = "select c.codigo,c.nombre,c.estado from caja c where c.cod_sucursal='" + s.codigo_sucursal.ToString() + "' and c.estado='1'";
                    //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (codigo_sucursal == null && mantenimiento == true)
                {
                    s = singleton.obtenerDatos();
                    string sql = "select c.codigo,c.nombre,c.estado from caja c where c.cod_sucursal='" + s.codigo_sucursal.ToString() + "'";
                    //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las cajas");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = "";
                //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                codigo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                pasado(codigo.ToString());
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error pasando variable hacia atras");
            }
        }

        private void nombre_txt_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void nombre_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (codigo_sucursal == null && mantenimiento==false)
                {
                    //MessageBox.Show(s.codigo_usuario.ToString());
                    string sql = "select c.codigo,c.nombre,c.estado from caja c join sucursal s on s.codigo=c.cod_sucursal join empleado e on e.cod_sucursal=s.codigo where c.estado='1' and e.codigo='" + s.codigo_usuario + "' and c.nombre like '%" + nombre_txt.Text.Trim() + "%'";
                    //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if(codigo_sucursal!=null && mantenimiento==true)
                {
                    s = singleton.obtenerDatos();
                    string sql = "select c.codigo,c.nombre,c.estado from caja c where  c.cod_sucursal='" + codigo_sucursal.ToString() + "' and c.nombre like '%"+nombre_txt.Text.Trim()+"%'";
                    //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (codigo_sucursal != null && mantenimiento ==false)
                {
                    s = singleton.obtenerDatos();
                    string sql = "select c.codigo,c.nombre,c.estado from caja c where c.estado='1' and  c.cod_sucursal='" + codigo_sucursal.ToString() + "' and c.nombre like '%" + nombre_txt.Text.Trim() + "%'";
                    //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando las cajas");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            caja c = new caja();
            c.ShowDialog();
        }
    }
}
