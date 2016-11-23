﻿using System;
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


       

        public List<sistema_modulo_ventanas> GetListaVentanasByEmpleado(empleado empleado)
        {
            try
            {

                coneccion con = new coneccion();
                punto_ventaEntities entity = con.GetConeccion();

                //listas
                List<empleado_accesos_ventanas> listaAccesoVentanas = new List<empleado_accesos_ventanas>();
                List<sistema_modulo_ventanas> listaSistemaModulosVentanas = new List<sistema_modulo_ventanas>();
                 List<sistema_modulo_ventanas> ListaVentanas = new List<sistema_modulo_ventanas>();
                listaAccesoVentanas = (from c in entity.empleado_accesos_ventanas
                             where c.id_empleado == empleado.codigo
                             select c).ToList();


                listaSistemaModulosVentanas = (from c in entity.sistema_modulo_ventanas
                                               select c).ToList();

                foreach (var acceso in listaAccesoVentanas)
                {
                    foreach (var ventana in listaSistemaModulosVentanas)
                    {
                        if (acceso.id_ventana_sistema == ventana.codigo)
                        {
                            ListaVentanas.Add(ventana);
                        }
                    }
                }


                return ListaVentanas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetListaVentanasByEmpleado.: " + ex.ToString());
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

        public empleado getEmpleadoByLogin(empleado e)
        {
            try
            {
                coneccion coneccion = new coneccion();
                punto_ventaEntities entity = coneccion.GetConeccion();
                empleado empleado;
                List<empleado> lista = new List<empleado>();
                lista = getListaCompleta();
                empleado = lista.FindAll(x => x.login == e.login && x.clave == e.clave).ToList().FirstOrDefault();
                return empleado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEmpleadoByLogin.: " + ex.ToString());
                return null;
            }
        }

        public List<sistema_modulo> GetListaModulosByEmpleado(empleado empleado)
        {
            try
            {

                coneccion con = new coneccion();
                punto_ventaEntities entity = con.GetConeccion();

                
                //listas
               
                List<sistema_modulo> listaModulos = new List<sistema_modulo>();



                listaModulos = (from e in entity.sistema_modulo 
                                select e).ToList();

                return listaModulos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetListaModulosByEmpleado.: " + ex.ToString());
                return null;
            }
        }
    }
}
