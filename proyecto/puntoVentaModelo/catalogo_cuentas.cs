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
    
    public partial class catalogo_cuentas
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public string numero_cuenta { get; set; }
        public Nullable<sbyte> cuenta_master { get; set; }
        public Nullable<sbyte> cuenta_sub_master { get; set; }
        public Nullable<sbyte> cuenta_acumulativa { get; set; }
        public Nullable<sbyte> cuenta_movimiento { get; set; }
        public Nullable<sbyte> origen_credito { get; set; }
        public Nullable<sbyte> origen_debito { get; set; }
        public Nullable<bool> activo { get; set; }
    }
}
