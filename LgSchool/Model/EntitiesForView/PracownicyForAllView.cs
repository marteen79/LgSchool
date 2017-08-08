using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.EntitiesForView
{
    public class PracownicyForAllView
    {
        public int PracownikID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string Pesel { get; set; }
        public string Ulica { get; set; }
        public string Numer { get; set; }
        public string KodPocztowy { get; set; }
        public string Miejscowosc { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string StanowiskoNazwa { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public DateTime? DataZwolnienia { get; set; }
    }
}
