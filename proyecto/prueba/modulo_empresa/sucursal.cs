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
    public partial class sucursal : Form
    {
        public sucursal()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void sucursal_Load(object sender, EventArgs e)
        {
            button8.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            direccion d = new direccion();
            d.codigo_direccion_global = codigo_direccion_txt.Text.Trim();
            d.pasado += new direccion.pasar(ejecutar_direccion);
            d.ShowDialog();
        }
        public void ejecutar_direccion(string dato)
        {
            codigo_direccion_txt.Text = dato.ToString();
        }
        public void ejecutar(string dato)
        {
            codigo_direccion_txt.Text = dato.ToString();
            codigo_direccion_txt.ReadOnly = true;
            ck_activo.Focus();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select t.codigo from telefono t join tercero_vs_telefono tv on tv.cod_telefono=t.codigo where t.telefono='" + telefono_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    dataGridView1.Rows.Add(telefono_txt.Text.Trim());
                    telefono_txt.Clear();
                    telefono_txt.Focus();
                }
                else
                {
                    MessageBox.Show("Ese numero ya se encuentra en uso");
                    telefono_txt.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error agregando el numero");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    codigo_empresa_txt.Clear();
                    nombre_empresa_txt.Clear();
                    codigo_sucursal_txt.Clear();
                    sucursal_nombre_txt.Clear();
                    secuencia_txt.Clear();
                    codigo_direccion_txt.Clear();
                    ck_activo.Checked = true;
                    telefono_txt.Clear();
                    dataGridView1.Rows.Clear();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }
        public void cargar_datos()
        {
            try
            {
                if (codigo_sucursal_txt.Text.Trim() != "")
                {
                    string sql = "select t.nombre,s.secuencia,(select top(1)td.cod_direccion from tercero_vs_direccion td where td.cod_tercero=t.codigo)as cod_direccion,s.estado,t.codigo from sucursal s join tercero t on t.codigo=s.codigo where s.codigo='" + codigo_sucursal_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    sucursal_nombre_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                    secuencia_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                    codigo_direccion_txt.Text = ds.Tables[0].Rows[0][2].ToString();
                    if (ds.Tables[0].Rows[0][3].ToString() == "True")
                    {
                        ck_activo.Checked = true;
                    }
                    else
                    {
                        ck_activo.Checked = false;
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los datos de la sucursal");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (codigo_empresa_txt.Text.Trim() != "")
            {

                secuencia_txt.Clear();
                codigo_direccion_txt.Clear();
                ck_activo.Checked = false;
                dataGridView1.Rows.Clear();
                telefono_txt.Clear();

                busqueda_sucursal bs = new busqueda_sucursal();
                bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal);
                bs.codigo_empresa_global = codigo_empresa_txt.Text.Trim();
                bs.mantenimiento = true;
                bs.ShowDialog();
                cargar_datos();
                cargar_numeros();

            }
            else
            {
                MessageBox.Show("Debe seleccionar la empresa");
            }
        }
        public void ejecutar_codigo_sucursal(string dato)
        {
            codigo_sucursal_txt.Text = dato.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                guardar();
                actualiza_numeros();
            }
        }
        public void cargar_numeros()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select telefono,tipo_telefono from tercero_vs_telefono where tipo_entidad='SUC' and cod_tercero='" + codigo_sucursal_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString());
                }
            }
            catch (Exception)
            {

            }
        }
        public void actualiza_numeros()
        {
            try
            {
                //create proc insert_telefono_sucursal @codigo_sucursal int,@telefono varchar(15)

                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    //exec insert_telefono_tercero 'codigo_ter','telefono','entidad','tipo_tel'
                    string sql = "exec insert_telefono_tercero'"+codigo_sucursal_txt.Text.Trim()+"','"+row.Cells[0].Value.ToString()+"','SUC','"+row.Cells[1].Value.ToString()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                }
            }
            catch(Exception)
            {

            }
        }
        public void guardar()
        {
            try
            {
                //create proc insert_sucursal @nombre varchar(100),@codigo_empresa int,
                //@secuencia varchar(3),@codigo_direccion int,@estado bit,@codigo_sucursal int

                string sql = "";
                DataSet ds =new DataSet();
                if(codigo_empresa_txt.Text.Trim()!="")
                {
                    if(sucursal_nombre_txt.Text.Trim()!="")
                    {
                        if(secuencia_txt.Text.Trim()!="" && secuencia_txt.TextLength==3)
                        {
                            sql = "select *from sucursal where secuencia='"+secuencia_txt.Text.Trim()+"' and codigo!='"+codigo_sucursal_txt.Text.Trim()+"' and codigo_empresa='"+codigo_empresa_txt.Text.Trim()+"'";
                            ds = Utilidades.ejecutarcomando(sql);
                            if(ds.Tables[0].Rows.Count==0)
                            {
                                if(codigo_direccion_txt.Text.Trim()!="")
                                {
                                    int estado = 0;
                                    if (ck_activo.Checked == true)
                                        estado = 1;
                                    else
                                        estado = 0;
                                    if (secuencia_txt.Text.Trim() != "" && secuencia_txt.TextLength == 3)
                                    {
                                        if (codigo_sucursal_txt.Text.Trim() == "")
                                        {

                                            //guardar
                                            //create proc insert_sucursal @nombre varchar(100),@codigo_empresa int,
                                            //@secuencia varchar(3),@codigo_direccion int,@estado bit,@codigo_sucursal int
                                            sql = "exec insert_sucursal '" + sucursal_nombre_txt.Text.Trim() + "','" + codigo_empresa_txt.Text.Trim() + "','" + secuencia_txt.Text.Trim() + "','" + codigo_direccion_txt.Text.Trim() + "','" + estado.ToString() + "','0'";
                                            ds = Utilidades.ejecutarcomando(sql);
                                            if (ds.Tables[0].Rows.Count > 0)
                                            {
                                                codigo_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                                                actualiza_numeros();
                                                MessageBox.Show("Se guardo");
                                            }
                                            else
                                            {
                                                MessageBox.Show("No se guardo");
                                            }
                                        }
                                        else
                                        {
                                            /*actualizar
                                            create proc insert_sucursal @nombre varchar(100),@codigo_empresa int,
                                            @secuencia varchar(3),@codigo_direccion int,@estado bit,@codigo_sucursal int
                                            */
                                            sql = "exec insert_sucursal '" + sucursal_nombre_txt.Text.Trim() + "','" + codigo_empresa_txt.Text.Trim() + "','" + secuencia_txt.Text.Trim() + "','" + codigo_direccion_txt.Text.Trim() + "','" + estado.ToString() + "','" + codigo_sucursal_txt.Text.Trim() + "'";
                                            ds = Utilidades.ejecutarcomando(sql);
                                            if (ds.Tables[0].Rows.Count > 0)
                                            {
                                                codigo_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                                                actualiza_numeros();
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
                                        MessageBox.Show("La secuencia de la sucursal debe tener tres digitos(001-029-123)");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Debe tener el codigo de la direccion");
                                }
                            }
                            else
                            {
                                MessageBox.Show("La secuencia ya la tiene otra sucursal");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe tener la secuencia de la sucursal que son tres digitos(001-002-003)");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe tener el nombre");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar la empresa");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error guardando la sucursal");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            busqueda_empresa be = new busqueda_empresa();
            be.pasado += new busqueda_empresa.pasar(ejecutar_codigo_empresa);
            be.ShowDialog();
            cargar_nombre_empresa();
            sucursal_nombre_txt.Focus();
            //para cuando se cambie la empresa limpiar todos los datos de 
            //abajo porq ya no pertenecen a la misma empresa y aunque lo fuera debe
            //de limpiarse
            codigo_sucursal_txt.Clear();
            sucursal_nombre_txt.Clear();
            secuencia_txt.Clear();
            codigo_direccion_txt.Clear();
            ck_activo.Checked = false;
            dataGridView1.Rows.Clear();
            telefono_txt.Clear();
        }
        public void ejecutar_codigo_empresa(string dato)
        {
            codigo_empresa_txt.Text = dato.ToString();
            
        }
        public void cargar_nombre_empresa()
        {
            try
            {
                string sql = "select nombre from tercero where codigo='"+codigo_empresa_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_empresa_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre de la empresa");
            }
        }

        private void telefono_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                button12.Focus();
            }
        }

        private void sucursal_nombre_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                secuencia_txt.Focus();
            }
        }

        private void secuencia_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

            }
        }

        private void ck_activo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                telefono_txt.Focus();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int cont = 0;
            try
            {
                string sql = "select *from tercero_vs_telefono where telefono='" + telefono_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (telefono_txt.Text != "")
                {
                    if (tipo_telefono_combo_txt.Text != "")
                    {
                        if (ds.Tables[0].Rows.Count == 0)
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
                            MessageBox.Show("Ese numero ya se encuentra registrado en la base de datos");
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

        private void tipo_telefono_combo_txt_KeyUp(object sender, KeyEventArgs e)
        {
            tipo_telefono_combo_txt.Text = "";
        }

        private void secuencia_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if(Utilidades.numero_entero(secuencia_txt.Text.Trim())==false)
            {
                secuencia_txt.Clear();
            }
        }
    }
}
