using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.EntitiesForView
{
    // pola które będą wykorzystane zamiast klucza obcego w klasie UzytkownicyForAllView
    public class StatusyForAllView
    {
        public int StatusID { get; set; }
        public string Nazwa { get; set; }
    }
}
