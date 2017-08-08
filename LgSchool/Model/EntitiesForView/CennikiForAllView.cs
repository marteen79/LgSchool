using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.EntitiesForView
{
   public class CennikiForAllView
    {
        public int CennikID { get; set; }
        public string KursNazwa { get; set; }
        public string KursPoziom { get; set; }
        public decimal Cena { get; set; }
        public string Opis { get; set; }
    }
}
