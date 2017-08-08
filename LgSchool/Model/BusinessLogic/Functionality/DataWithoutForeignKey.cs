using LgSchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.BusinessLogic.Functionality
{
    public class DataWithoutForeignKey : DatabaseClass
    {
        public DataWithoutForeignKey(LgSchoolEntities lgSdatabase)
            :base(lgSdatabase)
        {

        }
        
        public List<KategoriaOcen> PobierzKategorieOcen()
        {
            return
                (
                    from kategoria in lgSdatabase.KategoriaOcen
                    select kategoria
                ).ToList();
        }
        public List<Poziom> PobierzPoziomy()
        {
            return
                (
                    from poziom in lgSdatabase.Poziom
                    select poziom
                ).ToList();
        }
        public List<Autor> PobierzAutorow()
        {
            return
                (
                    from autor in lgSdatabase.Autor
                    select autor
                ).ToList();
        }
        public List<Status> PobierzStatusy()
        {
            return
                (
                    from status in lgSdatabase.Status
                    select status
                ).ToList();
        }
        public List<TypyMaterialow> PobierzTypyMaterialow()
        {
            return
                (
                    from typ in lgSdatabase.TypyMaterialow
                    select typ
                ).ToList();
        }
    }
}
