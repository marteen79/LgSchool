using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    class NowaKategoriaOcenViewModel : NowyViewModel<KategoriaOcen>
    {
        #region Fields

        #endregion Fields
        #region Constructor
        public NowaKategoriaOcenViewModel()
            :base()
        {
            base.DisplayName = "Nowa kategoria";
            item = new KategoriaOcen();
        }
        #endregion Constructor
        #region Properties
        public int KategoriaID
        {
            get
            {
                return item.kategoriaID;
            }
            set
            {
                if (value == item.kategoriaID)
                    return;
                item.kategoriaID = value;
                base.OnPropertyChanged(() => KategoriaID);
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
            lgSdatabase.KategoriaOcen.Add(item);
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
