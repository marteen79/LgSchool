using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.BusinessLogic.Sprzedaz
{
   public class FirmaVip : FirmaB
    {
        #region Constructor
        public FirmaVip(LgSchoolEntities lgSdatabase)
            : base(lgSdatabase)
        {

        }
        #endregion Constructor

        #region BusinessLogic
        public override int RabatZTypu()
        {
            return 10;
            //powinno być
            // return fakturyEntities.Parametry.Find(30);
        }
        #endregion BusinessLogic
    }
}
