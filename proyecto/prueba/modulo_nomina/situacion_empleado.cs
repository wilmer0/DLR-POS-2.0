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
    public partial class situacion_empleado : Form
    {
        public situacion_empleado()
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
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    codigo_situacion_empleado_txt.Clear();
                    nombre_situacion_txt.Clear();
                    dataGridView1.Rows.Clear();
                    ck_estado.Checked = true;
               

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        
        private void situacion_empleado_Load(object sender, EventArgs e)
        {
            cargar_situaciones();
        }
        public void cargar_datos()
        {
            try
            {
                string sql = "select codigo,descripcion, estado from situacion_empleado where codigo='"+codigo_situacion_empleado_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_situacion_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                if (ds.Tables[0].Rows[0][2].ToString() == "True")
                    ck_estado.Checked = true;
                else
                    ck_estado.Checked = false;
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los datos de la situacion");
            }
        }
        public void cargar_situaciones()
        {
            try
            {
                string sql = "select codigo,descripcion,estado from situacion_empleado where estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando las situaciones");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = "";
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

        
        public void seleccion()
        {
            try
            {
               codigo_situacion_empleado_txt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
               nombre_situacion_txt.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();

               if (dataGridView1.CurrentRow.Cells[2].Value.ToString() =="True")
                   ck_estado.Checked = true;
               else
                   ck_estado.Checked = false;
            }
            catch(Exception)
            {
                MessageBox.Show("Error seleccionando la fila");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            busqueda_situacion_empleado bs = new busqueda_situacion_empleado();
            bs.pasado += new busqueda_situacion_empleado.pasar(ejecutar_codigo_situacion);
            bs.mantenimiento = true;
            bs.ShowDialog();
            cargar_datos();
        }
        public void ejecutar_codigo_situacion(string dato)
        {
            codigo_situacion_empleado_txt.Text = dato.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
             create procedure insert_situacion_empleado @descripcion varchar(50),@estado bit,@codigo int
            */
            try
            {
                string sql = "";
                int estado=0;
                if(codigo_situacion_empleado_txt.Text.Trim()=="")
                {
                    //guarda
                    if(nombre_situacion_txt.Text.Trim()!="")
                    {
                        if(ck_estado.Checked==true)
                            estado=1;
                        else
                            estado=0;
                        sql = "exec insert_situacion_empleado '"+nombre_situacion_txt.Text.Trim()+"','"+estado.ToString()+"','0'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if(ds.Tables[0].Rows.Count>0)
                        {
                            MessageBox.Show("Se guardo");
                        }
                        else
                        {
                            MessageBox.Show("No se guardo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el nombre de la situacion");
                    }
                }
                else
                {
                    //actualiza
                    if (nombre_situacion_txt.Text.Trim() != "")
                    {
                        if (ck_estado.Checked == true)
                            estado = 1;
                        else
                            estado = 0;
                        sql = "exec insert_situacion_empleado '" + nombre_situacion_txt.Text.Trim() + "','" + estado.ToString() + "','"+codigo_situacion_empleado_txt.Text.Trim()+"'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Se actualizo");
                        }
                        else
                        {
                            MessageBox.Show("No se actualizo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el nombre de la situacion");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error");
            }
            cargar_situaciones();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = dataGridView1.CurrentRow.Index;
                codigo_situacion_empleado_txt.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                nombre_situacion_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                if (dataGridView1.Rows[fila].Cells[2].Value.ToString() == "True")
                    ck_estado.Checked = true;
                else
                    ck_estado.Checked = false;


            }
            catch (Exception)
            {
                MessageBox.Show("Error seleccionando la fila");
            }
        }
    }
}
