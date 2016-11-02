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
    public partial class inventario_entrada_salida : Form
    {
        public inventario_entrada_salida()
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //limpiar
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea guardar?", "Guardando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //
                try
                {
                    if(dataGridView1.Rows.Count>0)
                    {
                        //se puede agregar
                    }
                    else
                    {
                        MessageBox.Show("No hay elementos que agregar");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //bajar al datagrid
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                busqueda_producto bp = new busqueda_producto();
                bp.ShowDialog();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando la busqueda de producto");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
            catch(Exception)
            {
                MessageBox.Show("Error eliminando el producto");
            }
        }
    }
}
