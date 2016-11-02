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
    public partial class pago_desglose : Form
    {
        public pago_desglose()
        {
            InitializeComponent();
        }
        public delegate void pasar(string dato, string dato2,string dato3,string dato4,string dato5,string dato6,string dato7);
        public event pasar pasado;
        internal singleton s { get; set; }
        public string total_esperado = "";
        private void dinero_desglose_Load(object sender, EventArgs e)
        {
            total_esperado_txt.Text = total_esperado.ToString();
            efectivo_txt.Text = total_esperado.ToString();
            s = singleton.obtenerDatos();
            efectivo_txt.Focus();
            devuelta_txt.Text = "0";
            calcular_devuelta();

            //para cargar las cuentas bancarias para hacer los depositos automaticos
            //string sql = "";
            //DataSet ds = Utilidades.ejecutarcomando(sql);
            //cuenta_bancaria_combo.DataSource = ds.Tables[0];
            //cuenta_bancaria_combo.ValueMember = "";
            //cuenta_bancaria_combo.DisplayMember = "";
            
        }
        double total = 0;

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (total_esperado.ToString() != "")
                {
                    if (Convert.ToDouble(devuelta_txt.Text.Trim())>=0)
                    {
                        if (Convert.ToDouble(devuelta_txt.Text.Trim()) >0 || devuelta_txt.Text==".00")
                        {
                            if (Convert.ToDouble(monto_cheque_txt.Text.Trim()) >= 0 && Convert.ToDouble(monto_transferencia_txt.Text.Trim()) >= 0)
                            {
                                
                                if(monto_cheque_txt.Text.Trim()!="0" && numero_cheque_txt.Text.Trim()=="")
                                {
                                    MessageBox.Show("Se encontro un monto en cheque pero no el numero de cheque");
                                }
                                if(monto_transferencia_txt.Text.Trim()!="0" && cuenta_transferencia_txt.Text.Trim()=="")
                                {
                                    MessageBox.Show("Se encontro un monto en transferencia, pero no el numero de cuenta");
                                }
                                    pasado(efectivo_txt.Text.Trim(), devuelta_txt.Text.Trim(), monto_cheque_txt.Text.Trim(), monto_transferencia_txt.Text.Trim(),monto_tarjeta_txt.Text.Trim(),codigo_orden_de_compra_txt.Text.Trim(),monto_orden_de_compra_txt.Text.Trim());
                                    this.Close();
                                    /*
                                     * create proc insert_factura_contado
                                       @cod_factura int,@cod_empleado int,@monto float
                                     */           
                            }
                            else
                            {
                                MessageBox.Show("El monto en deposito y cheque no puede estar vacio o ser negativo");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La devuelta no puede ser negativa");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La devuelta no puede ser negativa");
                    }
                }
                else
                {
                    pasado(total.ToString(), devuelta_txt.Text.Trim(), monto_cheque_txt.Text.Trim(), monto_transferencia_txt.Text.Trim(),monto_tarjeta_txt.Text.Trim(),codigo_orden_de_compra_txt.Text.Trim(),monto_orden_de_compra_txt.Text.Trim());
                }
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

        private void efectivo_txt_TextChanged(object sender, EventArgs e)
        {

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
                efectivo_txt.Text = total_esperado_txt.Text.Trim();

                numero_cheque_txt.Clear();
                monto_cheque_txt.Text = "0";

                cuenta_transferencia_txt.Clear();
                monto_transferencia_txt.Text = "0";

                codigo_orden_de_compra_txt.Text = "0";
                monto_orden_de_compra_txt.Text = "0";

                numero_tarjeta_txt.Clear();
                monto_tarjeta_txt.Text = "0";
                calcular_devuelta();
            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }

        private void ck_deposito_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ck_cheque_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            cuenta_transferencia_txt.Clear();
            monto_transferencia_txt.Text="0";
            calcular_devuelta();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            numero_cheque_txt.Clear();
            monto_cheque_txt.Text = "0";
            calcular_devuelta();
        }

        private void monto_transferencia_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void monto_cheque_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void efectivo_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void efectivo_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if(Utilidades.numero_decimal(efectivo_txt.Text.Trim())==false)
            {
                efectivo_txt.Text = "0";
            }
                calcular_devuelta();
        }
        public void calcular_devuelta()
        {
            try
            {
                double efectivo = 0;
                double devuelta = 0;
                double deposito = 0;
                double orden_compra = 0;

                double cheque = 0;
                double tarjeta = 0;
                double esperado = 0;
                
                esperado = Convert.ToDouble(total_esperado_txt.Text.Trim());
                efectivo = Convert.ToDouble(efectivo_txt.Text.Trim());
                cheque =Convert.ToDouble(monto_cheque_txt.Text.Trim());
                deposito=Convert.ToDouble(monto_transferencia_txt.Text.Trim());
                tarjeta = Convert.ToDouble(monto_tarjeta_txt.Text.Trim());
                orden_compra = Convert.ToDouble(monto_orden_de_compra_txt.Text.Trim());



                devuelta_txt.Text = ((efectivo + cheque + deposito+tarjeta+orden_compra) - esperado).ToString("###,###,###,###,###.#0");
    
            }
            catch(Exception)
            {
                limpiar();
            }
        }

        private void monto_transferencia_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (Utilidades.numero_decimal(monto_transferencia_txt.Text.Trim()) == false)
            {
                monto_transferencia_txt.Text = "0";
            }
            calcular_devuelta();
        }

        private void monto_cheque_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (Utilidades.numero_decimal(monto_cheque_txt.Text.Trim()) == false)
            {
                monto_cheque_txt.Text = "0";
            }
            calcular_devuelta();
        }

        private void monto_transferencia_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            efectivo_txt.Clear();
            calcular_devuelta();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            codigo_orden_de_compra_txt.Clear();
            monto_orden_de_compra_txt.Text = "0";
            calcular_devuelta();
        }

        private void monto_tarjeta_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if(Utilidades.numero_decimal(monto_tarjeta_txt.Text.Trim())==false)
            {
                monto_tarjeta_txt.Text = "0";
            }
            calcular_devuelta();
        }

        private void monto_orden_de_compra_txt_TextChanged(object sender, EventArgs e)
        {

            calcular_devuelta();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void codigo_orden_de_compra_txt_TextChanged(object sender, EventArgs e)
        {
            calcular_devuelta();
        }
    }
}
