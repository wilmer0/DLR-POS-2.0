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
    public partial class busqueda_vendedores : Form
    {
        public busqueda_vendedores()
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

        private void button3_Click(object sender, EventArgs e)
        {
            vendedores ven = new vendedores();
            ven.ShowDialog();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        public bool mantenimiento = false;
        private void busqueda_vendedores_Load(object sender, EventArgs e)
        {
            cargar_datos();
        }
        public void cargar_datos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                if (mantenimiento == false)
                {
                    string sql = "select v.codigo,(t.nombre+' '+p.apellido),t.identificacion,v.estado from vendedor v join persona p on p.codigo=v.codigo join tercero t on t.codigo=v.codigo where v.estado='1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach(DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                    }
                }
                else
                {
                    string sql = "select v.codigo,(t.nombre+' '+p.apellido),t.identificacion,v.estado from vendedor v join persona p on p.codigo=v.codigo join tercero t on t.codigo=v.codigo";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los suplidores");
            }
        }

        private void nombre_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                if (mantenimiento == false)
                {
                    string sql = "select v.codigo,(t.nombre+' '+p.apellido),t.identificacion,v.estado from vendedor v join persona p on p.codigo=v.codigo join tercero t on t.codigo=v.codigo where v.estado='1' and nombre like '%"+nombre_txt.Text.Trim()+"%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                    }
                }
                else
                {
                    string sql = "select v.codigo,(t.nombre+' '+p.apellido),t.identificacion,v.estado from vendedor v join persona p on p.codigo=v.codigo join tercero t on t.codigo=v.codigo where and nombre like '%"+nombre_txt.Text.Trim()+"%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los suplidores");
            }
        }
    }
}
