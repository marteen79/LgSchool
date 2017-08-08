using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.EntitiesForView
{
    public class WplatyForAllView
    {
        public int WplataID { get; set; }
        public string WplataNumer { get; set; }
        public string UczenImie { get; set; } // FK Uczen
        public string UczenNazwisko { get; set; } // FK Uczen
        public string FirmaNazwa { get; set; } // FK Firma
        public DateTime DataWplaty { get; set; }
        public string RodzajPlatnosciNazwa { get; set; } // FK RodzajPlatnosci
    }
}
