using GalaSoft.MvvmLight.Messaging;
using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using MVVMFirma.Pomocniczy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LgSchool.ViewModel
{
   public class NowaWplataViewModel : NowyViewModel<Wplata>
    {
        #region Constructor
        public NowaWplataViewModel()
        {
            base.DisplayName = "Wplata";
            //tworzymy nową wplate
            item = new Wplata();
            Messenger.Default.Register<UczniowieForAllView>
                (this, getWybranyUczen);
            DataWplaty = DateTime.Now;
        }
        #endregion Constructor
        #region Properties
        private BaseCommand _ShowUczniowie;
        private string _WplataNumer;
        public string WplataNumer
        {
            get
            {
                return _WplataNumer;
            }
            set
            {
                if (_WplataNumer != value)
                {
                    _WplataNumer = value;
                    OnPropertyChanged(() => WplataNumer);
                }
            }
        }
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
        private string _FirmaNazwa;
        public string FirmaNazwa
        {
            get
            {
                return _FirmaNazwa;
            }
            set
            {
                if (_FirmaNazwa != value)
                {
                    _FirmaNazwa = value;
                    OnPropertyChanged(() => FirmaNazwa);
                }
            }
        }
        public DateTime DataWplaty
        {
            get
            {
                return item.data;
            }
            set
            {
                if (item.data != value)
                {
                    item.data = value;
                    OnPropertyChanged(() => DataWplaty);
                }
            }
        }
        private string _RodzajPlatnosciNazwa;
        public string RodzajPlatnosciNazwa
        {
            get
            {
                return _RodzajPlatnosciNazwa;
            }
            set
            {
                if (_RodzajPlatnosciNazwa != value)
                {
                    _RodzajPlatnosciNazwa = value;
                    OnPropertyChanged(() => RodzajPlatnosciNazwa);
                }
            }
        }
        // properties dla ID kluczy obcych
        public int? FirmaID
        {
            get
            {
                return item.firmaID;
            }
            set
            {
                if (item.firmaID != value)
                {
                    item.firmaID = value;
                    OnPropertyChanged(() => FirmaID);
                }
            }
        }
        public int? UczenID
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
        public int RodzajPlatnosciID
        {
            get
            {
                return item.rodzajPlatnosciID;
            }
            set
            {
                if (item.rodzajPlatnosciID != value)
                {
                    item.rodzajPlatnosciID = value;
                    OnPropertyChanged(() => RodzajPlatnosciID);
                }
            }
        }
        //to jest properties który dostarcza danych do combobox'a
        //który po rozwinięciu wyświetla wszystkie statusy - ich nazwy
        public IQueryable<ComboboxKeyAndValue> FirmyComboboxItems
        {
            get
            {
                return
                    (
                        from firma in lgSdatabase.Firma
                        select new ComboboxKeyAndValue
                        {
                            Key = firma.firmaID, // tutaj wchodzi ID klucza obcego
                            Value = firma.nazwa // tutaj wchodzi wartość
                        }
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<ComboboxKeyAndValue> RodzajePlatnosciComboboxItems
        {
            get
            {
                return
                    (
                        from rodzaj in lgSdatabase.RodzajPlatnosci
                        select new ComboboxKeyAndValue
                        {
                            Key = rodzaj.rodzajPlatnosciID,
                            Value = rodzaj.nazwaPlatnosci
                        }
                    ).ToList().AsQueryable();
            }
        }
        public override void Save()
        {
            //dodajemy użytkownika do lokalnej kolekcji
            lgSdatabase.Wplata.Add(item);
            //zapisujemy użytkownika do bazy danych
            lgSdatabase.SaveChanges();
        }
        private void getWybranyUczen(UczniowieForAllView uczen)
        {
            UczenID = uczen.UczenID;
            UczenImie = uczen.Imie;
            UczenNazwisko = uczen.Nazwisko;
        }
        #endregion Properties
        #region Commands
        public ICommand ShowUczniowie
        {
            get
            {
                if (_ShowUczniowie == null)
                {
                    // zatem ta komenda wyśle komunikat do MainWindowViewModel
                    // "Statusy Show" żeby MainWindowWievModel pokazało okno 
                    //ze wszystkimi statusami do wyboru
                    _ShowUczniowie = new BaseCommand(() =>
                    Messenger.Default.Send("Uczniowie Show"));
                }
                return _ShowUczniowie;
            }
        }
        #endregion Commands
    }
}
