using LgSchool.Model.BusinessLogic.Sprzedaz;
using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
   public class WszystkieFakturyViewModel : WszystkieViewModel<FakturyForAllView>
    {
        #region Constructor
        public WszystkieFakturyViewModel()
            : base()
        {
            base.DisplayName = "Faktury";
        }
        #endregion Constructor

        #region DedicatedFiltering
        private string _NumerFind;
        public string NumerFind
        {
            get
            {
                return _NumerFind;
            }
            set
            {
                if (_NumerFind != value)
                {
                    _NumerFind = value;
                    OnPropertyChanged(() => NumerFind);
                }
            }
        }
        private DateTime? _DataOdFind;
        public DateTime? DataOdFind
        {
            get
            {
                return _DataOdFind;
            }
            set
            {
                if (_DataOdFind != value)
                {
                    _DataOdFind = value;
                    OnPropertyChanged(() => DataOdFind);
                }
            }
        }
        private DateTime? _DataDoFind;
        public DateTime? DataDoFind
        {
            get
            {
                return _DataDoFind;
            }
            set
            {
                if (_DataDoFind != value)
                {
                    _DataDoFind = value;
                    OnPropertyChanged(() => DataDoFind);
                }
            }
        }
        #endregion DedicatedFiltration

        #region Helpers
        //to jest metoda która pobiera wszystkie towary z bazy danych
        public override void Load()
        {
            //List = new ObservableCollection<FakturyForAllView>
            //    (
            //        from faktura in fakturyEntities.Faktury
            //        select new FakturyForAllView
            //        {
            //            IdFaktury=faktura.idFaktury,
            //            Numer=faktura.numer,
            //            DataWystawienia=faktura.dataWystawienia,
            //            KontrahentNazwa=faktura.Kontrahenci.nazwa,//to jest magia Linq oraz EntityFramework a nie żadne Joiny
            //            KontrahentNip=faktura.Kontrahenci.nip,
            //            KontrahentAdres=
            //            faktura.Kontrahenci.Adresy.miejscowosc+" "
            //            +faktura.Kontrahenci.Adresy.nrDomu,
            //            TerminPlatnosci=faktura.terminPlatnosci,
            //            SposobPlatnosciNazwa=faktura.SposobyPlatnosci.nazwa
            //        }
            //    );
        }
        public override void Sort()
        {

        }
        public override List<string> GetComboboxSortList()
        {
            return null;
        }
        public override void Find()
        {

        }
        public override List<string> GetComboboxFindList()
        {
            return null;
        }
        public override void FindDedicated()
        {

            List = new ObservableCollection<FakturyForAllView>
                (
                    new FakturaB(lgSdatabase).FindDedicated(NumerFind,
                    DataOdFind, DataDoFind)
                );
        }
        #endregion Helpers
    }
}
