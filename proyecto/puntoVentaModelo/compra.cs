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
    
    public partial class compra
    {
        public compra()
        {
            this.compra_detalle = new HashSet<compra_detalle>();
            this.pagos_detalles = new HashSet<pagos_detalles>();
        }
    
        public int codigo { get; set; }
        public string num_factura { get; set; }
        public int cod_suplidor { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<System.DateTime> fecha_limite { get; set; }
        public string ncf { get; set; }
        public string rnc { get; set; }
        public string cod_tipo { get; set; }
        public Nullable<bool> activo { get; set; }
        public Nullable<byte> pagada { get; set; }
        public Nullable<int> cod_sucursal { get; set; }
        public Nullable<decimal> efectivo { get; set; }
        public Nullable<decimal> devuelta { get; set; }
        public Nullable<int> codigo_empleado { get; set; }
        public Nullable<int> codigo_empleado_anular { get; set; }
        public string motivo_anulado { get; set; }
        public string compracol { get; set; }
    
        public virtual ICollection<compra_detalle> compra_detalle { get; set; }
        public virtual empleado empleado { get; set; }
        public virtual sucursal sucursal { get; set; }
        public virtual suplidor suplidor { get; set; }
        public virtual ICollection<pagos_detalles> pagos_detalles { get; set; }
    }
}
