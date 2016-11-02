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
    public partial class busqueda_factura : Form
    {
        public busqueda_factura()
        {
            InitializeComponent();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        
        private void busqueda_factura_Load(object sender, EventArgs e)
        {
            ck_cliente.Checked = true;
            cargar_comprobante();
        }
        public void cargar_comprobante()
        {
            try
            {
                string sql="select codigo,nombre from tipo_comprobante_fiscal where estado='1'";
                DataSet ds=Utilidades.ejecutarcomando(sql);
                comprobante_combo_txt.DataSource = ds.Tables[0];
                comprobante_combo_txt.DisplayMember = "nombre";//nombre a mostrar
                comprobante_combo_txt.ValueMember = "nombre";//nombre logico del campo de bd
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los comprobante fiscales");
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

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
                //limpiar ventana
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if(ck_cliente.Checked==true)
            {
                busqueda_factura_cliente bfc = new busqueda_factura_cliente();
                bfc.ShowDialog();
            }
            if(ck_suplidor.Checked==true)
            {
                busqueda_factura_suplidor bfs = new busqueda_factura_suplidor();
                bfs.ShowDialog();
            }
        }
        public void ejecutar_factura_cliente(string dato)
        {
            numero_factura_txt.Text = dato.ToString();
        }
        public void ejecutar_factura_suplidor(string dato)
        {
            numero_factura_txt.Text = dato.ToString();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = "";
                //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                codigo =dataGridView1_facturas.CurrentRow.Cells[0].Value.ToString();
                pasado(codigo.ToString());
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error pasando la factura hacias atras");
            }
        }

        private void ck_cliente_Click(object sender, EventArgs e)
        {
            ck_cliente.Checked = true;
            ck_suplidor.Checked = false;
        }

        private void ck_suplidor_Click(object sender, EventArgs e)
        {

            ck_cliente.Checked = false;
            ck_suplidor.Checked = true;
        }

        private void ck_credito_Click(object sender, EventArgs e)
        {
            ck_contado.Checked = false;
            ck_credito.Checked =true;
            ck_cotizacion.Checked = false;
            dias_txt.ReadOnly = false;
        }

        private void ck_contado_Click(object sender, EventArgs e)
        {
            dias_txt.ReadOnly = true;
            ck_contado.Checked = true;
            ck_credito.Checked = false;
            ck_cotizacion.Checked = false;
        }

        private void ck_cotizacion_Click(object sender, EventArgs e)
        {

            ck_contado.Checked = false;
            ck_credito.Checked = false;
            ck_cotizacion.Checked = true;
            dias_txt.ReadOnly = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea imprimir?", "Imprimiendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //imprimir la factura
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //anular el movimiento seleccionado, si se hizo un pago o se cobro algun pago
            MessageBox.Show("Se eliminara el pago o cobro, si tienes permiso para hacer esto si no valiste");
        }
    }
}
