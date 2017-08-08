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
   public class WszystkieWplatyViewModel : WszystkieViewModel<WplatyForAllView>
    {
        #region Constructor
        public WszystkieWplatyViewModel()
            :base()
        {
            base.DisplayName = "Wplaty";
        }
        #endregion Constructor

        #region Helpers
        //to jest metoda która pobiera wszystkie wplaty z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<WplatyForAllView>
                 (
                     new DataWithForeignKey(lgSdatabase).PobierzWplaty()
                 );
        }
        public override List<string> GetComboboxSortList()
        {
            return new List<string> {
                "nazwisko","nazwa firmy","data wpłaty"
            };
        }
        public override void Sort()
        {
            if (SortField == "nazwisko")
            {
                List = new ObservableCollection<WplatyForAllView>(
                    List.OrderBy(item => item.UczenNazwisko)
                );
            }
            if (SortField == "nazwa firmy")
            {
                List = new ObservableCollection<WplatyForAllView>(
                    List.OrderBy(item => item.FirmaNazwa)
                );
            }
            if (SortField == "data wpłaty")
            {
                List = new ObservableCollection<WplatyForAllView>(
                    List.OrderBy(item => item.DataWplaty)
                );
            }

        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> {
                   "nazwisko","nazwa firmy"
            };
        }
        public override void Find()
        {
            if (FindField == "nazwisko")
            {
                List = new ObservableCollection<WplatyForAllView>
                    (
                        List.Where(item => item.UczenNazwisko != null
                        && item.UczenNazwisko.StartsWith(FindTextBox))
                    );
            }
            if (FindField == "nazwa firmy")
            {
                List = new ObservableCollection<WplatyForAllView>
                    (
                        List.Where(item => item.FirmaNazwa != null
                        && item.FirmaNazwa.StartsWith(FindTextBox))
                    );
            }
    #endregion Helpers
        }
    }
}