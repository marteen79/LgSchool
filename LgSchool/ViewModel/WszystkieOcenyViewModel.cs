using GalaSoft.MvvmLight.Messaging;
using LgSchool.Model.BusinessLogic.Functionality;
using LgSchool.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    public class WszystkieOcenyViewModel : WszystkieViewModel<OcenyForAllView>
    {
        #region Constructor
        public WszystkieOcenyViewModel()
            :base()
        {
            base.DisplayName = "Oceny";
        }
        #region Properties
        private OcenyForAllView _WybranaOcena;
        public OcenyForAllView WybranaOcena
        {
            get
            {
                return _WybranaOcena;
            }
            set
            {
                if (_WybranaOcena != value)
                {
                    _WybranaOcena = value;
                    //wybrany firme wysyłamy Messengerem do okna faktura
                    Messenger.Default.Send(_WybranaOcena);
                    //po wybraniu kontrahenta zamykamy zakładkę
                    OnRequestClose();
                }
            }
        }
        #endregion Properties
        public override void Load()
        {

            List = new ObservableCollection<OcenyForAllView>
                (
                    new DataWithForeignKey(lgSdatabase).PobierzOceny()
                );

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
                List = new ObservableCollection<OcenyForAllView>(
                    List.OrderBy(item => item.Nazwa)
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
                List = new ObservableCollection<OcenyForAllView>
                    (
                        List.Where(item => item.Nazwa != null
                        && item.Nazwa.StartsWith(FindTextBox))
                    );
            }
        }
        #endregion Helpers
    }
}
