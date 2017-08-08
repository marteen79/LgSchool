using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.BusinessLogic.Sprzedaz
{
   public  class FakturaB : DatabaseClass
    {
        #region Constructor
        public FakturaB(LgSchoolEntities lgSdatabase)
            : base(lgSdatabase)
        {

        }
        #endregion Constructor       

        #region ViewFunction
        public List<FakturyForAllView> FindDedicated(string NumerFind,
            DateTime? DataOdFind, DateTime? DataDoFind)
        {
            List<FakturyForAllView> listaFaktur =
                (
                    from faktura in lgSdatabase.Faktura
                    select new FakturyForAllView
                    {
                        FakturaID = faktura.fakturaID,
                        NumerFaktury = faktura.numerFaktury,
                        DataWystawienia = faktura.dataWystawienia,
                        TerminPlatnosci = faktura.terminPlatnosci,
                        DataWplaty = faktura.dataWplaty,
                        RodzajPlatnosciNazwa = faktura.RodzajPlatnosci.nazwaPlatnosci
                    }
                ).ToList();
            if (!String.IsNullOrEmpty(NumerFind))
            {
                listaFaktur =
                    (
                        from element in listaFaktur
                        where element.NumerFaktury == NumerFind
                        select element
                    ).ToList();
            }
            if (DataOdFind != null)
            {
                listaFaktur =
                    (
                        from element in listaFaktur
                        where element.DataWystawienia >= DataOdFind
                        select element
                    ).ToList();
            }
            if (DataDoFind != null)
            {
                listaFaktur =
                    (
                        from element in listaFaktur
                        where element.DataWystawienia <= DataDoFind
                        select element
                    ).ToList();
            }
            return listaFaktur;
        }
        #endregion ViewFunction

        #region BusinessFunction
        public decimal? LiczWartoscNetto(List<PozycjeFaktury> lista)
        {
            decimal? suma = 0;
            decimal? wartoscElementu = 0;
            foreach (var item in lista)
            {
                wartoscElementu = item.ilosc * item.cena;
                suma += wartoscElementu - wartoscElementu * item.rabat / 100;
            }
            return suma;
        }
        public decimal? LiczWartoscBrutto(List<PozycjeFaktury> lista)
        {
            decimal? suma = 0;
            decimal? wartoscElementu = 0;
            foreach (var item in lista)
            {
                wartoscElementu = item.ilosc * (item.cena + item.cena * item.Usluga.stawkaVAT / 100);
                suma += wartoscElementu - wartoscElementu * item.rabat / 100;
            }
            return suma;
        }
        public decimal? ObliczPozostaje
            (decimal? wartoscBrutto, decimal? zaplacono)
        {
            return wartoscBrutto - zaplacono;
        }
        #endregion BusinessFunction
        #region ViewFunction
        //To jest funkcja uzywana na wszystkich widokach, 
        //uzywających wyswietlanie wszystkich danych towarów
        //public List<Faktura> PobierzWszystkoZFaktury()
        //{
        //    return
        //        (
        //            from faktura in lgSdatabase.Faktura
        //            select faktura
        //        ).ToList();
        //}
        #endregion ViewFunction
    }
}
