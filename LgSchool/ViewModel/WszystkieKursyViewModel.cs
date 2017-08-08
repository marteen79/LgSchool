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
    public class WszystkieKursyViewModel : WszystkieViewModel<KursyForAllView>
    {
        #region Constructor
        public WszystkieKursyViewModel()
            :base()
        {
            base.DisplayName = "Kursy";
        }

        public override void Load()
        {

            List = new ObservableCollection<KursyForAllView>
                (
                    new DataWithForeignKey(lgSdatabase).PobierzKursy()
                );

        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> {
                "nazwa","poziom","lektor"
            };
        }
        public override void Sort()
        {
            if (SortField == "nazwa")
            {
                List = new ObservableCollection<KursyForAllView>(
                    List.OrderBy(item => item.Nazwa)
                );
            }
            if (SortField == "poziom")
            {
                List = new ObservableCollection<KursyForAllView>(
                    List.OrderBy(item => item.PoziomNazwa)
                );
            }
            if (SortField == "lektor")
            {
                List = new ObservableCollection<KursyForAllView>(
                    List.OrderBy(item => item.PracownikNazwa)
                );
            }

        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> {
                  "nazwa","poziom","lektor"
            };
        }
        public override void Find()
        {
            if (FindField == "nazwa")
            {
                List = new ObservableCollection<KursyForAllView>
                    (
                        List.Where(item => item.Nazwa != null
                        && item.Nazwa.StartsWith(FindTextBox))
                    );
            }
            if (FindField == "poziom")
            {
                List = new ObservableCollection<KursyForAllView>
                    (
                        List.Where(item => item.PoziomNazwa != null
                        && item.PoziomNazwa.StartsWith(FindTextBox))
                    );
            }
            if (FindField == "lektor")
            {
                List = new ObservableCollection<KursyForAllView>
                    (
                        List.Where(item => item.PracownikNazwa != null
                        && item.PracownikNazwa.StartsWith(FindTextBox))
                    );
            }
        }
        #endregion Helpers
    }
}
