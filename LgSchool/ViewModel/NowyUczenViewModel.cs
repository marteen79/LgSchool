using GalaSoft.MvvmLight.Messaging;
using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using MVVMFirma.Pomocniczy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LgSchool.ViewModel
{
    public class NowyUczenViewModel : JedenWszystkieViewModel<Uczen, OcenyUczniaForAllView>
    {
        #region Constructor
        public NowyUczenViewModel()
        {
            base.DisplayName = "Uczen";
            //tworzymy nowego użytkownika
            item = new Uczen();
            DataUrodzenia = DateTime.Now;
            //Messenger.Default.Register<OcenyForAllView>(this, getWybranaOcena);
            base.DisplayListName = "Lista ocen";

            Messenger.Default.Register<OcenyUcznia>(this, addOcenyUcznia);
        }
        #endregion Constructor
        #region Commands
        //private BaseCommand _ShowOceny;
        //public ICommand ShowOceny
        //{
        //    get
        //    {
        //        if (_ShowOceny == null)
        //        {
        //            // zatem ta komenda wyśle komunikat do MainWindowViewModel
        //            // "Uczniowie Show" żeby MainWindowWievModel pokazało okno 
        //            //ze wszystkimi osobami do wyboru
        //            _ShowOceny = new BaseCommand(() =>
        //            Messenger.Default.Send("Oceny Show"));
        //        }
        //        return _ShowOceny;
        //    }
        //}
        private BaseCommand _ShowAddViewCommand;
        public ICommand ShowAddViewCommand
        {
            get
            {
                if (_ShowAddViewCommand == null)
                {
                    _ShowAddViewCommand =
                        new BaseCommand(() =>
                        Messenger.Default.Send("ListaOcen Show"));
                }
                return _ShowAddViewCommand;
            }
        }
        #endregion Commands
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
        public string TelefonOpiekuna
        {
            get
            {
                return item.telefonOpiekuna;
            }
            set
            {
                if (item.telefonOpiekuna != value)
                {
                    item.telefonOpiekuna = value;
                    OnPropertyChanged(() => TelefonOpiekuna);
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
        private string _OcenaNazwa;
        public string OcenaNazwa
        {
            get
            {
                return _OcenaNazwa;
            }
            set
            {
                if (_OcenaNazwa != value)
                {
                    _OcenaNazwa = value;
                    OnPropertyChanged(() => OcenaNazwa);
                }
            }
        }
        public int? OcenaID
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
        public int? GrupaID
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
        private string _StatusNazwa;
        public string StatusNazwa
        {
            get
            {
                return _StatusNazwa;
            }
            set
            {
                if (_StatusNazwa != value)
                {
                    _StatusNazwa = value;
                    OnPropertyChanged(() => StatusNazwa);
                }
            }
        }
        public int StatusID
        {
            get
            {
                return item.statusID;
            }
            set
            {
                if (item.statusID != value)
                {
                    item.statusID = value;
                    OnPropertyChanged(() => StatusID);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> StatusyComboboxItems
        {
            get
            {
                return
                    (
                        from status in lgSdatabase.Status
                        select new ComboboxKeyAndValue
                        {
                            Key = status.statusID, // tutaj wchodzi ID klucza obcego
                            Value = status.nazwa // tutaj wchodzi wartość
                        }
                    ).ToList().AsQueryable();
            }
        }
        #endregion Properties
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<OcenyUczniaForAllView>
                (
                    from lista in item.OcenyUcznia
                    select new OcenyUczniaForAllView
                    {
                        OcenaNazwa = lista.Ocena.nazwa,
                        OcenaOpis = lista.Ocena.opis,
                        //KategoriaNazwa = lista.KategoriaOcen.nazwa,
                        //DataWpisu = lista.data,
                        //PracownikNazwa = lista.Pracownik.imie + " "+ lista.Pracownik.nazwisko
                    }
                );
        }
        private void addOcenyUcznia(OcenyUcznia listaOcen)
        {
            OcenyUcznia nowa = new OcenyUcznia();
            nowa.ocenaID = listaOcen.ocenaID;
            nowa.Ocena = lgSdatabase.Ocena.Find(listaOcen.ocenaID);
            //nowa.kategoriaID = listaOcen.kategoriaID;
            //nowa.KategoriaOcen = lgSdatabase.KategoriaOcen.Find(listaOcen.kategoriaID);
            
            //nowa.data = listaOcen.data;      
            //nowa.kategoriaID = listaOcen.kategoriaID;
            //nowa.pracownikID = listaOcen.pracownikID; 

            //tak utworzoną pozycję dodajemy do bazy danych
            lgSdatabase.OcenyUcznia.Add(nowa);
            //utworzoną pozycję faktury dodajemy do pozycji aktualnie
            //dodawanej faktury
            item.OcenyUcznia.Add(nowa);
            //na koniec dodajemy utworzoną pozycję do listy wyświetlanej pozycji
            List.Add
               (
                new OcenyUczniaForAllView
                {
                    OcenaID = nowa.ocenaID, // dodałem
                    OcenaNazwa = nowa.Ocena.nazwa,
                    OcenaOpis = nowa.Ocena.opis,
                    //KategoriaNazwa = nowa.KategoriaOcen.nazwa,
                    //DataWpisu = nowa.data,
                    //PracownikNazwa = nowa.Pracownik.imie + " " + nowa.Pracownik.nazwisko
                }
              );
        }
        public override void Save()
        {
            //dodajemy użytkownika do lokalnej kolekcji
            lgSdatabase.Uczen.Add(item);
            //zapisujemy użytkownika do bazy danych
            lgSdatabase.SaveChanges();
        }
        #endregion Helpers
    }
}
