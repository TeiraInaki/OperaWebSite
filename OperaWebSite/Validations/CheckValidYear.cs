using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OperaWebSite.Validations
{
    public class CheckValidYear : ValidationAttribute
    {
        //Modifico el error message
        public CheckValidYear() 
        {
            ErrorMessage = "The earliest Opera was written in 1598 by Corsi, Peri and Rinuccini.";
        }
        //Chequeo si es valido
        public override bool IsValid(object value)
        {
            int year = (int)value;

            if (year < 1598)
            {
                return false;
            }
            else return true;
        }
    }
}