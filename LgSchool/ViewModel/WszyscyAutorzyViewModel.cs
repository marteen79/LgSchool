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
    public class WszyscyAutorzyViewModel : WszystkieViewModel<Autor>
    {
        #region Constructor
        public WszyscyAutorzyViewModel()
            : base()
        {
            base.DisplayName = "Autorzy";
        }

        public override void Load()
        {

            List = new ObservableCollection<Autor>
                (
                    new DataWithoutForeignKey(lgSdatabase).PobierzAutorow()
                );

        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> {
                "kraj", "imie", "nazwisko"
            };
        }
        public override void Sort()
        {
            if (SortField == "kraj")
            {
                List = new ObservableCollection<Autor>(
                    List.OrderBy(item => item.kraj)
                );
            }
            if (SortField == "imie")
            {
                List = new ObservableCollection<Autor>(
                    List.OrderBy(item => item.imie)
                );
            }
            if (SortField == "nazwisko")
            {
                List = new ObservableCollection<Autor>(
                    List.OrderBy(item => item.nazwisko)
                );
            }
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> {
                "nazwisko", "kraj"
            };
        }
        public override void Find()
        {
            if (FindField == "nazwisko")
            {
                List = new ObservableCollection<Autor>
                    (
                        List.Where(item => item.nazwisko != null
                        && item.nazwisko.StartsWith(FindTextBox))
                    );
            }
            if (FindField == "kraj")
            {
                List = new ObservableCollection<Autor>
                    (
                        List.Where(item => item.kraj != null
                        && item.kraj.StartsWith(FindTextBox))
                    );
            }
        }
        #endregion Helpers
    }
}