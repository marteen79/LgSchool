using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    public class NowyCennikViewModel : NowyViewModel<Cennik>
    {
        #region Constructor
        public NowyCennikViewModel()
        {
            base.DisplayName = "Cennik";
            //tworzymy nowy kurs
            item = new Cennik();
        }
        #endregion Constructor
        #region Properties
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
        private string _KursPoziom;
        public string KursPoziom
        {
            get
            {
                return _KursPoziom;
            }
            set
            {
                if (_KursPoziom != value)
                {
                    _KursPoziom = value;
                    OnPropertyChanged(() => KursPoziom);
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
                            Value = kurs.nazwa + " " + kurs.Poziom.nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }
        public override void Save()
        {
            //dodajemy użytkownika do lokalnej kolekcji
            lgSdatabase.Cennik.Add(item);
            //zapisujemy użytkownika do bazy danych
            lgSdatabase.SaveChanges();
        }
        #endregion Properties
    }
}
