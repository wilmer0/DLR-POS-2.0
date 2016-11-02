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
    public partial class cliente : Form
    {
        public cliente()
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

        private void button9_Click(object sender, EventArgs e)
        {
            busqueda_sexo bs=new busqueda_sexo();
            bs.pasado += new busqueda_sexo.pasar(ejecutar_codigo_sexo);
            bs.ShowDialog();
        }
        public void ejecutar_codigo_sexo(string dato)
        {
            codigo_sexo_txt.Text = dato.ToString();
            cargar_nombre_sexo();
        }
        public void cargar_nombre_sexo()
        {
            try
            {
                string sql = "select sexo from sexo where codigo='"+codigo_sexo_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_sexo_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando nombre de genero");
            }
        }
        public void ejecutar_codigo_cliente(string dato)
        {
            codigo_cliente_txt.Text = dato.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //limpiar ventana
                limpiar();
            }
        }
        public void limpiar()
        {
            codigo_cliente_txt.Clear();
            nombre_txt.Clear();
            //resetear la fecha
            identificacion_txt.Clear();
            codigo_sexo_txt.Clear();
            nombre_sexo_txt.Clear();
            apellido_txt.Clear();
            credito_txt.Clear();
            ck_activo.Checked = false;
            telefono_txt.Clear();
            dataGridView1.Rows.Clear();
            cargar_primera_categoria();
            cargar_primera_subcategoria();
            

        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            limpiar();
            //busqueda_tercero bt = new busqueda_tercero();
            //bt.pasado += new busqueda_tercero.pasar(ejecutar_codigo_cliente);
            //bt.ShowDialog();
            busqueda_tercero bt = new busqueda_tercero();
            bt.pasado += new busqueda_tercero.pasar(ejecutar_codigo_cliente);
            bt.ShowDialog();
            cargar_numeros_telefonos();
            cargar_datos_personales();
            cargar_datos_cliente();
        }
        public void cargar_datos_personales()
        {
            try
            {
                if (codigo_cliente_txt.Text.Trim() == "")
                    return;

                string sql = "select t.nombre,p.apellido,t.identificacion,p.cod_sexo,s.sexo,p.fecha_nacimiento from tercero t join persona p on p.codigo=t.codigo join sexo s on s.codigo=p.cod_sexo  where t.codigo='" + codigo_cliente_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                apellido_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                identificacion_txt.Text = ds.Tables[0].Rows[0][2].ToString();
                codigo_sexo_txt.Text = ds.Tables[0].Rows[0][3].ToString();
                nombre_sexo_txt.Text = ds.Tables[0].Rows[0][4].ToString();
                fecha_nacimiento.Text = ds.Tables[0].Rows[0][5].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los datos personales","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        public void cargar_datos_cliente()
        {
            try
            {
                if (codigo_cliente_txt.Text.Trim() == "")
                    return;

                string sql = "select t.nombre,p.apellido,t.identificacion,p.cod_sexo,s.sexo,p.fecha_nacimiento,c.cod_categoria,cc.nombre,c.cod_subcategoria,csc.nombre,c.limite_credito,c.estado,c.abrir_credito,c.cliente_contado from tercero t join persona p on p.codigo=t.codigo join cliente c on c.codigo=p.codigo join sexo s on s.codigo=p.cod_sexo join cliente_categoria cc on cc.codigo=c.cod_categoria join cliente_subcategoria csc on csc.codigo=c.cod_subcategoria where c.codigo='"+codigo_cliente_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                codigo_categoria_txt.Text = ds.Tables[0].Rows[0][6].ToString();
                nombre_categoria_txt.Text = ds.Tables[0].Rows[0][7].ToString();
                codigo_subcategoria_txt.Text = ds.Tables[0].Rows[0][8].ToString();
                nombre_subcategria_txt.Text = ds.Tables[0].Rows[0][9].ToString();
                credito_txt.Text = ds.Tables[0].Rows[0][10].ToString();
                //cliente activo
                if(ds.Tables[0].Rows[0][11].ToString()=="True")
                {
                    ck_activo.Checked = true;
                }
                else
                {
                    ck_activo.Checked = false;
                }

                //tiene credito abierto
                if (ds.Tables[0].Rows[0][12].ToString() == "True")
                {
                    ck_abrir_credito.Checked = true;
                }
                else
                {
                    ck_abrir_credito.Checked = false;
                }
                //cliente al contado
                if (ds.Tables[0].Rows[0][13].ToString() == "True")
                {
                    clienteContadoCheck.Checked = true;
                }
                else
                {
                    clienteContadoCheck.Checked = false;
                }
                cargar_numeros_telefonos();
                
            }
            catch(Exception)
            {
                MessageBox.Show("No existe como cliente","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }
        public void cargar_numeros_telefonos()
        {
            try
            {
                if (codigo_cliente_txt.Text.Trim() == "")
                    return;

                dataGridView1.Rows.Clear();
                string sql = "select telefono,tipo_telefono from tercero_vs_telefono where tipo_entidad='CLI' and cod_tercero='" + codigo_cliente_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los numeros del cliente");
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select *from telefono where telefono='" + telefono_txt.Text.Trim() + "'";
                DataSet ds=Utilidades.ejecutarcomando(sql);
                if(ds.Tables[0].Rows.Count==0)
                {
                    dataGridView1.Rows.Add(telefono_txt.Text.Trim());
                    telefono_txt.Clear();
                    telefono_txt.Focus();
                }
                else
                {
                    MessageBox.Show("Ese numero ya se encuentra registrado en la base de datos");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error agregando el numero");
            }
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("No hay elementos para eliminar", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error eliminando la fila seleccionada");
            }
        }
        public void actualiza_telefono()
        {
            try
            {
                string sql = "delete from tercero_vs_telefono where cod_tercero='"+codigo_cliente_txt.Text.Trim()+"' and tipo_entidad='CLI'";
                Utilidades.ejecutarcomando(sql);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    sql = "exec insert_telefono_tercero '" + codigo_cliente_txt.Text.Trim() + "','" + row.Cells[0].Value.ToString() + "','CLI','" + row.Cells[1].Value.ToString() + "'";
                    Utilidades.ejecutarcomando(sql);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error guardando los telefonos");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //guardar
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (nombre_txt.Text.Trim() != "")
                    {
                        if (apellido_txt.Text.Trim() != "")
                        {

                            if (codigo_sexo_txt.Text.Trim() != "")
                            {
                                if (fecha_nacimiento.Text.Trim() != "")
                                {
                                    //estado
                                    int estado = 0;
                                    if (ck_activo.Checked == true)
                                        estado = 1;
                                    else
                                        estado = 0;

                                    //credito abierto
                                    int abrir_cre = 0;
                                    if (ck_abrir_credito.Checked == true)
                                        abrir_cre = 1;
                                    else
                                        abrir_cre = 0;
                                    /*
                                     create proc insert_cliente
                                     @nombre varchar(100),@apellido varchar(100),@identificacion varchar(15),
                                     @estado bit,@cod_sexo int,@fecha_nacimiento date,@cod_categoria int,
                                     @cod_subcategoria int,@limite_credito float,@abrir_credito bit,@cod_sucursal_creado int,@cliente_contado,@codigo_cliente int
                                     */
                                    if (codigo_cliente_txt.Text.Trim() == "")
                                           {
                                               string sql = "select *from tercero where identificacion= '" + identificacion_txt.Text.Trim() + "' and identificacion!=''";
                                               DataSet ds = Utilidades.ejecutarcomando(sql);
                                               if (ds.Tables[0].Rows.Count == 0)
                                               {
                                                  
                                                   sql = "exec insert_cliente '" + nombre_txt.Text.Trim() + "','" + apellido_txt.Text.Trim() + "','" + identificacion_txt.Text.Trim() + "','" + estado.ToString() + "','" + codigo_sexo_txt.Text.Trim() + "','" + fecha_nacimiento.Value.ToString("yyyy-MM-dd") + "','" + codigo_categoria_txt.Text.Trim() + "','" + codigo_subcategoria_txt.Text.Trim() + "','" + credito_txt.Text.Trim() + "','" + abrir_cre.ToString() +"','"+s.codigo_sucursal.ToString()+"','"+(bool)clienteContadoCheck.Checked+ "','0'";
                                                   ds = Utilidades.ejecutarcomando(sql);
                                                   if (ds.Tables[0].Rows.Count > 0)
                                                   {
                                                       codigo_cliente_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                                                       actualiza_telefono();
                                                       MessageBox.Show("Se guardo");
                                                   }
                                                   else
                                                   {
                                                       MessageBox.Show("No se guardo");
                                                   }
                                               }
                                               else
                                               {
                                                   MessageBox.Show("La identificacion ya se encuentra en uso");
                                               }
                                           }
                                           else
                                           {
                                               //actualiza
                                               string sql = "select *from tercero where identificacion= '" + identificacion_txt.Text.Trim() + "' and codigo!='" + codigo_cliente_txt.Text.Trim() + "' and identificacion!=''";
                                               DataSet ds = Utilidades.ejecutarcomando(sql);
                                               if (ds.Tables[0].Rows.Count == 0)
                                               {
                                                   sql = "exec insert_cliente '" + nombre_txt.Text.Trim() + "','" + apellido_txt.Text.Trim() + "','" + identificacion_txt.Text.Trim() + "','" + estado.ToString() + "','" + codigo_sexo_txt.Text.Trim() + "','" + fecha_nacimiento.Value.ToString("yyyy-MM-dd") + "','" + codigo_categoria_txt.Text.Trim() + "','" + codigo_subcategoria_txt.Text.Trim() + "','" + credito_txt.Text.Trim() + "','" + abrir_cre.ToString() + "','" + s.codigo_sucursal.ToString() + "','"+ (bool)clienteContadoCheck.Checked+"','" + codigo_cliente_txt.Text.Trim() + "'";
                                                   ds = Utilidades.ejecutarcomando(sql);
                                                   if (ds.Tables[0].Rows.Count > 0)
                                                   {
                                                       codigo_cliente_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                                                       actualiza_telefono();
                                                       MessageBox.Show("Se actualizo", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                   }
                                                   else
                                                   {
                                                       MessageBox.Show("No se actualizo","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                                   }
                                               }
                                               else
                                               {
                                                   MessageBox.Show("La identificacion ya se encuentra en uso");
                                               }
                                           }
                                       }
                                       else
                                       {
                                           MessageBox.Show("Falta la fecha de nacimiento");
                                           fecha_nacimiento.Focus();
                                       }
                                   }
                                   else
                                   {
                                       MessageBox.Show("Falta el genero");
                                   }

                               }
                               else
                               {
                                   MessageBox.Show("Falta el apellido");
                                   apellido_txt.Focus();
                               }
                           }
                           else
                           {
                               MessageBox.Show("Falta el nombre");
                               nombre_txt.Focus();
                           }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error guardando: "+ex.ToString());
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int cont = 0;
            try
            {
                
                if (telefono_txt.Text != "")
                {
                    if (tipo_telefono_combo_txt.Text != "")
                    {
                       
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.Cells[0].Value.ToString() == telefono_txt.Text.Trim())
                                {
                                    cont++;
                                }
                            }
                            if (cont == 0)
                            {

                                dataGridView1.Rows.Add(telefono_txt.Text.Trim(), tipo_telefono_combo_txt.Text.Trim());
                                telefono_txt.Clear();
                                telefono_txt.Focus();
                            }
                            else
                            {
                                MessageBox.Show("El telefono que intenta poner ya se encuentra puesto");
                                telefono_txt.Focus();
                            }
                    }
                    else
                    {
                        MessageBox.Show("Falta el tipo de telefono");
                    }
                }
                else
                {
                    MessageBox.Show("Falta el telefono");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error agregando el numero");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea eliminar el telefono?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    }
                    else
                    {
                        dr = MessageBox.Show("No hay elementos para eliminar", "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error eliminando la fila seleccionada");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            busqueda_cliente_categoria b = new busqueda_cliente_categoria();
            b.pasado += new busqueda_cliente_categoria.pasar(ejecutar_codigo_categoria);
            b.ShowDialog();
            cargar_nombre_categoria();
            codigo_subcategoria_txt.Clear();
            nombre_subcategria_txt.Clear();
        }
        public void ejecutar_codigo_categoria(string dato)
        {
            codigo_categoria_txt.Text = dato.ToString();
        }
        public void cargar_nombre_categoria()
        {
            try
            {
                string sql = "select nombre from cliente_categoria where codigo='"+codigo_categoria_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_categoria_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando el nombre de la categoria");
            }
        }
        private void tipo_telefono_combo_txt_KeyUp(object sender, KeyEventArgs e)
        {
            tipo_telefono_combo_txt.Text = "";
        }
        internal singleton s { get; set; }
        private void cliente_Load(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            if(s.puede_poner_credito_cliente==true)
            {
                credito_txt.Enabled = true;
            }
            else
            {
                credito_txt.Enabled = false;
            }
            cargar_primera_categoria();
            cargar_primera_subcategoria();
        }
        public void cargar_primera_categoria()
        {
            try
            {
                string sql = "select top(1) codigo from cliente_categoria where estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                codigo_categoria_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                cargar_nombre_categoria();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando la categoria");
            }
        }
        public void cargar_primera_subcategoria()
        {
            try
            {
                string sql = "select top(1)codigo from cliente_subcategoria where cod_categoria='"+codigo_categoria_txt.Text.Trim()+"' and estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                codigo_subcategoria_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                cargar_nombre_subcategoria();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando la categoria");
            }
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            busqueda_cliente_subcategoria b = new busqueda_cliente_subcategoria();
            b.codigo_categoria = codigo_categoria_txt.Text.Trim();
            b.pasado += new busqueda_cliente_subcategoria.pasar(ejecutar_codigo_subcategoria);
            b.ShowDialog();
            cargar_nombre_subcategoria();
        }
        public void ejecutar_codigo_subcategoria(string dato)
        {
            codigo_subcategoria_txt.Text = dato.ToString();
        }
        public void cargar_nombre_subcategoria()
        {
            try
            {
                string sql = "select nombre from cliente_subcategoria where codigo='"+codigo_subcategoria_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_subcategria_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre de la subcategoria");
            }
        }

        private void identificacion_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
