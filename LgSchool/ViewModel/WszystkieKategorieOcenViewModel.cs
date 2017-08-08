using LgSchool.Model.BusinessLogic.Functionality;
using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    public class WszystkieKategorieOcenViewModel : WszystkieViewModel<KategoriaOcen>
    {
        #region Constructor
        public WszystkieKategorieOcenViewModel()
            :base()
        {
            base.DisplayName = "Kategorie ocen";
        }

        public override void Load()
        {

            List = new ObservableCollection<KategoriaOcen>
                (
                    new DataWithoutForeignKey(lgSdatabase).PobierzKategorieOcen()
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
                List = new ObservableCollection<KategoriaOcen>(
                    List.OrderBy(item => item.nazwa)
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
                List = new ObservableCollection<KategoriaOcen>
                    (
                        List.Where(item => item.nazwa != null
                        && item.nazwa.StartsWith(FindTextBox))
                    );
            }

        }
        #endregion Helpers
    }
}
