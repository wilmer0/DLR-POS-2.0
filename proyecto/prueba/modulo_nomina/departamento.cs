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
using puntoVenta;
namespace puntoVenta
{
    public partial class departamento : Form
    {

        public departamento()
        {
            InitializeComponent();
        }
        internal singleton s { get; set; }

        private void departamento_Load(object sender, EventArgs e)
        {
            try
            {
                s = singleton.obtenerDatos();
                if (s.codigo_sucursal.ToString() != "")
                {
                    codigo_sucursal_txt.Text = s.codigo_sucursal.ToString();
                    cargar_nombre_sucursal();
                }
            }
            catch(Exception)
            {

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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //guardar

                try
                {
                    if (codigo_sucursal_txt.Text.Trim() != "")
                    {
                        if (codigo_departamento_txt.Text.Trim() == "")
                        {
                            int estado = 0;
                            if (ck_activo.Checked == true)
                                estado = 1;
                            else
                                estado = 0;

                            /*
                             create proc insert_departamento
                             @nombre varchar(50),@cod_sucursal int,@estado bit,@codigo int
                             */
                            string sql = "exec insert_departamento '"+nombre_departaento_txt.Text.Trim()+"','"+codigo_sucursal_txt.Text.Trim()+"','"+estado.ToString()+"','0'";
                            DataSet ds = Utilidades.ejecutarcomando(sql);
                            if(ds.Tables[0].Rows.Count>0)
                            {
                                codigo_departamento_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                                MessageBox.Show("Se agrego");
                            }
                            else
                            {
                                MessageBox.Show("No se agrego");
                            }
                        }
                        else
                        {
                            int estado = 0;
                            if (ck_activo.Checked == true)
                                estado = 1;
                            else
                                estado = 0;

                            /*
                             create proc insert_departamento
                             @nombre varchar(50),@cod_sucursal int,@estado bit,@codigo int
                             */
                            string sql = "exec insert_departamento '" + nombre_departaento_txt.Text.Trim() + "','" + codigo_sucursal_txt.Text.Trim() + "','" + estado.ToString() + "','"+codigo_departamento_txt.Text.Trim()+"'";
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
                    }
                    else
                    {
                        MessageBox.Show("Falta la sucursal");
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Error guardando el departamento");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    codigo_departamento_txt.Clear();
                    nombre_departaento_txt.Clear();
                    codigo_sucursal_txt.Clear();
                    nombre_sucursal_txt.Clear();
                    ck_activo.Checked = true;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            busqueda_sucursal bs = new busqueda_sucursal();
            bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal);
            bs.ShowDialog();
            cargar_nombre_sucursal();
        }
        public void ejecutar_codigo_sucursal(string dato)
        {
            codigo_sucursal_txt.Text = dato.ToString();   
        }
        public void cargar_nombre_sucursal()
        {
            try
            {
                string sql = "select t.nombre from sucursal s join tercero t on t.codigo=s.codigo where s.codigo='" + codigo_sucursal_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando nombre de la sucursal");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_departamento b = new busqueda_departamento();
            b.codigo_sucursal = codigo_sucursal_txt.Text.Trim();
            b.mantenimiento = true;
            b.pasado += new busqueda_departamento.pasar(ejecutar_codigo_departamento);
            b.ShowDialog();
            cargar_datos();
        }
        public void ejecutar_codigo_departamento(string dato)
        {
            codigo_departamento_txt.Text = dato.ToString();
            cargar_nombre_departamento();
            cargar_datos();
        }
        public void cargar_datos()
        {
            try
            {
                string sql = "select nombre,estado from departamento where codigo ='" + codigo_departamento_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_departaento_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                if (ds.Tables[0].Rows[0][1].ToString() == "True")
                    ck_activo.Checked = true;
                else
                    ck_activo.Checked = false;
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los datos del departamento");
            }
        }
        public void cargar_nombre_departamento()
        {
            try
            {
                string sql = "select nombre from departamento where codigo='"+codigo_departamento_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_departaento_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando nombre de departamento");
            }
        }
    }
}
