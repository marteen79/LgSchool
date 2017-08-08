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
    public class WszyscyUczniowieViewModel : WszystkieViewModel<UczniowieForAllView>
    {
        #region Constructor
        public WszyscyUczniowieViewModel()
            :base()
        {
            base.DisplayName = "Uczniowie";
        }
        #endregion Contructor
        #region Properties
        private UczniowieForAllView _WybranyUczen;
        public UczniowieForAllView WybranyUczen
        {
            get
            {
                return _WybranyUczen;
            }
            set
            {
                if (_WybranyUczen != value)
                {
                    _WybranyUczen = value;
                    //wybrany firme wysyłamy Messengerem do okna faktura
                    Messenger.Default.Send(_WybranyUczen);
                    //po wybraniu kontrahenta zamykamy zakładkę
                    OnRequestClose();
                }
            }
        }
        #endregion Properties
        #region Helpers
        public override void Load()
        {

            List = new ObservableCollection<UczniowieForAllView>
                (
                    new DataWithForeignKey(lgSdatabase).PobierzUczniow()
                );

        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> {
                "nazwisko","pesel","email"
            };
        }
        public override void Sort()
        {
            if (SortField == "nazwisko")
            {
                List = new ObservableCollection<UczniowieForAllView>(
                    List.OrderBy(item => item.Nazwisko)
                );
            }
            if (SortField == "pesel")
            {
                List = new ObservableCollection<UczniowieForAllView>(
                    List.OrderBy(item => item.Pesel)
                );
            }
            if (SortField == "email")
            {
                List = new ObservableCollection<UczniowieForAllView>(
                    List.OrderBy(item => item.Email)
                );
            }

        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> {
                 "nazwisko","email"
            };
        }
        public override void Find()
        {
            if (FindField == "nazwisko")
            {
                List = new ObservableCollection<UczniowieForAllView>
                    (
                        List.Where(item => item.Nazwisko != null
                        && item.Nazwisko.StartsWith(FindTextBox))
                    );
            }
            if (FindField == "email")
            {
                List = new ObservableCollection<UczniowieForAllView>
                    (
                        List.Where(item => item.Email != null
                        && item.Email.StartsWith(FindTextBox))
                    );
            }
        }
        #endregion Helpers
    }
}
