using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.EntitiesForView
{
    public class KursyForAllView
    {
        public int KursID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string PoziomNazwa { get; set; }
        public string PracownikNazwa { get; set; }
    }
}
