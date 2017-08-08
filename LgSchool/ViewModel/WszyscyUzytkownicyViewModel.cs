using LgSchool.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    public class WszyscyUzytkownicyViewModel : WszystkieViewModel<UzytkownicyForAllView>
    {
        #region Constructor
        public WszyscyUzytkownicyViewModel()
            :base()
        {
            base.DisplayName = "Uzytkownicy";
        }

        public override void Find()
        {
           
        }

        public override List<string> GetComboboxFindList()
        {
            return null;
        }

        public override List<string> GetComboboxSortList()
        {
            return null;
        }
        #endregion Constructor

        #region Helpers
        //to jest metoda która pobiera wszystkie faktury z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<UzytkownicyForAllView>
                (
                    from user in lgSdatabase.Uzytkownik
                    select new UzytkownicyForAllView
                    {
                        UzytkownikID = user.uzytkownikID,
                        Login = user.login,
                        Haslo = user.haslo
                    }
                );
        }

        public override void Sort()
        {
            
        }
        #endregion Helpers
    }
}
