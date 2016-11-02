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
    public partial class observaciones_empleados : Form
    {
        public observaciones_empleados()
        {
            InitializeComponent();
        }

        public void cargar_observaciones()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select codigo,observacion from tercero_observaciones where cod_tercero='"+codigo_empleado_txt.Text.Trim()+"' and estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando las observacion del empleado");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            busqueda_empleado be = new busqueda_empleado();
            be.pasado += new busqueda_empleado.pasar(ejecutar_codigo_empleado);
            be.ShowDialog();
            cargar_nombre_empleado();
            cargar_observaciones();
        }
        public void cargar_nombre_empleado()
        {
            try
            {
                string sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='"+codigo_empleado_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_empleado_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando nombre del empleado");
            }
        }
        public void ejecutar_codigo_empleado(string dato)
        {
            codigo_empleado_txt.Text = dato.ToString();
            cargar_nombre_empleado();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //guardar
                /*
                 create proc insert_obervaciones_tercero
                 @cod_tercero int,@observacion varchar(500),@entidad varchar(3)
                 */
                try
                {
                    if(codigo_empleado_txt.Text.Trim()!="")
                    {
                        if(observacion_txt.Text.Trim()!="")
                        {
                            string sql = "exec insert_obervaciones_tercero '"+codigo_empleado_txt.Text.Trim()+"','"+observacion_txt.Text.Trim()+"','EMP'";
                            DataSet ds = Utilidades.ejecutarcomando(sql);
                            if(ds.Tables[0].Rows.Count>0)
                            {
                                MessageBox.Show("Se guardo");
                            }
                            else
                            {
                                MessageBox.Show("No se guardo");
                            }
                            observacion_txt.Focus();
                            cargar_observaciones();
                        }
                        else
                        {
                            MessageBox.Show("La observacion no puede estar vacia");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Falta seleccionar el empleado");
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }
        private void observaciones_empleados_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("Desea anular la observacion seleccionada?", "Anulando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        //create proc anular_observacion_tercero @codigo int    
                        string sql = "exec anular_observacion_tercero '"+dataGridView1.CurrentRow.Cells[0].Value.ToString()+"'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if(ds.Tables[0].Rows.Count>0)
                        {
                            MessageBox.Show("Se anulo la observacion");
                            cargar_observaciones();
                        }
                        else
                        {
                            MessageBox.Show("No se anulo la observacion");
                        }   
                    }
                }
                else
                {
                    DialogResult dr = MessageBox.Show("No hay elementos para eliminar", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error eliminando la fila seleccionada");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    codigo_empleado_txt.Clear();
                    nombre_empleado_txt.Clear();
                    observacion_txt.Clear();
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
