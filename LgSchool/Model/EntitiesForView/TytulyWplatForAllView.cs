using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.EntitiesForView
{
   public class TytulyWplatForAllView
    {
        public int TytulWplatyID { get; set; }
        public string WplataNumer { get; set; }
        public string KursNazwa { get; set; }
        public decimal Cena { get; set; }
        public int IloscGodzin { get; set; }
    }
}
