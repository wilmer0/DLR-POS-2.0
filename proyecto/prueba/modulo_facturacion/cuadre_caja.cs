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
    public partial class cuadre_caja : Form
    {
        public cuadre_caja()
        {
            InitializeComponent();
        }
        internal singleton s { get; set; }
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
                codigo_cajero_txt.Clear();
                nombre_cajero_txt.Clear();
                
                cargar_cajero();
                foreach (Control c in panel1.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "0";
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (Convert.ToDouble(total_desglose_txt.Text.Trim()) >= 0)
                    {
                        try
                        {
                            /*
                                alter proc insert_cuadre_caja
                                @cod_cajero int,@fecha date,@efectivo float
                             */
                            int cont = 0;
                            foreach (Control c in panel1.Controls)
                            {
                                if (c is TextBox & c.Text == String.Empty)
                                {
                                    cont++;
                                }
                            }
                            if (cont == 0)
                            {
                                string sql = "exec insert_cuadre_caja '" + codigo_cajero_txt.Text.Trim() + "','" + fecha.Value.ToString("yyyy-MM-dd") + "','" + sumatoria.ToString() + "'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show("Se se guardo","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                    limpiar();
                                }
                                else
                                {
                                    MessageBox.Show("No se guardo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No puede dejar campos vacios","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("El cajero no tiene una apertura de caja activa","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El monto debe ser igual o mayor que cero","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error haciendo el cuadre de caja: "+ex.ToString());
            }
        }
        double sumatoria = 0;
      
        private void cuadre_caja_Load(object sender, EventArgs e)
        {
            s=singleton.obtenerDatos();
            if(s.cambiaf_fecha_cuadre_caja==true)
            {
                fecha.Enabled = true;
            }
            cargar_cajero();
           
        }
        public void cargar_cajero()
        {
            s = singleton.obtenerDatos();
            try
            {
                string sql = "select *from cajero where cod_empleado='" + s.codigo_usuario.ToString() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                codigo_cajero_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                cargar_nombre_cajero();
            }
            catch (Exception)
            {
                MessageBox.Show("Su usuario no es cajero");
                this.Close();
            }
        }
        public void cargar_nombre_cajero()
        {
            try
            {
                string sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + s.codigo_usuario.ToString() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_cajero_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando el nombre del cajero");
            }
        }

        public void sumar_total()
        {
            try
            {
                sumatoria = 0;
                sumatoria = Convert.ToDouble(textBox3.Text.Trim()) + Convert.ToDouble(textBox4.Text.Trim()) + Convert.ToDouble(textBox5.Text.Trim()) + Convert.ToDouble(textBox6.Text.Trim()) + Convert.ToDouble(textBox7.Text.Trim()) + Convert.ToDouble(textBox8.Text.Trim()) + Convert.ToDouble(textBox9.Text.Trim()) + Convert.ToDouble(textBox10.Text.Trim()) + Convert.ToDouble(textBox11.Text.Trim()) + Convert.ToDouble(textBox12.Text.Trim()) + Convert.ToDouble(textBox13.Text.Trim());
                total_desglose_txt.Text = sumatoria.ToString("###,###,###,###.#0");
                
            }
            catch(Exception)
            {
                MessageBox.Show("Los campos no pueden estar vacios, si no tiene dinero se debe dejar en cero");
            }
        }
        public void cargar_nombre_empleado()
        {
            try
            {
                string sql = "select nombre from tercero where codigo='"+codigo_cajero_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_cajero_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando nombre de empleado");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            busqueda_empleado be = new busqueda_empleado();
            be.pasado += new busqueda_empleado.pasar(ejecutar_codigo_empleado);
            be.ShowDialog();
            cargar_nombre_empleado();
            cargar_factura_empleado();
            
        }
        public void ejecutar_codigo_empleado(string dato)
        {
            codigo_cajero_txt.Text = dato.ToString();

        }
        public void cargar_factura_empleado()
        {
            s=singleton.obtenerDatos();

            double total_cobros = 0;
            double total_contado = 0;
            double total_credito = 0;
            double total_ingresos = 0;
            double total_egresos = 0;
                if (codigo_cajero_txt.Text.Trim() != "")
                {
                    //facturas al contado
                    string sql = "select f.codigo,f.num_factura,f.ncf,f.codigo_tipo_factura,sum((f.efectivo-f.devuelta)) from factura f join cajero c on f.codigo_empleado=c.cod_empleado where f.codigo_tipo_factura='CON' and f.estado='1' and f.codigo_empleado='" + codigo_cajero_txt.Text.Trim() + "' and f.fecha='" + fecha.Value.ToString("yyyy-MM-dd") + "' and f.cod_sucursal='" + s.codigo_sucursal.ToString() + "' group by f.codigo,f.num_factura,f.ncf,f.codigo_tipo_factura order by f.codigo desc";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                    }
                    //facturas a credito que se le hicieron cobros
                    sql = "select f.codigo,f.num_factura,f.ncf,f.codigo_tipo_factura,sum(vp.monto) from factura f join cajero c on c.codigo=f.codigo_empleado join venta_vs_pagos vp on vp.cod_factura=f.codigo and vp.cod_empleado=c.codigo where f.estado='1' and f.codigo_tipo_factura='CRE' and vp.estado='1' and f.codigo_empleado='"+codigo_cajero_txt.Text.Trim()+"'  and f.fecha='"+fecha.Value.ToString("yyyy-MM-dd")+"' and f.cod_sucursal='"+s.codigo_sucursal.ToString()+"' group by f.codigo,f.num_factura,f.ncf,f.codigo_tipo_factura order by f.codigo desc";
                    ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                    }
                    //sumar todos los ingresos
                  
                    /*foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[3].Value.ToString() == "CON")
                        {
                            total_contado += Convert.ToDouble(row.Cells[4].Value.ToString());
                        }
                        if (row.Cells[3].Value.ToString() == "CRE")
                        {
                            total_credito += Convert.ToDouble(row.Cells[4].Value.ToString());
                        }
                    }*/

                    total_cobros = total_contado + total_credito;
                    //total_contado_txt.Text = total_contado.ToString("###,###,###,###.#0");
                    //total_credito_txt.Text = total_credito.ToString("###,###,###,###.#0");
                    //total_cobros_txt.Text = total_cobros.ToString("###,###,###,###.#0");

                }
                else
                {
                    MessageBox.Show("Falta el cajero");
                }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            cargar_factura_empleado();
        }

        private void dos_mil_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double dinero=0;
                dinero = 2000 * (Convert.ToDouble(dos_mil_txt.Text.Trim()));
                textBox13.Text = dinero.ToString("###,###,###,###.#0");
                sumar_total();
            }
            catch
            {
                textBox13.Text = "0";
            }
        }

        private void dos_mil_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void mill_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double dinero = 0;
                dinero = 1000 * (Convert.ToDouble(mill_txt.Text.Trim()));
                textBox8.Text = dinero.ToString("###,###,###,###.#0");
                sumar_total();
            }
            catch
            {
                textBox8.Text = "0";
            }
        }

        private void quinientos_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double dinero = 0;
                dinero = 500 * (Convert.ToDouble(quinientos_txt.Text.Trim()));
                textBox9.Text = dinero.ToString("###,###,###,###.#0");
                sumar_total();
            }
            catch
            {
                textBox9.Text = "0";
            }
        }

        private void doscientos_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double dinero = 0;
                dinero = 200 * (Convert.ToDouble(doscientos_txt.Text.Trim()));
                textBox10.Text = dinero.ToString("###,###,###,###.#0");
                sumar_total();
            }
            catch
            {
                textBox10.Text = "0";
            }
        }

        private void cien_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double dinero = 0;
                dinero = 100 * (Convert.ToDouble(cien_txt.Text.Trim()));
                textBox12.Text = dinero.ToString("###,###,###,###.#0");
                sumar_total();
            }
            catch
            {
                textBox12.Text = "0";
            }
        }

        private void cincuenta_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double dinero = 0;
                dinero = 50 * (Convert.ToDouble(cincuenta_txt.Text.Trim()));
                textBox11.Text = dinero.ToString("###,###,###,###.#0");
                sumar_total();
            }
            catch
            {
                textBox11.Text = "0";
            }
        }

        private void venticinco_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double dinero = 0;
                dinero = 25 * (Convert.ToDouble(venticinco_txt.Text.Trim()));
                textBox7.Text = dinero.ToString("###,###,###,###.#0");
                sumar_total();
            }
            catch
            {
                textBox7.Text = "0";
            }
        }

        private void veinte_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double dinero = 0;
                dinero = 20 * (Convert.ToDouble(veinte_txt.Text.Trim()));
                textBox6.Text = dinero.ToString("###,###,###,###.#0");
                sumar_total();
            }
            catch
            {
                textBox6.Text = "0";
            }
        }

        private void venticinco_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void diez_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double dinero = 0;
                dinero = 10 * (Convert.ToDouble(diez_txt.Text.Trim()));
                textBox5.Text = dinero.ToString("###,###,###,###.#0");
                sumar_total();
            }
            catch
            {
                textBox5.Text = "0";
            }
        }

        private void cinco_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double dinero = 0;
                dinero = 5 * (Convert.ToDouble(cinco_txt.Text.Trim()));
                textBox4.Text = dinero.ToString("###,###,###,###.#0");
                sumar_total();
            }
            catch
            {
                textBox4.Text = "0";
            }
        }

        private void uno_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double dinero = 0;
                dinero = 1 * (Convert.ToDouble(uno_txt.Text.Trim()));
                textBox3.Text = dinero.ToString("###,###,###,###.#0");
                sumar_total();
            }
            catch
            {
                textBox3.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sumar_total();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
    }
}
