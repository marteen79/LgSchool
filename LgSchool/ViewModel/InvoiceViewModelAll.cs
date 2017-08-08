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
   public class InvoiceViewModelAll : WszystkieViewModel<Faktura>
    {
        #region Constructor
        public InvoiceViewModelAll()
            :base()
        {
            base.DisplayName = "Faktury";
        }

        public override void Find()
        {
            if (FindField == "numer")
            {
                List = new ObservableCollection<Faktura>
                    (
                        List.Where(item => item.numerFaktury != null
                        && item.numerFaktury.StartsWith(FindTextBox))
                    );
            }
            if (FindField == "rodzaj płatności")
            {
                List = new ObservableCollection<Faktura>
                    (
                        List.Where(item => item.RodzajPlatnosci.nazwaPlatnosci != null
                        && item.RodzajPlatnosci.nazwaPlatnosci.StartsWith(FindTextBox))
                    );
            }
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> {
                "rodzaj płatności", "numer faktury"
            };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> {
                "rodzaj płatności", "numer faktury"
            };
        }
        #endregion Constructor

        #region Helpers
        //to jest metoda która pobiera wszystkie faktury z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<Faktura>
                (
                    from faktura in lgSdatabase.Faktura
                    select faktura
                );
        }

        public override void Sort()
        {
            if (SortField == "rodzaj płatności")
            {
                List = new ObservableCollection<Faktura>(
                    List.OrderBy(item => item.rodzajPlatnosciID)
                );
            }
            if (SortField == "numer faktury")
            {
                List = new ObservableCollection<Faktura>(
                    List.OrderBy(item => item.numerFaktury)
                );
            }
        }
        #endregion Helpers
    }
}
