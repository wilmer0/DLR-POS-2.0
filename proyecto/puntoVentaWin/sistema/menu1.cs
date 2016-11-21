using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVentaModelo;
using puntoVentaModelo.modelos;

namespace puntoVenta.sistema
{
    public partial class menu1 : FormBase
    {


        //objetos
        private empleado empleado;



        //modelos
        modeloEmpleado modeloEmpleado=new modeloEmpleado();


        //listas
        List<sistema_modulo> listaModulos=new List<sistema_modulo>();
        List<sistema_modulo_ventanas> listaModuloVentanas=new List<sistema_modulo_ventanas>(); 

        public menu1(puntoVentaModelo.empleado empleado)
        {
            InitializeComponent();
        }

        private void menu1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void menu1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        
    }
}
