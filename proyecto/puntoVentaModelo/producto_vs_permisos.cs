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
    
    public partial class producto_vs_permisos
    {
        public int codigo { get; set; }
        public int cod_producto { get; set; }
        public int cod_permiso { get; set; }
    
        public virtual producto producto { get; set; }
        public virtual producto_permisos producto_permisos { get; set; }
    }
}
