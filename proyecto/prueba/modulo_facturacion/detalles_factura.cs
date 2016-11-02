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
    public partial class detalles_factura : Form
    {
        public detalles_factura()
        {
            InitializeComponent();
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
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                detalles_txt.Clear();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (codigo_factura_txt.Text.Trim() != "")
                {
                    
                    string sql = "update factura set detalles='"+detalles_txt.Text.Trim()+"' where codigo='" + codigo_factura_global.ToString() + "'";
                    Utilidades.ejecutarcomando(sql);
                    MessageBox.Show("Actualizado");
                }
                else
                {
                    MessageBox.Show("Falta la factura");
                }
            }
        }
        public string codigo_factura_global = "";
        internal singleton s { get; set; }
        private void detalles_factura_Load(object sender, EventArgs e)
        {
            if (codigo_factura_global.ToString() != "")
            {
                codigo_factura_txt.Text = codigo_factura_global.ToString();
                string sql = "select detalles from factura where codigo='"+codigo_factura_global.ToString()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    detalles_txt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            
        }
    }
}
