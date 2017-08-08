using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    public class NowaUslugaViewModel : NowyViewModel<Usluga>
    {
        #region Fields

        #endregion Fields
        #region Constructor
        public NowaUslugaViewModel()
            :base()
        {
            base.DisplayName = "Nowa usługa";
            item = new Usluga();
        }
        #endregion Constructor
        #region Properties
        public int UslugaID
        {
            get
            {
                return item.uslugaID;
            }
            set
            {
                if (value == item.uslugaID)
                    return;
                item.uslugaID = value;
                base.OnPropertyChanged(() => UslugaID);
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
        public string Opis
        {
            get
            {
                return item.opis;
            }
            set
            {
                if (value == item.opis)
                    return;
                item.opis = value;
                base.OnPropertyChanged(() => Opis);
            }
        }
        #endregion Properties
        #region Commands

        #endregion Commands
        #region Helpers
        public override void Save()
        {
            lgSdatabase.Usluga.Add(item);
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
