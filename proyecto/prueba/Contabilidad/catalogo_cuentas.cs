using IrisContabilidad.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IrisContabilidad.Contabilidad
{
    public partial class catalogo_cuentas : FormBase
    {

        //objetos
       


        public catalogo_cuentas()
        {
            InitializeComponent();
            loadVentana();
        }

        private void catalogo_cuentas_Load(object sender, EventArgs e)
        {

        }
        public override void loadVentana()
        {
           
        }
        public override bool ValidarCampos()
        {
            string sql = "";
           if(numeroCuentaText.Text.Trim()=="")
           {
               MessageBox.Show("Falta el número de cuenta","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
               return false;
           }
            if(descripcionText.Text.Trim()=="")
            {
                MessageBox.Show("Falta el descripción de cuenta", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (codigoCuentaText.Text.Trim() == "")
            {
                //crear
                sql = "select *from catalogo_cuentas where descripcion='"+descripcionText.Text.Trim()+"' or numero_cuenta='"+numeroCuentaText.Text.Trim()+"'";
                DataSet ds = utilidades.ejecutarcomando(sql);
                if(ds.Tables[0].Rows.Count>0)
                {
                    MessageBox.Show("Ya existe una cuenta creada con ese mismo número o descripción", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                //actualizar
                sql = "select *from catalogo_cuentas where codigo!='" + codigoCuentaText.Text.Trim() + "' and (descripcion='" + descripcionText.Text.Trim() + "' or numero_cuenta='"+numeroCuentaText.Text.Trim()+"')";
                DataSet ds = utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Ya existe una cuenta creada con ese mismo número o descripción", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }


            //validar cuando sea movimiento
            if(cuentaMovimientoRadioButton.Checked==true)
            {
                MessageBox.Show("Ya existe una cuenta creada con ese mismo número o descripción", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //validar cuando sea acumulativa
            if (cuentaAcumulativaRadioButton.Checked == true)
            {
                MessageBox.Show("Ya existe una cuenta creada con ese mismo número o descripción", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //validar cuando sea submater
            if (cuentaSubMasterRadioButton.Checked == true)
            {
                MessageBox.Show("Ya existe una cuenta creada con ese mismo número o descripción", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //validar cuando sea master
            if (cuentaMasterRadioButton.Checked == true)
            {
                MessageBox.Show("Ya existe una cuenta creada con ese mismo número o descripción", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        public override void Procesar()
        {
            try
            {
                if (MessageBox.Show("Desea procesar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Sistema.procesando_ventana ventana = new Sistema.procesando_ventana();
                    //ventana.ShowDialog();


                  /*
                     alter proc insert_catalogo_cuentas_cuenta
                     @descripcion varchar(max),@numero_cuenta varchar(max),@cuenta_master bit,@cuenta_sub_master bit,
                     @cuenta_acumulativa bit,@cuenta_movimiento bit,@origen_credito bit,@origen_debito bit,@estado bit,@codigo int
                  */

                    if (ValidarCampos())
                    {
                        string sql = "exec insert_catalogo_cuentas_cuenta '" + descripcionText.Text.Trim() + "','" + numeroCuentaText.Text.Trim() + "','" +((bool)cuentaMasterRadioButton.Checked) + "','" + ((bool)cuentaSubMasterRadioButton.Checked) + "','" + ((bool)cuentaAcumulativaRadioButton.Checked) + "','" + ((bool)cuentaMovimientoRadioButton.Checked)+"','"+(bool)creditoRadioButton.Checked+"','"+ (bool)debitoRadioButton.Checked+ "','" + ((bool)activoCheck.Checked) + "','0'";
                        DataSet ds = utilidades.ejecutarcomando(sql);
                        //MessageBox.Show(sql);
                        if (ds.Tables[0].Rows.Count !=null)
                        {
                            MessageBox.Show("Se agrego la cuenta", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se agrego la cuenta", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error procesando: "+ex.ToString());
            }
         
        }
        public override void limpiar()
        {
            if (MessageBox.Show("Desea limpiar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            numeroCuentaAcumulativaText.Clear();
            numeroCuentaAcumulativaText.ReadOnly = true;
            numeroCuentaPadreText.ReadOnly = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numeroCuentaAcumulativaText.ReadOnly = true;
            numeroCuentaPadreText.ReadOnly = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            numeroCuentaAcumulativaText.ReadOnly = false;
            numeroCuentaPadreText.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void descripcionText_TextChanged(object sender, EventArgs e)
        {
            descripcionText.ScrollBars = ScrollBars.Vertical;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Contabilidad.busqueda_cuenta_contable ventana = new busqueda_cuenta_contable();
            ventana.mantenimiento = true;
            ventana.pasado += new busqueda_cuenta_contable.pasar(ejecutar_codigo);
            ventana.ShowDialog();
        }
        public void ejecutar_codigo(string dato)
        {
            codigoCuentaText.Text = dato.ToString();
        }
    }
}
