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
    class NowaListaDoUczniaViewModel : NowyViewModel<OcenyUcznia>
    {
        #region Constructor
        public NowaListaDoUczniaViewModel()
        {
            base.DisplayName = "Dodanie oceny";
            item = new OcenyUcznia();
        }
        #endregion Constructor

        #region Properties
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
        public int OcenaID
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
        //private string _KategoriaNazwa;
        //public string KategoriaNazwa
        //{
        //    get
        //    {
        //        return _KategoriaNazwa;
        //    }
        //    set
        //    {
        //        if (_KategoriaNazwa != value)
        //        {
        //            _KategoriaNazwa = value;
        //            OnPropertyChanged(() => KategoriaNazwa);
        //        }
        //    }
        //}
        //public int KategoriaID
        //{
        //    get
        //    {
        //        return item.kategoriaID;
        //    }
        //    set
        //    {
        //        if (item.kategoriaID != value)
        //        {
        //            item.kategoriaID = value;
        //            OnPropertyChanged(() => KategoriaID);
        //        }
        //    }
        //}
        //public DateTime DataWpisu
        //{
        //    get
        //    {
        //        return item.data;
        //    }
        //    set
        //    {
        //        if (item.data != value)
        //        {
        //            item.data = value;
        //            OnPropertyChanged(() => DataWpisu);
        //        }
        //    }
        //}
        //private string _PracownikNazwa;
        //public string PracownikNazwa
        //{
        //    get
        //    {
        //        return _PracownikNazwa;
        //    }
        //    set
        //    {
        //        if (_PracownikNazwa != value)
        //        {
        //            _PracownikNazwa = value;
        //            OnPropertyChanged(() => PracownikNazwa);
        //        }
        //    }
        //}
        //public int PracownikID
        //{
        //    get
        //    {
        //        return item.pracownikID;
        //    }
        //    set
        //    {
        //        if (item.pracownikID != value)
        //        {
        //            item.pracownikID = value;
        //            OnPropertyChanged(() => PracownikID);
        //        }
        //    }
        //}
        //public IQueryable<ComboboxKeyAndValue> KategorieComboboxItems
        //{
        //    get
        //    {
        //        return
        //            (
        //                from kategoria in lgSdatabase.KategoriaOcen
        //                select new ComboboxKeyAndValue
        //                {
        //                    Key = kategoria.kategoriaID,
        //                    Value = kategoria.nazwa
        //                }
        //            ).ToList().AsQueryable();
        //    }
        //}
        //public IQueryable<ComboboxKeyAndValue> PracownicyComboboxItems
        //{
        //    get
        //    {
        //        return
        //            (
        //                from pracownik in lgSdatabase.Pracownik
        //                select new ComboboxKeyAndValue
        //                {
        //                    Key = pracownik.pracownikID,
        //                    Value = pracownik.imie + " " + pracownik.nazwisko
        //                }
        //            ).ToList().AsQueryable();
        //    }
        //}
        #endregion Properties

        #region Helpers
        public override void Save()
        {
            // Po dodaniu pozycji nie należy jej zapisywać do bazy
            // należy ją wysłać do okna z fakturą i jej pozycjami
            Messenger.Default.Send<OcenyUcznia>(item);
        }
        #endregion Helpers
    }
}
