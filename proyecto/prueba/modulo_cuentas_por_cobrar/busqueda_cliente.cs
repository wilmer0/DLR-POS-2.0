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
    public partial class busqueda_cliente : Form
    {
        public busqueda_cliente()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {

        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        public bool mantenimiento = false;
        private void busqueda_cliente_Load(object sender, EventArgs e)
        {
            cargar_cliente();
        }
        public void cargar_cliente()
        {
            try
            {
                if (mantenimiento == true)
                {
                    string sql = "select t.codigo,t.nombre,p.apellido,(select sex.sexo from sexo sex where p.cod_sexo=sex.codigo) as sexo,t.identificacion,c.estado from tercero t join persona p on t.codigo=p.codigo join cliente c on p.codigo=c.codigo where c.estado='1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select t.codigo,t.nombre,p.apellido,(select sex.sexo from sexo sex where p.cod_sexo=sex.codigo) as sexo,t.identificacion,c.estado from tercero t join persona p on t.codigo=p.codigo join cliente c on p.codigo=c.codigo";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los clientes");
            }
        }
        private void nombre_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nombre_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select t.codigo,t.nombre,p.apellido,(select sex.sexo from sexo sex where p.cod_sexo=sex.codigo) as sexo,t.identificacion,c.estado from tercero t join persona p on t.codigo=p.codigo join cliente c on p.codigo=c.codigo where c.estado='1' and t.nombre like '%" + nombre_txt.Text + "%' or p.apellido like '%" + nombre_txt.Text.Trim() + "%' or t.identificacion like'%" + nombre_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select t.codigo,t.nombre,p.apellido,(select sex.sexo from sexo sex where p.cod_sexo=sex.codigo) as sexo,t.identificacion,c.estado from tercero t join persona p on t.codigo=p.codigo join cliente c on p.codigo=c.codigo where t.nombre like '%" + nombre_txt.Text + "%' or p.apellido like '%" + nombre_txt.Text.Trim() + "%' or t.identificacion like'%" + nombre_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los clientes");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cliente c= new cliente();
            c.ShowDialog();
        }
    }
}
