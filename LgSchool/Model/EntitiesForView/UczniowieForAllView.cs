using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.EntitiesForView
{
    public class UczniowieForAllView
    {
        public int UczenID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string Pesel { get; set; }
        public string Telefon { get; set; }
        public string TelefonOpiekuna { get; set; }
        public string Email { get; set; }
        //public int? GrupaID { get; set; }
        public string StatusNazwa { get; set; }

    }
}
