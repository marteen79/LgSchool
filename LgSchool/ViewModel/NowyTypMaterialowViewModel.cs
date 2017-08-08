using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    class NowyTypMaterialowViewModel : NowyViewModel<TypyMaterialow>
    {
        #region Fields

        #endregion Fields
        #region Constructor
        public NowyTypMaterialowViewModel()
            :base()
        {
            base.DisplayName = "Nowy typ";
            item = new TypyMaterialow();
        }
        #endregion Constructor
        #region Properties
        public int TypID
        {
            get
            {
                return item.typID;
            }
            set
            {
                if (value == item.typID)
                    return;
                item.typID = value;
                base.OnPropertyChanged(() => TypID);
            }
        }
        public string Nazwa
        {
            get
            {
                return item.nazwa;
            }
            set
            {
                if (value == item.nazwa)
                    return;
                item.nazwa = value;
                base.OnPropertyChanged(() => Nazwa);
            }
        }
        #endregion Properties
        #region Commands

        #endregion Commands
        #region Helpers
        public override void Save()
        {
            lgSdatabase.TypyMaterialow.Add(item);
            lgSdatabase.SaveChanges();
        }
        public void SaveAndClose()
        {
            Save();
            ShowMessageBoxInfo();
            OnRequestClose();
        }
        #endregion Helpers
    }
}
