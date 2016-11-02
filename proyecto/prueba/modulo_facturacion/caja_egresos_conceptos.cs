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
    public partial class caja_egresos_conceptos : Form
    {
        public caja_egresos_conceptos()
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

        private void button1_Click(object sender, EventArgs e)
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
                cargar_egresos();
                codigo_egreso_txt.Clear();
                nombre_egreso_txt.Clear();
                ck_activo.Checked = true;
            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }

        private void button7_Click(object sender, EventArgs e)
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
                /*
                 create proc insert_egreso_caja_concepto
                 @nombre varchar(max),@estado int,@codigo int
                 */
                if(nombre_egreso_txt.Text.Trim()!="")
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
                    if(codigo_egreso_txt.Text.Trim()=="")
                    {
                        //guarda
                        string sql = "exec insert_egreso_caja_concepto '"+nombre_egreso_txt.Text.Trim()+"','"+estado.ToString()+"','0'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if(ds.Tables[0].Rows.Count>0)
                        {
                            MessageBox.Show("Se guardo");
                            cargar_egresos();
                        }
                        else
                        {
                            MessageBox.Show("No se guardo");
                        }
                    }
                    else
                    {
                        //actualiza
                        string sql = "exec insert_egreso_caja_concepto '" + nombre_egreso_txt.Text.Trim() + "','" + estado.ToString() + "','" + codigo_egreso_txt.Text.Trim() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Se actualizo");
                            cargar_egresos();
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
            catch(Exception)
            {
                MessageBox.Show("Error guardando");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void caja_egresos_conceptos_Load(object sender, EventArgs e)
        {
            cargar_egresos();
        }
        public void cargar_egresos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select codigo,nombre,estado from egresos_conceptos";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los datos");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int fila=dataGridView1.CurrentRow.Index;
                codigo_egreso_txt.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                nombre_egreso_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
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

        private void button11_Click(object sender, EventArgs e)
        {
            busqueda_egresos_caja_conceptos be = new busqueda_egresos_caja_conceptos();
            be.pasado += new busqueda_egresos_caja_conceptos.pasar(ejecutar_codigo_egreso);
            be.ShowDialog();
            cargar_nombre_egreso();
        }
        public void ejecutar_codigo_egreso(string dato)
        {
            codigo_egreso_txt.Text = dato.ToString();
        }
        public void cargar_nombre_egreso()
        {
            try
            {
                if (codigo_egreso_txt.Text.Trim() != "")
                {
                    string sql = "select  nombre,estado from egresos_conceptos where codigo='"+codigo_egreso_txt.Text.Trim()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_egreso_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                    if(ds.Tables[0].Rows[0][1].ToString()=="1")
                    {
                        ck_activo.Checked=true;
                    }
                    else
                    {
                        ck_activo.Checked=false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            codigo_egreso_txt.Clear();
            nombre_egreso_txt.Clear();
            ck_activo.Checked = true;
        }
    }
}
