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
    public partial class busqueda_compras : Form
    {
        public busqueda_compras()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //limpiar
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //guardar
            }
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        
        private void busqueda_compras_Load(object sender, EventArgs e)
        {
            cargar_suplidores();
        }
        internal singleton s { get; set; }
        public void cargar_compras_suplidor(string codigo_suplidor_txt)
        {
            s=singleton.obtenerDatos();
            try
            {
                /*
                    create proc compras_suplidor
                    @codigo_suplidor int,@cod_sucursal int
                 */
                dataGridView2_compras.Rows.Clear();
                string sql = "exec compras_suplidor '" + codigo_suplidor_txt.ToString().Trim() + "','"+s.codigo_sucursal.ToString()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView2_compras.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No hay compras de este suplidor");
            }
        }
        public void cargar_suplidores()
        {
            try
            {

                dataGridView1_suplidores.Rows.Clear();
                string sql = "select t.codigo,(t.nombre+' '+p.apellido),t.identificacion from tercero t join persona p on t.codigo=p.codigo join suplidor s on p.codigo=s.codigo where s.estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1_suplidores.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando suplidores");
            }
        }

        private void nombre_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dataGridView1_suplidores.Rows.Clear();
                string sql = "select t.codigo,(t.nombre+' '+p.apellido),t.identificacion from tercero t join persona p on t.codigo=p.codigo join suplidor s on p.codigo=s.codigo where s.estado='1' and t.nombre like '%" + nombre_txt.Text.Trim() + "%' or p.apellido like '%" + nombre_txt.Text.Trim() + "%' or t.identificacion like '%" + nombre_txt.Text.Trim() + "%'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1_suplidores.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando suplidor");
            }
        }

        private void dataGridView1_suplidores_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_suplidores_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = 0;
                fila = dataGridView1_suplidores.CurrentRow.Index;
                cargar_compras_suplidor(dataGridView1_suplidores.Rows[fila].Cells[0].Value.ToString());
                dataGridView3_detalle_compras.Rows.Clear();
            }
            catch(Exception)
            {
                MessageBox.Show("Error seleccionando el suplidor para cargar las compras");
            }
        }

        private void dataGridView2_compras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_suplidores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_compras_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = 0;
                fila = dataGridView2_compras.CurrentRow.Index;
                cargar_productos(dataGridView2_compras.Rows[fila].Cells[0].Value.ToString());
            }
            catch(Exception)
            {

            }
        }
        public void cargar_productos(string codigo_compra_txt)
        {
            try
            {
                dataGridView3_detalle_compras.Rows.Clear();
                string sql = "select cd.cod_producto,p.nombre as producto,cd.cod_unidad,u.nombre as unidad,cd.costo,cd.cantidad,cd.monto from compra c join compra_detalle cd on c.codigo=cd.cod_compra join producto p on p.codigo=cd.cod_producto join unidad u on u.codigo=cd.cod_unidad where c.codigo='"+codigo_compra_txt.ToString().Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView3_detalle_compras.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los componentes de la compra");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea anular la compra?", "Anulando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (dataGridView3_detalle_compras.Rows.Count > 0)
                    {
                        string sql = "";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        int fila = dataGridView2_compras.CurrentRow.Index;
                        sql = "select count(*) from compra_vs_pagos cp where cp.estado='1' and cod_compra='" + dataGridView2_compras.Rows[fila].Cells[0].Value.ToString() + "'";
                        ds = Utilidades.ejecutarcomando(sql);
                        double registros = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                        if (registros == 0)
                        {
                            sql = "update compra set estado ='0' where codigo='" + dataGridView2_compras.Rows[fila].Cells[0].Value.ToString() + "'";
                            Utilidades.ejecutarcomando(sql);
                            foreach (DataGridViewRow row in dataGridView3_detalle_compras.Rows)
                            {
                                /*
                                 create proc compra_anulada_inventario
                                 @cod_compra int,@cod_producto int,@cod_unidad int
                                 */
                                int fila_compra = dataGridView2_compras.CurrentRow.Index;
                                sql = "exec compra_anulada_inventario '" + dataGridView2_compras.Rows[fila_compra].Cells[0].Value.ToString() + "','" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "'";
                                ds = Utilidades.ejecutarcomando(sql);
                            }
                        }
                        else
                        {
                            MessageBox.Show("La compra tiene pagos activos");
                        }
                        MessageBox.Show("Compra anulada");
                        dataGridView3_detalle_compras.Rows.Clear();
                        dataGridView2_compras.Rows.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Deben haber productos que anular");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error anulando la compra");
            }
        }

        private void dataGridView1_suplidores_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int fila = 0;
                fila = dataGridView1_suplidores.CurrentRow.Index;
                cargar_compras_suplidor(dataGridView1_suplidores.Rows[fila].Cells[0].Value.ToString());
                dataGridView3_detalle_compras.Rows.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Error seleccionando el suplidor para cargar las compras");
            }
        }
    }
}
