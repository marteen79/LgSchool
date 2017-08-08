using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.BusinessLogic.Sprzedaz
{
   public abstract class FirmaB : DatabaseClass
    {
        #region Constructor
        public FirmaB(LgSchoolEntities lgSdatabase)
            :base(lgSdatabase)
        {

        }
        #endregion Constructor

        #region BusinessFunction
        public int RabatZZakupow(int? firmaID)
        {
            var lista =
                (
                    from element in lgSdatabase.PozycjeFaktury
                    where element.Faktura.firmaID == firmaID
                    select new
                    {
                        element.cena,
                        element.ilosc
                    }
                ).ToList();
            decimal? wartoscZakupow = 0;
            foreach (var item in lista)
            {
                wartoscZakupow += item.cena * Convert.ToDecimal(item.ilosc);
            }
            decimal parametr1 = 500;
            //powinno byc
            //decimal parametr1 = fakturyEntities.Parametry.Find(1);
            decimal parametr2 = 1000;
            //powinno byc
            //decimal parametr1 = fakturyEntities.Parametry.Find(2);
            decimal parametr3 = 3000;
            //powinno byc
            //decimal parametr1 = fakturyEntities.Parametry.Find(3);
            if (wartoscZakupow <= parametr1)
            {
                return 0;
            }
            else
            {
                if (wartoscZakupow <= parametr2)
                {
                    return 5;
                }
                else
                {
                    if (wartoscZakupow <= parametr3)
                    {
                        return 10;
                    }
                }
            }
            return 0;
        }
        public abstract int RabatZTypu();
        public int RabatRazem(int? firmaID)
        {
            return RabatZZakupow(firmaID) + RabatZTypu();
        }
        public string PobierzInfoORabatach(int? firmaID)
        {
            return
                "Wartość rabatu z zakupów: " + RabatZZakupow(firmaID) +
                "\nWartość rabatu z typu: " + RabatZTypu() +
                "\nWartość rabatu razem:" + RabatRazem(firmaID);
        }
        #endregion BusinessFunction
    }
}
