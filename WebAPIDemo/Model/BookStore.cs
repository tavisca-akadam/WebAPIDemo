using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Model
{
    public class BookStore
    {
        public static List<Book> Books { get; set; } = null;

        public static List<Book> GetBookStore()
        {
            if (Books == null)
                Books = new List<Book>();
            return Books;
        }

        public static List<Book> Get()
        {
            return Books;
        }

        public static Book Get(int id)
        {
            var book = Books.Find(b => b.ID == id);
            if (book == null)
                throw new BookNotFoundException();
            return book;
        }

        public static void Post(Book book)
        {
            Books = GetBookStore();
            Books.Add(book);
        }

        public static void Put(int id, Book updateBook)
        {
            var book = Books.Find(b => b.ID == id);
            if (book == null)
                throw new BookNotFoundException();
            book.Name = updateBook.Name;
            book.Price = updateBook.Price;
            book.Author = updateBook.Author;
            book.Category = updateBook.Category;
        }

        public static void Delete(int id)
        {
            var book = Books.Find(b => b.ID == id);
            if (book == null)
                throw new BookNotFoundException();
            Books.Remove(book);
        }
    }
}
