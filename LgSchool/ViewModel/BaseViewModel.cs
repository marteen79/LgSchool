﻿using MVVMFirma.Pomocniczy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LgSchool.ViewModel
{
   public class BaseViewModel : INotifyPropertyChanged
    {
        #region DisplayName
        public virtual string DisplayName { get; protected set; }
        #endregion //DisplayName

        #region Command
        public delegate void CommandDelegate();
        protected BaseCommand GetCommand(BaseCommand baseCommand, CommandDelegate function)
        {
            if (baseCommand == null)
            {
                baseCommand = new BaseCommand(() => function());
            }
            return baseCommand;
        }
        public ICommand CloseApplicationCommand
        {
            get
            {
                return new BaseCommand(closeApplication);
            }
        }
        private static void closeApplication()
        {
            Application.Current.Shutdown();
        }

        #endregion
        #region Propertychanged

        protected void OnPropertyChanged<T>(Expression<Func<T>> action)
        {
            var propertyName = GetPropertyName(action);
            OnPropertyChanged(propertyName);
        }

        private static string GetPropertyName<T>(Expression<Func<T>> action)
        {
            var expression = (MemberExpression)action.Body;
            var propertyName = expression.Member.Name;
            return propertyName;
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ShowMessageBoxInfo()
        {
            Console.WriteLine("Zapisano nowy obiekt do bazy danych");
        }

        #endregion
    }
}
