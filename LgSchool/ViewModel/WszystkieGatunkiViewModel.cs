using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.ViewModel
{
    public class WszystkieGatunkiViewModel : WszystkieViewModel<Gatunek>
    {
        #region Constructor
        public WszystkieGatunkiViewModel()
            : base()
        {
            base.DisplayName = "Gatunki";
        }

        public override void Find()
        {
            throw new NotImplementedException();
        }

        public override List<string> GetComboboxFindList()
        {
            throw new NotImplementedException();
        }

        public override List<string> GetComboboxSortList()
        {
            throw new NotImplementedException();
        }
        #endregion Constructor

        #region Helpers

        public override void Load()
        {
            List = new ObservableCollection<Gatunek>
                (
                    from gatunek in lgSdatabase.Gatunek
                    select gatunek
                );
        }

        public override void Sort()
        {
            
        }
        #endregion Helpers
    }
}