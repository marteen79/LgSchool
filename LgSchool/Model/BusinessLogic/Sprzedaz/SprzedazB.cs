using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.BusinessLogic.Sprzedaz
{
    public class SprzedazB : DatabaseClass
    {
        #region Constructor
        public SprzedazB(LgSchoolEntities lgSdatabase)
            : base(lgSdatabase)
        {

        }
        #endregion Constructor

        #region IdentityFunction
        public FirmaB IdentyfikujTypFirmy(int? firmaID)
        {
            if (lgSdatabase.Firma.Find(firmaID).Status.statusID == 1)
            {
                return new FirmaStandard(lgSdatabase);
            }
            if (lgSdatabase.Firma.Find(firmaID).Status.statusID == 2)
            {
                return new FirmaVip(lgSdatabase);
            }
            return null;
        }
        #endregion IdentityFunction

        #region BusinessFunction
        public int OkreslRabat(int? firmaID)
        {
            return IdentyfikujTypFirmy(firmaID).RabatRazem(firmaID);
        }
        #endregion BusinessFunction
    }
}
