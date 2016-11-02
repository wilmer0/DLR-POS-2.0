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
    public partial class suplidores : Form
    {
        public suplidores()
        {
            InitializeComponent();
        }

        private void suplidores_Load(object sender, EventArgs e)
        {

        }
        public void cargar_telefono()
        {
            dataGridView2.Rows.Clear();
            try
            {
                string sql = "select telefono,tipo_telefono from tercero_vs_telefono tt where tt.cod_tercero='" + codigo_suplidor_txt.Text.Trim() + "' and tt.tipo_entidad='SUP'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView2.Rows.Add(row[0].ToString(), row[1].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los telefonos");
            }
        }
        public void actualiza_telefono()
        {
            string sql = "";
            DataSet ds = new DataSet();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                sql = "exec insert_telefono_tercero '" + codigo_suplidor_txt.Text.Trim() + "','" + row.Cells[0].Value.ToString() + "','SUP','" + row.Cells[1].Value.ToString() + "'";
                Utilidades.ejecutarcomando(sql);
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //guardar
                try
                {
                    
                    if(codigo_suplidor_txt.Text.Trim()=="")
                    {
                        //guarda
                        if(nombre_suplidor_txt.Text.Trim()!="")
                        {
                               
                                    if(codigo_sexo_txt.Text.Trim()!="")
                                    {
                                        if(dateTimePicker1.Text!="")
                                        {
                                            /*
                                            create proc insert_suplidor
                                            @nombre varchar(50),@identificacion varchar(200),@apellido varchar(50),
                                            @fecha_nacimiento date,@cod_sexo int,@estado bit,@codigo int
                                            */
                                            string sql="";
                                            DataSet ds=new DataSet();
                                            if (codigo_suplidor_txt.Text.Trim() != "")
                                            {
                                                sql = "select *from tercero where identificacion ='" + identificacion_txt.Text.Trim() + "' and codigo !='" + codigo_suplidor_txt.Text.Trim() + "' and identificacion!=''";
                                                ds = Utilidades.ejecutarcomando(sql);
                                            }
                                            else
                                            {
                                                sql = "select *from tercero where identificacion ='" + identificacion_txt.Text.Trim() + "' and identificacion!='' and codigo!='"+codigo_suplidor_txt.Text.Trim()+"'";
                                                ds = Utilidades.ejecutarcomando(sql);
                                            }
                                            if (ds.Tables[0].Rows.Count == 0)
                                            {
                                                int estado = 0;

                                                if (ck_activo.Checked == true)
                                                {
                                                    estado = 1;
                                                }
                                                else
                                                {
                                                    estado = 0;
                                                }
                                                //MessageBox.Show(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                                                sql = "exec insert_suplidor '"+nombre_suplidor_txt.Text.Trim()+"','"+identificacion_txt.Text.Trim()+"','"+apellido_suplidor_txt.Text.Trim()+"','"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+"','"+codigo_sexo_txt.Text.Trim()+"','"+estado.ToString()+"','0'";
                                                ds = Utilidades.ejecutarcomando(sql);
                                                codigo_suplidor_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                                                if(ds.Tables[0].Rows.Count>0)
                                                {
                                                 actualiza_telefono();
                                                 MessageBox.Show("Se agrego");
                                                }
                                                else
                                                {
                                                    MessageBox.Show("No se agrego");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Esa identificacion se encuentra registrada");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Falta la fecha de nacimiento");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Falta el genero");
                                    }
                        }
                        else
                        {
                            MessageBox.Show("Falta el nombre");
                        }
                    }
                    else
                    {
                        //actualiza
                        if (nombre_suplidor_txt.Text.Trim() != "")
                        {
                            if (codigo_sexo_txt.Text.Trim() != "")
                            {
                                if (dateTimePicker1.Text != "")
                                {
                                    /*
                                    create proc insert_suplidor
                                    @nombre varchar(50),@identificacion varchar(200),@apellido varchar(50),
                                    @fecha_nacimiento date,@cod_sexo int,@fecha_creacion date,@estado bit,@codigo int
                                    */
                                    string sql = "";
                                    DataSet ds = new DataSet();
                                    sql = "select *from tercero where identificacion ='" + identificacion_txt.Text.Trim() + "' and identificacion!='' and codigo!='"+codigo_suplidor_txt.Text.Trim()+"'";
                                    ds = Utilidades.ejecutarcomando(sql);
                                    if (ds.Tables[0].Rows.Count == 0)
                                    {
                                        int estado = 0;
                                        if (ck_activo.Checked == true)
                                            estado = 1;
                                        else
                                            estado = 0;
                                        sql = "exec insert_suplidor '" + nombre_suplidor_txt.Text.Trim() + "','" + identificacion_txt.Text.Trim() + "','" + apellido_suplidor_txt.Text.Trim() + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + codigo_sexo_txt.Text.Trim() + "','" + estado.ToString() + "','" + codigo_suplidor_txt.Text.Trim() + "'";
                                        ds = Utilidades.ejecutarcomando(sql);
                                        codigo_suplidor_txt.Text = ds.Tables[0].Rows[0][0].ToString();

                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            actualiza_telefono();
                                            MessageBox.Show("Se actualizo");
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se actualizo");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Esa identificacion se encuentra registrada");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Falta la fecha de nacimiento");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Falta el genero");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta el nombre");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error agregando/actualizando del suplidor");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                codigo_suplidor_txt.Clear();
                nombre_suplidor_txt.Clear();
                apellido_suplidor_txt.Clear();
                identificacion_txt.Clear();
                codigo_sexo_txt.Clear();
                nombre_sexo_txt.Clear();
                ck_activo.Checked = true;
                telefono_txt.Clear();
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }
        public void llenar_campos()
        {
            try
            {
                //buscar todos los datos del suplidor cuando se seleccione uno existente

            }
            catch(Exception)
            {
                MessageBox.Show("Error llenando los campos de suplidor");
            }
        }
        public void cargar_datos_suplidor()
        {
            try
            {
                if (codigo_suplidor_txt.Text.Trim() == "")
                    return;

                string sql = "select t.nombre,p.apellido,t.identificacion,p.cod_sexo,p.fecha_nacimiento,s.estado,s.fecha_creacion from tercero t join persona p on p.codigo=t.codigo join suplidor s on s.codigo=p.codigo where s.codigo='"+codigo_suplidor_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                string fecha = ds.Tables[0].Rows[0][6].ToString();
                fecha_ingreso.Value =Convert.ToDateTime(fecha.ToString());
                if(ds.Tables[0].Rows[0][5].ToString()=="True")
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
                MessageBox.Show("No existe como suplidor","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private void pais_btn_Click(object sender, EventArgs e)
        {
            limpiar();
            busqueda_tercero bt = new busqueda_tercero();
            bt.pasado += new busqueda_tercero.pasar(ejecutar_codigo_suplidor);
            bt.mantenimiento = true;
            bt.ShowDialog();
            cargar_datos_personales();
            cargar_datos_suplidor();
            cargar_telefono();
            cargar_productos_suplidos();
        }
        public void cargar_datos_personales()
        {
            try
            {
                string sql = "select t.nombre,p.apellido,t.identificacion,p.cod_sexo,p.fecha_nacimiento,t.estado from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + codigo_suplidor_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_suplidor_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                apellido_suplidor_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                identificacion_txt.Text = ds.Tables[0].Rows[0][2].ToString();
                codigo_sexo_txt.Text = ds.Tables[0].Rows[0][3].ToString();
                cargar_nombre_sexo();
                string fecha = ds.Tables[0].Rows[0][4].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(fecha.ToString());
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando datos personales");
            }
        }
        public void cargar_productos_suplidos()
        {
            dataGridView1.Rows.Clear();
            try
            { 
                string sql = "select distinct p.codigo,p.nombre from suplidor s join compra c on s.codigo=c.cod_suplidor join compra_detalle cd on cd.cod_compra=c.codigo join producto p on cd.cod_producto=p.codigo join unidad u on u.codigo=cd.cod_unidad join tercero t on t.codigo=s.codigo where s.codigo='"+codigo_suplidor_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("No hay productos por parte de este suplidor");
            }

        }
     
        public void ejecutar_codigo_suplidor(string dato)
        {
            codigo_suplidor_txt.Text = dato.ToString();
        }
        public void buscar_productos_suplidor()
        {
            try
            {
                string sql = "select p.nombre,sp.detalle from producto p join suplidor_vs_producto sp on sp.cod_producto=p.codigo where sp.cod_suplidor='"+codigo_suplidor_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando los productos que ha suplido");
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int cont = 0;
                string sql = "";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells[0].Value.ToString() == telefono_txt.Text.Trim())
                    {
                        cont++;
                    }
                }
                if (cont == 0)
                {
                    if (tipo_telefono_combo_txt.Text.Trim() != "")
                    {
                        dataGridView2.Rows.Add(telefono_txt.Text.Trim(), tipo_telefono_combo_txt.Text.Trim());
                        telefono_txt.Clear();
                        telefono_txt.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Falta el tipo de telefono");
                    }
                }
                else
                {
                    MessageBox.Show("El telefono que intenta poner ya se encuentra puesto");
                    telefono_txt.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error agregando el numero");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
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

        private void sexo_combo_txt_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            busqueda_sexo bs = new busqueda_sexo();
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
                string sql = "select sexo from sexo where codigo='" + codigo_sexo_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_sexo_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando nombre del sexo");
            }
        }

        private void tipo_telefono_combo_txt_KeyUp(object sender, KeyEventArgs e)
        {
            tipo_telefono_combo_txt.Text = "";
        }

        private void identificacion_txt_TextChanged(object sender, EventArgs e)
        {

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
