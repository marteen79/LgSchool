using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.EntitiesForView
{
    //to jest klasa która jest niezbędna do wyświetlania klucza
    //obcego w Combobox'ie
    //do pola Key wskakuje Id klucza obcego 
    //a do pola Value wskakuje sklejone kilka pól z tabeli połączonej
    public class ComboboxKeyAndValue
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}