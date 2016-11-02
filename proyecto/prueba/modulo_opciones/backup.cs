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
    public partial class backup : Form
    {
        public backup()
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

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea generar el backup?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //salvar
                string base_datos = "punto_venta";
                    if (ruta_txt.Text.Trim() != "")
                    {
                        /*
                         *create proc backup_sistema
                            @ruta varchar(max),@base_de_datos varchar(max)

                         */
                        string ruta = ruta_txt.Text.Trim() + @"\";
                        string sql = "exec backup_sistema '"+ruta.ToString()+"','"+base_datos.ToString()+"'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        MessageBox.Show("Se genero el backup");
                    }
                    else
                    {
                        MessageBox.Show("Debe elegir una ruta donde guardar el backup");
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fol = new FolderBrowserDialog();
                if(fol.ShowDialog()==DialogResult.OK)
                {
                    ruta_txt.Text = fol.SelectedPath;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error pasando la imagen al directorio local");
            }
        }

        private void backup_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "select top(1) ruta_backup from sistema";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                ruta_txt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {

            }
        }
    }
}
