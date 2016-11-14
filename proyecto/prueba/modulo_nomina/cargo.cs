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
    public partial class cargo : Form
    {
        public cargo()
        {
            InitializeComponent();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        private void cargo_Load(object sender, EventArgs e)
        {
            cargar_cargos();
        }
        public void cargar_cargos()
        {
            try
            {
                string sql = "select codigo,nombre,estado from cargo where estado='1' order by nombre";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los cargos");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
                create proc insert_cargo
                @nombre varchar(50),@estado bit,@codigo_mod int
             */
            //el codigo_mod es para si el codigo esta en el textbox y se va actualizar
            string sql = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //limpiar ventana
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            busqueda_cargo bc=new busqueda_cargo();
            bc.pasado += new busqueda_cargo.pasar(ejecutar_codigo_cargo);
            bc.mantenimiento = true;
            bc.ShowDialog();
            cargar_datos();
        }
        public void cargar_datos()
        {
            try
            {
                string sql = "select codigo,nombre,estado from cargo where codigo='"+codigo_cargo_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_cargo_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                if (ds.Tables[0].Rows[0][2].ToString() == "True")
                    ck_estado.Checked = true;
                else
                    ck_estado.Checked = false;
                
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los datos del cargo");
            }
        }
        public void ejecutar_codigo_cargo(string dato)
        {
            codigo_cargo_txt.Text = dato.ToString();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = dataGridView1.CurrentRow.Index;
                codigo_cargo_txt.Text = dataGridView1.Rows[fila].Cells[0].Value.ToString();
                nombre_cargo_txt.Text = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                if(dataGridView1.Rows[fila].Cells[2].Value.ToString()=="True")
                {
                    ck_estado.Checked = true;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error seleccionando la fila");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //guardar
            /*
             create procedure insert_cargo @nombre varchar(50),@estado bit,@codigo int
             */
            try
            {
                string sql = "";
                int estado = 0;
                if(codigo_cargo_txt.Text.Trim()=="")
                {
                    //guarda
                    if(nombre_cargo_txt.Text.Trim()!="")
                    {
                        if (ck_estado.Checked == true)
                            estado = 1;
                        else
                            estado = 0;
                        sql = "exec insert_cargo '"+nombre_cargo_txt.Text.Trim()+"','"+estado.ToString()+"','0'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if(ds.Tables[0].Rows.Count>0)
                        {
                            MessageBox.Show("Se agrego");
                            cargar_cargos();
                        }
                        else
                        {
                            MessageBox.Show("No se agrego");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el nombre del cargo");
                    }
                    
                }
                else
                {
                    //actualiza
                    if (nombre_cargo_txt.Text.Trim() != "")
                    {
                        if (ck_estado.Checked == true)
                            estado = 1;
                        else
                            estado = 0;
                        sql = "exec insert_cargo '" + nombre_cargo_txt.Text.Trim() + "','" + estado.ToString() + "','"+codigo_cargo_txt.Text.Trim()+"'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Se actualizo");
                            cargar_cargos();
                        }
                        else
                        {
                            MessageBox.Show("No se actualizo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el nombre del cargo");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
