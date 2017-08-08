using LgSchool.Model.Entities;
using LgSchool.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.BusinessLogic.Sprzedaz
{
   public class UslugaB : DatabaseClass
    {
        #region Constructor
        public UslugaB(LgSchoolEntities lgSdatabase)
            :base(lgSdatabase)
        {
        }              
        #endregion Constructor

        #region Helpers
        //to jest funkcja pobierająca dane wszystkich towarów, która będzie
        //uzywana np w ComboBoxach
        public IQueryable<ComboboxKeyAndValue> GetUslugiComboBoxItems()
        {
            return
                (
                    from usluga in lgSdatabase.Usluga
                    select new ComboboxKeyAndValue
                    {
                        Key = usluga.uslugaID,
                        Value = usluga.nazwa
                    }
                ).ToList().AsQueryable();
        }
        #endregion Helpers

        #region ViewFunction
        //To jest funkcja uzywana na wszystkich widokach, 
        //uzywających wyswietlanie wszystkich danych towarów
        public List<Usluga> PobierzWszystkoZUslug()
        {
            return
                (
                    from usluga in lgSdatabase.Usluga
                    select usluga
                ).ToList();
        }
        #endregion ViewFunction
        #region BusinessFunction
        #endregion BusinessFunction
    }
}
