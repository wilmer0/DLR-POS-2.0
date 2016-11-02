using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using puntoVenta;
namespace puntoVenta
{
    public partial class grupo_usuarios :Form
    {
        public grupo_usuarios()
        {
            InitializeComponent();
        }

        private void grupo_usuarios_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            busqueda_grupo_usuario bg = new busqueda_grupo_usuario();
            bg.pasado += new busqueda_grupo_usuario.pasar(ejecutar_codigo_grupo);
            bg.mantenimientos = true;
            bg.ShowDialog();
            cargar_permisos_grupo();
        }
        public void cargar_permisos_grupo()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select gu.cod_permiso,p.descripcion from grupo_usuarios_permisos gu join permiso p on p.codigo=gu.cod_permiso where gu.cod_grupo ='"+codigo_grupo_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando permisos del grupo");
            }
        }
        public void ejecutar_codigo_grupo(string dato)
        {
            try
            {
                codigo_grupo_txt.Text = dato.ToString();
                string sql = "select nombre,estado from grupo_usuarios where codigo='" + codigo_grupo_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_grupo_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                if(ds.Tables[0].Rows[0][1].ToString()=="True")
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
                MessageBox.Show("Error cargando los datos del grupo de usuario");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            busqueda_permisos bp = new busqueda_permisos();
            bp.pasado += new busqueda_permisos.pasar(ejecutar_codigo_permiso);
            bp.ShowDialog();
        }
        public void ejecutar_codigo_permiso(string dato)
        {
            codigo_permiso_txt.Text = dato.ToString();
            cargar_nombre_permiso();
        }
        public void cargar_nombre_permiso()
        {
            try
            {
                string sql = "select descripcion from permiso where codigo='" + codigo_permiso_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_permiso_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando nombre de permiso");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int cont = 0;//contador para saber si un permiso se encuentra mas de una vez
            try
            {
                if (codigo_permiso_txt.Text.Trim() != "")
                {
                    if (nombre_permiso_txt.Text.Trim() != "")
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == codigo_permiso_txt.Text.Trim())
                            {
                                cont++;
                            }
                        }
                        if (cont == 0)
                        {
                            dataGridView1.Rows.Add(codigo_permiso_txt.Text.Trim(), nombre_permiso_txt.Text.ToString().Trim());
                            codigo_permiso_txt.Clear();
                            nombre_permiso_txt.Clear();
                            button4.Focus();
                        }
                        else
                        {
                            MessageBox.Show("El permiso que ha seleccionado ya se encuentra puesto.");
                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error agregando los permisos");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea quitar el permiso?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
        public void actualiza_permisos_grupo()
        {
            try
            {
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    /*create proc insert_permiso_grupo_usuario
                      @cod_grupo int,@cod_permiso int
                    */
                    string sql = "exec insert_permiso_grupo_usuario '" + codigo_grupo_txt.Text.Trim() + "','" + fila.Cells[0].Value.ToString() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error agregando los permisos");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (codigo_grupo_txt.Text.Trim() != "")
                {
                    string sql = "delete from grupo_usuarios_permisos where cod_grupo='" + codigo_grupo_txt.Text.Trim() + "'";
                    Utilidades.ejecutarcomando(sql);
                    actualiza_permisos_grupo();
                    MessageBox.Show("Finalizado");
                }
                else
                {
                    MessageBox.Show("Falta el grupo de usuario");
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                
                    if(nombre_grupo_txt.Text.Trim()!="")
                    {
                        int estado = 0;
                        if (ck_activo.Checked == true)
                            estado = 1;
                        else
                            estado = 0;
                        /*
                            create proc insert_grupo_usuario
                            @nombre varchar(50),@estado int,@codigo_v int
                         */
                        if (codigo_grupo_txt.Text.Trim()=="")
                        {
                            //guardar
                            string sql = "exec insert_grupo_usuario '"+nombre_grupo_txt.Text.Trim()+"','"+estado.ToString()+"','0'";
                            DataSet ds = Utilidades.ejecutarcomando(sql);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show("Se agrego");
                            }
                            else
                            {
                                MessageBox.Show("No se grego");
                            }
                        }
                        else
                        {
                            if (ck_activo.Checked == true)
                                estado = 1;
                            else
                                estado = 0;
                            //modificar
                            string sql = "exec insert_grupo_usuario '" + nombre_grupo_txt.Text.Trim() + "','" + estado.ToString() + "','"+codigo_grupo_txt.Text.Trim()+"'";
                            DataSet ds = Utilidades.ejecutarcomando(sql);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show("Se modifico");
                            }
                            else
                            {
                                MessageBox.Show("No se modifico");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el nombre del grupo");
                    }   
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    codigo_grupo_txt.Clear();
                    nombre_grupo_txt.Clear();
                    ck_activo.Checked = true;
                    codigo_permiso_txt.Clear();
                    nombre_permiso_txt.Clear();
                    dataGridView1.Rows.Clear();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if(ck_todos.Checked==true)
            {
                ck_todos.Checked = false;
            }
            else
            {
                ck_todos.Checked = true;
            }
            if(ck_todos.Checked==true)
            {
                cargar_permisos_por_defecto();   
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }
        public void cargar_permisos_por_defecto()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select codigo,descripcion from permiso where estado=1 order by codigo";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando todos los permisos por defecto");
            }
        }

        private void ck_todos_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
