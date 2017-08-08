using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
     public class NewGradeListViewModel : NowyViewModel<OcenyUcznia>
    {
        #region Constructor
        public NewGradeListViewModel()
        {
            base.DisplayName = "Dodanie oceny";
            //tworzymy nową
            item = new OcenyUcznia();
        }
        #endregion Constructor
        #region Properties
        public int OcenaID
        {
            get
            {
                return item.ocenaID;
            }
            set
            {
                if (item.ocenaID != value)
                {
                    item.ocenaID = value;
                    OnPropertyChanged(() => OcenaID);
                }
            }
        }
        // properties dla pola z tabeli Uczen
        private string _UczenImie;
        public string UczenImie
        {
            get
            {
                return _UczenImie;
            }
            set
            {
                if (_UczenImie != value)
                {
                    _UczenImie = value;
                    OnPropertyChanged(() => UczenImie);
                }
            }
        }
        private string _UczenNazwisko;
        public string UczenNazwisko
        {
            get
            {
                return _UczenNazwisko;
            }
            set
            {
                if (_UczenNazwisko != value)
                {
                    _UczenNazwisko = value;
                    OnPropertyChanged(() => UczenNazwisko);
                }
            }
        }
        private string _UczenPesel;
        public string UczenPesel
        {
            get
            {
                return _UczenPesel;
            }
            set
            {
                if (_UczenPesel != value)
                {
                    _UczenPesel = value;
                    OnPropertyChanged(() => UczenPesel);
                }
            }
        }
        public int UczenID
        {
            get
            {
                return item.uczenID;
            }
            set
            {
                if (item.uczenID != value)
                {
                    item.uczenID = value;
                    OnPropertyChanged(() => UczenID);
                }
            }
        }
        //to jest properties który dostarcza danych do combobox'a
        //który po rozwinięciu wyświetla wszystkich uczniów - ich imiona,nazwiska i pesele
        public IQueryable<ComboboxKeyAndValue> DodanieUczniaComboboxItems
        {
            get
            {
                return
                    (
                        from uczen in lgSdatabase.Uczen
                        select new ComboboxKeyAndValue
                        {
                            Key = uczen.uczenID,
                            Value = uczen.imie + " " + uczen.nazwisko + " - " + "Pesel: " + uczen.pesel
                        }
                    ).ToList().AsQueryable();
            }
        }
        public override void Save()
        {
            //dodajemy użytkownika do lokalnej kolekcji
            lgSdatabase.OcenyUcznia.Add(item);
            //zapisujemy użytkownika do bazy danych
            lgSdatabase.SaveChanges();

        }
        #endregion Properties
    }
}
