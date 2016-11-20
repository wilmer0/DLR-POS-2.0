using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using puntoVentaModelo1;

namespace puntoVentaModelo1.modelos
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


        //      public punto_ventaEntities(string servidor, string baseDatos, string usuario, string contrasena,string puerto="3306")
        //{
        //    var connectionString = this.Database.Connection.ConnectionString + ";password=" + contrasena;
        //    connectionString = "server=" + servidor + ";userid=" + usuario + ";persistsecurityinfo=true;database=" + baseDatos + ";password=" + contrasena + ";Port=" + puerto;

        //    this.Database.Connection.ConnectionString = connectionString;
        //}

                        //if (!System.IO.Directory.Exists("Configuracion"))
                        //{

                        //    System.IO.Directory.CreateDirectory("Configuracion");

                        //}

              


                //        // leer archivo

                //datosConeccionBd.Puerto = "3306";
                datosConeccionBd.Servidor = "localhost";
                datosConeccionBd.BaseDatos = "punto_venta";
                datosConeccionBd.Usuario = "root";
                datosConeccionBd.Contrasena = "wilmerlomas1";

                //MessageBox.Show("BD: " + datosConeccionBd.BaseDatos);
                return new punto_ventaEntities(datosConeccionBd.Servidor, datosConeccionBd.BaseDatos, datosConeccionBd.Usuario, datosConeccionBd.Contrasena);

            }
            else
            {   
                return new punto_ventaEntities(datosConeccionBd.Servidor, datosConeccionBd.BaseDatos, datosConeccionBd.Usuario, datosConeccionBd.Contrasena);
            }
        }
    }
}
