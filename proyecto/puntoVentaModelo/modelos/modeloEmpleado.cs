using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;



namespace puntoVentaModelo.modelos
{
    public class modeloEmpleado
    {


        public Boolean validarLogin()
        {
            try
            {
                punto_ventaEntities entity=new punto_ventaEntities();




                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error validarLogin.: "+ex.ToString());
                return false;
            }
        }
    }
}
