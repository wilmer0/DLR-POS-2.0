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

namespace puntoVentaWin
{
    public partial class Form1 : Form
    {


        //objetos
        public empleado empleado;


        //modelos
        modeloEmpleado modeloEmpleado = new modeloEmpleado();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
