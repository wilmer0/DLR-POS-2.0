using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

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

        public string getConeccionDirecta()
        {
            string connectionString = "server=" + datosConeccionBd.Servidor + ";userid=" + datosConeccionBd.Usuario + ";persistsecurityinfo=true;database=" + datosConeccionBd.BaseDatos + ";password=" + datosConeccionBd.Contrasena + ";Port=" + datosConeccionBd.Puerto;
            MySqlConnection coneccion = new MySqlConnection(connectionString);
            coneccion.Open();
            return connectionString;
            
        }
        public punto_ventaEntities GetConeccion()
        {

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

                //datosConeccionBd.Puerto = "3306";
                datosConeccionBd.Servidor = "localhost";
                datosConeccionBd.BaseDatos = "punto_venta";
                datosConeccionBd.Usuario = "root";
                datosConeccionBd.Contrasena = "wilmerlomas1";

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
