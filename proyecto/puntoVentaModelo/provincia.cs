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
    
    public partial class provincia
    {
        public provincia()
        {
            this.sector = new HashSet<sector>();
        }
    
        public int codigo { get; set; }
        public int cod_region { get; set; }
        public string nombre { get; set; }
        public byte activo { get; set; }
    
        public virtual region region { get; set; }
        public virtual ICollection<sector> sector { get; set; }
    }
}
