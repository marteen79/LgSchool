using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.Validators
{
   public class BirthdateValidator : Validator
    {
            public static string SprawdzDateUrodzenia(DateTime? data)
            {
                if (data > DateTime.Now)
                {
                    return "Nieprawidłowa data";
                }
                return null;
            }
     }
}
