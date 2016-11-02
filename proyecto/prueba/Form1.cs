using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba
{
    public partial class padre : Form
    {
        public padre()
        {
            InitializeComponent();
        }

        public void txt_padre_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                //create proc insert_sexo  @sexo varchar(50),@estado bit
                int estado = 0;
                if (ck_estado.Checked== true)
                    estado = 1;
                ds = Utilidades.ejecutarcomando("exec insert_sexo '"+txt_padre.Text+"','"+estado+"'");
                if (ds.Tables.Count>0)
                {
                    MessageBox.Show("se agrego el sexo");
                }
            }catch(Exception)
            {
                MessageBox.Show("Error agregando el sexo");
            }
            clase_login c = new clase_login();
            c.nombre = txt_padre.Text;
            MessageBox.Show(c.nombre.ToString());
            hijo h = new hijo();
            h.pasado += new hijo.pasar(ejecutar);
            h.ShowDialog();
        }
        public void ejecutar(string dato)
        {
            txt_padre.Text = dato.ToString();
        }
        private void padre_Load(object sender, EventArgs e)
        {
            cargar_sexo();
        }
        public void cargar_sexo()
        {
            string sql = "select *from sexo";
            DataSet ds = new DataSet();
            ds = Utilidades.ejecutarcomando(sql);
            dataGridView1.DataSource= ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string opcion = "";
                //opcion = dataGridView1.Rows[0].Cells[0].Value.ToString();
                opcion = dataGridView1.CurrentRow.Cells[1].Value.ToString();//con esta selecciona donde esta el mouse la primera columna
                MessageBox.Show(opcion.ToString());
            }
            catch(Exception)
            {
                MessageBox.Show("Error de seleccion");
            }
        }
    }
}
