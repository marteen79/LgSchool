using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
   public class NowyTytulWplatyViewModel : NowyViewModel<TytulWplaty>
    {
        #region Constructor
        public NowyTytulWplatyViewModel()
        {
            base.DisplayName = "Tytul wplaty";
            //tworzymy nowy kurs
            item = new TytulWplaty();
        }
        #endregion Constructor
        #region Properties

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
                    OnPropertyChanged(() => _WplataNumer);
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
        public decimal Cena
        {
            get
            {
                return item.cena;
            }
            set
            {
                if (item.cena != value)
                {
                    item.cena = value;
                    OnPropertyChanged(() => Cena);
                }
            }
        }
        public int IloscGodzin
        {
            get
            {
                return item.iloscGodzin;
            }
            set
            {
                if (item.iloscGodzin != value)
                {
                    item.iloscGodzin = value;
                    OnPropertyChanged(() => IloscGodzin);
                }
            }
        }
        // properties dla pola z tabeli Kurs - do Combobox'a
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
        // properties dla pola z tabeli Wplata - do Combobox'a
        public int WplataID
        {
            get
            {
                return item.wplataID;
            }
            set
            {
                if (item.wplataID != value)
                {
                    item.wplataID = value;
                    OnPropertyChanged(() => WplataID);
                }
            }
        }
        //to jest properties który dostarcza danych do combobox'a
        //który po rozwinięciu wyświetla wszystkie kursy - ich nazwy oraz wpłaty - ich numery 
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
        public IQueryable<ComboboxKeyAndValue> WplatyComboboxItems
        {
            get
            {
                return
                    (
                        from wplata in lgSdatabase.Wplata
                        select new ComboboxKeyAndValue
                        {
                            Key = wplata.wplataID,
                            Value = wplata.numerWplaty
                        }
                    ).ToList().AsQueryable();
            }
        }
        public override void Save()
        {
            //dodajemy użytkownika do lokalnej kolekcji
            lgSdatabase.TytulWplaty.Add(item);
            //zapisujemy użytkownika do bazy danych
            lgSdatabase.SaveChanges();
        }
        #endregion Properties
    }
}