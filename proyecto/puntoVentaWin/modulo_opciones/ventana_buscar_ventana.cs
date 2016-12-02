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
    public partial class ventana_buscar_ventana : FormBase
    {

        //objetos
        public sistema_ventanas Getventana;
        private empleado empleado;
        utilidades utilidades=new utilidades();


        //listas
        private List<sistema_ventanas> lista; 


        //modelos
        modeloVentana modeloVentana=new modeloVentana();

        public ventana_buscar_ventana(empleado empleadoApp)
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
                lista=new List<sistema_ventanas>();
                lista = modeloVentana.getListaCompleta();
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                lista.ForEach(x =>
                {
                    dataGridView1.Rows.Add(x.codigo, x.nombre_ventana, x.sistema_modulo.nombre,x.activo);
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
                Getventana = null;
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
                Getventana = modeloVentana.getVentanaById(index);

                if (Getventana != null)
                {
                    //MessageBox.Show(index.ToString());
                    //return Getventana;
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getObjeto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getObjeto();
        }

        public override void GetAction()
        {
            getObjeto();
        }
        private void ventana_buscar_ventana_Load(object sender, EventArgs e)
        {

        }

       

       

       

       

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
