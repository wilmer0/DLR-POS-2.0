using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puntoVenta.clases
{
    public class reporte_facturacion_rollo
    {



        public string producto { get; set; }
        public float cantidad { get; set; }
        public string unidad { get; set; }
        public float itbis { get; set; }
        public float subTotal { set; get; }
        public string total { get; set; }

    }
}
