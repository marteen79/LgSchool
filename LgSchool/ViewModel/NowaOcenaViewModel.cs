using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    public class NowaOcenaViewModel : NowyViewModel<Ocena>
    {
        #region Constructor
        public NowaOcenaViewModel()
        {
            base.DisplayName = "Ocena";
            //tworzymy nowy kurs
            item = new Ocena();
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
                if (item.nazwa != value)
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
        public override void Save()
        {
            //dodajemy użytkownika do lokalnej kolekcji
            lgSdatabase.Ocena.Add(item);
            //zapisujemy użytkownika do bazy danych
            lgSdatabase.SaveChanges();
        }
        #endregion Properties
    }
}
