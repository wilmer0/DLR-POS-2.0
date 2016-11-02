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
    public partial class prestamo : Form
    {
        public prestamo()
        {
            InitializeComponent();
        }
        int contador = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                contador = 0;
            }
            catch(Exception)
            {

            }
            double monto_global=Convert.ToDouble(monto_txt.Text.ToString());
            //para el prestamo aleman se divide el monto entre la cantidad
            //de periodo y eso me da la amortizcion fija que sera fija
            double amorti = (Convert.ToDouble(monto_txt.Text.ToString())) / (Convert.ToDouble(meses_txt.Text.ToString()));
            //para agregar el primer valor de la tabla de amortizacion
            dataGridView1.Rows.Add(contador.ToString(), monto_global.ToString(),0,0,0);
            contador++;
            //para agregar las filas vacias que se van a llenar despues
            for(double f=2;f<Convert.ToDouble(meses_txt.Text);f++)
            {
                dataGridView1.Rows.Add();   
            }
            //para llenar la amortizacion que siempre sera fija
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["amortizacion"].Value = amorti.ToString();
            }
            //para poner los saldos que son saldo saldo_siguiente=saldo_actual-amortizacion
            double saldoo = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                saldoo = monto_global;
                row.Cells["codigo"].Value = contador++;
                saldoo = saldoo - (Convert.ToDouble(row.Cells["amortizacion"].Value.ToString()));
                row.Cells["saldo"].Value = saldoo.ToString();
                row.Cells["interes"].Value = monto_global * (Convert.ToDouble(tasa_txt.Text) / 100);
                row.Cells["cuota"].Value = Convert.ToDecimal(row.Cells["interes"].Value.ToString()) + Convert.ToDecimal(row.Cells["amortizacion"].Value.ToString());
                monto_global = saldoo;
            }
            //para poner los totales
            decimal sum_saldo = 0;
            decimal sum_interes = 0;
            decimal sum_cuota = 0;
            decimal sum_amorti = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
               sum_amorti += Convert.ToDecimal(row.Cells["amortizacion"].Value.ToString());
               sum_saldo+=Convert.ToDecimal(row.Cells["saldo"].Value.ToString());
               sum_interes+=Convert.ToDecimal( row.Cells["interes"].Value.ToString());
               sum_cuota += Convert.ToDecimal(row.Cells["cuota"].Value.ToString());
            }
            //dataGridView1.Rows.Add("total", "", sum_amorti, sum_interes, sum_cuota);
        }
    }
}
