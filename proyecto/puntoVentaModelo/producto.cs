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
    
    public partial class producto
    {
        public producto()
        {
            this.entrada_salida_inventario = new HashSet<entrada_salida_inventario>();
            this.inventario = new HashSet<inventario>();
            this.inventario_reparacion = new HashSet<inventario_reparacion>();
            this.compra_detalle = new HashSet<compra_detalle>();
            this.factura_detalle = new HashSet<factura_detalle>();
            this.oferta_producto_detalle = new HashSet<oferta_producto_detalle>();
            this.producto_codigobarra = new HashSet<producto_codigobarra>();
            this.producto_unidad_conversion = new HashSet<producto_unidad_conversion>();
            this.producto_vs_detalle = new HashSet<producto_vs_detalle>();
            this.producto_vs_permisos = new HashSet<producto_vs_permisos>();
            this.unidad1 = new HashSet<unidad>();
        }
    
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string referencia { get; set; }
        public Nullable<bool> activo { get; set; }
        public decimal reorden { get; set; }
        public decimal punto_maximo { get; set; }
        public int cod_itebis { get; set; }
        public int cod_categoria { get; set; }
        public int cod_subcategoria { get; set; }
        public int cod_almacen { get; set; }
        public string imagen { get; set; }
        public int cod_unidad_minima { get; set; }
    
        public virtual almacen almacen { get; set; }
        public virtual categoria_producto categoria_producto { get; set; }
        public virtual ICollection<entrada_salida_inventario> entrada_salida_inventario { get; set; }
        public virtual ICollection<inventario> inventario { get; set; }
        public virtual ICollection<inventario_reparacion> inventario_reparacion { get; set; }
        public virtual itebis itebis { get; set; }
        public virtual ICollection<compra_detalle> compra_detalle { get; set; }
        public virtual ICollection<factura_detalle> factura_detalle { get; set; }
        public virtual ICollection<oferta_producto_detalle> oferta_producto_detalle { get; set; }
        public virtual ICollection<producto_codigobarra> producto_codigobarra { get; set; }
        public virtual subcategoria_producto subcategoria_producto { get; set; }
        public virtual ICollection<producto_unidad_conversion> producto_unidad_conversion { get; set; }
        public virtual unidad unidad { get; set; }
        public virtual ICollection<producto_vs_detalle> producto_vs_detalle { get; set; }
        public virtual ICollection<producto_vs_permisos> producto_vs_permisos { get; set; }
        public virtual ICollection<unidad> unidad1 { get; set; }
    }
}
