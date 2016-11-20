using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace puntoVentaModelo.modelos
{
    public class modeloEmpleado
    {


        public Boolean validarLogin(empleado empleado)
        {
            try
            {
                
                coneccion con=new coneccion();
                punto_ventaEntities entity= con.getConeccion();

                List<empleado> listaEmpleado=new List<empleado>();
                foreach (var x in listaEmpleado)
                {
                    if (x.login == empleado.login && x.clave == empleado.clave)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error validarLogin.: "+ex.ToString());
                return false;
            }
        }


        public List<sistema_modulo> GetListaModulosDisponibles(empleado empleado)
        {
            try
            {
                //lista
                List<sistema_modulo> lista=new List<sistema_modulo>();
                List<sistema_modulo> listaModulos = new List<sistema_modulo>();

                coneccion con=new coneccion();
                punto_ventaEntities entity = con.getConeccion();
                

                return listaModulos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetListaModulosDisponibles.: " + ex.ToString());
                return null;
            }
        }

         
    }
}
