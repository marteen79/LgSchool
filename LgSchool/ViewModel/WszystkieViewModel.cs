using GalaSoft.MvvmLight.Messaging;
using LgSchool.Model.Entities;
using MVVMFirma.Pomocniczy;
using MVVMFirma.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LgSchool.ViewModel
{
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        protected readonly LgSchoolEntities lgSdatabase;
        private BaseCommand _LoadCommand;
        private BaseCommand _AddCommand;
        private BaseCommand _RefreshCommand;
        private ObservableCollection<T> _List;
        private BaseCommand _SortCommand;
        // to pole zostanie podpiete pod Button Filtruj
        private BaseCommand _FindCommand;
        private BaseCommand _FindDedicatedCommand;
        #endregion Fields
        #region Properties

        public ICommand LoadCommand
        {
            // 1 metoda 
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => Load());
                }
                return _LoadCommand;
            }
        }
        public ICommand RefreshCommand
        {
            // 1 metoda 
            get
            {
                if (_RefreshCommand == null)
                {
                    _RefreshCommand = new BaseCommand(() => Load());
                }
                return _RefreshCommand;
            }
        }
        public ICommand FindDedicatedCommand
        {
            get
            {
                if (_FindDedicatedCommand == null)
                {
                    //ta komenda wykonuje funkcje FindDedicated(), ktora bedzie zdefiniowana w sekcji helpers
                    _FindDedicatedCommand = new BaseCommand(() => FindDedicated());
                }
                return _FindDedicatedCommand;
            }
        }
        // 2 metoda
        //public ICommand LoadCommand
        //{
        //    get
        //    {
        //      return GetCommand(_LoadCommand,Load());
        //    }
        //}
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    //ta komenda wykonuje funkcje add, ktora bedzie zdefiniowana w sekcji helpers
                    _AddCommand = new BaseCommand(() => add());
                }
                return _AddCommand;
            }
        }
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                {
                    Load();
                }
                return _List;
            }
            set
            {
                if (_List != value)
                {
                    _List = value;
                    OnPropertyChanged(() => List);
                }
            }
        }
        public string SortField { get; set; }
        // ten properties dostarczy elementów Comboboxowi 
        // sortującemu
        public List<string> SortComboboxItems
        {
            get
            {
                return GetComboboxSortList();
            }
        }
        // ta komenda zostanie podpieta pod przycisk sortujący
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    _SortCommand =
                        new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }
        // w tym polu zdecydujemy po czym filtrować
        public string FindField { get; set; }
        // w tej właściwości zostanie zapisane 
        // początek frazy filtrującej
        public string FindTextBox { get; set; }
        // ta właściwość dostarczy itemsów do Comboboxa 
        public List<string> FindComboboxItems
        {
            get
            {
                return GetComboboxFindList();
            }
        }
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                {
                    _FindCommand =
                        new BaseCommand(() => Find());
                }
                return _FindCommand;
            }
        }
        #endregion
        #region Constructor
        public WszystkieViewModel()
        {
            this.lgSdatabase = new LgSchoolEntities();
        }
        #endregion Constructor
        #region Helpers
        //to jest metoda która pobiera wszystkie towary z bazy danych
        public abstract void Load();
        public abstract void Sort();
        public abstract List<string> GetComboboxSortList();
        public abstract void Find();
        public abstract List<string> GetComboboxFindList();
        //ta metoda jest wirtualna bo będzie nadpisana w klasach dziedziczących 
        //które będą miały dedykowane filtrowanie
        private void add()
        {
            Messenger.Default.Send(DisplayName + " Add");
            OnRequestClose();
        }
        public virtual void FindDedicated()
        {

        }
        #endregion Helpers
    }
}
