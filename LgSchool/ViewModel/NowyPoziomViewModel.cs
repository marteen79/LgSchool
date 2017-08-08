using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    class NowyPoziomViewModel : NowyViewModel<Poziom>
    {
        #region Fields

        #endregion Fields
        #region Constructor
        public NowyPoziomViewModel()
            :base()
        {
            base.DisplayName = "Nowy poziom";
            item = new Poziom();
        }
        #endregion Constructor
        #region Properties
        public int PoziomID
        {
            get
            {
                return item.poziomID;
            }
            set
            {
                if (value == item.poziomID)
                    return;
                item.poziomID = value;
                base.OnPropertyChanged(() => PoziomID);
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
            lgSdatabase.Poziom.Add(item);
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
