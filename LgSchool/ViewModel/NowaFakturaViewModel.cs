using GalaSoft.MvvmLight.Messaging;
using LgSchool.Model.BusinessLogic.Sprzedaz;
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
    public class NowaFakturaViewModel : JedenWszystkieViewModel<Faktura, PozycjeFakturyForAllView>
    {
        #region Constructor
        public NowaFakturaViewModel()
        {
            base.DisplayName = "Faktura";
            base.DisplayListName = "Pozycje Faktury";
            //DataWystawienia = DateTime.Today;
            //TerminPlatnosci = DateTime.Today;
            //DataWplaty = DateTime.Today;
            //tworzymy nowa faktura
            item = new Faktura();
            //Messenger.Default.Register<FirmyForAllView>(this, getWybranaFirma);
            Messenger.Default.Register<PozycjeFaktury>(this, addPozycjeFaktury);
            WartoscNetto = 0;
            WartoscBrutto = 0;
            Zaplacono = 0;
            Pozostaje = 0;
        }
        #endregion Constructor
        #region Command
        private BaseCommand _ShowAddViewCommand;
        public ICommand ShowAddViewCommand
        {
            get
            {
                if (_ShowAddViewCommand == null)
                {
                    _ShowAddViewCommand =
                        new BaseCommand(() =>
                        Messenger.Default.Send("PozycjeFaktury Show"));
                }
                return _ShowAddViewCommand;
            }
        }
        #endregion Command
        #region Properties
        public string NumerFaktury
        {
            get
            {
                return item.numerFaktury;
            }
            set
            {
                if (item.numerFaktury != value)
                {
                    item.numerFaktury = value;
                    OnPropertyChanged(() => NumerFaktury);
                }
            }
        }
        public int FirmaID
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
                    WartoscRabatu = new SprzedazB(lgSdatabase).OkreslRabat(FirmaID);
                }
            }
        }
        //to jest properties który dostarcza danych do combobox'a
        //który po rozwinięciu wyświetla wszystkie firmy - ich nazwy i nr NIP
        public IQueryable<ComboboxKeyAndValue> FirmyComboboxItems
        {
            get
            {
                return
                    (
                        from firma in lgSdatabase.Firma
                        select new ComboboxKeyAndValue
                        {
                            Key = firma.firmaID,
                            Value = firma.nazwa + " " + firma.nip
                        }
                    ).ToList().AsQueryable();
            }
        }
        public DateTime DataWystawienia
        {
            get
            {
                return item.dataWystawienia;
            }
            set
            {
                if (item.dataWystawienia != value)
                {
                    item.dataWystawienia = value;
                    OnPropertyChanged(() => DataWystawienia);
                }
            }
        }
        public DateTime TerminPlatnosci
        {
            get
            {
                return item.terminPlatnosci;
            }
            set
            {
                if (item.terminPlatnosci != value)
                {
                    item.terminPlatnosci = value;
                    OnPropertyChanged(() => TerminPlatnosci);
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
        public DateTime DataWplaty
        {
            get
            {
                return item.dataWplaty;
            }
            set
            {
                if (item.dataWplaty != value)
                {
                    item.dataWplaty = value;
                    OnPropertyChanged(() => DataWplaty);
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
        private decimal? _WartoscNetto;
        public decimal? WartoscNetto
        {
            get
            {
                return _WartoscNetto;
            }
            set
            {
                if (_WartoscNetto != value)
                {
                    _WartoscNetto = value;
                    OnPropertyChanged(() => WartoscNetto);
                }
            }
        }
        private decimal? _WartoscBrutto;
        public decimal? WartoscBrutto
        {
            get
            {
                return _WartoscBrutto;
            }
            set
            {
                if (_WartoscBrutto != value)
                {
                    _WartoscBrutto = value;
                    OnPropertyChanged(() => WartoscBrutto);
                    Pozostaje = new FakturaB(lgSdatabase).ObliczPozostaje(WartoscBrutto, Zaplacono);
                    OnPropertyChanged(() => Pozostaje);
                }
            }
        }
        private decimal? _Zaplacono;
        public decimal? Zaplacono
        {
            get
            {
                return _Zaplacono;
            }
            set
            {
                if (_Zaplacono != value)
                {
                    _Zaplacono = value;
                    OnPropertyChanged(() => Zaplacono);

                    Pozostaje = new FakturaB(lgSdatabase).ObliczPozostaje(WartoscBrutto, Zaplacono);
                    OnPropertyChanged(() => Pozostaje);
                }
            }
        }
        private decimal? _Pozostaje;
        public decimal? Pozostaje
        {
            get
            {
                return _Pozostaje;
            }
            set
            {
                if (_Pozostaje != value)
                {
                    _Pozostaje = value;
                    OnPropertyChanged(() => Pozostaje);
                }
            }
        }
        private int? _WartoscRabatu;
        public int? WartoscRabatu
        {
            get
            {
                return _WartoscRabatu;
            }
            set
            {
                if (_WartoscRabatu != value)
                {
                    _WartoscRabatu = value;
                    OnPropertyChanged(() => WartoscRabatu);
                }
            }
        }
        public override void Load()
        {
            List = new ObservableCollection<PozycjeFakturyForAllView>
                (
                    from pozycja in item.PozycjeFaktury
                    select new PozycjeFakturyForAllView
                    {
                        UslugaNazwa = pozycja.Usluga.nazwa,
                        Cena = pozycja.Usluga.cena,
                        Ilosc = pozycja.ilosc,
                        Rabat = pozycja.rabat
                    }
                );
        }
        private void addPozycjeFaktury(PozycjeFaktury pozycjaFaktury)
        {
            //Ponieważ pozycja faktury, która przyjdzie messengerem z innego okna
            //jest z innego entitiesa, musimy utworzyć nową pozycję
            //taką samą jak poprzednia
            PozycjeFaktury nowa = new PozycjeFaktury();
            nowa.uslugaID = pozycjaFaktury.uslugaID;
            nowa.Usluga = lgSdatabase.Usluga.Find(pozycjaFaktury.uslugaID);
            nowa.ilosc = pozycjaFaktury.ilosc;
            nowa.rabat = pozycjaFaktury.rabat;
            nowa.cena = pozycjaFaktury.cena;
            //tak utworzoną pozycję dodajemy do bazy danych
            lgSdatabase.PozycjeFaktury.Add(nowa);
            //utworzoną pozycję faktury dodajemy do pozycji aktualnie
            //dodawanej faktury
            item.PozycjeFaktury.Add(nowa);
            //na koniec dodajemy utworzoną pozycję do listy wyświetlanej pozycji
            List.Add
               (
                new PozycjeFakturyForAllView
                {
                    UslugaNazwa = nowa.Usluga.nazwa,
                    Cena = nowa.cena,
                    Ilosc = nowa.ilosc,
                    Rabat = nowa.rabat
                }
              );
            //w tym miejscu aktualizujemy pola: wartość netto i wartość brutto
            WartoscNetto = new FakturaB(lgSdatabase).
                LiczWartoscNetto(item.PozycjeFaktury.ToList());
            WartoscBrutto = new FakturaB(lgSdatabase).
                LiczWartoscBrutto(item.PozycjeFaktury.ToList());
        }
        public override void Save()
        {
            //dodajemy fakturę do lokalnej kolekcji
            lgSdatabase.Faktura.Add(item);
            //zapisujemy fakturę do bazy danych
            lgSdatabase.SaveChanges();
        }
        #endregion Helpers
    }
}
