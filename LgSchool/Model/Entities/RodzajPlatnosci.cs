//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LgSchool.Model.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class RodzajPlatnosci
    {
        public RodzajPlatnosci()
        {
            this.Faktura = new HashSet<Faktura>();
            this.Wplata = new HashSet<Wplata>();
        }
    
        public int rodzajPlatnosciID { get; set; }
        public string nazwaPlatnosci { get; set; }
    
        public virtual ICollection<Faktura> Faktura { get; set; }
        public virtual ICollection<Wplata> Wplata { get; set; }
    }
}