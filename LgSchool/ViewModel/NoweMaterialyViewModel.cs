using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
   public class NoweMaterialyViewModel : NowyViewModel<Materialy>
    {
        #region Constructor
        public NoweMaterialyViewModel()
        {
            base.DisplayName = "Materialy";
            item = new Materialy();
        }
        #endregion Constructor
        #region Properties
        private string _TypNazwa;
        public string TypNazwa
        {
            get
            {
                return _TypNazwa;
            }
            set
            {
                if (_TypNazwa != value)
                {
                    _TypNazwa = value;
                    OnPropertyChanged(() => TypNazwa);
                }
            }
        }
        public string Tytul
        {
            get
            {
                return item.tytul;
            }
            set
            {
                if (item.tytul != value)
                {
                    item.tytul = value;
                    OnPropertyChanged(() => Tytul);
                }
            }
        }
        private string _AutorNazwa;
        public string AutorNazwa
        {
            get
            {
                return _AutorNazwa;
            }
            set
            {
                if (_AutorNazwa != value)
                {
                    _AutorNazwa = value;
                    OnPropertyChanged(() => AutorNazwa);
                }
            }
        }
        private string _GatunekNazwa;
        public string GatunekNazwa
        {
            get
            {
                return _GatunekNazwa;
            }
            set
            {
                if (_GatunekNazwa != value)
                {
                    _GatunekNazwa = value;
                    OnPropertyChanged(() => GatunekNazwa);
                }
            }
        }
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
        //private string _DostepnoscWartosc;
        //public string DostepnoscWartosc
        //{
        //    get
        //    {
        //        return _DostepnoscWartosc;
        //    }
        //    set
        //    {
        //        if (_DostepnoscWartosc != value)
        //        {
        //            _DostepnoscWartosc = value;
        //            OnPropertyChanged(() => DostepnoscWartosc);
        //        }
        //    }
        //}
        public int TypID
        {
            get
            {
                return item.typID;
            }
            set
            {
                if (item.typID != value)
                {
                    item.typID = value;
                    OnPropertyChanged(() => TypID);
                }
            }
        }
        public int AutorID
        {
            get
            {
                return item.autorID;
            }
            set
            {
                if (item.autorID != value)
                {
                    item.autorID = value;
                    OnPropertyChanged(() => AutorID);
                }
            }
        }
        public int GatunekID
        {
            get
            {
                return item.gatunekID;
            }
            set
            {
                if (item.gatunekID != value)
                {
                    item.gatunekID = value;
                    OnPropertyChanged(() => GatunekID);
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
        //public int DostepnoscID
        //{
        //    get
        //    {
        //        return item.dostepnoscID;
        //    }
        //    set
        //    {
        //        if (item.dostepnoscID != value)
        //        {
        //            item.dostepnoscID = value;
        //            OnPropertyChanged(() => DostepnoscID);
        //        }
        //    }
        //}
        public IQueryable<ComboboxKeyAndValue> TypyComboboxItems
        {
            get
            {
                return
                    (
                        from item in lgSdatabase.TypyMaterialow
                        select new ComboboxKeyAndValue
                        {
                            Key = item.typID,
                            Value = item.nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<ComboboxKeyAndValue> AutorComboboxItems
        {
            get
            {
                return
                    (
                        from item in lgSdatabase.Autor
                        select new ComboboxKeyAndValue
                        {
                            Key = item.autorID,
                            Value = item.imie + " " + item.nazwisko
                        }
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<ComboboxKeyAndValue> GatunkiComboboxItems
        {
            get
            {
                return
                    (
                        from item in lgSdatabase.Gatunek
                        select new ComboboxKeyAndValue
                        {
                            Key = item.gatunekID,
                            Value = item.nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<ComboboxKeyAndValue> PoziomyComboboxItems
        {
            get
            {
                return
                    (
                        from item in lgSdatabase.Poziom
                        select new ComboboxKeyAndValue
                        {
                            Key = item.poziomID,
                            Value = item.nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }
        //public IQueryable<ComboboxKeyAndValue> DostepnoscComboboxItems
        //{
        //    get
        //    {
        //        return
        //            (
        //                from item in lgSdatabase.Dostepnosc
        //                select new ComboboxKeyAndValue
        //                {
        //                    Key = item.dostepnoscID,
        //                    Value = item.dostepnoscID
        //                }
        //            ).ToList().AsQueryable();
        //    }
        //}
        public override void Save()
        {
            //dodajemy użytkownika do lokalnej kolekcji
            lgSdatabase.Materialy.Add(item);
            //zapisujemy użytkownika do bazy danych
            lgSdatabase.SaveChanges();
        }
        #endregion Properties
    }
}
