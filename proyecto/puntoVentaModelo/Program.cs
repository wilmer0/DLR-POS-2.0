using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using puntoVentaModelo.modelos;

namespace puntoVentaModelo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<empleado> lista=new List<empleado>();
            modeloEmpleado modeloEmpleado=new modeloEmpleado();
            lista = modeloEmpleado.getListaCompleta();
            lista.ForEach(x =>
            {
                Console.WriteLine(x.login+"-"+x.clave +"-"+x.cod_cargo);
            });
            Console.ReadLine();
        }
    }
}
