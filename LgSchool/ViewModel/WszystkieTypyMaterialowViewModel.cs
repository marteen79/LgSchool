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
    public class WszystkieTypyMaterialowViewModel : WszystkieViewModel<TypyMaterialow>
    {
        #region Constructor
        public WszystkieTypyMaterialowViewModel()
            :base()
        {
            base.DisplayName = "Typy materialow";
        }

        public override void Load()
        {

            List = new ObservableCollection<TypyMaterialow>
                (
                    new DataWithoutForeignKey(lgSdatabase).PobierzTypyMaterialow()
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
                List = new ObservableCollection<TypyMaterialow>(
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
                List = new ObservableCollection<TypyMaterialow>
                    (
                        List.Where(item => item.nazwa != null
                        && item.nazwa.StartsWith(FindTextBox))
                    );
            }
            
        }
        #endregion Helpers
    }
}
