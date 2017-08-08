using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LgSchool.Model.Validators
{
   public class NipValidator : Validator
    {
        public static string NIPValidate(string NIPValidate)
	    {
	     const byte lenght = 10; 
	     ulong nip = ulong.MinValue;
	     byte[] digits;
	     byte[] weights = new byte[] { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
	 
	     if (NIPValidate.Length.Equals(lenght).Equals(false)) return null;	 
	     if (ulong.TryParse(NIPValidate, out nip).Equals(false)) return null;
	     else
	         {
	         string sNIP = NIPValidate.ToString();
	         digits = new byte[lenght];	 
	         for (int i = 0; i<lenght; i++)
	             {
	                if (byte.TryParse(sNIP[i].ToString(), out digits[i]).Equals(false)) return null;
	             }	 
	         int checksum = 0;
	 
	         for (int i = 0; i<lenght - 1; i++)
	             {
	                checksum += digits[i] * weights[i];
	             }
	                return (checksum % 11 % 10).Equals(digits[digits.Length - 1]).ToString();
	           }

	     }
    }
}
