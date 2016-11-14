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
    public partial class busqueda_suplidor : Form
    {
        public busqueda_suplidor()
        {
            InitializeComponent();
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
        private void busqueda_suplidor_Load(object sender, EventArgs e)
        {
            cargar_suplidores();
        }
        public void cargar_suplidores()
        {
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select s.codigo,t.nombre,p.apellido,t.identificacion,s.estado from tercero t join persona p on t.codigo=p.codigo join suplidor s on s.codigo=p.codigo where s.estado='1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select s.codigo,t.nombre,p.apellido,t.identificacion,s.estado from tercero t join persona p on t.codigo=p.codigo join suplidor s on s.codigo=p.codigo";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los suplidores");
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo_sup = "";
                //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                codigo_sup = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                pasado(codigo_sup.ToString());
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error pasando variable hacia atras");
            }
        }

        private void nombre_suplidor_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (mantenimiento == false)
                {

                    string sql = "select s.codigo,t.nombre,p.apellido,t.identificacion,s.estado from tercero t join persona p on t.codigo=p.codigo join suplidor s on s.codigo=p.codigo where s.estado='1' and t.nombre like '%" + nombre_suplidor_txt.Text.Trim() + "%' or p.apellido like '%" + nombre_suplidor_txt.Text.Trim() + "%' or t.identificacion like '%" + nombre_suplidor_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select s.codigo,t.nombre,p.apellido,t.identificacion,s.estado from tercero t join persona p on t.codigo=p.codigo join suplidor s on s.codigo=p.codigo where t.nombre like '%" + nombre_suplidor_txt.Text.Trim() + "%' or p.apellido like '%" + nombre_suplidor_txt.Text.Trim() + "%' or t.identificacion like '%" + nombre_suplidor_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los suplidores");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            suplidores s = new suplidores();
            s.ShowDialog();
        }

        private void nombre_suplidor_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
