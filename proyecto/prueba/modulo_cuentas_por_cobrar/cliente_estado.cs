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
    public partial class cliente_estado : Form
    {
        public cliente_estado()
        {
            InitializeComponent();
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
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    codigo_cliente_txt.Clear();
                    nombre_cliente_txt.Clear();
                    dataGridView1.Rows.Clear();
                   

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

            }
        }

        private void form_padre_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_cliente bc = new busqueda_cliente();
            bc.pasado += new busqueda_cliente.pasar(ejecutar_codigo_cliente);
            bc.ShowDialog();
            cargar_nombre_cliente();
            cargar_facturas();
            
        }
        double saldado = 0;
        double pendiente=0;
        double total_factura = 0;
        public void cargar_facturas()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select f.codigo,f.num_factura,f.ncf,f.codigo_tipo_factura,f.rnc,f.fecha,t.nombre from factura f join cliente c on c.codigo=f.codigo_cliente join sucursal s on f.cod_sucursal=s.codigo join tercero t on t.codigo=s.codigo where f.codigo_cliente='" + codigo_cliente_txt.Text.Trim() + "' and f.codigo_tipo_factura='CRE' order by f.codigo desc";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    double monto_saldo = 0;
                    double monto_pendiente = 0;
                    double monto_factura = 0;
                    string codigo_factura = row[0].ToString();
                    //MessageBox.Show("codigo fac->"+codigo_factura.ToString());
                    string cmd = "select sum(vp.monto) from venta_vs_pagos vp join factura f on f.codigo=vp.cod_factura join cliente c on f.codigo_cliente=c.codigo where vp.estado='1' and f.codigo='" + codigo_factura.ToString() + "'";
                    DataSet dx = Utilidades.ejecutarcomando(cmd);
                    if (dx.Tables[0].Rows[0][0].ToString() != "")
                    {
                        monto_saldo += Convert.ToDouble(dx.Tables[0].Rows[0][0].ToString());
                    }
                    cmd = "select sum(fd.monto) from factura_detalle fd join factura f on f.codigo=fd.cod_factura where f.estado='1' and fd.estado='1' and f.codigo='" + codigo_factura.ToString() + "'";
                    dx = Utilidades.ejecutarcomando(cmd);
                    if (dx.Tables[0].Rows[0][0].ToString() != "")
                    {
                        monto_factura = Convert.ToDouble(dx.Tables[0].Rows[0][0].ToString());
                    }
                    monto_pendiente = (monto_factura - monto_saldo);
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), monto_saldo.ToString("###,###,###,###,#0"), monto_pendiente.ToString("###,###,###,###,#0"));
                }
                pendiente = 0;
                saldado = 0;
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    saldado += Convert.ToDouble(row.Cells[7].Value.ToString());
                    pendiente += Convert.ToDouble(row.Cells[8].Value.ToString());
                }
                total_factura_pendiente_txt.Text = pendiente.ToString("###,###,###,###.#0");
                total_saldadas_txt.Text = saldado.ToString("###,###,###,###.#0");
                MessageBox.Show("Finalizado");
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el estado del cliente");
            }
        }
        public void ejecutar_codigo_cliente(string dato)
        {
            codigo_cliente_txt.Text = dato.ToString();
        }
        public void cargar_nombre_cliente()
        {
            try
            {
                string sql = "select (t.nombre+' '+p.apellido) as nombre from tercero t join persona p on p.codigo=t.codigo where t.codigo='"+codigo_cliente_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_cliente_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre del cliente");
            }
        }
    }
}
