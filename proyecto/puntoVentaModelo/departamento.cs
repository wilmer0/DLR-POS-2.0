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
    
    public partial class departamento
    {
        public departamento()
        {
            this.empleado_historial_datos = new HashSet<empleado_historial_datos>();
        }
    
        public int codigo { get; set; }
        public int cod_sucursal { get; set; }
        public string nombre { get; set; }
        public Nullable<byte> activo { get; set; }
    
        public virtual ICollection<empleado_historial_datos> empleado_historial_datos { get; set; }
    }
}
