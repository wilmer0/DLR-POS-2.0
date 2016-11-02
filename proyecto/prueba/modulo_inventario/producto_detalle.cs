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
    public partial class producto_detalle : Form
    {
        public producto_detalle()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            busqueda_producto_detalle bp = new busqueda_producto_detalle();
            bp.mantenimiento = true;
            bp.pasado += new busqueda_producto_detalle.pasar(ejecutar_codigo_detalle);
            bp.ShowDialog();
            cargar_datos();
        }
        public void ejecutar_codigo_detalle(string dato)
        {
            codigo_detalle_txt.Text = dato.ToString();
        }
        public void cargar_datos()
        {
            try
            {
                if (codigo_detalle_txt.Text.Trim() != "")
                {
                    string sql = "select descripcion,estado from producto_detalle where codigo='" + codigo_detalle_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_detalle_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                    if (ds.Tables[0].Rows[0][1].ToString() == "True")
                    {
                        ck_estado.Checked = true;
                    }
                    else
                    {
                        ck_estado.Checked = false;
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre del detalle producto");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                /*
                    create proc insert_producto_detalle_m
                    @descripcion varchar(100),@estado bit,@codigo int
                 */
                try
                {
                    
                    int estado = 0;
                    if (codigo_detalle_txt.Text.Trim() == "")
                    {
                        //guarda
                        if (ck_estado.Checked == true)
                            estado = 1;
                        else
                            estado = 0;

                        string sql = "exec insert_producto_detalle_m '"+nombre_detalle_txt.Text.Trim()+"','"+estado.ToString()+"','0'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            codigo_detalle_txt.Text = ds.Tables[0].Rows[0][0].ToString();
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
                        if(ck_estado.Checked==true)
                            estado=1;
                        else
                            estado=0;

                        string sql = "exec insert_producto_detalle_m '"+nombre_detalle_txt.Text.Trim()+"','"+estado.ToString()+"','"+codigo_detalle_txt.Text.Trim()+"'";
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
                catch(Exception)
                {
                    MessageBox.Show("Error guardando el detalle");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    codigo_detalle_txt.Clear();
                    nombre_detalle_txt.Clear();
                    ck_estado.Checked = true;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }
    }
}
