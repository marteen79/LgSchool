using LgSchool.Model.BusinessLogic.Functionality;
using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LgSchool.ViewModel
{
    public class WszystkieMaterialyViewModel : WszystkieViewModel<MaterialyForAllView>
    {
        #region Constructor
        public WszystkieMaterialyViewModel()
            :base()
        {
            base.DisplayName = "Materialy";
        }
        #endregion Constructor


        #region Helpers
        public override void Load()
        {
            {
                List = new ObservableCollection<MaterialyForAllView>
                    (
                       new DataWithForeignKey(lgSdatabase).PobierzMaterialy()
                    );
            }
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> {
                "tytul", "gatunek", "poziom"
            };
        }
        public override void Sort()
        {
            if (SortField == "tytul")
            {
                List = new ObservableCollection<MaterialyForAllView>(
                    List.OrderBy(item => item.Tytul)
                );
            }
            if (SortField == "gatunek")
            {
                List = new ObservableCollection<MaterialyForAllView>(
                    List.OrderBy(item => item.GatunekNazwa)
                );
            }
            if (SortField == "poziom")
            {
                List = new ObservableCollection<MaterialyForAllView>(
                    List.OrderBy(item => item.PoziomNazwa)
                );
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> {
                "poziom", "gatunek"
            };
        }
        public override void Find()
        {
            if (FindField == "poziom")
            {
                List = new ObservableCollection<MaterialyForAllView>
                    (
                        List.Where(item => item.PoziomNazwa != null
                        && item.PoziomNazwa.StartsWith(FindTextBox))
                    );
            }
            if (FindField == "gatunek")
            {
                List = new ObservableCollection<MaterialyForAllView>
                    (
                        List.Where(item => item.GatunekNazwa != null
                        && item.GatunekNazwa.StartsWith(FindTextBox))
                    );
            }
        }
        #endregion Helpers
    }
}
