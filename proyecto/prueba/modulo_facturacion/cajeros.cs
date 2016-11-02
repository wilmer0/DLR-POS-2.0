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
    public partial class cajeros : Form
    {
        public cajeros()
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

        private void button1_Click(object sender, EventArgs e)
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
                if(codigo_empleado_txt.Text.Trim()!="")
                {
                    if(codigo_caja_txt.Text.Trim()!="")
                    {
                        int estado = 0;
                        if (ck_activo.Checked == true)
                            estado = 1;
                        else
                            estado = 0;
                        /*
                         create proc insert_cajero
                        @cod_empleado int,@cod_caja int,@estado bit

                         */
                        string cmd = "delete from cajero where codigo='"+codigo_empleado_txt.Text.Trim()+"'";
                        Utilidades.ejecutarcomando(cmd);
                        string sql = "exec insert_cajero '"+codigo_empleado_txt.Text.Trim()+"','"+codigo_caja_txt.Text.Trim()+"','"+estado.ToString()+"'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        if(ds.Tables[0].Rows.Count>0)
                        {
                            MessageBox.Show("Se agrego");
                        }
                        else
                        {
                            MessageBox.Show("No se agrego");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta la caja");
                    }
                }
                else
                {
                    MessageBox.Show("Falta el empleado");
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            busqueda_empleado be = new busqueda_empleado();
            be.pasado += new busqueda_empleado.pasar(ejecutar_codigo_empleado);
            be.ShowDialog();
            cargar_nombre_empleado();
            cargar_cajero();
        }
        public void cargar_cajero()
        {
            s = singleton.obtenerDatos();
            try
            {
                if (codigo_empleado_txt.Text.Trim() != "")
                {
                    string sql = "select caj.cod_caja,ca.nombre from cajero caj join caja ca on ca.codigo=caj.cod_caja where caj.cod_empleado='" + codigo_empleado_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    codigo_caja_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                    nombre_caja_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Este empleado no tiene cajero asignado.");
            }
        }
        public void ejecutar_codigo_empleado(string dato)
        {
            codigo_empleado_txt.Text = dato.ToString();
        }
        public void cargar_nombre_empleado()
        {
            try
            {
                if (codigo_empleado_txt.Text.Trim() != "")
                {
                    string sql = "select t.nombre+' '+p.apellido from tercero t join persona p  on p.codigo=t.codigo join empleado e on e.codigo=p.codigo where e.codigo='" + codigo_empleado_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_empleado_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el nombre del empleado");
            }
        }
        public bool validar_caja_en_uso()
        {
            try
            {
                string sql = "select *from cajero where cod_empleado!='"+codigo_empleado_txt.Text.Trim()+"' and cod_caja='"+codigo_caja_txt.Text.Trim()+"' and estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if(ds.Tables[0].Rows.Count==0)
                {
                    return true;
                }
                else
                {
                    codigo_caja_txt.Clear();
                    nombre_caja_txt.Clear();
                    MessageBox.Show("La caja ya esta en uso por otro cajero");
                    return false;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error validando la caja");
                return false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            busqueda_caja bc= new busqueda_caja();
            bc.codigo_sucursal = s.codigo_sucursal.ToString();
            bc.pasado += new busqueda_caja.pasar(ejecutar_codigo_caja);
            bc.ShowDialog();
            cargar_nombre_caja();
            validar_caja_en_uso();
        }
        public void ejecutar_codigo_caja(string dato)
        {
            codigo_caja_txt.Text = dato.ToString();
        }
        public void cargar_nombre_caja()
        {
            try
            {
                string sql = "select nombre,estado from caja where codigo='" + codigo_caja_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_caja_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                if (ds.Tables[0].Rows[0][1].ToString() == "True")
                    ck_activo.Checked = true;
                else
                    ck_activo.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el nombre de caja");
            }
        }
        internal singleton s { get; set; }
        private void cajeros_Load(object sender, EventArgs e)
        {

        }
    }
}
