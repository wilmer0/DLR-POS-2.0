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
    
    public partial class situacion_empleado
    {
        public situacion_empleado()
        {
            this.empleado = new HashSet<empleado>();
            this.empleado_historial_datos = new HashSet<empleado_historial_datos>();
        }
    
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public byte activo { get; set; }
    
        public virtual ICollection<empleado> empleado { get; set; }
        public virtual ICollection<empleado_historial_datos> empleado_historial_datos { get; set; }
    }
}
