using LgSchool.Model.BusinessLogic.Sprzedaz;
using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.BusinessLogic
{
   public class FirmaStandard : FirmaB
    {
        #region Constructor
        public FirmaStandard(LgSchoolEntities lgSdatabase)
            : base(lgSdatabase)
        {

        }
        #endregion Constructor

        #region BusinessLogic
        public override int RabatZTypu()
        {
            return 0;
            //powinno być
            // return fakturyEntities.Parametry.Find(30);
        }
        #endregion BusinessLogic
    }
}