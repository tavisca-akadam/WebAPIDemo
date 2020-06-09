using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Model;

namespace WebAPIDemo.lib
{
    public class ErrorHandler
    {
        private List<string> errorMessages = new List<string>();
        public List<string> BookValidation(Book book)
        {
            var propertiesList = book.GetType().GetProperties();
            foreach(var item in propertiesList)
            {
                if(item.Name.Equals("ID") || item.Name.Equals("Price"))
                {
                    if (Int32.Parse(item.GetValue(book).ToString()) <= 0)
                    {
                        errorMessages.Add($"{item.Name} should be positive");
                    }
                    continue;
                }
                if(!Validation.ValidateString(item.GetValue(book).ToString()))
                {
                    errorMessages.Add($"{item.Name} is invalid");
                }
            }
            return errorMessages;
        }
    }
}
