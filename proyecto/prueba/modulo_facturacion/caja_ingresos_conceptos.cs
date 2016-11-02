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


namespace puntoVenta.modulo_facturacion
{
    public partial class caja_ingresos_conceptos : Form
    {
        public caja_ingresos_conceptos()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            busqueda_ingresos_caja_conceptos be = new busqueda_ingresos_caja_conceptos();
            be.pasado += new busqueda_ingresos_caja_conceptos.pasar(ejecutar_codigo_ingreso);
            be.ShowDialog();
            cargar_nombre_ingreso();
        }
        public void ejecutar_codigo_ingreso(string dato)
        {
            codigo_ingreso_txt.Text = dato;
        }
        public void cargar_nombre_ingreso()
        {
            try
            {
                if (codigo_ingreso_txt.Text.Trim() != "")
                {
                    string sql = "select  nombre,estado from ingresos_conceptos where codigo='" + codigo_ingreso_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_ingreso_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                    if (ds.Tables[0].Rows[0][1].ToString() == "1")
                    {
                        ck_activo.Checked = true;
                    }
                    else
                    {
                        ck_activo.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int fila = dataGridView1.CurrentRow.Index;
                codigo_ingreso_txt.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                nombre_ingreso_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                if (dataGridView1.Rows[fila].Cells[2].Value.ToString() == "1")
                {
                    ck_activo.Checked = true;
                }
                else
                {
                    ck_activo.Checked = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error seleccionando");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            codigo_ingreso_txt.Clear();
            nombre_ingreso_txt.Clear();
            ck_activo.Checked = true;
        }

        private void caja_ingresos_conceptos_Load(object sender, EventArgs e)
        {
            cargar_ingresos();
        }
        public void cargar_ingresos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select codigo,nombre,estado from ingresos_conceptos";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando los datos: "+ex.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                if (nombre_ingreso_txt.Text.Trim() != "")
                {

                    int estado = 0;
                    if (ck_activo.Checked == true)
                    {
                        estado = 1;
                    }
                    else
                    {
                        estado = 0;
                    }
                    if (codigo_ingreso_txt.Text.Trim() == "")
                    {
                        //guarda
                        string sql = "exec insert_ingreso_caja_concepto '" + nombre_ingreso_txt.Text.Trim() + "','" + estado.ToString() + "','0'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Se guardo", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargar_ingresos();
                        }
                        else
                        {
                            MessageBox.Show("No se guardo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        //actualiza
                        string sql = "exec insert_ingreso_caja_concepto '" + nombre_ingreso_txt.Text.Trim() + "','" + estado.ToString() + "','" + codigo_ingreso_txt.Text.Trim() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Se actualizo","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            cargar_ingresos();
                        }
                        else
                        {
                            MessageBox.Show("No se actualizo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falta el nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error guardando", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cargar_ingresos();
                codigo_ingreso_txt.Clear();
                nombre_ingreso_txt.Clear();
                ck_activo.Checked = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }
    }
}
