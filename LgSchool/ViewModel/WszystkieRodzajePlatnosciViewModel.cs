using GalaSoft.MvvmLight.Messaging;
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
    public class WszystkieRodzajePlatnosciViewModel : WszystkieViewModel<RodzajePlatnosciForAllView>
    {
        #region Constructor
        public WszystkieRodzajePlatnosciViewModel()
            :base()
        {
            base.DisplayName = "Platnosci";
        }
        #endregion Constructor
        #region Propertis
        private RodzajePlatnosciForAllView _WybranaPlatnosc;
        public RodzajePlatnosciForAllView WybranaPlatnosc
        {
            get
            {
                return _WybranaPlatnosc;
            }
            set
            {
                if (_WybranaPlatnosc != value)
                {
                    _WybranaPlatnosc = value;
                    //wybrana platnosc wysyłamy Messengerem do okna faktura
                    Messenger.Default.Send(_WybranaPlatnosc);
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
            List = new ObservableCollection<RodzajePlatnosciForAllView>
                (
                    from platnosc in lgSdatabase.RodzajPlatnosci
                    select new RodzajePlatnosciForAllView
                    {
                        RodzajPlatnosciID = platnosc.rodzajPlatnosciID,
                        NazwaPlatnosci = platnosc.nazwaPlatnosci
                    }
                );
        }

        public override void Sort()
        {
            
        }

        public override List<string> GetComboboxSortList()
        {
            return null;
        }

        public override void Find()
        {
            
        }

        public override List<string> GetComboboxFindList()
        {
            return null;
        }
        #endregion Helpers
    }
}