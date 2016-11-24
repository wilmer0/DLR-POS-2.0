using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVentaModelo.modelos;

namespace puntoVentaModelo.Modelos
{
    public class modeloSistemaModulos
    {
        public Boolean agregarModulos(List<sistema_modulo> listaModulos)
        {
            coneccion coneccion = new coneccion();
            punto_ventaEntities entity = coneccion.GetConeccion();
            try
            {
                listaModulos.ForEach(x =>
                {
                    entity.sistema_modulo.Add(x); 
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



        public Boolean modificarModulos(List<sistema_modulo> listaModulos)
        {
            coneccion coneccion = new coneccion();
            punto_ventaEntities entity = coneccion.GetConeccion();
            try
            {

                listaModulos.ForEach(x =>
                {
                    entity.sistema_modulo.Add(x);
                });

                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error agregarListaModulos.:" + ex.ToString(), "", MessageBoxButtons.OK,
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
                count = entity.sistema_modulo.Count();
                if (count > 0)
                {
                    count = entity.sistema_modulo.Max(c => c.id);
                }
                return count + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getNext.: " + ex.ToString());
                return count;
            }
        }

        public List<sistema_modulo_ventanas> getListaSistemaVentanas()
        {
            try
            {
                coneccion coneccion = new coneccion();
                punto_ventaEntities entity = coneccion.GetConeccion();

                List<sistema_modulo_ventanas> lista = new List<sistema_modulo_ventanas>();

                lista = (from c in entity.sistema_modulo_ventanas
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

                List<sistema_modulo> lista=new List<sistema_modulo>();

                lista = (from c in entity.sistema_modulo
                            where c.activo==true
                            select c).ToList();


                return lista;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getListaSistemaModulos.: " + ex.ToString());
                return null;
            }
        }

        public Boolean agregarModulosVentanas(List<sistema_modulo_ventanas> lista)
        {
            coneccion coneccion = new coneccion();
            punto_ventaEntities entity = coneccion.GetConeccion();
            try
            {
                //eliminando las ventans viejas
                List<sistema_modulo_ventanas> listaVieja = getListaSistemaVentanas();
                listaVieja.ForEach(x =>
                {
                    entity.sistema_modulo_ventanas.Remove(x);
                });

                //agregando las ventanas nuevas
                lista.ForEach(x =>
                {
                    entity.sistema_modulo_ventanas.Add(x);
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
