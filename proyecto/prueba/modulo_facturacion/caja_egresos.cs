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
    public partial class caja_egresos : Form
    {
        public caja_egresos()
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
                limpiar();
            }
        }
        public void limpiar()
        {
            try
            {
                codigo_cajero_txt.Clear();
                nombre_cajero_txt.Clear();
                codigo_concepto_txt.Clear();
                nombre_concepto_txt.Clear();
                monto_egreso_txt.Clear();
                detalles_txt.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Error limpiando");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                guardar();
            }
        }
        double monto_disponible_caja = 0;

        public void disponible_en_caja()
        {
            try
            {
                /*
                 ALTER proc [dbo].[validar_monto_egreso_caja]
                 @cod_cajero int,@fecha date
                */
                string sql = "exec validar_monto_egreso_caja '" + codigo_cajero_txt.Text.Trim() + "','" + fecha.Value.ToString("yyyy-MM-dd") + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    monto_disponible_caja = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                    //MessageBox.Show("no vacio monto disponible en caja es:"+monto_disponible_caja.ToString("###,###,###,###,###,###.#0"));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error buscando cuanto hay disponible en la caja");
            }
        }
        public void guardar()
        {
            try
            {
                validar_caja_abierta();
                int afecta = 0;
                if (ck_afecta_cuadre.Checked == true)
                {
                    afecta = 1;
                }
                else
                {
                    afecta = 0;
                }
                if (codigo_cajero_txt.Text.Trim() != "")
                {
                    if (codigo_concepto_txt.Text.Trim() != "")
                    {
                        if (monto_egreso_txt.Text.Trim() != "")
                        {
                            disponible_en_caja();
                            double monto_egreso=Convert.ToDouble(monto_egreso_txt.Text.Trim());
                            if (monto_egreso <= monto_disponible_caja)
                            {
                                /*
                                 create proc insert_egreso_caja
                                 @cod_concepto int,@fecha date,@cod_cajero int,@monto float,@detalles varchar(max),@afecta_cuadre int
                                */
                                string sql = "exec insert_egreso_caja '" + codigo_concepto_txt.Text.Trim() + "','" + fecha.Value.ToString("yyyy-MM-dd") + "','" + codigo_cajero_txt.Text.Trim() + "','" + monto_egreso_txt.Text.Trim() + "','" + detalles_txt.Text.Trim() + "','" + afecta.ToString() + "'";
                                DataSet ds = Utilidades.ejecutarcomando(sql);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    MessageBox.Show("Se efectuo el egreso");
                                }
                                else
                                {
                                    MessageBox.Show("No se efectuo el egreso");
                                }
                            }
                            else
                            {
                                MessageBox.Show("El monto establecido sobrepasa el fondo de la caja");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta el monto del egreso");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta el concepto del egreso");
                    }
                }
                else
                {
                    MessageBox.Show("Falta el cajero");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error guardando");
            }
        }
        string codigo_cuadre_global = "0";
        public bool validar_caja_abierta()
        {
            string sql = "select max(codigo) from cuadre_caja where cod_cajero='" + codigo_cajero_txt.Text.Trim() + "' and fecha<='" + fecha.Value.ToString("yyyy-MM-dd") + "' and abierta_cerrada='A' and estado='1'";
            DataSet ds = Utilidades.ejecutarcomando(sql);
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                sql = "select max(codigo)from cuadre_caja where cod_cajero='" + codigo_cajero_txt.Text.Trim() + "' and fecha<='" + fecha.Value.ToString("yyyy-MM-dd") + "' and abierta_cerrada='A' and estado='1'";
                ds = Utilidades.ejecutarcomando(sql);
                codigo_cuadre_global = ds.Tables[0].Rows[0][0].ToString();
                return true;
            }
            else
            {
                MessageBox.Show("Su cajero no tiene caja abierta");
                codigo_cajero_txt.Clear();
                nombre_cajero_txt.Clear();
                return false;
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            s = singleton.obtenerDatos();
            busqueda_cajero bc = new busqueda_cajero();
            bc.pasado += new busqueda_cajero.pasar(ejecutar_codigo_cajero);
            bc.codigo_sucursal_global = s.codigo_sucursal.ToString();
            bc.ShowDialog();
            cargar_nombre_cajero();
            validar_caja_abierta();
        }
        public void ejecutar_codigo_cajero(string dato)
        {
            codigo_cajero_txt.Text = dato.ToString();
        }
        public void cargar_nombre_cajero()
        {
            try
            {
                if (codigo_cajero_txt.Text.Trim() != "")
                {
                    string sql = "select (t.nombre+' '+p.apellido) from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + codigo_cajero_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_cajero_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el nombre del cajero");
                codigo_cajero_txt.Clear();
            }
        }
        internal singleton s { get; set; }
        private void caja_egresos_Load(object sender, EventArgs e)
        {

            s = singleton.obtenerDatos();
            if (s.puede_cambiar_fecha_en_egreso_caja == true)
            {
                fecha.Enabled = true;
            }
            else
            {
                fecha.Enabled = false;
            }
            codigo_cajero_txt.Text = s.codigo_usuario.ToString();
            cargar_nombre_cajero();
            validar_caja_abierta();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            busqueda_egresos_caja_conceptos be = new busqueda_egresos_caja_conceptos();
            be.pasado += new busqueda_egresos_caja_conceptos.pasar(ejecutar_codigo_egreso);
            be.ShowDialog();
            cargar_nombre_concepto();
        }
        public void ejecutar_codigo_egreso(string dato)
        {
            codigo_concepto_txt.Text = dato.ToString();
        }
        public void cargar_nombre_concepto()
        {
            try
            {
                if (codigo_concepto_txt.Text.Trim() != "")
                {
                    string sql = "select nombre from egresos_conceptos where codigo='" + codigo_concepto_txt.Text.Trim() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    nombre_concepto_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando el nombre del concepto");
            }
        }

        private void monto_egreso_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (Utilidades.numero_decimal(monto_egreso_txt.Text.Trim()) == false)
            {
                monto_egreso_txt.Clear();
            }
        }
    }
}
