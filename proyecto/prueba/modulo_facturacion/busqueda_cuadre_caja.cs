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
    public partial class busqueda_cuadre_caja : Form
    {
        public busqueda_cuadre_caja()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            busqueda_cuadre bc = new busqueda_cuadre();
            bc.pasado += new busqueda_cuadre.pasar(ejecutar_codigo_cuadre);
            bc.ShowDialog();
        }
        public void ejecutar_codigo_cuadre(string dato)
        {
            codigo_cuadre_txt.Text = dato.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_cajero bca = new busqueda_cajero();
            bca.pasado += new busqueda_cajero.pasar(ejecutar_codigo_cajero);
            bca.ShowDialog();
            cargar_nombre_cajero();
        }
        public void ejecutar_codigo_cajero(string dato)
        {
            codigo_cajero_txt.Text = dato.ToString();
        }
        public void cargar_nombre_cajero()
        {
            try
            {
                if (codigo_cajero_txt.Text.Trim() != "")
                {
                    string sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='"+codigo_cajero_txt.Text.Trim()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_cajero_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el nombre del cajero");
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
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                limpiar();
            }
        }
        public void limpiar()
        {
            try
            {
                dataGridView1.Rows.Clear();
                codigo_cajero_txt.Clear();
                nombre_cajero_txt.Clear();
                codigo_cuadre_txt.Clear();
            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select c.codigo,c.cod_cajero,(t.nombre+' '+p.apellido),c.fecha,c.turno,c.efectivo,c.cheque,c.transferencia,c.tarjeta,c.efectivo_inicial,c.sobrante,c.faltante  from cuadre_caja c join tercero t on t.codigo=c.cod_cajero join persona p on t.codigo=p.codigo where c.estado='1' and c.abierta_cerrada='C'";
                if(codigo_cuadre_txt.Text.Trim()!="")
                {
                    sql+=" and c.codigo='"+codigo_cuadre_txt.Text.Trim()+"'";
                }
                if(codigo_cajero_txt.Text.Trim()!="")
                {
                    sql += " and c.cod_cajero='"+codigo_cajero_txt.Text.Trim()+"'";
                }
                sql += " order by c.fecha desc";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(),row[1].ToString(),row[2].ToString(),row[3].ToString(),row[4].ToString(),row[5].ToString(),row[6].ToString(),row[7].ToString(),row[8].ToString(),row[9].ToString(),row[10].ToString(),row[11].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            codigo_cuadre_txt.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            codigo_cajero_txt.Clear();
            nombre_cajero_txt.Clear();
        }

    }
}
