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
    public class WszystkiePoziomyViewModel : WszystkieViewModel<Poziom>
    {
        #region Constructor
        public WszystkiePoziomyViewModel()
            :base()
        {
            base.DisplayName = "Poziomy";
        }

        public override void Load()
        {

            List = new ObservableCollection<Poziom>
                (
                    new DataWithoutForeignKey(lgSdatabase).PobierzPoziomy()
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
                List = new ObservableCollection<Poziom>(
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
                List = new ObservableCollection<Poziom>
                    (
                        List.Where(item => item.nazwa != null
                        && item.nazwa.StartsWith(FindTextBox))
                    );
            }

        }
        #endregion Helpers
    }
}
