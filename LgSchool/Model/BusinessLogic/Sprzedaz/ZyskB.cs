using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.BusinessLogic.Sprzedaz
{
    public class ZyskB : DatabaseClass
    {
        #region Constructor
        public ZyskB(LgSchoolEntities lgSdatabase)
            : base(lgSdatabase)
        {

        }
        #endregion Constructor

        #region BusinessFunction
        //to jest funkcja, która liczy dla wybranego towaru i wybranych
        //dat od-do wartość sprzedaży tego towaru
        public decimal? UtargOkresTowar(int idTowaru, DateTime DataOd, DateTime DataDo)
        {
            var listaCenIIlosci =
                (
                    from pozycja in lgSdatabase.PozycjeFaktury
                    where
                        pozycja.uslugaID == idTowaru &&
                        pozycja.Faktura.dataWystawienia >= DataOd &&
                        pozycja.Faktura.dataWystawienia <= DataDo
                    select new
                    {
                        pozycja.cena,
                        pozycja.ilosc
                    }
                );
            decimal? suma = 0;
            foreach (var towar in listaCenIIlosci)
                suma += towar.cena * towar.ilosc;
            return suma;
        }
        #endregion BusinessFunction
    }
}
