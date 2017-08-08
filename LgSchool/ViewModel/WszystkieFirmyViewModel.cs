using GalaSoft.MvvmLight.Messaging;
using LgSchool.Model.BusinessLogic.Functionality;
using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    public class WszystkieFirmyViewModel : WszystkieViewModel<FirmyForAllView>
    {
        #region Constructor
        public WszystkieFirmyViewModel()
            : base()
        {
            base.DisplayName = "Firmy";
        }
        #endregion Constructor
        #region Properties
        private FirmyForAllView _WybranaFirma;
        public FirmyForAllView WybranaFirma
        {
            get
            {
                return _WybranaFirma;
            }
            set
            {
                if (_WybranaFirma != value)
                {
                    _WybranaFirma = value;
                    //wybrany firme wysyłamy Messengerem do okna faktura
                    Messenger.Default.Send(_WybranaFirma);
                    //po wybraniu kontrahenta zamykamy zakładkę
                    OnRequestClose();
                }
            }
        }
        #endregion Properties
        #region Helpers

        public override void Load()
        {
            List = new ObservableCollection<FirmyForAllView>
                    (
                        new DataWithForeignKey(lgSdatabase).PobierzFirmy()
                    );
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> {
                "nazwa", "osoba kontaktowa", "email"
            };
        }
        public override void Sort()
        {
            if (SortField == "nazwa")
            {
                List = new ObservableCollection<FirmyForAllView>(
                    List.OrderBy(item => item.Nazwa)
                );
            }
            if (SortField == "osoba kontaktowa")
            {
                List = new ObservableCollection<FirmyForAllView>(
                    List.OrderBy(item => item.OsobaKontaktowa)
                );
            }
            if (SortField == "email")
            {
                List = new ObservableCollection<FirmyForAllView>(
                    List.OrderBy(item => item.Email)
                );
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> {
                "nazwa", "osoba kontaktowa "
            };
        }
        public override void Find()
        {
            if (FindField == "nazwa")
            {
                List = new ObservableCollection<FirmyForAllView>
                    (
                        List.Where(item => item.Nazwa != null
                        && item.Nazwa.StartsWith(FindTextBox))
                    );
            }
            if (FindField == "osoba kontaktowa")
            {
                List = new ObservableCollection<FirmyForAllView>
                    (
                        List.Where(item => item.OsobaKontaktowa != null
                        && item.OsobaKontaktowa.StartsWith(FindTextBox))
                    );
            }
        }
        #endregion Helpers
    }
}
