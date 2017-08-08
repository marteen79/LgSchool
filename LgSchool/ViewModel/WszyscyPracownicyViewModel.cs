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
    public class WszyscyPracownicyViewModel : WszystkieViewModel<PracownicyForAllView>
    {
        #region Constructor
        public WszyscyPracownicyViewModel()
            :base()
        {
            base.DisplayName = "Pracownicy";
        }
        #endregion Constructor
        #region Properties
        private PracownicyForAllView _WybranyPracownik;
        public PracownicyForAllView WybranyPracownik
        {
            get
            {
                return _WybranyPracownik;
            }
            set
            {
                if (_WybranyPracownik != value)
                {
                    _WybranyPracownik = value;
                    //wybrany firme wysyłamy Messengerem do okna faktura
                    Messenger.Default.Send(_WybranyPracownik);
                    //po wybraniu kontrahenta zamykamy zakładkę
                    OnRequestClose();
                }
            }
        }
        #endregion Properties
        public override void Load()
        {

            List = new ObservableCollection<PracownicyForAllView>
                (
                    new DataWithForeignKey(lgSdatabase).PobierzPracownikow()
                );

        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> {
                "nazwisko","stanowisko","data zatrudnienia"
            };
        }
        public override void Sort()
        {
            if (SortField == "nazwisko")
            {
                List = new ObservableCollection<PracownicyForAllView>(
                    List.OrderBy(item => item.Nazwisko)
                );
            }
            if (SortField == "stanowisko")
            {
                List = new ObservableCollection<PracownicyForAllView>(
                    List.OrderBy(item => item.StanowiskoNazwa)
                );
            }
            if (SortField == "data zatrudnienia")
            {
                List = new ObservableCollection<PracownicyForAllView>(
                    List.OrderBy(item => item.DataZatrudnienia)
                );
            }

        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> {
                   "nazwisko","stanowisko"
            };
        }
        public override void Find()
        {
            if (FindField == "nazwisko")
            {
                List = new ObservableCollection<PracownicyForAllView>
                    (
                        List.Where(item => item.Nazwisko != null
                        && item.Nazwisko.StartsWith(FindTextBox))
                    );
            }
            if (FindField == "stanowisko")
            {
                List = new ObservableCollection<PracownicyForAllView>
                    (
                        List.Where(item => item.StanowiskoNazwa != null
                        && item.StanowiskoNazwa.StartsWith(FindTextBox))
                    );
            }
        }
    }
}
