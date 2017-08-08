using GalaSoft.MvvmLight.Messaging;
using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    class NowaPozycjaFakturyViewModel : NowyViewModel<PozycjeFaktury>
    {
        #region Constructor
        public NowaPozycjaFakturyViewModel()
        {
            base.DisplayName = "Pozycja faktury";
            item = new PozycjeFaktury();
        }
        #endregion Constructor

        #region Properties
        public int UslugaID
        {
            get
            {
                return item.uslugaID;
            }
            set
            {
                if (item.uslugaID != value)
                {
                    item.uslugaID = value;
                    OnPropertyChanged(() => UslugaID);
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
        public decimal Ilosc
        {
            get
            {
                return item.ilosc;
            }
            set
            {
                if (item.ilosc != value)
                {
                    item.ilosc = value;
                    OnPropertyChanged(() => Ilosc);
                }
            }
        }
        public decimal Rabat
        {
            get
            {
                return item.rabat;
            }
            set
            {
                if (item.rabat != value)
                {
                    item.rabat = value;
                    OnPropertyChanged(() => Rabat);
                }
            }
        }
        #endregion Properties

        #region Helpers
        public override void Save()
        {
            // Po dodaniu pozycji nie należy jej zapisywać do bazy
            // należy ją wysłać do okna z fakturą i jej pozycjami
            Messenger.Default.Send<PozycjeFaktury>(item);
        }
        #endregion Helpers
    }
}
