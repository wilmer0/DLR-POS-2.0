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
            punto_ventaEntities entity=new punto_ventaEntities();
            coneccion con=new coneccion();
            entity = con.getConeccion();


            Console.Write(entity.cliente.ToList().Count);
            Console.ReadLine();
        }
    }
}
