﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puntoVentaModelo.modelos
{
    public class coneccion
    {

        private static coneccion instance;

        public static coneccion Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new coneccion();
                }
                return instance;
            }
        }
        public coneccion()
        {

        }
        public static DatosConeccionBD datosConeccionBd { get; set; }

        public coneccion(DatosConeccionBD datosConeccion)
        {
            datosConeccionBd = datosConeccion;
        }


        public DatosConeccionBD GetDatos()
        {
            return datosConeccionBd;
        }


        public punto_ventaEntities getConeccion()
        {
            datosConeccionBd = new DatosConeccionBD();

            if (datosConeccionBd == null)
            {
                datosConeccionBd = new DatosConeccionBD();


                //         public punto_ventaEntities(string servidor, String baseDatos, String user, String pass, String Puerto="3306"): base("name=ADMFICEntities")
                //        {


                //    var connectionString = this.Database.Connection.ConnectionString + ";password=" + pass;
                //    connectionString = "server=" + servidor + ";userid=" + user + ";persistsecurityinfo=true;database=" + baseDatos + ";password=" + pass;

                //    this.Database.Connection.ConnectionString = connectionString;
                //}

                //        if (!System.IO.Directory.Exists("Configuracion"))
                //        {

                //            System.IO.Directory.CreateDirectory("Configuracion");

                     //   }

              


                //        // leer archivo

                    
                    datosConeccionBd.Servidor = "localhost";
                    datosConeccionBd.BaseDatos = "puntoventa";
                    datosConeccionBd.Usuario = "dextroyex";
                    datosConeccionBd.Contrasena = "123456";

                    MessageBox.Show("BD: " + datosConeccionBd.BaseDatos);
                    return new punto_ventaEntities(datosConeccionBd.Servidor, datosConeccionBd.BaseDatos, datosConeccionBd.Usuario, datosConeccionBd.Contrasena);
               
            }
            else
            {
                return new punto_ventaEntities(datosConeccionBd.Servidor, datosConeccionBd.BaseDatos, datosConeccionBd.Usuario, datosConeccionBd.Contrasena);
            }
        }
    }
}
