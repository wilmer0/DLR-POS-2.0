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
    public partial class busqueda_pagos_compras : Form
    {

        Utilidades utilidades=new Utilidades();
        public busqueda_pagos_compras()
        {
            InitializeComponent();
        }
        internal singleton s { get; set; }
        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //limpiar
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_suplidor bs = new busqueda_suplidor();
            bs.pasado += new busqueda_suplidor.pasar(ejecutar_codigo_suplidor);
            bs.ShowDialog();
            cargar_pagos();
        }
        public void ejecutar_codigo_suplidor(string dato)
        {

            try
            {
                codigo_suplidor_txt.Text = dato.ToString();
                string sql = "select nombre from tercero where codigo='" + codigo_suplidor_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_suplidor_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                cargar_datos_suplidor();
            }
            catch (Exception)
            {
                MessageBox.Show("Error carganado codigo suplidor");
            }
        }
       
        public void cargar_datos_suplidor()
        {
            try
            {
                string sql = "";
                DataSet ds = new DataSet();
                sql = "select apellido from persona where codigo='" + codigo_suplidor_txt.Text.Trim() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                nombre_suplidor_txt.Text += " " + ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los datos del suplidor");
            }
        }

        private void button8_Click(object sender, EventArgs e)
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
                s = singleton.obtenerDatos();
                if (s.anular_pagos_compras == true)
                {
                    if (detalle_txt.Text.Trim() != "")
                    {
                        /*
                         create proc anular_compra_pagos
                        @codigo_pago int int,@detalle varchar(100),@cod_empleado int
                         */
                        int fila = 0;
                        fila = dataGridView1.CurrentRow.Index;
                        int filacompra = 0;
                        //MessageBox.Show(dataGridView1.Rows[fila].Cells[0].Value.ToString());
                        string sql = "exec anular_compra_pagos '" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "','"+ detalle_txt.Text.Trim() + "','" + s.codigo_usuario.ToString() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        MessageBox.Show("Se guardo");
                        cargar_pagos();
                    }
                    else
                    {
                        MessageBox.Show("Debe especificar un motivo o detalle de porque esta anulando el pago");
                    }
                }
                else
                {
                    MessageBox.Show("Su usuario no tiene permisos para anular pagos");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error anulando el pago");
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            cargar_pagos();
        }
        public void cargar_pagos()
        {
            try
            {
                int fila = 0;
                dataGridView1.Rows.Clear();
                string sql = "select cp.codigo,c.num_factura,cp.monto,cp.cod_empleado,(t.nombre+''+p.apellido)as nombre,cp.fecha,cp.detalle from compra_vs_pagos cp join compra c on c.codigo=cp.cod_compra join tercero t on t.codigo=cp.cod_empleado join persona p on p.codigo=t.codigo where cp.estado='1' and c.cod_suplidor='"+codigo_suplidor_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los pagos para este suplidor");
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea anular el pago seleccionado?", "Anulando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                s = singleton.obtenerDatos();
                if (detalle_txt.Text.Trim() != "")
                {
                    string sql = "update compra_vs_pagos set estado='0',cod_empleado_anular='" + s.codigo_usuario.ToString() + "',motivo_anular='" + detalle_txt.Text.Trim() + "' where codigo='codigo'";
                    Utilidades.ejecutarcomando(sql);
                    MessageBox.Show("Se anulo el pago");
                }
                else
                {
                    MessageBox.Show("Debe especificar el motivo por el que desea anular el documento");
                }
            }
        }

        private void busqueda_pagos_compras_Load(object sender, EventArgs e)
        {

        }
    }
}
