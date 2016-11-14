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
    public partial class vendedores : Form
    {
        public vendedores()
        {
            InitializeComponent();
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
                codigo_empleado_txt.Clear();
                nombre_empleado_txt.Clear();
                porciento_txt.Clear();
                ck_activo.Checked = true;
            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }

        public void validar_vendedor()
        {
            try
            {
                string sql = "select porciento,estado from vendedor where codigo='"+codigo_empleado_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if(ds.Tables[0].Rows.Count>0)
                {
                    porciento_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                    if (ds.Tables[0].Rows[0][1].ToString() == "1")
                    {
                        ck_activo.Checked = true;
                    }
                    else
                    {
                        ck_activo.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("El empleado seleccionado no es vendedor");
                }
            }
            catch(Exception)
            {

            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            busqueda_empleado be = new busqueda_empleado();
            be.pasado += new busqueda_empleado.pasar(ejecutar_codigo_vendedores);
            be.ShowDialog();
           
        }
        public void ejecutar_codigo_vendedores(string dato)
        {
            try
            {
                codigo_empleado_txt.Text = dato.ToString();
                string sql = "select (t.nombre+' '+p.apellido) as nombre from tercero t join persona p on t.codigo=p.codigo where t.codigo='" + codigo_empleado_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_empleado_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                validar_vendedor();//pasa saber si el empleado seleccionado es vendedor
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando los datos del vendedor");
            }
        }

        private void porciento_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if(Utilidades.numero_decimal(porciento_txt.Text.Trim())==false)
            {
                porciento_txt.Clear();
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
                   alter proc insert_vendedor
                   @porciento float,@estado int,@codigo int
                */
                if (codigo_empleado_txt.Text.Trim() != "")
                {
                    if (porciento_txt.Text.Trim() != "")
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
                        string sql = "exec insert_vendedor '" + porciento_txt.Text.Trim() + "','" + estado.ToString() + "','" + codigo_empleado_txt.Text.Trim() + "'";
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
                    else
                    {
                        MessageBox.Show("Falta el porciento, si no tiene porciento de ganancia debe de poner cero");
                    }
                }
                else
                {
                    MessageBox.Show("Falta el empleado");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error guardando");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
