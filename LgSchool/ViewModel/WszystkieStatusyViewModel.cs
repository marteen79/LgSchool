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
    public class WszystkieStatusyViewModel : WszystkieViewModel<Status>
    {
        #region Constructor
        public WszystkieStatusyViewModel()
            :base()
        {
            base.DisplayName = "Statusy";
        }
        #endregion Constructor
        #region Propertis
        private StatusyForAllView _WybranyStatus;
        public StatusyForAllView WybranyStatus
        {
            get
            {
                return _WybranyStatus;
            }
            set
            {
                if (_WybranyStatus != value)
                {
                    _WybranyStatus = value;
                    //wybrany status wysyłamy Messengerem do okna użytkownik
                    Messenger.Default.Send(_WybranyStatus);
                    //po wybraniu kontrahenta zamykamy zakłdkę
                    OnRequestClose();
                }
            }
        }
        #endregion Propertis
        #region Helpers
        //to jest metoda która pobiera wszystkie statusy z bazy danych
        public override void Load()
        {
            {
                List = new ObservableCollection<Status>
                    (
                       new DataWithoutForeignKey(lgSdatabase).PobierzStatusy()
                    );
            }
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> {
                "nazwa"
            };
        }
        public override void Sort()
        {
            if (SortField == "nazwa")
            {
                List = new ObservableCollection<Status>(
                    List.OrderBy(item => item.nazwa)
                );
            }

        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> {
                "nazwa"
            };
        }
        public override void Find()
        {
            if (FindField == "nazwa")
            {
                List = new ObservableCollection<Status>
                    (
                        List.Where(item => item.nazwa != null
                        && item.nazwa.StartsWith(FindTextBox))
                    );
            }

        }
        #endregion Helpers
    }
}
