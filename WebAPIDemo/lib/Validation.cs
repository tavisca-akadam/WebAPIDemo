using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebAPIDemo.Model;

namespace WebAPIDemo.lib
{
    public class Validation
    {
        public static bool ValidateString(string input)
        {
            return input.All(Char.IsLetter);
        }
       public static bool ValidateBook(Book book)
        {
            return new ErrorHandler().BookValidation(book).Count > 0;
        }

    }
}
