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
    public class WszystkieListyDoUczniaViewModel : WszystkieViewModel<OcenyUczniaForAllView>
    {
        #region Constructor
        public WszystkieListyDoUczniaViewModel()
            :base()
        {
            base.DisplayName = "Oceny uczniów";
        }
        public override void Load()
        {

            List = new ObservableCollection<OcenyUczniaForAllView>
                (
                    new DataWithForeignKey(lgSdatabase).PobierzListyDoUczniow()
                );
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> {
                "nazwisko"
            };
        }
        public override void Sort()
        {
            if (SortField == "nazwisko")
            {
                List = new ObservableCollection<OcenyUczniaForAllView>(
                    List.OrderBy(item => item.UczenNazwisko)
                );
            }
            //if (SortField == "data")
            //{
            //    List = new ObservableCollection<OcenyUczniaForAllView>(
            //        List.OrderBy(item => item.DataWpisu)
            //    );
            //}
            //if (SortField == "lektor")
            //{
            //    List = new ObservableCollection<OcenyUczniaForAllView>(
            //        List.OrderBy(item => item.PracownikNazwa)
            //    );
            //    //}
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> {
                  "nazwisko"
            };
        }
        public override void Find()
        {
            if (FindField == "nazwisko")
            {
                List = new ObservableCollection<OcenyUczniaForAllView>
                    (
                        List.Where(item => item.UczenNazwisko != null
                        && item.UczenNazwisko.StartsWith(FindTextBox))
                    );
            }
        }
        #endregion Helpers
    }
}
