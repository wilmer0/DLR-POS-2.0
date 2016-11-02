using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Data.Entity;

namespace puntoVentaModelo.Modelos
{
    public class ModeloLogin
    {
        public empleado login(string usuario,string clave)
        {


            coneccion coneccion = new coneccion();
            puntoVentaEntities entity = coneccion.getConeccion();
            empleado empleado=new empleado();
            List<empleado> lista=new List<empleado>();
            try
            {
                empleado = (from c in entity.empleado
                             where c.login == usuario && c.clave==clave
                             select c).FirstOrDefault();

                return empleado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error login.:"+ex.ToString());
                return null;
            }
            finally
            {
                entity = null;
            }
        }



    }
}
