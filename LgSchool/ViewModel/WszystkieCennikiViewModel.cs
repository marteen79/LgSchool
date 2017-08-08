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
    class WszystkieCennikiViewModel : WszystkieViewModel<CennikiForAllView>
    {
        #region Constructor
        public WszystkieCennikiViewModel()
            :base()
        {
            base.DisplayName = "Cenniki";
        }
        #endregion Constructor
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<CennikiForAllView>
                (
                    new DataWithForeignKey(lgSdatabase).PobierzCennik()
                );

        }
        public override List<string> GetComboboxSortList()
        {
            return new List<string> {
                "nazwa kursu","cena"
            };
        }
        public override void Sort()
        {
            if (SortField == "nazwa kursu")
            {
                List = new ObservableCollection<CennikiForAllView>(
                    List.OrderBy(item => item.KursNazwa)
                );
            }
            if (SortField == "cena")
            {
                List = new ObservableCollection<CennikiForAllView>(
                    List.OrderBy(item => item.Cena)
                );
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> {
                  "nazwa kursu"
            };
        }
        public override void Find()
        {
            if (FindField == "nazwa kursu")
            {
                List = new ObservableCollection<CennikiForAllView>
                    (
                        List.Where(item => item.KursNazwa != null
                        && item.KursNazwa.StartsWith(FindTextBox))
                    );
            }
        }
    #endregion Helpers
    }
}
