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
    
    public partial class Usluga
    {
        public Usluga()
        {
            this.PozycjeFaktury = new HashSet<PozycjeFaktury>();
        }
    
        public int uslugaID { get; set; }
        public string nazwa { get; set; }
        public decimal cena { get; set; }
        public decimal stawkaVAT { get; set; }
        public string opis { get; set; }
    
        public virtual ICollection<PozycjeFaktury> PozycjeFaktury { get; set; }
    }
}
