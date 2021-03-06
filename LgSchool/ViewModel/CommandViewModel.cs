﻿using LgSchool.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModel
{
   public class CommandViewModel : BaseViewModel
    {
        #region Command
        public ICommand Command { get; private set; }
        #endregion // Command

        #region Constructor
        public CommandViewModel(string displayName, ICommand command)
        {
            // Na wszelki wypadek sprawdźmy, czy ktoś nie podał pustej komendy (null).
            if (command == null)
            {
                throw new ArgumentNullException("Komenda jest pusta");
            }
            base.DisplayName = displayName;
            this.Command = command;
        }
        #endregion // Constructor
    }
}
