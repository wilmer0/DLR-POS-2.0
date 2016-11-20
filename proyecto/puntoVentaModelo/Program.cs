using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using puntoVentaModelo;
using puntoVentaModelo.modelos;


namespace puntoVentaModelo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Entro-->");
                modeloEmpleado modeloEmpleado=new modeloEmpleado();
                List<empleado> lista=new List<empleado>();
                lista = modeloEmpleado.getListaCompleta();
                lista.ForEach(x =>
                {
                    Console.Write(x.nombre+"-"+x.login+"-"+x.clave+"-"+x.cargo);
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error.: "+ex.ToString());
            }
            Console.ReadLine();
        }
    }
}
