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
            coneccion coneccion=new coneccion();
            punto_ventaEntities entity = coneccion.getConeccion();

            Console.WriteLine(entity.cliente.ToList().Count);
            Console.ReadLine();
        }
    }
}
