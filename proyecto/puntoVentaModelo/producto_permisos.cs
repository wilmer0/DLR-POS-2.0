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
    
    public partial class producto_permisos
    {
        public producto_permisos()
        {
            this.producto_vs_permisos = new HashSet<producto_vs_permisos>();
        }
    
        public int codigo { get; set; }
        public string nombre { get; set; }
        public byte activo { get; set; }
    
        public virtual ICollection<producto_vs_permisos> producto_vs_permisos { get; set; }
    }
}
