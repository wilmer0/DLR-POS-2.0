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
    public partial class nomina_tipos : Form
    {
        public nomina_tipos()
        {
            InitializeComponent();
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

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                guardar();
            }
        }
        public void guardar()
        {
            /*
                create proc insert_nomina_tipo
                @nombre varchar(max),@estado int,@codigo int
             */
            if(nombre_tipo_nomina_txt.Text.Trim()!="")
            {
                int estado = 0;
                if(ck_activo.Checked==true)
                {
                    estado = 1;
                }
                else
                {
                    estado = 0;
                }
                if(codigo_tipo_nomina_txt.Text.Trim()=="")
                {
                    //guarda
                    string sql = "exec insert_nomina_tipo '"+nombre_tipo_nomina_txt.Text.Trim()+"','"+estado.ToString()+"','0'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    if(ds.Tables[0].Rows.Count>0)
                    {
                        MessageBox.Show("Se guardo");
                        cargar_datos();
                    }
                    else
                    {
                        MessageBox.Show("No se guardo");
                    }
                }
                else
                {
                    //actualiza
                    string sql = "exec insert_nomina_tipo '" + nombre_tipo_nomina_txt.Text.Trim() + "','" + estado.ToString() + "','"+codigo_tipo_nomina_txt.Text.Trim()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Se actualizo");
                        cargar_datos();
                    }
                    else
                    {
                        MessageBox.Show("No se actualizo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Falta el nombre");
            }
        }

        private void nomina_tipos_Load(object sender, EventArgs e)
        {
            cargar_datos();
        }
        public void cargar_datos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select codigo,nombre,estado from nomina_tipos";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(),row[1].ToString(),row[2].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los datos");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int fila = dataGridView1.CurrentRow.Index;
                codigo_tipo_nomina_txt.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                nombre_tipo_nomina_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                if(dataGridView1.Rows[fila].Cells[2].Value.ToString()=="1")
                {
                    ck_activo.Checked = true;
                }
                else
                {
                    ck_activo.Checked = false;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error seleccionando");
            }
        }
    }
}
