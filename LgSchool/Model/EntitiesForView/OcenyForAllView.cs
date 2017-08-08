using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.EntitiesForView
{
    public class OcenyForAllView
    {
        public int OcenaID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public int? UczenID { get; set; }
    }
}
