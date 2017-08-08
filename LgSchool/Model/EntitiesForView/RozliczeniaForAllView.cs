using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.EntitiesForView
{
   public class RozliczeniaForAllView
    {
        public int RozliczenieID { get; set; }
        public string NumerRozliczenia { get; set; }
        public DateTime DataRozliczenia { get; set; }
        public string PracownikNazwa { get; set; }
        public string KursNazwa { get; set; }
        public int IloscGodzin { get; set; }
        public decimal Stawka { get; set; }
        public bool Bonus { get; set; }
    }
}
