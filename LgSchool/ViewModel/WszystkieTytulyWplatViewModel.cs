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
    public class WszystkieTytulyWplatViewModel : WszystkieViewModel<TytulyWplatForAllView>
    {
        #region Constructor
        public WszystkieTytulyWplatViewModel()
            :base()
        {
            base.DisplayName = "Tytuly wplat";
        }
        #endregion Contructor
        #region Helpers
        public override void Load()
        {

            List = new ObservableCollection<TytulyWplatForAllView>
                (
                    new DataWithForeignKey(lgSdatabase).PobierzTytulyWplat()
                );

        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> {
                "nazwa kursu","liczba godzin"
            };
        }
        public override void Sort()
        {
            if (SortField == "nazwa kursu")
            {
                List = new ObservableCollection<TytulyWplatForAllView>(
                    List.OrderBy(item => item.KursNazwa)
                );
            }
            if (SortField == "liczba godzin")
            {
                List = new ObservableCollection<TytulyWplatForAllView>(
                    List.OrderBy(item => item.IloscGodzin)
                );
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> {
                  "nazwa kursu","numer wplaty"
            };
        }
        public override void Find()
        {
            if (FindField == "nazwa kursu")
            {
                List = new ObservableCollection<TytulyWplatForAllView>
                    (
                        List.Where(item => item.KursNazwa != null
                        && item.KursNazwa.StartsWith(FindTextBox))
                    );
            }
            if (FindField == "numer wplaty")
            {
                List = new ObservableCollection<TytulyWplatForAllView>
                    (
                        List.Where(item => item.WplataNumer != null
                        && item.WplataNumer.StartsWith(FindTextBox))
                    );
            }
        }
        #endregion Helpers
    }
}
