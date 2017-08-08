using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.EntitiesForView
{
    public class PozycjeFakturyForAllView
    {
        #region Propertis
        public string UslugaNazwa { get; set; }
        public decimal? Cena { get; set; }
        public decimal? Ilosc { get; set; }
        public decimal? Rabat { get; set; }
        #endregion Propertis
    }
}