using LgSchool.ViewModel;
using MVVMFirma.Pomocniczy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModel
{
   public class WorkspaceViewModel : BaseViewModel //z BaseViewModel odzedziczył DisplayName
    {
        #region Fields
        private BaseCommand _CloseCommand;
        #endregion //Fields

        #region Properties
        public bool CzyModalne { get; set; }
        #endregion //Properties

        #region Constructor
        public WorkspaceViewModel()
        {
            CzyModalne = false;
        }
        #endregion //Constructor

        #region Commands
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                {
                    _CloseCommand = new BaseCommand(OnRequestClose);
                }
                return _CloseCommand;
            }
        }
        #endregion //Commands

        #region RequestClose
        public EventHandler RequestClose;
        public void OnRequestClose() //Ta metoda zamknie zakładkę
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        #endregion //RequestClose
    }
}
