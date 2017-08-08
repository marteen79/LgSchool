using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.EntitiesForView
{
   public class GrupyForAllView
    {
        public int GrupaID { get; set; }
        public string Numer { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string PoziomNazwa { get; set; }
        public string UczenNazwa { get; set; }
        //public string [] ListaUczniow { get; set; }
        public string KursNazwa { get; set; }
    }
}
