using System;
using WebAPIDemo.Model;
using Xunit;
using WebAPIDemo;
using System.Diagnostics;

namespace BookAPITest
{
    public class BookStoreFixture
    {
        [Fact]
        public void Empty_data_store_test()
        {
            var bookList = BookStore.GetBookStore();
            Assert.Empty(bookList);
        }



        [Fact]
        public void Check_book_data_store_after_adding_book()
        {
            var bookList = BookStore.GetBookStore();
            bookList.Add(new Book
            {
                ID = 1,
                Name = "Dotnet",
                Price = 2010,
                Author = "GSanap",
                Category = "Book"
            });
            Assert.Single(bookList);
        }



        [Fact]
        public void Update_book_data_using_put_method_success_scenario()
        {
            var bookList = BookStore.GetBookStore();
            if(bookList == null)
            {
                Debug.WriteLine("Null aalay");
            }
            bookList.Add(new Book
            {
                ID = 1,
                Name = "Dotnet",
                Price = 2010,
                Author = "GSanap",
                Category = "Book"
            });
            var newBook = new Book
            {
                ID = 1,
                Name = "Dotnet",
                Price = 2010,
                Author = "GSanap",
                Category = "Book"
            };
            BookStore.Put(1, newBook);
            var updatedBook = BookStore.Get(1);
            Assert.Equal(newBook.Name, updatedBook.Name);
        }
        [Fact]
        public void Update_book_data_using_put_method_failure_scenario()
        {
            var bookList = BookStore.GetBookStore();
            bookList.Add(new Book
            {
                ID = 1,
                Name = "Dotnet",
                Price = 2010,
                Author = "GSanap",
                Category = "Book"
            });
            var newBook = new Book
            {
                ID = 1,
                Name = "Dotnet",
                Price = 2010,
                Author = "GSanap",
                Category = "Book"
            };
            Assert.Throws<BookNotFoundException>(() => BookStore.Put(2, newBook));

        }
        [Fact]
        public void Delete_book_using_put_method_success_scenario()
        {
            var bookList = BookStore.GetBookStore();
            bookList.Add(new Book
            {
                ID = 1,
                Name = "Dotnet",
                Price = 2010,
                Author = "GSanap",
                Category = "Book"
            });



            BookStore.Delete(1);
            Assert.Empty(bookList);
        }
        [Fact]
        public void Delete_book_using_put_method_failure_scenario()
        {
            var bookList = BookStore.GetBookStore();
            bookList.Add(new Book
            {
                ID = 1,
                Name = "Dotnet",
                Price = 2010,
                Author = "GSanap",
                Category = "Book"
            });

            Assert.Throws<BookNotFoundException>(() => BookStore.Delete(2));



        }
    }
}
