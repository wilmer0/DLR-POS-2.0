//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace puntoVentaModelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class ingresos_conceptos
    {
        public ingresos_conceptos()
        {
            this.ingresos_caja = new HashSet<ingresos_caja>();
        }
    
        public int codigo { get; set; }
        public string nombre { get; set; }
        public int estado { get; set; }
    
        public virtual ICollection<ingresos_caja> ingresos_caja { get; set; }
    }
}
