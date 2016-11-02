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
    public partial class comprobante_fiscal : Form
    {
        public comprobante_fiscal()
        {
            InitializeComponent();
        }

        private void comprobante_fiscal_Load(object sender, EventArgs e)
        {
            cargar_tipo_comprobante();
            cargar_serie_comprobante();
        }
        public void cargar_serie_comprobante()
        {
            try
            {
                string sql = "select serie from comprobante_serie where estado='1'";
                DataSet ds=Utilidades.ejecutarcomando(sql);
                serie_comprobante_combo_txt.DisplayMember = "serie";
                serie_comprobante_combo_txt.DataSource = ds.Tables[0];
                serie_comprobante_combo_txt.ValueMember = "serie";
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando serie comprobante");
            }
        }
        public void cargar_tipo_comprobante()
        {
            try
            {
                string sql = "select nombre from tipo_comprobante_fiscal where estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                tipo_comprobante_combo.ValueMember = "nombre";
                tipo_comprobante_combo.DisplayMember = "nombre";
                tipo_comprobante_combo.DataSource = ds.Tables[0];
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los tipos de comprobante");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
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
                /*
                 alter proc insert_comprobante_fiscal
                 @cod_serie int,@cod_caja int,@cod_tipo int,@desde int,@hasta int,@avisar,@comenzar,@codigo int
                */
            try
            {
                string sql = "select *from comprobante_fiscal where  cod_serie='" + codigo_serie_txt.Text.Trim() + "' and codigo_tipo='" + codigo_tipo_comprobate_txt.Text.Trim() + "' and cod_caja='" + codigo_caja_txt.Text.Trim() + "' and ((desde_numero between '" + comprobante_inicial_txt.Text.Trim() + "' and '" + comprobante_final_txt.Text.Trim() + "') or (hasta_numero between '" + comprobante_inicial_txt.Text.Trim() + "' and '" + comprobante_final_txt.Text.Trim() + "'))";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    if (comenzar_txt.Text.Trim() != "")
                    {
                        sql = "";
                        ds.Clear();
                        if (comprobante_inicial_txt.Text.Trim() != "")
                        {
                            if (comprobante_final_txt.Text.Trim() != "")
                            {
                                if (codigo_caja_txt.Text.Trim() != "")
                                {
                                    if (codigo_sucursal_txt.Text.Trim()!="")
                                    {
                                        if (Convert.ToDouble(comenzar_txt.Text.Trim()) >= (Convert.ToDouble(comprobante_inicial_txt.Text.Trim())) && Convert.ToDouble(comenzar_txt.Text.Trim())<=(Convert.ToDouble(comprobante_final_txt.Text.Trim())))
                                        {
                                            sql = "exec insert_comprobante_fiscal '" + codigo_serie_txt.Text.Trim() + "','" + codigo_caja_txt.Text.Trim() + "','" + codigo_tipo_comprobate_txt.Text.Trim() + "','" + comprobante_inicial_txt.Text.Trim() + "','" + comprobante_final_txt.Text.Trim() + "','" + avisar_txt.Text.Trim() + "','" + comenzar_txt.Text.Trim() + "','0'";
                                            ds = Utilidades.ejecutarcomando(sql);
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
                                            MessageBox.Show("El numero de comenzar no se encuentra entre el rango inicial y final");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Falta la sucursal");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Falta la caja");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Falta el comprobante final");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta el numero incial");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta desde donde va a comenzar");
                    }
                }
                else
                {
                    MessageBox.Show("Error ya hay comprobantes de ese tipo con esa caja que choca con el rango descrito ene sta ventana");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error guardando el comprobante fiscal");
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
                cargar_serie_comprobante();
                codigo_sucursal_txt.Clear();
                nombre_sucursal_txt.Clear();
                codigo_caja_txt.Clear();
                nombre_caja_txt.Clear();
                secuencia_sucursal_txt.Clear();
                codigo_tipo_comprobate_txt.Clear();
                cargar_tipo_comprobante();
                comprobante_inicial_txt.Clear();
                comprobante_final_txt.Clear();
            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando los datos");
            }
        }
        private void tipo_comprobante_combo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "select secuencia from tipo_comprobante_fiscal where nombre ='"+tipo_comprobante_combo.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                codigo_tipo_comprobate_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                tipo_comprobante_combo.Text = "";
                cargar_tipo_comprobante();
                MessageBox.Show("Error buscando la secuencia del comprobante");
               
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (codigo_sucursal_txt.Text.Trim() != "")
            {
                busqueda_caja bs = new busqueda_caja();
                bs.pasado += new busqueda_caja.pasar(ejecutar_codigo_caja);
                bs.codigo_sucursal = codigo_sucursal_txt.Text.Trim();
                bs.ShowDialog();
                cargar_secuencia_caja();
            }
            else
            {
                MessageBox.Show("Debe especificar la sucursal");
            }
        }
        public void cargar_secuencia_caja()
        {
            try
            {
                string sql = "select secuencia from caja where codigo='"+codigo_caja_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                secuencia_caja_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando la secuncia de la caja");
            }
        }
        public void ejecutar_codigo_caja(string dato)
        {
            codigo_caja_txt.Text = dato.ToString();
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        singleton s = new singleton();
        private void codigo_caja_txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "select nombre from caja where codigo='" +codigo_caja_txt.Text.Trim()+"'";
                //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_caja_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las cajas");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_sucursal bs = new busqueda_sucursal();
            bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal);
            bs.ShowDialog();
            cargar_secuencia_sucursal();
            codigo_caja_txt.Clear();
            nombre_caja_txt.Clear();
            secuencia_caja_txt.Clear();
        }
        public void cargar_secuencia_sucursal()
        {
            try
            {
                string sql = "select secuencia from sucursal where codigo='"+codigo_sucursal_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                secuencia_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando la secuencia de la sucursal");
            }
        }
        public void ejecutar_codigo_sucursal(string dato)
        {
            codigo_sucursal_txt.Text = dato.ToString();
        }

        private void codigo_sucursal_txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "select nombre from tercero where codigo='" + codigo_sucursal_txt.Text.Trim() + "'";
                //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error tomando nombre de sucursal");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void serie_comprobante_combo_txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "select nombre,codigo from comprobante_serie where serie ='" + serie_comprobante_combo_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_serie_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                codigo_serie_txt.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando el nombre de serie comprobante");
                serie_comprobante_combo_txt.Text = "";
                cargar_serie_comprobante();
            }
        }

        private void nombre_serie_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void avisar_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if(Utilidades.numero_decimal(avisar_txt.Text.Trim())==false)
            {
                avisar_txt.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comprobante_serie cs = new comprobante_serie();
            cs.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            comprobante_tipo_comprobante ct = new comprobante_tipo_comprobante();
            ct.ShowDialog();
        }

        private void comenzar_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (Utilidades.numero_entero(comenzar_txt.Text.Trim()) == false)
                comenzar_txt.Clear();
        }
    }
}
