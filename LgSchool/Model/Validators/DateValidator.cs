using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.Validators
{
   public class DateValidator : Validator
    {
            public static string SprawdzDate(DateTime? data1, DateTime? data2)
            {
                if (data1 > data2)
                {
                    return "Nieprawidłowy przedział czasowy";
                }
                return null;
            }
     }
}
