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
    public partial class abrir_caja : Form
    {
        public abrir_caja()
        {
            InitializeComponent();
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            busqueda_cajero bc = new busqueda_cajero();
            bc.pasado += new busqueda_cajero.pasar(ejecutar_codigo_cajero);
            bc.ShowDialog();
            cargar_nombre_cajero();
            validar_cajero();
        }
        public void ejecutar_codigo_cajero(string dato)
        {
            codigo_cajero_txt.Text = dato.ToString();
        }
        internal singleton s { get; set; }
        private void abrir_caja_Load(object sender, EventArgs e)
        {
            cargar_cajero();
        }
        public void cargar_cajero()
        {
            s=singleton.obtenerDatos();
            try
            {
                string sql = "select *from cajero where cod_empleado='" + s.codigo_usuario.ToString() +"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                codigo_cajero_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                cargar_nombre_cajero();
            }
            catch(Exception)
            {
                MessageBox.Show("Su usuario no es cajero");
                this.Close();
            }
        }
        public void cargar_nombre_cajero()
        {
            try
            {
                string sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + s.codigo_usuario.ToString() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                nombre_cajero_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error buscando el nombre del cajero");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
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

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                limpiar();
            }
        }
        public void limpiar()
        {
            codigo_cajero_txt.Clear();
            nombre_cajero_txt.Clear();
            efectivo_txt.Clear();
            cargar_cajero();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                guardar();
            }
        }
        public void validar_cajero()
        {
            //esto sirve para poder validar si el cajero no tiene otro turno abierto antes de este
            try
            {
                string sql = "select max(cua.codigo) from cuadre_caja cua join cajero ca on ca.codigo=cua.cod_cajero join caja caj on  caj.codigo=ca.cod_caja where cua.cod_cajero='"+s.codigo_usuario.ToString()+"' and caj.cod_sucursal='"+s.codigo_sucursal.ToString()+"' and cua.fecha<='"+fecha.Value.ToString("yyyy-MM-dd")+"'  and cua.abierta_cerrada='A' and cua.estado='1'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count == 0)
                {

                }
                else
                {
                    MessageBox.Show("El cajero tiene un turno abierto, por favor hacer el cuadre de caja de ese turno");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error validando el cajero");
                codigo_cajero_txt.Clear();
                nombre_cajero_txt.Clear();
            }
        }
        public void guardar()
        {
                s = singleton.obtenerDatos();
                /*
                   alter proc insert_caja_apertura
                   @cod_cajero int,@fecha date,@efectivo_inicial float
                 */
            string sql = "select *from cuadre_caja cua join cajero ca on ca.codigo=cua.cod_cajero join caja caj on caj.codigo=ca.cod_caja where cua.cod_cajero='" + codigo_cajero_txt.Text.Trim() + "'  and caj.cod_sucursal='" + s.codigo_sucursal.ToString() + "' and cua.fecha<='" + fecha.Value.ToString("yyyy-MM-dd") + "' and cua.abierta_cerrada='A' and cua.estado='1'";
            DataSet ds = Utilidades.ejecutarcomando(sql);
            if (ds.Tables[0].Rows.Count==0)
            {
                sql = "exec insert_caja_apertura '" + s.codigo_usuario.ToString() + "','" + fecha.Value.ToString("yyyy-MM-dd") + "','" + efectivo_txt.Text.Trim() + "'";
                ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Se guardo");
                }
                else
                {
                    MessageBox.Show("No se guardo");
                }
            }
            else
            {
                MessageBox.Show("Su cajero ya tiene una apertura de caja activa, por favor haga su cuadre de caja correspondiendte antes de abrir otra caja");
            }
           
        }
    }
}
