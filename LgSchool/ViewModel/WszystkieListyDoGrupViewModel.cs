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
    public class WszystkieListyDoGrupViewModel : WszystkieViewModel<ListaDoGrupyForAllView>
    {
        #region Constructor
        public WszystkieListyDoGrupViewModel()
            :base()
        {
            base.DisplayName = "Listy do grup";
        }
        public override void Load()
        {

            List = new ObservableCollection<ListaDoGrupyForAllView>
                (
                    new DataWithForeignKey(lgSdatabase).PobierzListyDoGrup()
                );

        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> {
                "nazwisko","numer grupy"
            };
        }
        public override void Sort()
        {
            if (SortField == "nazwisko")
            {
                List = new ObservableCollection<ListaDoGrupyForAllView>(
                    List.OrderBy(item => item.UczenNazwisko)
                );
            }
            if (SortField == "numer grupy")
            {
                List = new ObservableCollection<ListaDoGrupyForAllView>(
                    List.OrderBy(item => item.GrupaNumer)
                );
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> {
                   "nazwisko","numer grupy"
            };
        }
        public override void Find()
        {
            if (FindField == "nazwisko")
            {
                List = new ObservableCollection<ListaDoGrupyForAllView>
                    (
                        List.Where(item => item.UczenNazwisko != null
                        && item.UczenNazwisko.StartsWith(FindTextBox))
                    );
            }
            if (FindField == "numer grupy")
            {
                List = new ObservableCollection<ListaDoGrupyForAllView>
                    (
                        List.Where(item => item.GrupaNumer != null
                        && item.GrupaNumer.StartsWith(FindTextBox))
                    );
            }
        }
        #endregion Helpers
    }
}
