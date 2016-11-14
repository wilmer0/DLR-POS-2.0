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
    public partial class mesas : Form
    {
        public mesas()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
        internal singleton s { get; set; }
        private void button6_Click(object sender, EventArgs e)
        {
            s=singleton.obtenerDatos();
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //guardar
                
                    string sql = "";
                    DataSet ds = new DataSet();
                    if(nombre_mesa_txt.Text.Trim()!="")
                    {
                        int estado=0;
                        if (ck_activo.Checked == true)
                            estado = 1;
                        else
                            estado = 0;
                        if(codigo_mesa_txt.Text.Trim()=="")
                        {
                            //guarda
                            /*
                             
                                create proc insert_mesas
                               @nombre varchar(max),@estado int,@cod_sucursal int,@codigo int

                             */
                            sql = "exec insert_mesas '"+nombre_mesa_txt.Text.Trim()+"','"+estado.ToString()+"','"+s.codigo_sucursal.ToString()+"','0'";
                            ds = Utilidades.ejecutarcomando(sql);
                            if(ds.Tables[0].Rows.Count>0)
                            {
                                actualiza_detalle_mesa();
                                MessageBox.Show("Se guardo");
                            }
                            else
                            {
                                MessageBox.Show("No se guardo");
                            }
                        }
                        else
                        {
                            //actualiza
                            sql = "exec insert_mesas '" + nombre_mesa_txt.Text.Trim() + "','" + estado.ToString() +"','"+s.codigo_sucursal.ToString()+ "','"+codigo_mesa_txt.Text.Trim()+"'"; 
                            ds = Utilidades.ejecutarcomando(sql);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                sql = "delete from mesas_detalles where codigo_mesa='"+codigo_mesa_txt.Text.Trim()+"'";
                                Utilidades.ejecutarcomando(sql);
                                actualiza_detalle_mesa();
                                MessageBox.Show("Se actualizo");
                            }
                            else
                            {
                                MessageBox.Show("No se actualizo");
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Falta el nombre de la mesa");
                    }
               
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //limpiar
            }
        }
        public void actualiza_detalle_mesa()
        {
            try
            {
                /*
                   create proc insert_mesa_detalle 
                   @cod_mesa int,@cod_detalle int,@descripcion varchar(max)
                */
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    string sql = "exec insert_mesa_detalle '" + codigo_mesa_txt.Text.Trim() + "','" + row.Cells[0].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "'";
                    Utilidades.ejecutarcomando(sql);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error actualizando/agregando los detalles a la mesa");
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea quitar el detalle?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (dataGridView3.Rows.Count > 0)
                    {
                        dataGridView3.Rows.RemoveAt(dataGridView3.CurrentRow.Index);
                    }
                    else
                    {
                        dr = MessageBox.Show("No hay elementos para eliminar", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                int cont = 0;
                if (codigo_detalle_mesa_txt.Text.Trim() != "")
                {
                    if (nombre_detalle_mesa_txt.Text.Trim() != "")
                    {
                        if (detalle_mesa_txt.Text.Trim() != "")
                        {
                            foreach (DataGridViewRow row in dataGridView3.Rows)
                            {
                                if (row.Cells[0].Value.ToString() == codigo_detalle_mesa_txt.Text.Trim())
                                {
                                    cont++;
                                }
                            }
                            if (cont == 0)
                            {
                                dataGridView3.Rows.Add(codigo_detalle_mesa_txt.Text.Trim(), nombre_detalle_mesa_txt.Text.Trim(), detalle_mesa_txt.Text.Trim());
                                detalle_mesa_txt.Clear();
                                nombre_detalle_mesa_txt.Clear();
                                codigo_detalle_mesa_txt.Clear();
                            }
                            else
                            {
                                MessageBox.Show("El detalle producto que ha seleccionado ya se encuentra puesto.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta el detalle del producto");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el nombre del detalle producto");
                    }
                }
                else
                {
                    MessageBox.Show("Falta el codigo del detalle producto");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error agregando el detalle de producto");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            busqueda_producto_detalle bud = new busqueda_producto_detalle();
            bud.pasado += new busqueda_producto_detalle.pasar(ejecutar_codigo_detalle);
            bud.ShowDialog();
            cargar_nombre_detalle_producto();
        }
        public void ejecutar_codigo_detalle(string dato)
        {
            codigo_detalle_mesa_txt.Text = dato.ToString();
        }
        public void cargar_nombre_detalle_producto()
        {
            try
            {
                string sql = "select descripcion from producto_detalle where codigo='"+codigo_detalle_mesa_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_detalle_mesa_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el nombre del detalle");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            busqueda_mesa bm = new busqueda_mesa();
            bm.pasado += new busqueda_mesa.pasar(ejecutar_codigo_mesa);
            bm.mantenimiento = true;
            bm.ShowDialog();
            cargar_nombre_mesa();
            cargar_detalles();
        }
        public void cargar_detalles()
        {
            dataGridView3.Rows.Clear();
            try
            {
                string sql="select md.cod_detalle,d.descripcion,md.descripcion from mesas_detalles md  join producto_detalle d on d.codigo=md.cod_detalle where codigo_mesa='"+codigo_mesa_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView3.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los detalles");
            }
        }
        public void ejecutar_codigo_mesa(string dato)
        {
            codigo_mesa_txt.Text = dato.ToString();
        }
        public void cargar_nombre_mesa()
        {
            try
            {
                string sql = "select nombre,estado from mesas where codigo='"+codigo_mesa_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_mesa_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                if(ds.Tables[0].Rows[0][1].ToString()=="1")
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
                MessageBox.Show("Error cargando nombre de la mesa");
            }
        }
    }
}

