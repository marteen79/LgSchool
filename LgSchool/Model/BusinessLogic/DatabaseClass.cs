using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.BusinessLogic
{
   public class DatabaseClass
    {
        #region Fields
        protected LgSchoolEntities lgSdatabase;
        #endregion Fields

        #region Constructor
        public DatabaseClass(LgSchoolEntities lgSdatabase)
        {
            this.lgSdatabase = lgSdatabase;
        }
        #endregion Constructor

    }
}
