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
    
    public partial class producto_oferta
    {
        public producto_oferta()
        {
            this.oferta_producto_detalle = new HashSet<oferta_producto_detalle>();
        }
    
        public int codigo { get; set; }
        public string nombre { get; set; }
        public float descuento { get; set; }
        public Nullable<System.DateTime> fecha_inicial { get; set; }
        public Nullable<System.DateTime> fecha_final { get; set; }
        public Nullable<int> estado { get; set; }
        public int cod_sucursal { get; set; }
    
        public virtual ICollection<oferta_producto_detalle> oferta_producto_detalle { get; set; }
    }
}
