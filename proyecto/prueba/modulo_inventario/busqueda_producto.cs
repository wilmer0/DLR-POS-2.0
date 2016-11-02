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
    public partial class busqueda_producto : Form
    {
        public busqueda_producto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = "";
                //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                codigo= dataGridView1.CurrentRow.Cells[0].Value.ToString();
                pasado(codigo.ToString());
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error pasando variable hacia atras");
            }
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        public bool mantenimiento = false;
        public string codigo_sucursal = "";
        private void busqueda_producto_Load(object sender, EventArgs e)
        {
            cargar_producto();
            nombre_txt.Focus();
        }
        public void cargar_producto()
        {
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select p.codigo,p.nombre,p.reorden,p.referencia as referencia,i.it,p.estado from  producto p join itebis i on p.cod_itebis=i.codigo join almacen a on a.codigo=p.cod_almacen join sucursal s on s.codigo=a.cod_sucursal where  p.estado='1' and s.codigo='" + codigo_sucursal.ToString() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select p.codigo,p.nombre,p.reorden,p.referencia as referencia,i.it,p.estado from producto p join itebis i on p.cod_itebis=i.codigo join almacen a on a.codigo=p.cod_almacen join sucursal s on s.codigo=a.cod_sucursal where  s.codigo='" + codigo_sucursal.ToString() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                nombre_txt.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los productos");
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
        private void nombre_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select p.codigo,p.nombre,p.reorden,p.referencia as referencia,i.it,p.estado from producto p join itebis i on p.cod_itebis=i.codigo join almacen a on a.codigo=p.cod_almacen join sucursal s on s.codigo=a.cod_sucursal where p.estado='1' and s.codigo='"+codigo_sucursal.ToString()+"' and (p.nombre like '%" + nombre_txt.Text.Trim() + "%' or p.referencia like '%" + nombre_txt.Text.Trim() + "%')";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select p.codigo,p.nombre,p.reorden,p.referencia as referencia,i.it,p.estado from producto p join itebis i on p.cod_itebis=i.codigo join almacen a on a.codigo=p.cod_almacen join sucursal s on s.codigo=a.cod_sucursal where  s.codigo='" + codigo_sucursal.ToString() + "' and (p.nombre like '%" + nombre_txt.Text.Trim() + "%' or p.referencia like '%" + nombre_txt.Text.Trim() + "%')";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
                {
                    dataGridView1.Focus();
                }
                

            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los productos");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            producto p = new producto();
            p.ShowDialog();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    button1.PerformClick();
                }
                if (e.KeyCode == Keys.Tab)
                {
                    nombre_txt.Focus();
                }
            }
            catch(Exception)
            {

            }
        }
    }
}
