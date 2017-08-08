using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.Validators
{
   public class StringValidator : Validator
    {
        public StringValidator()
        {

        }

        public static string SprawdzCzyZaczynaSieOdDuzej(string wartosc)
        {
            try
            {
                if (!char.IsUpper(wartosc, 0))
                {
                    return "Rozpocznij dużą literą!";
                }
            }
            catch (Exception) { };
            return null;
        }
    }
}
