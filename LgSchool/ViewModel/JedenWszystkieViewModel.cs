using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Pomocniczy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LgSchool.ViewModel
{
    //To jest klasa, z której będą dziedziczyć wszystkie ViewModele zgodne
    //ze scenariuszem JedenWszystkie np Jedna Faktura i wszystkie jej pozycje,
    //Jeden pracownik i wszystkie jego wypłaty
    //Typ generyczny J oznacza typ obiektu jeden 
    //typ generyczny W oznacza typ obiektu wszystkie
    //W przypadku faktur J=Faktury, a W oznacza Pozycje faktury
    public abstract class JedenWszystkieViewModel<J, W> : NowyViewModel<J>
    {
        #region Fields
        private BaseCommand _LoadListCommand;
        private ObservableCollection<W> _List;
        private BaseCommand _ShowAddViewCommand;
        protected string DisplayListName;
        #endregion // Fields
        #region Properties
        public ICommand ShowAddViewCommand
        {
            get
            {
                if (_ShowAddViewCommand == null)
                {
                    _ShowAddViewCommand = new BaseCommand(() => showAddView());
                }
                return _ShowAddViewCommand;
            }
        }
        public ObservableCollection<W> List
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
        
        #endregion //Properties
        #region Constructor
        public JedenWszystkieViewModel()
        : base()
        {
        }
        #endregion // Constructor
        #region Helpers
        public abstract void Load();
        private void showAddView()
        {
            Messenger.Default.Send(DisplayListName + " Add");
        }
        #endregion
    }
}