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
    
    public partial class sistema_modulo
    {
        public sistema_modulo()
        {
            this.sistema_ventanas = new HashSet<sistema_ventanas>();
            this.sistema_ventanas1 = new HashSet<sistema_ventanas>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public Nullable<bool> activo { get; set; }
        public string nombre_modulo_proyecto { get; set; }
        public string imagen { get; set; }
    
        public virtual ICollection<sistema_ventanas> sistema_ventanas { get; set; }
        public virtual ICollection<sistema_ventanas> sistema_ventanas1 { get; set; }
    }
}
