using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    public class NowyKursViewModel : NowyViewModel<Kurs>
    {
        #region Constructor
        public NowyKursViewModel()
        {
            base.DisplayName = "Kurs";
            //tworzymy nowy kurs
            item = new Kurs();
        }
        #endregion Constructor
        #region Properties
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
        private string _PracownikNazwa;
        public string PracownikNazwa
        {
            get
            {
                return _PracownikNazwa;
            }
            set
            {
                if (_PracownikNazwa != value)
                {
                    _PracownikNazwa = value;
                    OnPropertyChanged(() => PracownikNazwa);
                }
            }
        }
        public int? PoziomID
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
        public int? PracownikID
        {
            get
            {
                return item.pracownikID;
            }
            set
            {
                if (item.pracownikID != value)
                {
                    item.pracownikID = value;
                    OnPropertyChanged(() => PracownikID);
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
        public IQueryable<ComboboxKeyAndValue> PracownicyComboboxItems
        {
            get
            {
                return
                    (
                        from pracownik in lgSdatabase.Pracownik
                        select new ComboboxKeyAndValue
                        {
                            Key = pracownik.pracownikID,
                            Value = pracownik.imie + " " + pracownik.nazwisko
                        }
                    ).ToList().AsQueryable();
            }
        }
        public override void Save()
        {
            //dodajemy użytkownika do lokalnej kolekcji
            lgSdatabase.Kurs.Add(item);
            //zapisujemy użytkownika do bazy danych
            lgSdatabase.SaveChanges();
        }
        #endregion Properties
    }
}
