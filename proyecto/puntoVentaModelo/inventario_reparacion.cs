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
    
    public partial class inventario_reparacion
    {
        public int codigo { get; set; }
        public Nullable<int> codigo_producto { get; set; }
        public Nullable<int> codigo_unidad { get; set; }
        public Nullable<int> cod_marca { get; set; }
        public Nullable<int> cod_modelo { get; set; }
        public string imei { get; set; }
        public string matricula { get; set; }
        public string serial { get; set; }
        public Nullable<decimal> cantidad { get; set; }
        public Nullable<System.DateTime> fecha_entrada { get; set; }
        public Nullable<int> cod_empleado { get; set; }
        public Nullable<int> cod_cliente_titular { get; set; }
        public int estado_reparacion { get; set; }
        public string detalles { get; set; }
        public Nullable<sbyte> activo { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual estados_reparacion estados_reparacion { get; set; }
        public virtual marcas marcas { get; set; }
        public virtual modelo modelo { get; set; }
        public virtual producto producto { get; set; }
        public virtual unidad unidad { get; set; }
    }
}
