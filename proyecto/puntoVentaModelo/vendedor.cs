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
    
    public partial class vendedor
    {
        public int codigo { get; set; }
        public Nullable<decimal> porciento { get; set; }
        public Nullable<sbyte> activo { get; set; }
    
        public virtual empleado empleado { get; set; }
    }
}
