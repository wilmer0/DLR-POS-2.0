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
    public partial class almacen : Form
    {
        public almacen()
        {
            InitializeComponent();
        }

        private void almacen_Load(object sender, EventArgs e)
        {
            //cargar_almacen();
        }
        internal singleton s { get; set; }

        public void cargar_almacen()
        {
            try
            {
                s = singleton.obtenerDatos();
                string sql = "select a.codigo,a.nombre,t.nombre,a.estado from almacen a join tercero t  on a.cod_sucursal=t.codigo where a.estado='1' and a.cod_sucursal='"+codigo_sucursal_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los almacenes");
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
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
                limpiar();
            }
        }
        public void limpiar()
        {
            try
            {
                dataGridView1.Rows.Clear();
                codigo_almacen_txt.Clear();
                nombre_almacen_txt.Clear();
                ck_activo.Checked = true;
                cargar_almacen();
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
                busqueda_almacen ba = new busqueda_almacen();
                ba.pasado += new busqueda_almacen.pasar(ejecutar_codigo_almacen);
                ba.codigo_sucursal = codigo_sucursal_txt.Text.Trim();
                ba.mantenimiento = true;
                ba.ShowDialog();
                cargar_nombre_almacen();
            }
            catch(Exception)
            {
                MessageBox.Show("No se encontro sucursal a la que pertenee este usuario");
            }
        }
        public void cargar_nombre_almacen()
        {
            try
            {
                if (codigo_almacen_txt.Text.Trim() != "")
                {
                    string sql = "select nombre,estado from almacen where codigo='" + codigo_almacen_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_almacen_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                    if (ds.Tables[0].Rows[0][1].ToString() == "True")
                        ck_activo.Checked = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando nombre del almacen");
            }
        }
        public void ejecutar_codigo_almacen(string dato)
        {
            codigo_almacen_txt.Text = dato.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea Guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //guardar
                guardar();
                cargar_almacen();
            }
        }
        public void guardar()
        {
            try
            {
                //create proc insert_almacen
                //@nombre varchar(50),@cod_sucursal int,@estado bit,@codigo_alma int
                if(codigo_almacen_txt.Text=="")
                {
                    //guarda
                    int estado=0;
                    if(ck_activo.Checked==true)
                        estado=1;
                    else
                        estado=0;

                    string sql = "exec insert_almacen '" + nombre_almacen_txt.Text.Trim() + "','" + codigo_sucursal_txt.Text.Trim() + "','" + estado.ToString() + "','0'";
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
                    //actualiza

                    int estado = 0;
                    if (ck_activo.Checked == true)
                        estado = 1;
                    else
                        estado = 0;

                    string sql = "exec insert_almacen '" + nombre_almacen_txt.Text.Trim() + "','" + codigo_sucursal_txt.Text.Trim() + "','" + estado.ToString() + "','"+codigo_almacen_txt.Text.Trim()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Se guardo");
                    }
                    else
                    {
                        MessageBox.Show("No se guardo");
                    }

                }
                
            }
            catch(Exception)
            {
                MessageBox.Show("Error guardando el almacen");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_sucursal bs = new busqueda_sucursal();
            bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal);
            bs.ShowDialog();
            cargar_nombre_sucursal();
            cargar_almacen();
        }
        public void ejecutar_codigo_sucursal(string dato)
        {
            codigo_sucursal_txt.Text = dato.ToString();
            codigo_almacen_txt.Clear();
            nombre_almacen_txt.Clear();
            ck_activo.Checked = true;
        }
        public void cargar_nombre_sucursal()
        {
            try
            {
                if (codigo_sucursal_txt.Text.Trim() != "")
                {
                    string sql = "select nombre from tercero where codigo='" + codigo_sucursal_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando nombre de la sucursal");
            }
        }
    }
}
