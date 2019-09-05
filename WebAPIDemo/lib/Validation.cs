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
        private static bool ValidateString(string input)
        {
            return input.All(Char.IsLetter);
        }
       public static bool ValidateBook(Book book)
        {
            var type = book.ID > 0 && book.Price > 0 && ValidateString(book.Author) 
                && ValidateString(book.Name) && ValidateString(book.Category);
            return type;
        }

    }
}
