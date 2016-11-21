using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Objects.DataClasses;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace puntoVentaModelo.modelos
{
    public class modeloEmpleado
    {


        public Boolean validarLogin(empleado empleado)
        {
            try
            {
                
                coneccion con=new coneccion();
                punto_ventaEntities entity= con.GetConeccion();

                var Lista = (from c in entity.empleado
                             where c.login == empleado.login && c.clave==empleado.clave
                             select c).FirstOrDefault();

                if (Lista != null)
                {
                    return true;
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
                punto_ventaEntities entity = con.GetConeccion();
                

                return listaModulos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetListaModulosDisponibles.: " + ex.ToString());
                return null;
            }
        }

        public List<empleado> getListaCompleta()
        {
            try
            {
                coneccion coneccion=new coneccion();
                punto_ventaEntities entity = coneccion.GetConeccion();
                List<empleado> listaEmpleado=new List<empleado>();
                listaEmpleado = (from o in entity.empleado select o).ToList();
                return listaEmpleado;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error getListaCompleta.: " + ex.ToString());
                return null;
            }
        }
         
    }
}
