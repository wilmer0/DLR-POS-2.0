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
using puntoVentaModelo.modelos;

namespace puntoVentaWin.modulo_empresa
{
    public partial class ventana_busqueda_sucursal : FormBase
    {



        //objetos
        public empleado empleado;
        utilidades utilidades=new utilidades();
        public sucursal sucursal;


        //modelos
        modeloSucursal modeloSucursal=new modeloSucursal();


        //listas
        public List<sucursal> lista;



        public ventana_busqueda_sucursal(empleado empleadoA)
        {
            InitializeComponent();

            this.empleado = empleadoA;
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana busqueda sucursal");
            this.Text = tituloLabel.Text;
            LoadVentana();
        }

        private void ventana_busqueda_sucursal_Load(object sender, EventArgs e)
        {
            GetAcion();
        }

        public override void GetAcion()
        {
            getObjeto();

        }


        public sucursal getObjeto()
        {
            int index = dataGridView1.CurrentRow.Index;
            
            if (index < 0)
                return null;

            sucursal = lista[index];
            //MessageBox.Show(sucursal.codigo + "-" + sucursal.secuencia + "-" + sucursal.empresa.nombre);
            return sucursal;
        }

        public override void limpiar()
        {
            LoadVentana();
        }

        public override void LoadVentana()
        {
            if (lista!=null)
            {
                //mostrar
               lista=new List<sucursal>();
            }
            else
            {
                //no mostrar
            }
            loadLista();
        }

        public void loadLista()
        {
            try
            {

                lista = modeloSucursal.getListaCompleta();
                
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                lista.ForEach(x =>
                {
                   dataGridView1.Rows.Add(x.codigo,x.empresa.nombre,x.secuencia,x.direccion,(bool)x.activo);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GetAcion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAcion();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
