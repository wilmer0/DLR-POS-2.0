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
    public partial class permisos : Form
    {
        public permisos()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            busqueda_empleado be = new busqueda_empleado();
            be.pasado += new busqueda_empleado.pasar(ejecutar_codigo_empleado);
            be.ShowDialog();
            cargar_nombre_empleado();
            cargar_permisos();
        }
        public void ejecutar_codigo_empleado(string dato)
        {
            codigo_usuario_txt.Text = dato.ToString();
        }
        public void cargar_nombre_empleado()
        {
            try
            {
                string sql = "select t.nombre from tercero t where t.codigo='"+codigo_usuario_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_usuario_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando nombre del empleado");
            }
        }
        public void cargar_permisos()
        {
            try
            {
                string sql = "";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los permisos del usuario");
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
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    codigo_usuario_txt.Clear();
                    nombre_usuario_txt.Clear();
                    dataGridView1.Rows.Clear();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }
    }
}
