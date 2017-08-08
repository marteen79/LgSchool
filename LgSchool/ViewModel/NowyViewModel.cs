using GalaSoft.MvvmLight.Messaging;
using LgSchool.Model.Entities;
using MVVMFirma.Pomocniczy;
using MVVMFirma.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LgSchool.ViewModel
{
    public abstract class NowyViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        private BaseCommand _SaveCommand;
        protected T item;
        protected LgSchoolEntities lgSdatabase;
        #endregion Fields
        #region Constructor
        public NowyViewModel()
            :base()
        {
            this.lgSdatabase = new LgSchoolEntities();
        }
        #endregion
        #region Commands
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new BaseCommand(() => saveAndClose());
                }
                return _SaveCommand;
            }
        }
        #endregion Commands
        #region Helpers
        public abstract void Save();
        private void saveAndClose()
        {
            // przed zapisem sprawdzamy czy wszystkie obowiązkowe pola przeszły walidacje
            if (IsValid())
            {
                //jezeli przeszly walidacje to zapisujemy rekord
                //to jest wywoałanie powyższej metody Save()
                Save();
                //to jest zamknięcie okna
                OnRequestClose();
                Messenger.Default.Send(DisplayName + " Show");
            }
            // a jeżeli nie przeszły walidacji to wywołujemy okno z komunikatem - popraw błędy
            else
            {
                MessageBox.Show("Przed zapisem popraw wszystkie błędy!");
            }
            
        }
        #endregion Helpers
        #region Validator
        // to jest funkcja która sprawdza poprawnosc wpisania rekordu przed zapisem
        // domyślnie ta funkcja zwraca true, chyba że zostanie zmodyfikowana
        // (nadpisana) w klasie dziedziczącej
        public virtual bool IsValid()
        {
            return true;
        }
        #endregion Validator
    }
}
