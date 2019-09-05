using System;
using System.Collections.Generic;
using WebAPIDemo.Model;
using WebAPIDemo.lib;

namespace WebAPIDemo.Service
{
    public class BookService : IBookService
    {

        public void Delete(int id)
        {
            if (id <= 0)
                throw new InvalidIDException();
            BookStore.Delete(id);
        }

        public List<Book> Get()
        {
            return BookStore.Get();
        }

        public Book Get(int id)
        {
            if (id <= 0)
                throw new InvalidIDException();
            return BookStore.Get(id);
        }

        public List<Book> GetBookStore()
        {
            return BookStore.GetBookStore();
        }

        public void Post(Book book)
        {
            if (book.ID <= 0)
                throw new InvalidIDException();
            if (book.Price <= 0)
                throw new InvalidBookPriceException();
            if (Validation.ValidateBook(book))
                BookStore.Post(book);
            else
                throw new InvalidBookException();
        }

        public void Put(int id, Book updateBook)
        {
            if (Validation.ValidateBook(updateBook))
                BookStore.Put(id, updateBook);
            else
                throw new InvalidParameterException();
        }
    }
}
