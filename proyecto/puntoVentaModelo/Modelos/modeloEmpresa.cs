using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVentaModelo.modelos;

namespace puntoVentaModelo.modelos
{
    public class modeloEmpresa
    {


        //objetos
        


        public Boolean agregarEmpresa(empresa empresa)
        {
            coneccion coneccion = new coneccion();
            punto_ventaEntities entity = coneccion.GetConeccion();
            try
            {
                var listaEmpresa = (from c in entity.empresa
                                      select c).FirstOrDefault();
                if (listaEmpresa != null)
                {
                    MessageBox.Show("No se puede agregar la empresa, porque ya existe una", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }
                entity.empresa.Add(empresa);
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarEmpresa.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return false;
            }
        }


        public bool ModificarEmpresa(empresa empresa)
        {

            coneccion coneccion = new coneccion();
            punto_ventaEntities entity = coneccion.GetConeccion();
            try
            {

                var Lista = (from c in entity.empresa
                             where c.codigo == empresa.codigo
                             select c).FirstOrDefault();

                var listaDivision = (from c in entity.empresa
                                     where c.codigo != empresa.codigo && c.division==empresa.division 
                                     select c).FirstOrDefault();
                if (listaDivision != null)
                {
                    MessageBox.Show("No se modifico: se encuentra una empresa con la misma división", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                var listaRnc = (from c in entity.empresa
                                     where c.codigo != empresa.codigo && c.rnc == empresa.rnc
                                     select c).FirstOrDefault();
                if (listaRnc != null)
                {
                    MessageBox.Show("No se modifico: se encuentra una empresa con el mismo rnc", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                var listaSecuencia = (from c in entity.empresa
                                      where c.codigo != empresa.codigo && c.secuencia == empresa.secuencia
                                     select c).FirstOrDefault();
                if (listaSecuencia != null)
                {
                    MessageBox.Show("No se modifico: se encuentra una empresa con la misma secuencia", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                Lista.codigo = empresa.codigo;
                Lista.division = empresa.division;
                Lista.rnc = empresa.rnc;
                Lista.secuencia = empresa.secuencia;
                Lista.activo = empresa.activo;

                entity.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ModificarEmpresa.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public int getNext()
        {
            int count = 0;

            coneccion coneccion = new coneccion();
            punto_ventaEntities entity = coneccion.GetConeccion();
            try
            {
                count = entity.empresa.Count();
                if (count > 0)
                {
                    count = entity.empresa.Max(c => c.codigo);
                }
                return count + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getNext.: "+ex.ToString());
                return count;
            }
        }

        public empresa getEmpresaByRnc(string rnc)
        {
            coneccion coneccion = new coneccion();
            punto_ventaEntities entity = coneccion.GetConeccion();
            try
            {
               empresa empresa;
               empresa = (from c in entity.empresa
                             where c.rnc.ToLower().Contains(rnc.ToLower())
                             select c).FirstOrDefault();

                return empresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEmpresaByRnc.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public empresa getEmpresaById(int id)
        {
            coneccion coneccion = new coneccion();
            punto_ventaEntities entity = coneccion.GetConeccion();
            try
            {
                empresa empresa;
                empresa = (from c in entity.empresa
                           where c.codigo==id
                           select c).FirstOrDefault();

                return empresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEmpresaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<empresa> getListaCompleta()
        {
            coneccion coneccion = new coneccion();
            punto_ventaEntities entity = coneccion.GetConeccion();
            try
            {
               List<empresa> Lista=new List<empresa>(); 
               Lista = (from c in entity.empresa
                         
                           select c).ToList();

                return Lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public empresa getEmpresaBySucursal(sucursal sucursal)
        {
            coneccion coneccion = new coneccion();
            punto_ventaEntities entity = coneccion.GetConeccion();
            try
            {
                empresa empresa;
                empresa = (from c in entity.empresa
                           where c.codigo == sucursal.codigo_empresa
                           select c).FirstOrDefault();

                return empresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEmpresaBySucursal.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }




    }
}
