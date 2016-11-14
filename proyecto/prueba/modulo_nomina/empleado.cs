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
    public partial class empleado : Form
    {
        public empleado()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
        internal singleton s { get; set; }
        private void registro_empleado_Load(object sender, EventArgs e)
        {
            cargar_permisos_por_defecto();//carga todos los permisos por defecto cuando entra con un usuario nuevo
            cargar_sucursal();
            cargar_genero();
            cargar_situacion();
            s=singleton.obtenerDatos();
            if (s.codigo_usuario != "1")
            {
                //para que no le valide nada cuando sea admin
                //el admin podra hacer de todo
                if (s.puede_asignar_permisos == false)
                {
                    button4.Enabled = false;
                    button9.Enabled = false;
                    button10.Enabled = false;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Enabled = false;
                }
            }
        }
        
        public void cargar_sucursal()
        {
            try
            {
                string sql_sucu = "select t.nombre from sucursal s join tercero t on t.codigo=s.tercero where s.estado='1' order by t.nombre";
                DataSet su = Utilidades.ejecutarcomando(sql_sucu);
                //sucursal_combo.DataSource = su.Tables[0];
                //sucursal_combo.DisplayMember = "nombre";
                //sucursal_combo.ValueMember = "nombre";
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las situaciones del empleado");
            }
        }
        public void cargar_situacion()
        {
            try
            {
                string sql_situ = "select descripcion from situacion_empleado where estado='1' order by descripcion";
                DataSet si = Utilidades.ejecutarcomando(sql_situ);
                //situacion_combo.DataSource = si.Tables[0];
                //situacion_combo.DisplayMember = "descripcion";
                //situacion_combo.ValueMember = "descripcion";
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando las situaciones del empleado");
            }
        }
        public void cargar_genero()
        {
            try
            {
                
                string sql_gen = "select *from sexo where estado='1' order by sexo";
                DataSet gen = Utilidades.ejecutarcomando(sql_gen);
                //genero_combo.DataSource = gen.Tables[0];
                //genero_combo.DisplayMember = "sexo";//nombre a mostrar
                //genero_combo.ValueMember = "sexo";//nombre logico del campo de bd
            
                 
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los generos del empleado");
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void nombre_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
            {
                apellido_empleado_txt.Focus();
            }
        }

        private void codigo_usuario_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (codigo_empleado_txt.Text == "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    nombre_empleado_txt.Focus();
                }
            }
            else
            {
                    cargar_datos_empelado();    
            }
        }
        
      
        public void limpiar()
        {
            cargar_sucursal();
            cargar_genero();
            cargar_situacion();
            codigo_empleado_txt.Clear();
            nombre_empleado_txt.ReadOnly = false;
            nombre_empleado_txt.Clear();
            apellido_empleado_txt.Clear();
           
            cedula_txt.Clear();
            sueldo_fijo_txt.Clear();
            codigo_empleado_txt.Clear();
            login_txt.Clear();
            fecha_nacimiento.Text = "";
            codigo_sucursal_txt.Clear();
            nombre_sucursal_txt.Clear();
            codigo_cargo_txt.Clear();
            nombre_cargo_txt.Clear();
            codigo_permiso_txt.Clear();
            nombre_permiso_txt.Clear();
            telefono_txt.Clear();
            clave_txt.Clear();
            codigo_departamento_txt.Clear();
            nombre_departamento_txt.Clear();
            codigo_situacion_empleado_txt.Clear();
            nombre_situacion_empleado_txt.Clear();
            codigo_sexo_txt.Clear();
            nombre_sexo_txt.Clear();
           
            codigo_empresa_txt.Clear();
            nombre_empresa_txt.Clear();
            codigo_grupo_usuario_txt.Clear();
            nombre_grupo_usuario_txt.Clear();
            codigo_tipo_nomina_txt.Clear();
            nombre_tipo_nomina_txt.Clear();



            ck_activo.Checked = false;
            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Clear();
        }
        private void apellido_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cedula_txt.Focus();
            }
        }

        private void cedula_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode==Keys.Tab)
            {
                try
                {
                    if (cedula_txt.Text != "")
                    {
                        if (codigo_empleado_txt.Text != "")
                        {
                            string cmd = "select *from tercero where identificacion='" + cedula_txt.Text.Trim() + "' and codigo!='"+codigo_empleado_txt.Text.Trim()+"'";
                            DataSet ds = Utilidades.ejecutarcomando(cmd);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show("Esa identificacion ya esta en uso");
                                cedula_txt.Clear();
                                cedula_txt.Focus();
                            }
                        }
                        else
                        {
                            string cmd = "select *from tercero where identificacion='" + cedula_txt.Text.Trim() + "'";
                            DataSet ds = Utilidades.ejecutarcomando(cmd);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show("Esa identificacion ya esta en uso");
                                cedula_txt.Clear();
                                cedula_txt.Focus();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error en buqueda de cedula o rnc");
                }
                codigo_sexo_txt.Focus();
            }
        }

        private void genero_combo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sueldo_fijo_txt.Focus();
            }
        }

        private void sueldo_fijo_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fecha_nacimiento.Focus();
            }
        }

        private void fecha_nacimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //situacion_combo.Focus();
            }
        }

        private void situacion_combo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login_txt.Focus();
            }
        }

        private void login_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if(login_txt.Text!=""&& codigo_empleado_txt.Text.Trim()!="")
                    {
                        string cmd = "select *from empleado where login='" + login_txt.Text.Trim() + "' and codigo!='"+codigo_empleado_txt.Text.Trim()+"'";
                        DataSet ds = Utilidades.ejecutarcomando(cmd);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Ese login ya esta en uso");
                            login_txt.Clear();
                            cedula_txt.Focus();
                        }
                    }
                    if (login_txt.Text != "" && codigo_empleado_txt.Text.Trim()=="")
                    {
                        string cmd = "select *from empleado where login='" + login_txt.Text.Trim() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(cmd);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Ese login ya esta en uso");
                            login_txt.Clear();
                            cedula_txt.Focus();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error en buqueda de cedula o rnc");
                }
                //clave_txt.Focus();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ck_activo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void genero_combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void codigo_usuario_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr =MessageBox.Show("Desea salir?","Saliendo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dr==DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar la ventana?","Limpiando",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dr==DialogResult.Yes)
            {
                limpiar();
                cargar_permisos_por_defecto();
            }
        }
        public void actualiza_permisos()
        {
            try
            {
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                  string   sql = "exec insert_permiso_tercero '" + codigo_empleado_txt.Text.Trim() + "','" + fila.Cells[0].Value.ToString() + "','EMP'";
                   DataSet ds = Utilidades.ejecutarcomando(sql);
                    //MessageBox.Show(fila.Cells[1].Value.ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error agregando los permisos");
            }
        }
        public void actualiza_telefono()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                   string sql = "exec insert_telefono_tercero '" + codigo_empleado_txt.Text.Trim() + "','" + row.Cells[0].Value.ToString() + "','EMP','" + row.Cells[1].Value.ToString() + "'";
                   DataSet ds=Utilidades.ejecutarcomando(sql);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error actualizando los telefonos");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
                DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                { 
                            /*
                            ALTER proc [dbo].[insert_empleado]
                            @nombre varchar(50),@apellido varchar(50),@identificacion varchar(11),@cod_sexo int,
                            @fecha_nacimiento date,@login varchar(30),@clave varchar(30),@sueldo float,@cod_situacion int,
                            @cod_sucursal int,@cod_departamento int,@cod_cargo int,@cod_cliente int,@estado bit,@cod_tipo_nomina,@cod_tercero_modificar int
                             */
                            if (nombre_empleado_txt.Text.Trim() != "")
                            {
                                if (apellido_empleado_txt.Text.Trim() != "")
                                {
                                    if (cedula_txt.Text.Trim() != "")
                                    {
                                        if (nombre_sexo_txt.Text.Trim() != "")
                                        {
                                            if (sueldo_fijo_txt.Text.Trim() != "")
                                            {
                                                if (login_txt.Text.Trim() != "")
                                                {
                                                    if (codigo_sucursal_txt.Text.Trim() != "")
                                                    {
                                                        if (codigo_departamento_txt.Text.Trim() != "")
                                                        {
                                                            if (codigo_cargo_txt.Text.Trim() != "")
                                                            {
                                                                if (codigo_situacion_empleado_txt.Text.Trim() != "")
                                                                {
                                                                    if (codigo_tipo_nomina_txt.Text.Trim() != "")
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
                                                                        if (codigo_empleado_txt.Text.Trim() == "")
                                                                        {
                                                                            //se guarda
                                                                            //buscando si la cedula existe
                                                                            string cmd = "select *from tercero t where t.identificacion='" + cedula_txt.Text.Trim() + "' and t.codigo!='" + codigo_empleado_txt.Text.Trim() + "'";
                                                                            DataSet valcedula = Utilidades.ejecutarcomando(cmd);
                                                                            if (valcedula.Tables[0].Rows.Count == 0)
                                                                            {
                                                                                //puede seguir la cedula no existe con otro usuario
                                                                                cmd = "select *from empleado e where e.login='" + login_txt.Text.Trim() + "' and e.codigo!='" + codigo_empleado_txt.Text.Trim() + "'";
                                                                                DataSet vallogin = Utilidades.ejecutarcomando(cmd);
                                                                                if (vallogin.Tables[0].Rows.Count == 0)
                                                                                {
                                                                                    string sql = "";
                                                                                   
                                                                                    string clavee = Utilidades.encriptar(clave_txt.Text.Trim());
                                                                                   DataSet ds=new DataSet();
                                                                                        sql = "exec insert_empleado '" + nombre_empleado_txt.Text.Trim() + "','" + apellido_empleado_txt.Text.Trim() + "','" + cedula_txt.Text.Trim() + "','" + codigo_sexo_txt.Text.Trim() + "','" + fecha_nacimiento.Value.ToString("yyyy-MM-dd") + "','" + login_txt.Text.Trim() + "','" + clavee.ToString() + "','" + sueldo_fijo_txt.Text.Trim() + "','" + codigo_situacion_empleado_txt.Text.Trim() + "','" + codigo_sucursal_txt.Text.Trim() + "','" + codigo_departamento_txt.Text.Trim() + "','" + codigo_cargo_txt.Text.Trim() + "','" + estado.ToString() + "','" + s.codigo_usuario.ToString() + "','" + codigo_grupo_usuario_txt.Text.Trim() + "','" + fecha_ingreso.Value.ToString("yyyy-MM-dd") + "','" + codigo_tipo_nomina_txt.Text.Trim() + "','0'";
                                                                                        ds = Utilidades.ejecutarcomando(sql);
                                                                                        if (ds.Tables[0].Rows.Count > 0)
                                                                                        {
                                                                                            codigo_empleado_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                                                                                            sql = "delete from tercero_vs_permiso where cod_tercero='" + codigo_empleado_txt.Text.Trim() + "' and tipo_entidad='EMP'";
                                                                                            Utilidades.ejecutarcomando(sql);
                                                                                            sql = "delete from tercero_vs_telefono where cod_tercero='" + codigo_empleado_txt.Text.Trim() + "' and tipo_entidad='EMP'";
                                                                                            Utilidades.ejecutarcomando(sql);

                                                                                            try
                                                                                            {
                                                                                                foreach (DataGridViewRow fila in dataGridView1.Rows)
                                                                                                {
                                                                                                    sql = "exec insert_permiso_tercero '" + codigo_empleado_txt.Text.Trim() + "','" + fila.Cells[0].Value.ToString() + "','EMP'";
                                                                                                    ds = Utilidades.ejecutarcomando(sql);
                                                                                                    //MessageBox.Show(fila.Cells[1].Value.ToString());
                                                                                                }
                                                                                            }
                                                                                            catch (Exception)
                                                                                            {
                                                                                                MessageBox.Show("Error agregando los permisos");
                                                                                            }
                                                                                            try
                                                                                            {
                                                                                                foreach (DataGridViewRow row in dataGridView2.Rows)
                                                                                                {
                                                                                                    sql = "exec insert_telefono_tercero '" + codigo_empleado_txt.Text.Trim() + "','" + row.Cells[0].Value.ToString() + "','EMP','" + row.Cells[1].Value.ToString() + "'";
                                                                                                    ds = Utilidades.ejecutarcomando(sql);
                                                                                                }
                                                                                            }
                                                                                            catch (Exception)
                                                                                            {
                                                                                                MessageBox.Show("Error actualizando los telefonos");
                                                                                            }

                                                                                            MessageBox.Show("Se guardo");
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            MessageBox.Show("No se guardo");
                                                                                        }
                                                                                }
                                                                                else
                                                                                {
                                                                                    MessageBox.Show("El nombre de usuario esta siendo usado por otro usuario");
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                MessageBox.Show("La identificacion esta en uso por otra entidad");
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            //actualizar
                                                                            string sql = "";
                                                                            DataSet ds = Utilidades.ejecutarcomando(sql);
                                                                           
                                                                                string clavee = Utilidades.encriptar(clave_txt.Text.Trim());
                                                                                sql = "exec insert_empleado '" + nombre_empleado_txt.Text.Trim() + "','" + apellido_empleado_txt.Text.Trim() + "','" + cedula_txt.Text.Trim() + "','" + codigo_sexo_txt.Text.Trim() + "','" + fecha_nacimiento.Value.ToString("yyyy-MM-dd") + "','" + login_txt.Text.Trim() + "','" + clavee.ToString() + "','" + sueldo_fijo_txt.Text.Trim() + "','" + codigo_situacion_empleado_txt.Text.Trim() + "','" + codigo_sucursal_txt.Text.Trim() + "','" + codigo_departamento_txt.Text.Trim() + "','" + codigo_cargo_txt.Text.Trim() + "','" + estado.ToString() + "','" + s.codigo_usuario.ToString() + "','" + codigo_grupo_usuario_txt.Text.Trim() + "','" + fecha_ingreso.Value.ToString("yyyy-MM-dd") + "','" + codigo_tipo_nomina_txt.Text.Trim() + "','" + codigo_empleado_txt.Text.Trim() + "'";
                                                                                ds = Utilidades.ejecutarcomando(sql);
                                                                                if (ds.Tables[0].Rows.Count > 0)
                                                                                {
                                                                                    //actualizar los permisos
                                                                                    sql = "";
                                                                                    //primero elimino todos los permisos viejos para ingresar los nuevos que haya seleccionado el usuario
                                                                                    sql = "exec eliminar_permisos_tercero '" + codigo_empleado_txt.Text.Trim() + "','EMP'";
                                                                                    Utilidades.ejecutarcomando(sql);
                                                                                    actualiza_permisos();
                                                                                    //ahora actualizar los telefonos
                                                                                    if (dataGridView2.Rows.Count > 0)
                                                                                    {
                                                                                        sql = "delete from tercero_vs_telefono where cod_tercero='" + codigo_empleado_txt.Text.Trim() + "' and tipo_entidad='EMP'";
                                                                                        Utilidades.ejecutarcomando(sql);
                                                                                        actualiza_telefono();

                                                                                    }
                                                                                    MessageBox.Show("Se actualizo!");
                                                                                }
                                                                                else
                                                                                {
                                                                                    MessageBox.Show("No se actualizo");
                                                                                }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("Falta el tipo de nomina del empleado");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Falta la situacion del empleado");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Falta el cargo del empleado");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Falta el departamento del empleado");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Falta la sucursal del empleado");
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Falta el nombre de inicio de sesion->login");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Falta el sueldo");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Falta el genero");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Falta la cedula/identificacion");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Falta el apellido");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Falta el nombre");
                            }
                }
        }
        private void login_txt_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        public void cargar_permisos_por_defecto()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string sql = "select codigo,descripcion from permiso where estado=1 order by descripcion";
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
        public void cargar_datos_empresa()
        {
            try
            {
                if (codigo_empleado_txt.Text.Trim() != "")
                {
                    string sql = "select e.codigo from empresa e join sucursal s on s.codigo_empresa=e.codigo join tercero t on t.codigo=e.codigo where s.codigo='" + codigo_sucursal_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    codigo_empresa_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                    cargar_nombre_empresa();
                }
            }
            catch (Exception)
            {

            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            busqueda_tercero bt = new busqueda_tercero();
            bt.pasado += new busqueda_tercero.pasar(ejecutar_codigo_empleado);
            bt.ShowDialog();
            cargar_datos_personales();
            cargar_datos_empelado();
            cargar_datos_empresa();
            cargar_permisos();
            cargar_telefono();
           
        }
        public void cargar_telefono()
        {
            try
            {
                string sql = "select telefono,tipo_telefono from tercero_vs_telefono tt where tt.cod_tercero='"+codigo_empleado_txt.Text.Trim()+"' and tt.tipo_entidad='EMP'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView2.Rows.Add(row[0].ToString(),row[1].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los telefonos");
            }
        }
        public void cargar_permisos()
        {
            try
            {
                if (codigo_empleado_txt.Text.Trim() != "")
                {
                    dataGridView1.Rows.Clear();
                    string sql = "select cod_permiso,p.descripcion from tercero_vs_permiso tp join permiso p on p.codigo=tp.cod_permiso where cod_tercero='" + codigo_empleado_txt.Text.Trim() + "' and tp.tipo_entidad='EMP' order by p.descripcion";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString());
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los permisos");
            }
        }
       
        public void cargar_datos_empelado()
        {
            try
            {
                if (codigo_empleado_txt.Text.Trim() != "")
                {
                    //esta lleno
                    string sql = "select e.codigo,t.nombre,p.apellido,t.identificacion,s.codigo as sexo,e.sueldo,p.fecha_nacimiento,e.cod_situacion,e.login,e.clave,e.estado,e.cod_sucursal,e.cod_cargo, e.cod_departamento,e.cod_cliente,e.cod_grupo_usuario,e.fecha_ingreso,cod_tipo_nomina from tercero t join persona p on p.codigo=t.codigo join empleado e on e.codigo=t.codigo join sexo s on s.codigo=p.cod_sexo  join situacion_empleado se on se.codigo=e.cod_situacion join departamento de on de.codigo=e.cod_departamento join cargo car on car.codigo=e.cod_cargo where e.codigo='" + codigo_empleado_txt.Text.Trim() + "'";
                    DataSet ds = new DataSet();
                    ds = Utilidades.ejecutarcomando(sql);
                    sueldo_fijo_txt.Text = ds.Tables[0].Rows[0]["sueldo"].ToString();
                    codigo_situacion_empleado_txt.Text = ds.Tables[0].Rows[0]["cod_situacion"].ToString();
                    cargar_nombre_situacion_empleado();
                    codigo_departamento_txt.Text = ds.Tables[0].Rows[0]["cod_departamento"].ToString();
                    cargar_nombre_departamento();
                    codigo_cargo_txt.Text = ds.Tables[0].Rows[0]["cod_cargo"].ToString();
                    cargar_nombre_Cargo();
                    login_txt.Text = ds.Tables[0].Rows[0]["login"].ToString();
                    clave_txt.Text = Utilidades.desencriptar(ds.Tables[0].Rows[0]["clave"].ToString());
                    codigo_sucursal_txt.Text = ds.Tables[0].Rows[0]["cod_sucursal"].ToString();
                    cargar_nombre_sucursal();
                    codigo_grupo_usuario_txt.Text = ds.Tables[0].Rows[0]["cod_grupo_usuario"].ToString();
                    cargar_nombre_grupo_usuario();
                    fecha_ingreso.Text = ds.Tables[0].Rows[0]["fecha_ingreso"].ToString();
                    codigo_tipo_nomina_txt.Text = ds.Tables[0].Rows[0]["cod_tipo_nomina"].ToString();
                    cargar_nombre_tipo_nomina();
                    string estado = "0";
                    estado = ds.Tables[0].Rows[0]["estado"].ToString();
                    if (estado == "True")
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
                MessageBox.Show("Error cargando los datos del empleado, este usuario no existe como empleado");
            }
        }
        public void cargar_datos_personales()
        {
            try
            {
                if (codigo_empleado_txt.Text.Trim() != "")
                {
                    //esta lleno
                    string sql = "select t.nombre,p.apellido,t.identificacion,s.codigo as sexo,p.fecha_nacimiento from tercero t join persona p on p.codigo=t.codigo join sexo s on s.codigo=p.cod_sexo   where t.codigo='" + codigo_empleado_txt.Text.Trim() + "'";
                    DataSet ds = new DataSet();
                    ds = Utilidades.ejecutarcomando(sql);
                    nombre_empleado_txt.Text = ds.Tables[0].Rows[0]["nombre"].ToString();
                    apellido_empleado_txt.Text = ds.Tables[0].Rows[0]["apellido"].ToString();
                    cedula_txt.Text = ds.Tables[0].Rows[0]["identificacion"].ToString();
                    codigo_sexo_txt.Text = ds.Tables[0].Rows[0]["sexo"].ToString();
                    cargar_nombre_sexo();
                    fecha_nacimiento.Text = ds.Tables[0].Rows[0]["fecha_nacimiento"].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los datos personales");
            }
        }
        public void cargar_nombre_cargo()
        {
            try
            {
                string sql = "select nombre from cargo where codigo='" + codigo_cargo_txt.Text.Trim() + "";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_departamento_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando el nombre del cargo");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_empleado em = new busqueda_empleado();
            em.pasado += new busqueda_empleado.pasar(ejecutar_codigo_empleado);
            em.ShowDialog();
            cargar_datos_empelado();
        }
        public void ejecutar_codigo_empleado(string dato)
        {
            limpiar();
            codigo_empleado_txt.Text = dato.ToString();
            codigo_empleado_txt.ReadOnly = true;
            nombre_empleado_txt.Focus();
        }

        private void clave_txt_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void clave_txt_KeyDown(object sender, KeyEventArgs e)
        {
        }

        internal singleton si { get; set; }

        private void button6_Click(object sender, EventArgs e)
        {
            cargo c = new cargo();
            c.ShowDialog();

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            situacion_empleado se = new situacion_empleado();
            se.pasado += new situacion_empleado.pasar(ejecutar_codigo_situacion_empleado);
            se.ShowDialog();
            cargar_nombre_situacion_empleado();
        }
        public void ejecutar_codigo_situacion_empleado(string dato)
        {
           codigo_situacion_empleado_txt.Text = dato.ToString();
        }
        public void cargar_nombre_situacion_empleado()
        {
            try
            {
                string sql = "select descripcion from situacion_empleado where codigo='"+codigo_situacion_empleado_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_situacion_empleado_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre de la situacion");
            }
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (codigo_empresa_txt.Text.Trim() != "")
                {
                    s = singleton.obtenerDatos();
                    busqueda_sucursal bs = new busqueda_sucursal();
                    bs.pasado += new busqueda_sucursal.pasar(ejecutar_codigo_sucursal);
                    bs.codigo_empresa_global = codigo_empresa_txt.Text.Trim();
                    bs.ShowDialog();
                    cargar_nombre_sucursal();
                }
                else
                {
                    MessageBox.Show("Debe elegir una empresa");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("SU USUARIO NO TIENE NINGUNA EMPRESA");
            }
        }
        public void cargar_nombre_sucursal()
        {
            try
            {
                string sql = "select nombre from tercero where codigo='" + codigo_sucursal_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_sucursal_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando nombre de sucursal");
            }
        }
        public void ejecutar_codigo_sucursal(string dato)
        {
            codigo_sucursal_txt.Text = dato.ToString();
            cargar_nombre_sucursal();
        }

        private void button4_Click_1(object sender, EventArgs e)
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
                string sql = "select descripcion from permiso where codigo='"+codigo_permiso_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_permiso_txt.Text= ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando nombre de permiso");
            }
        }
        
        private void button9_Click(object sender, EventArgs e)
        {
            int cont=0;//contador para saber si un permiso se encuentra mas de una vez
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

        private void button12_Click(object sender, EventArgs e)
        {
            int cont = 0;
            try
            {
               DataSet ds=new DataSet();
               if (telefono_txt.Text != "")
               {
                   if (tipo_telefono_combo_txt.Text != "")
                   {
                       if (ds.Tables[0].Rows.Count == 0)
                       {
                           foreach (DataGridViewRow row in dataGridView2.Rows)
                           {
                               if (row.Cells[0].Value.ToString() == telefono_txt.Text.Trim())
                               {
                                   cont++;
                               }
                           }
                           if (cont == 0)
                           {
                               dataGridView2.Rows.Add(telefono_txt.Text.Trim(), tipo_telefono_combo_txt.Text.Trim());
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
        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea quitar el telefono?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (dataGridView2.Rows.Count > 0)
                    {
                        dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
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

        private void button5_Click(object sender, EventArgs e)
        {
            busqueda_cargo bc = new busqueda_cargo();
            bc.pasado += new busqueda_cargo.pasar(ejecutar_codigo_cargo);
            bc.ShowDialog();
        }
        public void ejecutar_codigo_cargo(string dato)
        {
            codigo_cargo_txt.Text = dato.ToString();
            cargar_nombre_Cargo();
        }
        public void cargar_nombre_Cargo()
        {
            try
            {
                string sql = "select nombre from cargo where codigo='" + codigo_cargo_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_cargo_txt.Text = ds.Tables[0].Rows[0][0].ToString();   
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el nombre del cargo");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
           
        }
      

       private void button13_Click(object sender, EventArgs e)
       {
           if (codigo_sucursal_txt.Text.Trim() != "")
           {
               busqueda_departamento bd = new busqueda_departamento();
               bd.codigo_sucursal = codigo_sucursal_txt.Text.Trim();
               bd.pasado += new busqueda_departamento.pasar(ejecutar_codigo_departamento);
               bd.ShowDialog();
               cargar_nombre_departamento();
           }
           else
           {
               MessageBox.Show("Falta la sucursal");
           }
       }
        public void ejecutar_codigo_departamento(string dato)
        {
            codigo_departamento_txt.Text = dato.ToString();
        }
        public void cargar_nombre_departamento()
        {
            try
            {
                string sql = "select nombre from departamento where codigo ='" + codigo_departamento_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_departamento_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el nombre del departamento");
            }
        }

        private void button15_Click(object sender, EventArgs e)
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
                string sql = "select sexo from sexo where codigo='"+codigo_sexo_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_sexo_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando nombre del sexo");
            }
        }

        private void tipo_telefono_combo_txt_KeyUp(object sender, KeyEventArgs e)
        {
            tipo_telefono_combo_txt.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            busqueda_empresa be = new busqueda_empresa();
            be.pasado += new busqueda_empresa.pasar(ejecutar_codigo_empresa);
            be.ShowDialog();
            cargar_nombre_empresa();
            codigo_sucursal_txt.Clear();
            nombre_sucursal_txt.Clear();
        }
        public void ejecutar_codigo_empresa(string dato)
        {
            codigo_empresa_txt.Text = dato.ToString();
        }
        public void cargar_nombre_empresa()
        {
            try
            {
                string sql="select nombre from tercero where codigo='"+codigo_empresa_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_empresa_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre de la empresa");
            }
        }

        private void cedula_txt_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void cedula_txt_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void cedula_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void sueldo_fijo_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            busqueda_grupo_usuario bg = new busqueda_grupo_usuario();
            bg.pasado += new busqueda_grupo_usuario.pasar(ejecutar_codigo_grupo_usuario);
            bg.ShowDialog();
            cargar_nombre_grupo_usuario();
        }
        public void ejecutar_codigo_grupo_usuario(string dato)
        {
            codigo_grupo_usuario_txt.Text = dato.ToString();
        }
        public void cargar_nombre_grupo_usuario()
        {
            try
            {
                string sql = "select nombre from grupo_usuarios where codigo='"+codigo_grupo_usuario_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_grupo_usuario_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre del grupo de usuario");
            }
        }

        private void fecha_nacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            busqueda_tipo_nomina bn = new busqueda_tipo_nomina();
            bn.pasado += new busqueda_tipo_nomina.pasar(ejecutar_codigo_tipo_nomina);
            bn.ShowDialog();
            cargar_nombre_tipo_nomina();
        }
        public void ejecutar_codigo_tipo_nomina(string dato)
        {
            codigo_tipo_nomina_txt.Text = dato.ToString();
        }
        public void cargar_nombre_tipo_nomina()
        {
            try
            {
                string sql = "select nombre from nomina_tipos where codigo='"+codigo_tipo_nomina_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_tipo_nomina_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando el nombre del tipo de nomina");
            }
        }
    }
}

