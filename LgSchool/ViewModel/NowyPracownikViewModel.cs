using GalaSoft.MvvmLight.Messaging;
using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using LgSchool.Model.Validators;
using MVVMFirma.Pomocniczy;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace LgSchool.ViewModel
{
    public class NowyPracownikViewModel : NowyViewModel<Pracownik>, IDataErrorInfo
    {
        #region Constructor
        public NowyPracownikViewModel()
        {
            base.DisplayName = "Pracownik";
            //tworzymy nowego użytkownika
            item = new Pracownik();
            DataUrodzenia = DateTime.Now;
            DataZatrudnienia = DateTime.Now;
            //DataZwolnienia = DateTime.Now;
        }
        #endregion Constructor
        #region Properties
        public string Imie
        {
            get
            {
                return item.imie;
            }
            set
            {
                if (item.imie != value)
                {
                    item.imie = value;
                    OnPropertyChanged(() => Imie);
                }
            }
        }
        public string Nazwisko
        {
            get
            {
                return item.nazwisko;
            }
            set
            {
                if (item.nazwisko != value)
                {
                    item.nazwisko = value;
                    OnPropertyChanged(() => Nazwisko);
                }
            }
        }
        public DateTime DataUrodzenia
        {
            get
            {
                return item.dataUrodzenia;
            }
            set
            {
                if (item.dataUrodzenia != value)
                {
                    item.dataUrodzenia = value;
                    OnPropertyChanged(() => DataUrodzenia);
                }
            }
        }
        public string Pesel
        {
            get
            {
                return item.pesel;
            }
            set
            {
                if (item.pesel != value)
                {
                    item.pesel = value;
                    OnPropertyChanged(() => Pesel);
                }
            }
        }
        public string Ulica
        {
            get
            {
                return item.ulica;
            }
            set
            {
                if (item.ulica != value)
                {
                    item.ulica = value;
                    OnPropertyChanged(() => Ulica);
                }
            }
        }
        public string Numer
        {
            get
            {
                return item.numer;
            }
            set
            {
                if (item.numer != value)
                {
                    item.numer = value;
                    OnPropertyChanged(() => Numer);
                }
            }
        }
        public string KodPocztowy
        {
            get
            {
                return item.kodPocztowy;
            }
            set
            {
                if (item.kodPocztowy != value)
                {
                    item.kodPocztowy = value;
                    OnPropertyChanged(() => KodPocztowy);
                }
            }
        }
        public string Miejscowosc
        {
            get
            {
                return item.miejscowosc;
            }
            set
            {
                if (item.miejscowosc != value)
                {
                    item.miejscowosc = value;
                    OnPropertyChanged(() => Miejscowosc);
                }
            }
        }
        public string Telefon
        {
            get
            {
                return item.telefon;
            }
            set
            {
                if (item.telefon != value)
                {
                    item.telefon = value;
                    OnPropertyChanged(() => Telefon);
                }
            }
        }
        public string Email
        {
            get
            {
                return item.email;
            }
            set
            {
                if (item.email != value)
                {
                    item.email = value;
                    OnPropertyChanged(() => Email);
                }
            }
        }
        private string _StanowiskoNazwa;
        public string StanowiskoNazwa
        {
            get
            {
                return _StanowiskoNazwa;
            }
            set
            {
                if (_StanowiskoNazwa != value)
                {
                    _StanowiskoNazwa = value;
                    OnPropertyChanged(() => StanowiskoNazwa);
                }
            }
        }
        public int StanowiskoID
        {
            get
            {
                return item.stanowiskoID;
            }
            set
            {
                if (item.stanowiskoID != value)
                {
                    item.stanowiskoID = value;
                    OnPropertyChanged(() => StanowiskoID);
                }
            }
        }
        public DateTime DataZatrudnienia
        {
            get
            {
                return item.dataZatrudnienia;
            }
            set
            {
                if (item.dataZatrudnienia != value)
                {
                    item.dataZatrudnienia = value;
                    OnPropertyChanged(() => DataZatrudnienia);
                }
            }
        }
        public DateTime? DataZwolnienia
        {
            get
            {
                return item.dataZwolnienia;
            }
            set
            {
                if (item.dataZwolnienia != value)
                {
                    item.dataZwolnienia = value;
                    OnPropertyChanged(() => DataZwolnienia);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> StanowiskaComboboxItems
        {
            get
            {
                return
                    (
                        from stanowisko in lgSdatabase.Stanowisko
                        select new ComboboxKeyAndValue
                        {
                            Key = stanowisko.stanowiskoID, // tutaj wchodzi ID klucza obcego
                            Value = stanowisko.nazwaStanowiska // tutaj wchodzi wartość
                        }
                    ).ToList().AsQueryable();
            }
        }
        public override void Save()
        {
            //dodajemy pracownika do lokalnej kolekcji
            lgSdatabase.Pracownik.Add(item);
            //zapisujemy pracownika do bazy danych
            lgSdatabase.SaveChanges();
        }
        #endregion Properties
        #region Commands
        #endregion Commands
        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }

        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                return null;
            }
        }

        public string this[string name]
        {
            get
            {
                string komunikat = null;

                if (name == "DataZatrudnienia")
                {
                    komunikat = BirthdateValidator.SprawdzDateUrodzenia(this.DataZatrudnienia);
                }

                //if (name == "DataOd" && name2 == "DataDo")
                //{
                //    komunikat = DateValidator.SprawdzDate(this.DataZatrudnienia, this.DataZwolnienia);
                //}
              
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["DataZatrudnienia"] == null)
                return true;
            return false;
        }
        #endregion //Validation
    }
}
