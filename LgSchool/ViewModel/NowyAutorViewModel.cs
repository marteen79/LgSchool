using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    public class NowyAutorViewModel : NowyViewModel<Autor>
    {
        #region Constructor
        public NowyAutorViewModel()
            :base()
        {
            base.DisplayName = "Nowy autor";
            item = new Autor();
        }
        #endregion Constructor
        #region Properties
        public string Imie
        {
            get
            {
                return item.imie;
            }
            set
            {
                if (value == item.imie)
                    return;
                item.imie = value;
                base.OnPropertyChanged(() => Imie);
            }
        }
        public string Nazwisko
        {
            get
            {
                return item.nazwisko;
            }
            set
            {
                if (value == item.nazwisko)
                    return;
                item.nazwisko = value;
                base.OnPropertyChanged(() => Nazwisko);
            }
        }
        public string Kraj
        {
            get
            {
                return item.kraj;
            }
            set
            {
                if (value == item.kraj)
                    return;
                item.kraj = value;
                base.OnPropertyChanged(() => Kraj);
            }
        }
        #endregion Properties
        #region Commands

        #endregion Commands
        #region Helpers
        public override void Save()
        {
            lgSdatabase.Autor.Add(item);
            lgSdatabase.SaveChanges();
        }
        public void SaveAndClose()
        {
            Save();
            ShowMessageBoxInfo();
            OnRequestClose();
        }
        #endregion Helpers
    }
}
