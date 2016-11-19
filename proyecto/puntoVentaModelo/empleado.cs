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
    
    public partial class empleado
    {
        public empleado()
        {
            this.cobros = new HashSet<cobros>();
            this.compra = new HashSet<compra>();
            this.empleado_historial_datos = new HashSet<empleado_historial_datos>();
            this.empleado_historial_datos1 = new HashSet<empleado_historial_datos>();
            this.factura = new HashSet<factura>();
            this.nomina_detalle = new HashSet<nomina_detalle>();
            this.nomina = new HashSet<nomina>();
            this.pagos = new HashSet<pagos>();
            this.producto_oferta_historial = new HashSet<producto_oferta_historial>();
            this.cargo = new HashSet<cargo>();
        }
    
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string login { get; set; }
        public string clave { get; set; }
        public decimal sueldo { get; set; }
        public Nullable<int> cod_situacion { get; set; }
        public byte activo { get; set; }
        public Nullable<int> cod_sucursal { get; set; }
        public Nullable<int> cod_departamento { get; set; }
        public Nullable<int> cod_cargo { get; set; }
        public Nullable<int> cod_grupo_usuario { get; set; }
        public Nullable<System.DateTime> fecha_ingreso { get; set; }
        public string permiso { get; set; }
        public Nullable<int> cod_tipo_nomina { get; set; }
        public string identificacion { get; set; }
        public string pasaporte { get; set; }
    
        public virtual cajero cajero { get; set; }
        public virtual ICollection<cobros> cobros { get; set; }
        public virtual ICollection<compra> compra { get; set; }
        public virtual ICollection<empleado_historial_datos> empleado_historial_datos { get; set; }
        public virtual ICollection<empleado_historial_datos> empleado_historial_datos1 { get; set; }
        public virtual ICollection<factura> factura { get; set; }
        public virtual ICollection<nomina_detalle> nomina_detalle { get; set; }
        public virtual ICollection<nomina> nomina { get; set; }
        public virtual ICollection<pagos> pagos { get; set; }
        public virtual ICollection<producto_oferta_historial> producto_oferta_historial { get; set; }
        public virtual ICollection<cargo> cargo { get; set; }
    }
}
