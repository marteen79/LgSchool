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
   public class WszystkieGrupyViewModel : WszystkieViewModel<GrupyForAllView>
    {
        #region Constructor
        public WszystkieGrupyViewModel()
            :base()
        {
            base.DisplayName = "Grupy";
        }
        public override void Load()
        {

            List = new ObservableCollection<GrupyForAllView>
                (
                    new DataWithForeignKey(lgSdatabase).PobierzGrupy()
                );

        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> {
                "nazwa","poziom","nazwisko"
            };
        }
        public override void Sort()
        {
            if (SortField == "nazwa")
            {
                List = new ObservableCollection<GrupyForAllView>(
                    List.OrderBy(item => item.Nazwa)
                );
            }
            if (SortField == "poziom")
            {
                List = new ObservableCollection<GrupyForAllView>(
                    List.OrderBy(item => item.PoziomNazwa)
                );
            }
            if (SortField == "nazwisko")
            {
                List = new ObservableCollection<GrupyForAllView>(
                    List.OrderBy(item => item.UczenNazwa)
                );
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> {
                  "nazwa","poziom","numer"
            };
        }
        public override void Find()
        {
            if (FindField == "nazwa")
            {
                List = new ObservableCollection<GrupyForAllView>
                    (
                        List.Where(item => item.Nazwa != null
                        && item.Nazwa.StartsWith(FindTextBox))
                    );
            }
            if (FindField == "poziom")
            {
                List = new ObservableCollection<GrupyForAllView>
                    (
                        List.Where(item => item.PoziomNazwa != null
                        && item.PoziomNazwa.StartsWith(FindTextBox))
                    );
            }
            if (FindField == "numer")
            {
                List = new ObservableCollection<GrupyForAllView>
                    (
                        List.Where(item => item.Numer != null
                        && item.Numer.StartsWith(FindTextBox))
                    );
            }
        }
        #endregion Helpers
    }
}
