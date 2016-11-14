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
    public partial class caja : Form
    {
        public caja()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            busqueda_caja bc = new busqueda_caja();
            bc.pasado += new busqueda_caja.pasar(ejecutar_codigo_caja);
            bc.codigo_sucursal = codigo_sucursal_txt.Text.Trim();
            bc.ShowDialog();
            cargar_datos_caja();
        }
        public void ejecutar_codigo_caja(string dato)
        {
            try
            {
                codigo_caja_txt.Text = dato.ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error poniendo codigo de la caja");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            busqueda_sucursal bs = new busqueda_sucursal();
            bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal);
            bs.ShowDialog();
            cargar_cajas();
        }
        public void cargar_cajas()
        {
            try
            {
                string sql = "select c.codigo,c.nombre,c.secuencia,c.estado from caja c join sucursal s on s.codigo=c.cod_sucursal where s.codigo='"+codigo_sucursal_txt.Text.Trim()+"' order by c.secuencia desc";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView1.DataSource = ds.Tables[0];
                foreach(DataRow row in ds.Tables[0].Rows)
                {

                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando las cajas de la sucursal");
            }
        }
        public void ejecutar_codigo_sucursal(string dato)
        {
            try
            {
                codigo_sucursal_txt.Text = dato.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error poniendo codigo de la sucursal");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
                codigo_sucursal_txt.Clear();
                nombre_sucursal_txt.Clear();
                codigo_caja_txt.Clear();
                nombre_caja_txt.Clear();
                secuencia_caja_txt.Clear();
                ck_activo.Checked = true;
                dataGridView1.Rows.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //guardar
                try
                {
                    if(codigo_caja_txt.Text=="")
                    {
                        //guarda
                        if(codigo_sucursal_txt.Text.Trim()!="")
                        {
                            if(nombre_caja_txt.Text.Trim()!="")
                            {
                                if(secuencia_caja_txt.Text.Trim()!="" && secuencia_caja_txt.TextLength==3)
                                {
                                    int estado = 1;
                                    if(ck_activo.Checked==true)
                                        estado=1;
                                    else
                                        estado=0;
                                    int cont = 0;
                                    string sql = "select c.codigo,c.nombre,c.secuencia,c.estado from caja c join sucursal s on s.codigo=c.cod_sucursal where s.codigo='" + codigo_sucursal_txt.Text.Trim() + "' order by c.secuencia desc";
                                    DataSet ds = Utilidades.ejecutarcomando(sql);
                                    sql = "select *from caja where secuencia='" + secuencia_caja_txt.Text.Trim() + "' and cod_sucursal='"+codigo_sucursal_txt.Text.Trim()+"'";
                                    ds = Utilidades.ejecutarcomando(sql);
                                    if (ds.Tables[0].Rows.Count == 0)
                                    {
                                        /*
                                         create proc insert_caja
                                         @nombre varchar(50),@secuencia varchar(3),@cod_sucursal int,@estado bit,@codigo int
                                         */
                                        sql = "exec insert_caja '"+nombre_caja_txt.Text.Trim()+"','"+secuencia_caja_txt.Text.Trim()+"','"+codigo_sucursal_txt.Text.Trim()+"','"+estado.ToString()+"','0'";
                                        ds = Utilidades.ejecutarcomando(sql);
                                        if(ds.Tables[0].Rows.Count>0)
                                        {
                                            codigo_caja_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                                            cargar_cajas();
                                            MessageBox.Show("Se guardo");
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se guardo");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Esa secuencia ya la tiene otra caja");
                                    }
                                }
                                else
                                {
                                    secuencia_caja_txt.Focus();
                                    MessageBox.Show("Falta la secuencia de la caja que debe tener solo tres digitos(001-002-003)");
                                }
                            }
                            else
                            {
                                nombre_caja_txt.Focus();
                                MessageBox.Show("Falta el nombre de la cada");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta la sucursal");
                        }
                    }
                    else
                    {
                        //actualiza
                        if (codigo_sucursal_txt.Text.Trim() != "")
                        {
                            if (nombre_caja_txt.Text.Trim() != "")
                            {
                                if (secuencia_caja_txt.Text.Trim() != "" && secuencia_caja_txt.TextLength==3)
                                {
                                    int estado = 1;
                                    if (ck_activo.Checked == true)
                                        estado = 1;
                                    else
                                        estado = 0;
                                    int cont = 0;
                                    string sql = "select c.codigo,c.nombre,c.secuencia,c.estado from caja c join sucursal s on s.codigo=c.cod_sucursal where s.codigo='" + codigo_sucursal_txt.Text.Trim() + "' order by c.secuencia desc";
                                    DataSet ds = Utilidades.ejecutarcomando(sql);
                                    sql="select *from caja where secuencia='"+secuencia_caja_txt.Text.Trim()+"' and codigo!='"+codigo_caja_txt.Text.Trim()+"' and cod_sucursal='"+codigo_sucursal_txt.Text.Trim()+"'";
                                    ds = Utilidades.ejecutarcomando(sql);
                                    if (ds.Tables[0].Rows.Count==0)
                                    {
                                        /*
                                         create proc insert_caja
                                         @nombre varchar(50),@secuencia varchar(3),@cod_sucursal int,@estado bit,@codigo int
                                         */
                                        sql = "exec insert_caja '" + nombre_caja_txt.Text.Trim() + "','" + secuencia_caja_txt.Text.Trim() + "','" + codigo_sucursal_txt.Text.Trim() + "','" + estado.ToString() + "','"+codigo_caja_txt.Text.Trim()+"'";
                                        ds = Utilidades.ejecutarcomando(sql);
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            cargar_cajas();
                                            MessageBox.Show("Se actualizo");
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se actualizo");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Esa secuencia ya la tiene otra caja");
                                    }
                                }
                                else
                                {
                                    secuencia_caja_txt.Focus();
                                    MessageBox.Show("Falta la secuencia de la caja que debe tener tres digitos(001-002-003)");
                                }
                            }
                            else
                            {
                                nombre_caja_txt.Focus();
                                MessageBox.Show("Falta el nombre de la cada");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta la sucursal");
                        }
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Erro guardando la caja");
                }
            }
        }
        public void cargar_datos_caja()
        {
            try
            {
                string sql = "select nombre,secuencia,estado from caja where codigo='"+codigo_caja_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_caja_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                secuencia_caja_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                if(ds.Tables[0].Rows[0][2].ToString()=="True")
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
                MessageBox.Show("Error cargando nombre de la caja");
            }
        }
        public void cargar_nombre_sucursal()
        {
            try
            {
                string sql = "select t.nombre from tercero t join sucursal s on s.codigo=t.codigo where s.codigo='" + codigo_sucursal_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();

                sql = "select c.secuencia from caja c join sucursal s on c.cod_sucursal=s.codigo join empresa e on s.codigo_empresa=e.codigo where s.codigo='"+codigo_sucursal_txt.Text.Trim()+"' order by c.secuencia desc";
                ds = Utilidades.ejecutarcomando(sql);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando nombre de la sucursal");
            }
        }
        private void caja_Load(object sender, EventArgs e)
        {

        }

        private void codigo_caja_txt_TextChanged(object sender, EventArgs e)
        {
            cargar_datos_caja();
        }

        private void codigo_sucursal_txt_TextChanged(object sender, EventArgs e)
        {
            cargar_nombre_sucursal();
        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            validar_secuencia_caja();
        }
        public int validar_secuencia_caja()
        {
            try
            {
                int digi = secuencia_caja_txt.TextLength;
                //MessageBox.Show(digi.ToString());
                return digi;
            }
            catch(Exception)
            {
                MessageBox.Show("Error validando la secuencia de la caja");
                return 0;
            }
        }

        private void secuencia_caja_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (Utilidades.numero_entero(secuencia_caja_txt.Text.Trim()) == false)
                secuencia_caja_txt.Clear();
        }
    }
}
