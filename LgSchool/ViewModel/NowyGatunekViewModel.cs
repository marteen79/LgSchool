using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    public class NowyGatunekViewModel : NowyViewModel<Gatunek>
    {
        #region Fields

        #endregion Fields
        #region Constructor
        public NowyGatunekViewModel()
            :base()
        {
            base.DisplayName = "Nowy gatunek";
            item = new Gatunek();
        }
        #endregion Constructor
        #region Properties
        public int GatunekID
        {
            get
            {
                return item.gatunekID;
            }
            set
            {
                if (value == item.gatunekID)
                    return;
                item.gatunekID = value;
                base.OnPropertyChanged(() => GatunekID);
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
            lgSdatabase.Gatunek.Add(item);
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
