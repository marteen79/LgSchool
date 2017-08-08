using LgSchool.Model.Entities;

namespace LgSchool.ViewModel
{
    public class NowyUzytkownikViewModel : NowyViewModel<Uzytkownik>
    {
        #region Constructor
        public NowyUzytkownikViewModel()
        {
            base.DisplayName = "Uzytkownik";
            //tworzymy nowego użytkownika
            item = new Uzytkownik();
        }
        #endregion Constructor
        #region Properties
        public string Login
        {
            get
            {
                return item.login;
            }
            set
            {
                if (item.login != value)
                {
                    item.login = value;
                    OnPropertyChanged(() => Login);
                }
            }
        }
        public string Haslo
        {
            get
            {
                return item.haslo;
            }
            set
            {
                if (item.haslo != value)
                {
                    item.haslo = value;
                    OnPropertyChanged(() => Haslo);
                }
            }
        }
        //to jest properties który dostarcza danych do combobox'a
        //który po rozwinięciu wyświetla wszystkie statusy - ich nazwy
        public override void Save()
        {
            //dodajemy użytkownika do lokalnej kolekcji
            lgSdatabase.Uzytkownik.Add(item);
            //zapisujemy użytkownika do bazy danych
            lgSdatabase.SaveChanges();
        }
        #endregion Properties
    }
}
