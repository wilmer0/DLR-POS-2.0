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
    
    public partial class modelo
    {
        public modelo()
        {
            this.inventario_reparacion = new HashSet<inventario_reparacion>();
        }
    
        public int codigo { get; set; }
        public int codigo_marca { get; set; }
        public string nombre_modelo { get; set; }
        public sbyte activo { get; set; }
    
        public virtual ICollection<inventario_reparacion> inventario_reparacion { get; set; }
    }
}
