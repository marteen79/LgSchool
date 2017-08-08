using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using LgSchool.Model.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    public class NowaFirmaViewModel : NowyViewModel<Firma>,IDataErrorInfo
    {
        #region Constructor
        public NowaFirmaViewModel()
            :base()
        {
            base.DisplayName = "Firma";
            item = new Firma();
        }
        #endregion Constructor
        #region Properties
        public string Nazwa
        {
            get
            {
                return item.nazwa;
            }
            set
            {
                if (item.nazwa !=value)
                {
                    item.nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }            
            }
        }
        public string Opis
        {
            get
            {
                return item.opis;
            }
            set
            {
                if (item.opis != value)
                {
                    item.opis = value;
                    OnPropertyChanged(() => Opis);
                }
            }
        }
        public string Nip
        {
            get
            {
                return item.nip;
            }
            set
            {
                if (item.nip != value)
                {
                    item.nip = value;
                    OnPropertyChanged(() => Nip);
                }
            }
        }
        public string Regon
        {
            get
            {
                return item.regon;
            }
            set
            {
                if (item.regon != value)
                {
                    item.regon = value;
                    OnPropertyChanged(() => Regon);
                }
            }
        }
        public string Telefon1
        {
            get
            {
                return item.telefon1;
            }
            set
            {
                if (item.telefon1 != value)
                {
                    item.telefon1 = value;
                    OnPropertyChanged(() => Telefon1);
                }
            }
        }
        public string Telefon2
        {
            get
            {
                return item.telefon2;
            }
            set
            {
                if (item.telefon2 != value)
                {
                    item.telefon2 = value;
                    OnPropertyChanged(() => Telefon2);
                }
            }
        }
        public string Fax
        {
            get
            {
                return item.fax;
            }
            set
            {
                if (item.fax != value)
                {
                    item.fax = value;
                    OnPropertyChanged(() => Fax);
                }
            }
        }
        public string Email
        {
            get
            {
                return item.email;
            }
            set
            {
                if (item.email != value)
                {
                    item.email = value;
                    OnPropertyChanged(() => Email);
                }
            }
        }
        public string OsobaKontaktowa
        {
            get
            {
                return item.osobaKontaktowa;
            }
            set
            {
                if (item.osobaKontaktowa != value)
                {
                    item.osobaKontaktowa = value;
                    OnPropertyChanged(() => OsobaKontaktowa);
                }
            }
        }
        public int? StatusID
        {
            get
            {
                return item.statusID;
            }
            set
            {
                if (item.statusID != value)
                {
                    item.statusID = value;
                    OnPropertyChanged(() => StatusID);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> StatusyComboboxItems
        {
            get
            {
                return
                    (
                        from status in lgSdatabase.Status
                        select new ComboboxKeyAndValue
                        {
                            Key = status.statusID, // tutaj wchodzi ID klucza obcego
                            Value = status.nazwa // tutaj wchodzi wartość
                        }
                    ).ToList().AsQueryable();
            }
        }
        #endregion Properties
        #region Commands
        #endregion Commands
        #region Helpers
        public override void Save()
        {
            lgSdatabase.Firma.Add(item);
            lgSdatabase.SaveChanges();
        }
        public void SaveAndClose()
        {
            Save();
            ShowMessageBoxInfo();
            OnRequestClose();
        }
        #endregion Helpers
        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Nazwa")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Nazwa);
                }
                if (name == "Osoba kontaktowa")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.OsobaKontaktowa);
                }
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Nazwa"] == null && this["Osoba kontaktowa"] == null)
                return true;
            return false;
        }
        #endregion //Validation
    }
}
