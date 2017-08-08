using LgSchool.Model.BusinessLogic.Sprzedaz;
using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    public class WszystkieUslugiViewModel : WszystkieViewModel<Usluga>
    {
        #region Constructor
        public WszystkieUslugiViewModel()
            :base()
        {
            base.DisplayName = "Uslugi";
        }
        #endregion Constructor

        #region Helpers
        //to jest metoda która pobiera wszystkie towary z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<Usluga>
                (
                    new UslugaB(lgSdatabase).PobierzWszystkoZUslug()
                );
        }
        public override List<string> GetComboboxSortList()
        {
            return new List<string> {
                "nazwa", "cena", "kod"
            };
        }
        public override void Sort()
        {
            if (SortField == "nazwa")
            {
                List = new ObservableCollection<Usluga>(
                    List.OrderBy(item => item.nazwa)
                );
            }
            if (SortField == "cena")
            {
                List = new ObservableCollection<Usluga>(
                    List.OrderBy(item => item.cena)
                );
            }
            //if (SortField == "kod")
            //{
            //    List = new ObservableCollection<Towary>(
            //        List.OrderBy(item => item.kod)
            //    );
            //}
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> {
                "nazwa"/*, "kod"*/
            };
        }
        public override void Find()
        {
            if (FindField == "nazwa")
            {
                List = new ObservableCollection<Usluga>
                    (
                        List.Where(item => item.nazwa != null
                        && item.nazwa.StartsWith(FindTextBox))
                    );
            }
            //if (FindField == "kod")
            //{
            //    List = new ObservableCollection<Towary>
            //        (
            //            List.Where(item => item.kod != null
            //            && item.kod.StartsWith(FindTextBox))
            //        );
            //}
        }
        #endregion Helpers
    }
}
