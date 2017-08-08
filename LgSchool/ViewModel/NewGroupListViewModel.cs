using GalaSoft.MvvmLight.Messaging;
using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    public class NewGroupListViewModel : NowyViewModel<ListaDoGrup>
    {
        #region Constructor
        public NewGroupListViewModel()
        {
            base.DisplayName = "Dodanie ucznia";
            //tworzymy nową
            item = new ListaDoGrup();
        }
        #endregion Constructor
        #region Properties
        public int GrupaID
        {
            get
            {
                return item.grupaID;
            }
            set
            {
                if (item.grupaID != value)
                {
                    item.grupaID = value;
                    OnPropertyChanged(() => GrupaID);
                }
            }
        }
        private string _GrupaNumer;
        public string GrupaNumer
        {
            get
            {
                return _GrupaNumer;
            }
            set
            {
                if (_GrupaNumer != value)
                {
                    _GrupaNumer = value;
                    OnPropertyChanged(() => GrupaNumer);
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
                            Value = uczen.imie + " " + uczen.nazwisko + " - " + "Pesel: "+ uczen.pesel
                        }
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<ComboboxKeyAndValue> NumeryGrupComboboxItems
        {
            get
            {
                return
                    (
                        from grupa in lgSdatabase.Grupa
                        select new ComboboxKeyAndValue
                        {
                            Key = grupa.grupaID,
                            Value = grupa.grupaNumer
                        }
                    ).ToList().AsQueryable();
            }
        }
        public override void Save()
        {
            //dodajemy użytkownika do lokalnej kolekcji
            lgSdatabase.ListaDoGrup.Add(item);
            //zapisujemy użytkownika do bazy danych
            lgSdatabase.SaveChanges();
            
        }
        #endregion Properties
    }
}
