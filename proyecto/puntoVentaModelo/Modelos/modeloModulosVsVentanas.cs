using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVentaModelo.modelos;

namespace puntoVentaModelo.Modelos
{
    public class modeloModulosVsVentanas
    {

        public List<modulos_vs_ventanas> getListaCompleta()
        {
            try
            {
                coneccion coneccion = new coneccion();
                punto_ventaEntities entity = coneccion.GetConeccion();

                var lista = (from c in entity.modulos_vs_ventanas
                             select c).ToList();


                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getListaCompleta.: " + ex.ToString());
                return null;
            }
        }

    }
}
