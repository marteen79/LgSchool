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
    
    public partial class Materialy
    {
        public int materialID { get; set; }
        public int typID { get; set; }
        public string tytul { get; set; }
        public int autorID { get; set; }
        public int gatunekID { get; set; }
        public int poziomID { get; set; }
    
        public virtual Autor Autor { get; set; }
        public virtual Gatunek Gatunek { get; set; }
        public virtual Poziom Poziom { get; set; }
        public virtual TypyMaterialow TypyMaterialow { get; set; }
    }
}