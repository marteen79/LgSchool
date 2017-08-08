using GalaSoft.MvvmLight.Messaging;
using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using MVVMFirma.Pomocniczy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LgSchool.ViewModel
{
    public class NowaListaDoGrupyViewModel : NowyViewModel<ListaDoGrup>
    {
        #region Constructor
        public NowaListaDoGrupyViewModel()
        {
            base.DisplayName = "Lista grupy";
            item = new ListaDoGrup();

            Messenger.Default.Register<UczniowieForAllView>
                (this, getWybranyUczen);
        }
        #endregion Constructor
        #region Commands
        private BaseCommand _ShowUczniowie;
        public ICommand ShowUczniowie
        {
            get
            {
                if (_ShowUczniowie == null)
                {
                    // zatem ta komenda wyśle komunikat do MainWindowViewModel
                    // "Uczniowie Show" żeby MainWindowViewModel pokazało okno 
                    //ze wszystkimi statusami do wyboru
                    _ShowUczniowie = new BaseCommand(() =>
                    Messenger.Default.Send("Uczniowie Show"));
                }
                return _ShowUczniowie;
            }
        }
        #endregion Commands
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
        private string _UczenImie;
        public string UczenImie
        {
            get
            {
                return _UczenImie;
            }
            set
            {
                if (_UczenImie != value)
                {
                    _UczenImie = value;
                    OnPropertyChanged(() => UczenImie);
                }
            }
        }
        private string _UczenNazwisko;
        public string UczenNazwisko
        {
            get
            {
                return _UczenNazwisko;
            }
            set
            {
                if (_UczenNazwisko != value)
                {
                    _UczenNazwisko = value;
                    OnPropertyChanged(() => UczenNazwisko);
                }
            }
        }

        #endregion Properties

        #region Helpers
        public override void Save()
        {
            // Po dodaniu pozycji nie należy jej zapisywać do bazy
            // należy ją wysłać do okna z fakturą i jej pozycjami
            Messenger.Default.Send<ListaDoGrup>(item);
        }
        private void getWybranyUczen(UczniowieForAllView uczen)
        {
            UczenID = uczen.UczenID;
            UczenImie = uczen.Imie;
            UczenNazwisko = uczen.Nazwisko;
        }
        #endregion Helpers
    }
}
