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
    
    public partial class Bonusy
    {
        public Bonusy()
        {
            this.Rozliczenie = new HashSet<Rozliczenie>();
        }
    
        public int bonusID { get; set; }
        public byte[] bonus { get; set; }
    
        public virtual ICollection<Rozliczenie> Rozliczenie { get; set; }
    }
}