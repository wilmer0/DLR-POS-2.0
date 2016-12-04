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
using puntoVentaModelo;
using puntoVentaModelo.Modelos;

namespace puntoVentaWin.modulo_opciones
{
    public partial class ventana_buscar_modulo : FormBase
    {

        //variables
        private bool mantenimiento = false;

        //objetos
        public sistema_modulo GetModulo;
        private empleado empleado;
        utilidades utilidades = new utilidades();


        //listas
        private List<sistema_modulo> lista;


        //modelos
        modeloModulos modeloModulo = new modeloModulos();
        

        public ventana_buscar_modulo(empleado empleadoApp)
        {
            InitializeComponent();
            this.empleado = empleadoApp;
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "buscar ventanas");
            this.Text = tituloLabel.Text;
            loadList();
            
        }

        public void loadList()
        {
            try
            {
                if (lista == null)
                {
                    lista = new List<sistema_modulo>();
                    lista = modeloModulo.GetListaCompleta(true);
                }
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                lista.ForEach(x =>
                {
                    dataGridView1.Rows.Add(x.id, x.nombre, x.activo);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadList.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void limpiar()
        {
            if (MessageBox.Show("Desea limpiar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GetModulo = null;
                loadList();
            }
        }
        public override void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public void getObjeto()
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;

                if (index < 0)
                    return;

                index = Convert.ToInt16(dataGridView1.Rows[index].Cells[0].Value);
                GetModulo = modeloModulo.getModuloById(index);

                if (GetModulo != null)
                {
                    //MessageBox.Show(index.ToString());
                    //return GetModulo;
                    this.Close();
                }
                else
                {
                    //return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getObjeto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return null;
            }
        }

        public override void GetAction()
        {
            getObjeto();
        }

        private void ventana_buscar_modulo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getObjeto();
            }
        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (moduloRadio.Checked)
                {
                    //modulo
                    lista = modeloModulo.getListaByModulo(nombreText.Text.Trim());
                }

                loadList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
