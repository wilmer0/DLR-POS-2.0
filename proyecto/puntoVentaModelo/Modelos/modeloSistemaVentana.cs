using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVentaModelo.modelos;

namespace puntoVentaModelo.Modelos
{
    public class modeloSistemaVentana
    {
        public Boolean agregarVentana(sistema_ventanas ventana)
        {
            coneccion coneccion = new coneccion();
            punto_ventaEntities entity = coneccion.GetConeccion();
            try
            {
                var lista = (from c in entity.sistema_ventanas
                             where c.codigo == ventana.codigo
                             select c).FirstOrDefault();

                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error agregarVentana.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                entity = null;
            }
        }



        public Boolean modificarVentanas(sistema_ventanas ventana)
        {
            coneccion coneccion = new coneccion();
            punto_ventaEntities entity = coneccion.GetConeccion();
            try
            {
               

               var lista = (from c in entity.sistema_ventanas
                         where c.codigo == ventana.codigo
                         select c).ToList().FirstOrDefault();


                lista.cod_modulo = ventana.cod_modulo;
                lista.nombre_ventana = ventana.nombre_ventana;
                lista.nombre_logico = ventana.nombre_logico;
                lista.imagen = ventana.imagen;
                lista.activo = ventana.activo;


                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error modificarVentanas.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                entity = null;
            }
        }

        public int getNext()
        {
            int count = 0;

            coneccion coneccion = new coneccion();
            punto_ventaEntities entity = coneccion.GetConeccion();
            try
            {
                count = entity.sistema_ventanas.Count();
                if (count > 0)
                {
                    count = entity.sistema_ventanas.Max(c => c.codigo);
                }
                return count + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getNext.: " + ex.ToString());
                return count;
            }
        }

        public List<sistema_ventanas> getListaCompleta()
        {
            try
            {
                coneccion coneccion = new coneccion();
                punto_ventaEntities entity = coneccion.GetConeccion();

                List<sistema_ventanas> lista = new List<sistema_ventanas>();

                lista = (from c in entity.sistema_ventanas
                         where c.activo == true
                         select c).ToList();


                return lista;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getListaSistemaVentanas.: " + ex.ToString());
                return null;
            }
        }

        public List<sistema_modulo> getListaSistemaModulos()
        {
            try
            {
                coneccion coneccion = new coneccion();
                punto_ventaEntities entity = coneccion.GetConeccion();

                List<sistema_modulo> lista = new List<sistema_modulo>();

                lista = (from c in entity.sistema_modulo
                         where c.activo == true
                         select c).ToList();


                return lista;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getListaSistemaModulos.: " + ex.ToString());
                return null;
            }
        }

        public Boolean agregarModulosVentanas(List<sistema_ventanas> lista)
        {
            coneccion coneccion = new coneccion();
            punto_ventaEntities entity = coneccion.GetConeccion();
            try
            {
                //eliminando las ventans viejas
                List<sistema_ventanas> listaVieja = getListaCompleta();
                listaVieja.ForEach(x =>
                {
                    entity.sistema_ventanas.Remove(x);
                });

                //agregando las ventanas nuevas
                lista.ForEach(x =>
                {
                    entity.sistema_ventanas.Add(x);
                });

                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error agregarModulos.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                entity = null;
            }
        }


    }
}
