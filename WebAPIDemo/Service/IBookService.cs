using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Model;

namespace WebAPIDemo.Service
{
    public interface IBookService
    {
        List<Book> GetBookStore();
        List<Book> Get();
        Book Get(int id);
        void Post(Book book);
        void Put(int id, Book updateBook);
        void Delete(int id);

    }
}
