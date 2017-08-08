using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.EntitiesForView
{
   public class FakturyForAllView
    {
        public int FakturaID { get; set; }
        public string NumerFaktury { get; set; }
        public string FirmaNazwa { get; set; }
        public string FirmaNip { get; set; }
        //public string OsobaNazwa { get; set; } // imię i nazwisko

        //public string UslugaNazwa { get; set; }
        public DateTime DataWystawienia { get; set; }
        public DateTime TerminPlatnosci { get; set; }
        public string RodzajPlatnosciNazwa { get; set; }
        public DateTime DataWplaty { get; set; }
    }
}
