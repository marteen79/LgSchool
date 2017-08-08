using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    class NowyStatusViewModel : NowyViewModel<Status>
    {
        #region Fields

        #endregion Fields
        #region Constructor
        public NowyStatusViewModel()
            :base()
        {
            base.DisplayName = "Nowy status";
            item = new Status();
        }
        #endregion Constructor
        #region Properties
        public int StatusID
        {
            get
            {
                return item.statusID;
            }
            set
            {
                if (value == item.statusID)
                    return;
                item.statusID = value;
                base.OnPropertyChanged(() => StatusID);
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
            lgSdatabase.Status.Add(item);
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
