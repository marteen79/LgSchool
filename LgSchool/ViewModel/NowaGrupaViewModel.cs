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
   public class NowaGrupaViewModel : JedenWszystkieViewModel<Grupa,ListaDoGrupyForAllView>
    {
        #region Constructor
        public NowaGrupaViewModel()
        {
            base.DisplayName = "Nowa grupa";
            //tworzymy nowa grupa
            item = new Grupa();
            //Messenger.Default.Register<UczniowieForAllView>(this, getWybranyUczen);
            base.DisplayListName = "Lista grupy";
            
            Messenger.Default.Register<ListaDoGrup>(this, addListaDoGrup);
        }
        #endregion Constructor
        #region Commands
        //private BaseCommand _ShowUczniowie;
        //public ICommand ShowUczniowie
        //{
        //    get
        //    {
        //        if (_ShowUczniowie == null)
        //        {
        //            // zatem ta komenda wyśle komunikat do MainWindowViewModel
        //            // "Uczniowie Show" żeby MainWindowWievModel pokazało okno 
        //            //ze wszystkimi osobami do wyboru
        //            _ShowUczniowie = new BaseCommand(() =>
        //            Messenger.Default.Send("Uczniowie Show"));
        //        }
        //        return _ShowUczniowie;
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
                        Messenger.Default.Send("ListaGrupy Show"));
                }
                return _ShowAddViewCommand;
            }
        }
        #endregion Commands
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
        public string Numer
        {
            get
            {
                return item.grupaNumer;
            }
            set
            {
                if (item.grupaNumer != value)
                {
                    item.grupaNumer = value;
                    OnPropertyChanged(() => Numer);
                }
            }
        }
        public string Nazwa
        {
            get
            {
                return item.nazwa;
            }
            set
            {
                if (item.nazwa != value)
                {
                    item.nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public string Opis
        {
            get
            {
                return item.opis;
            }
            set
            {
                if (item.opis != value)
                {
                    item.opis = value;
                    OnPropertyChanged(() => Opis);
                }
            }
        }
        // properties dla pola z tabeli Status
        private string _PoziomNazwa;
        public string PoziomNazwa
        {
            get
            {
                return _PoziomNazwa;
            }
            set
            {
                if (_PoziomNazwa != value)
                {
                    _PoziomNazwa = value;
                    OnPropertyChanged(() => PoziomNazwa);
                }
            }
        }
        private string _UczenNazwa;
        public string UczenNazwa
        {
            get
            {
                return _UczenNazwa;
            }
            set
            {
                if (_UczenNazwa != value)
                {
                    _UczenNazwa = value;
                    OnPropertyChanged(() => UczenNazwa);
                }
            }
        }
        private string _KursNazwa;
        public string KursNazwa
        {
            get
            {
                return _KursNazwa;
            }
            set
            {
                if (_KursNazwa != value)
                {
                    _KursNazwa = value;
                    OnPropertyChanged(() => KursNazwa);
                }
            }
        }
        public int PoziomID
        {
            get
            {
                return item.poziomID;
            }
            set
            {
                if (item.poziomID != value)
                {
                    item.poziomID = value;
                    OnPropertyChanged(() => PoziomID);
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
        public int KursID
        {
            get
            {
                return item.kursID;
            }
            set
            {
                if (item.kursID != value)
                {
                    item.kursID = value;
                    OnPropertyChanged(() => KursID);
                }
            }
        }
        //to jest properties który dostarcza danych do combobox'a
        //który po rozwinięciu wyświetla wszystkie statusy - ich nazwy
        
        public IQueryable<ComboboxKeyAndValue> PoziomyComboboxItems
        {
            get
            {
                return
                    (
                        from poziom in lgSdatabase.Poziom
                        select new ComboboxKeyAndValue
                        {
                            Key = poziom.poziomID,
                            Value = poziom.nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }     
        public IQueryable<ComboboxKeyAndValue> KursyComboboxItems
        {
            get
            {
                return
                    (
                        from kurs in lgSdatabase.Kurs
                        select new ComboboxKeyAndValue
                        {
                            Key = kurs.kursID,
                            Value = kurs.nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }
        #endregion Properties

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ListaDoGrupyForAllView>
                (
                    from lista in item.ListaDoGrup
                    select new ListaDoGrupyForAllView
                    {
                        UczenImie = lista.Uczen.imie,
                        UczenNazwisko = lista.Uczen.nazwisko,
                        UczenPesel = lista.Uczen.pesel
                    }
                );
        }
        private void addListaDoGrup(ListaDoGrup listaDoGrup)
        {
            ListaDoGrup nowa = new ListaDoGrup();
            nowa.uczenID = listaDoGrup.uczenID;
            nowa.Uczen = lgSdatabase.Uczen.Find(listaDoGrup.uczenID);
            //tak utworzoną pozycję dodajemy do bazy danych
            lgSdatabase.ListaDoGrup.Add(nowa);
            //utworzoną pozycję faktury dodajemy do pozycji aktualnie dodawanej faktury
            item.ListaDoGrup.Add(nowa);
            //na koniec dodajemy utworzoną pozycję do listy wyświetlanej pozycji
            List.Add
               (
                new ListaDoGrupyForAllView
                {
                    UczenImie = nowa.Uczen.imie,
                    UczenNazwisko = nowa.Uczen.nazwisko,
                    UczenPesel = nowa.Uczen.pesel
                }
              );
        }
        
        public override void Save()
        {
            //dodajemy użytkownika do lokalnej kolekcji
            lgSdatabase.Grupa.Add(item);
            //zapisujemy użytkownika do bazy danych
            lgSdatabase.SaveChanges();
        }
        #endregion Helpers
    }
}
