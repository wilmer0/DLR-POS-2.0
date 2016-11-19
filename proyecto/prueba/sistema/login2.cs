using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVentaModelo.modelos;

namespace puntoVenta.sistema
{
    public partial class login2 : FormBase
    {



        //modelos
        private modeloEmpleado modeloEmpleado = new modeloEmpleado();


        //objetos
        public empleado empleado;




        public login2()
        {
            InitializeComponent();
            loadVentana();
        }

        private void login2_Load(object sender, EventArgs e)
        {

        }


        public void loadVentana()
        {
            
        }

        public void getAction()
        {
        }
    }
}
