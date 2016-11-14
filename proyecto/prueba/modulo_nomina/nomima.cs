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
    public partial class nomima : Form
    {
        public nomima()
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
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();
                codigo_departamento_txt.Clear();
                nombre_departamento_txt.Clear();
                monto_txt.Clear();
                ck_cerrar_nomina.Checked = false;
                fecha_desde.Value = DateTime.Today;
                fecha_hasta.Value = DateTime.Today;

            }
            catch(Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }
        public void actualiza_conceptos_fijos()
        {
            try
            {
                int fila = dataGridView1.CurrentRow.Index;

                string sql = "delete from empleado_conceptos_fijo_nomina where cod_empleado='" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "'";
                Utilidades.ejecutarcomando(sql);
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    /*
                     alter proc insert_empleado_nomina_conceptos_fijos
                     @cod_empleado int,@cod_concepto int
                     */
                    sql = "exec insert_empleado_nomina_conceptos_fijos '" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "','"+row.Cells[0].Value.ToString()+"'";  
                    Utilidades.ejecutarcomando(sql);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error agregando los conceptos fijo de nomina");
            }
        }
        private void button1_Click(object sender, EventArgs e)
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
                string sql = "";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (codigo_tipo_nomina_txt.Text.Trim()!="")
                {
                    //actualiza_conceptos_fijos();
                    actualiza_nomina_detalles();
                    MessageBox.Show("Nomina guardada, para  modificarla solo debes volver a guardar cuando realices cambios");
                    if (ck_cerrar_nomina.Checked == true)
                    {
                        DialogResult dr = MessageBox.Show("Desea Cerrar la nomina?. Esta sera la ultima modificacion que acepte el sistema, despues de cerrar la nomina no se puede modificar dicha nomina.", "Cerrando el perioso de la nomina", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            /*
                           ALTER proc [dbo].[cerrar_nomina]
                          @codigo int,@cod_usuario int

                             */
                            sql = "exec cerrar_nomina '"+codigo_nomina_global.ToString()+"','"+s.codigo_usuario.ToString()+"'";
                            ds = Utilidades.ejecutarcomando(sql);
                            if(ds.Tables[0].Rows.Count>0)
                            {
                                sql = "delete from empleado_vs_conceptos_nomina";
                                Utilidades.ejecutarcomando(sql);
                                MessageBox.Show("Se cerro la nomina, esta nomina ya no puede ser modificada");
                            }
                            else
                            {
                                MessageBox.Show("No se cerro la nomina");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Falta el tipo de nomina");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error generando la nomina");
            }
        }

        private void nomima_Load(object sender, EventArgs e)
        {
            cargar_empleados();
            cargar_conceptos_normales();
        }
        public void cargar_conceptos_normales()
        {
            try
            {
                string sql = "select codigo,nombre,aumenta_sueldo from nomina_conceptos where estado ='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView2.Rows.Add(row[0].ToString(),row[1].ToString(),"0",row[2]);
                }
                
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando los conceptos de nomina");
            }
        }
        public void cargar_empleados()
        {
            try
            {
                dataGridView1.Rows.Clear();
                
                string sql = "select t.codigo,(t.nombre+' '+p.apellido),t.identificacion from tercero t join persona p on p.codigo=t.codigo join empleado e on t.codigo=e.codigo where e.estado='1' and e.codigo!='1'";
                if(codigo_tipo_nomina_txt.Text.Trim()!="")
                {
                    sql += " and e.cod_tipo_nomina='"+codigo_tipo_nomina_txt.Text.Trim()+"'";
                }
                if(codigo_departamento_txt.Text.Trim()!="")
                {
                    sql += " and e.cod_departamento='" + codigo_departamento_txt.Text.Trim() + "'";
                }
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
                //para sacar la nomina abierta del tipo de nomina que seleccione
                if (codigo_tipo_nomina_txt.Text.Trim() != "")
                {
                    sql = "select max(codigo) from nomina where cod_tipo='"+codigo_tipo_nomina_txt.Text.Trim()+"' and abierta_cerrada='A' and estado='1' ";
                    ds = Utilidades.ejecutarcomando(sql);
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                        codigo_nomina_global = ds.Tables[0].Rows[0][0].ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando los datos de los empleados");
            }
        }
        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int fila = 0;
            try
            {
                if (monto_txt.Text.Trim() != "")
                {
                    fila = dataGridView2.CurrentRow.Index;
                    dataGridView2.Rows[fila].Cells[2].Value = monto_txt.Text.Trim();
                    monto_txt.Clear();
                    monto_txt.Focus();

                    /*
                        alter proc insert_nomina_detalle
                        @cod_nomina int,@cod_empleado int,@cod_concepto int,@monto float,@cod_empleado_modifico int
                    */
                    string sql = "";
                    fila = dataGridView1.CurrentRow.Index;
                    sql = "delete from empleado_vs_conceptos_nomina where cod_nomina='" + codigo_nomina_global.ToString() + "' and cod_empleado='" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "'";
                    Utilidades.ejecutarcomando(sql);
                    sql = "delete from nomina_detalle where cod_nomina='" + codigo_nomina_global.ToString() + "' and cod_empleado='" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "'";
                    Utilidades.ejecutarcomando(sql);
                    foreach (DataGridViewRow con in dataGridView2.Rows)
                    {
                        sql = "exec insert_nomina_detalle '" + codigo_nomina_global.ToString() + "','" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "','" + con.Cells[0].Value.ToString() + "','" + con.Cells[2].Value.ToString() + "','" + s.codigo_usuario.ToString() + "'";
                        Utilidades.ejecutarcomando(sql);
                    }
                }
                else
                {
                    MessageBox.Show("Falta el monto que desea aplicar");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error aplicando el monto al concepto");
            }

           
       
        }

        private void monto_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void monto_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (Utilidades.numero_decimal(monto_txt.Text.Trim()) == false)
            {
                monto_txt.Clear();
            }
        }

        private void pais_btn_Click(object sender, EventArgs e)
        {
            busqueda_tipo_nomina btn = new busqueda_tipo_nomina();
            btn.pasado += new busqueda_tipo_nomina.pasar(ejecutar_codigo_nomina);
            btn.ShowDialog();
            cargar_empleados();
            
        }
        public void ejecutar_codigo_nomina(string dato)
        {
            try
            {
                codigo_tipo_nomina_txt.Text = dato.ToString();
                string sql = "select nombre from nomina_tipos where codigo='" + codigo_tipo_nomina_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_tipo_nomina_txt.Text = ds.Tables[0].Rows[0][0].ToString();

                sql = "select *from nomina where cod_tipo='"+codigo_tipo_nomina_txt.Text.Trim()+"' and abierta_cerrada='A' and cod_empleado_cerrada='0' and estado='1'";
                ds = Utilidades.ejecutarcomando(sql);
                if(ds.Tables[0].Rows.Count>0)
                {
                    codigo_nomina_global = ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("No hay nomina "+nombre_tipo_nomina_txt.Text.Trim()+" abierta");
                    limpiar();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando el nombre del tipo de nomina");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int cont = 0;//contador para saber si un permiso se encuentra mas de una vez
            try
            {
                if (codigo_concepto_txt.Text.Trim() != "")
                {
                    if (nombre_concepto_txt.Text.Trim() != "")
                    {
                        foreach (DataGridViewRow row in dataGridView3.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == codigo_concepto_txt.Text.Trim())
                            {
                                cont++;
                            }
                        }
                        if (cont == 0)
                        {
                            dataGridView3.Rows.Add(codigo_concepto_txt.Text.Trim(), nombre_concepto_txt.Text.ToString().Trim());
                            codigo_concepto_txt.Clear();
                            nombre_concepto_txt.Clear();
                            button5.Focus();
                        }
                        else
                        {
                            MessageBox.Show("El concepto que ha seleccionado ya se encuentra puesto.");
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea quitar el telefono?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
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
                catch (Exception)
                {
                    MessageBox.Show("Error eliminando la fila seleccionada");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            busqueda_nomina_conceptos bn = new busqueda_nomina_conceptos();
            bn.pasado += new busqueda_nomina_conceptos.pasar(ejecutar_codigo_concepto);
            bn.ShowDialog();
        }
        public void ejecutar_codigo_concepto(string dato)
        {
            try
            {
                codigo_concepto_txt.Text = dato.ToString();
                string sql = "select nombre from nomina_conceptos where codigo='" + codigo_concepto_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_concepto_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando el nombre del concepto");
            }
        }
        internal singleton s { get; set; }
        private void button6_Click(object sender, EventArgs e)
        {
            s=singleton.obtenerDatos();
            busqueda_departamento bd = new busqueda_departamento();
            bd.pasado += new busqueda_departamento.pasar(ejecutar_codigo_departamento);
            bd.codigo_sucursal = s.codigo_sucursal.ToString();
            bd.ShowDialog();
            cargar_nombre_departamento();
        }
        public void ejecutar_codigo_departamento(string dato)
        {
            codigo_departamento_txt.Text = dato.ToString();
        }
        public void cargar_nombre_departamento()
        {
            try
            {
                if (codigo_departamento_txt.Text.Trim() != "")
                {
                    string sql = "select nombre from departamento where codigo='"+codigo_departamento_txt.Text.Trim()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_departamento_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando el nombre del departamento");
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            codigo_departamento_txt.Clear();
            nombre_departamento_txt.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea generar la nomina?", "Generando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    /*
                     create proc insert_nomina
                     @cod_empleado int,@fecha_inicial date,@fecha_final date,@cod_tipo int,@cod_sucursal int
                     */
                    if(codigo_tipo_nomina_txt.Text.Trim()!="")
                    {
                        s = singleton.obtenerDatos();
                        string sql = "exec insert_nomina '" + s.codigo_usuario.ToString() + "','" + fecha_desde.Value.ToString("yyyy-MM-dd") + "','" + fecha_hasta.Value.ToString("yyyy-MM-dd") + "','" + codigo_tipo_nomina_txt.Text.Trim() + "','" + s.codigo_sucursal.ToString() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                       
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            codigo_nomina_global = ds.Tables[0].Rows[0][0].ToString();
                            generar_conceptos_empelado();
                            MessageBox.Show("Se genero la nomina");
                        }
                        else
                        {
                            MessageBox.Show("No se genero la nomina");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el tipo de nomina");
                    }

                }
                catch(Exception)
                {
                    MessageBox.Show("Error generando la nomina, por favor revise que las fecha no solapen con una nomina activa de este tipo");
                }
            }
        }
        public void actualiza_nomina_detalles()
        {
            try
            {
                string sql = "";
                s=singleton.obtenerDatos();
                /*
                 create proc insert_nomina_detalle
                 @cod_nomina int,@cod_empleado int,@cod_concepto int,@monto float,@cod_empleado_modifico int
                 */
                foreach(DataGridViewRow emp in dataGridView1.Rows)
                {
                    sql = "delete from nomina_detalle where cod_nomina='"+codigo_nomina_global.ToString()+"' and cod_empleado='"+emp.Cells[0].Value.ToString()+"'";
                    Utilidades.ejecutarcomando(sql);
                    foreach (DataGridViewRow con in dataGridView2.Rows)
                    {
                        sql = "exec insert_nomina_detalle '"+codigo_nomina_global.ToString()+"','"+emp.Cells[0].Value.ToString()+"','"+con.Cells[0].Value.ToString()+"','"+con.Cells[2].Value.ToString()+"','"+s.codigo_usuario.ToString()+"'";
                        Utilidades.ejecutarcomando(sql);
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error insertando el empleado en la nomina");
            }
        }
        string codigo_nomina_global = "";
        public void generar_conceptos_empelado()
        {
            try
            {
                s = singleton.obtenerDatos();
                string sql = "select *from empleado e where e.estado='1' and e.cod_tipo_nomina='" + codigo_tipo_nomina_txt.Text.Trim() + "' and e.cod_sucursal='" + s.codigo_sucursal.ToString() + "'";
                if (codigo_departamento_txt.Text.Trim() != "")
                {
                    sql += " and e.cod_departamento='" + codigo_departamento_txt.Text.Trim() + "'";
                }
                DataSet ds = Utilidades.ejecutarcomando(sql);
                foreach (DataRow emp in ds.Tables[0].Rows)
                {
                    //primero borrar todo los conceptos generado de ese empleado anteriormente que tenga que ver con la nomina actual
                    string x = "delete from empleado_vs_conceptos_nomina where cod_nomina='" + codigo_tipo_nomina_txt.Text.Trim() + "' and cod_empleado='" + emp[0].ToString() + "'";
                    Utilidades.ejecutarcomando(x);
                    string sql2 = " select codigo,nombre,aumenta_sueldo,estado from nomina_conceptos where estado='1'";
                    DataSet ds2 = Utilidades.ejecutarcomando(sql2);
                    foreach (DataRow cn in ds2.Tables[0].Rows)
                    {
                        //para entonces agregar los nuevos conceptos  
                        if (cn[0].ToString() == "1")
                        {
                            //si el concepto es el codigo 1 es decir sueldo base el le ingresara el sueldo base del empleado automatico
                            /*
                             ALTER proc [dbo].[insert_nomina_detalle]
                             @cod_nomina int,@cod_empleado int,@cod_concepto int,@monto float,@cod_empleado_modifico int
                             */
                            string cmd = "";
                            //cmd="insert into empleado_vs_conceptos_nomina(cod_nomina,cod_empleado,cod_concepto,monto) values('" + codigo_nomina_global.ToString() + "','" + emp[0].ToString() + "','" + cn[0].ToString() + "','" + emp["sueldo"].ToString() + "')";
                            cmd = "exec insert_nomina_detalle '"+ codigo_nomina_global.ToString()+"','"+emp[0].ToString()+"','"+cn[0].ToString()+"','"+emp["sueldo"].ToString()+"','"+s.codigo_usuario.ToString()+"'";
                            Utilidades.ejecutarcomando(cmd);
                        }
                        else
                        {
                            string cmd = "";
                            //cmd="insert into empleado_vs_conceptos_nomina(cod_nomina,cod_empleado,cod_concepto,monto) values('" + codigo_nomina_global.ToString() + "','" + emp[0].ToString() + "','" + cn[0].ToString() + "','0'" + ")";
                            cmd = "exec insert_nomina_detalle '" + codigo_nomina_global.ToString() + "','" + emp[0].ToString() + "','" + cn[0].ToString() + "','0','" + s.codigo_usuario.ToString() + "'";
                            Utilidades.ejecutarcomando(cmd);
                        }
                    }
                    
                }

            }
            catch(Exception)
            {
                MessageBox.Show("Error generando los conceptos de nomina por empleado");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cargar_empleados();
        }
        double sueldo_suma = 0;
        double sueldo_resta = 0;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int fila = dataGridView1.CurrentRow.Index;
                string sql = "select en.cod_concepto,nc.nombre,en.monto,nc.aumenta_sueldo from empleado_vs_conceptos_nomina en join nomina_conceptos nc on nc.codigo=en.cod_concepto join empleado e on e.codigo=en.cod_empleado  where en.cod_empleado='" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "' and e.cod_tipo_nomina='" + codigo_tipo_nomina_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                dataGridView2.Rows.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataGridView2.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                }
                sueldo_suma = 0;
                sueldo_resta = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells[3].Value.ToString() == "1")
                    {
                        //si aumenta sueldo
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.SelectionBackColor = Color.Blue;
                        row.DefaultCellStyle.SelectionForeColor = Color.White;
                        sueldo_suma +=Convert.ToDouble(row.Cells[2].Value.ToString());
                    }
                    else
                    {
                        //si baja sueldo
                        row.DefaultCellStyle.BackColor = Color.Orange;
                        row.DefaultCellStyle.SelectionBackColor = Color.Blue;
                        row.DefaultCellStyle.SelectionForeColor = Color.White;
                        sueldo_resta += Convert.ToDouble(row.Cells[2].Value.ToString());
                    }
                }
                sueldo_suma_total_txt.Text = (sueldo_suma-sueldo_resta).ToString("###,###,###,###,###.#0");
                sueldo_resta_total_txt.Text= sueldo_resta.ToString("###,###,###,###,###.#0");

            }
            catch (Exception)
            {

            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string sql = "";
            //    int fila = dataGridView1.CurrentRow.Index;
            //    sql = "delete from empleado_vs_conceptos_nomina where cod_nomina='" + codigo_nomina_global.ToString() + "' and cod_empleado='" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "'";
            //    Utilidades.ejecutarcomando(sql);
            //    sql = "delete from nomina_detalle where cod_nomina='" + codigo_nomina_global.ToString() + "' and cod_empleado='" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "'";
            //    Utilidades.ejecutarcomando(sql);
            //    foreach (DataGridViewRow con in dataGridView2.Rows)
            //    {
            //        sql = "exec insert_nomina_detalle '" + codigo_nomina_global.ToString() + "','" + dataGridView1.Rows[fila].Cells[0].Value.ToString() + "','" + con.Cells[0].Value.ToString() + "','" + con.Cells[2].Value.ToString() + "','" + s.codigo_usuario.ToString() + "'";
            //        Utilidades.ejecutarcomando(sql);
            //    }
            //}
            //catch (Exception)
            //{
            //    //MessageBox.Show("Error aplicando los cambios al empleado");
            //}
        }

    }
}
