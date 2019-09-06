using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WebAPIDemo;
using WebAPIDemo.Service;
using WebAPIDemo.Model;

namespace BookAPITest
{
    public class BookServicesFixture
    {
        private IBookService _bookService = new BookService();
        [Fact]
        public void Check_empty_book_store()
        {
            var bookList = _bookService.GetBookStore();
            Assert.Empty(bookList);
        }

        [Fact]
        public void Check_valid_post_api_request()
        {
            var bookStore = _bookService.GetBookStore();

            _bookService.Post(new Book
            {
                ID =  2,
                Name = "PQRs",
                Price = 200,
                Author = "GSanap",
                Category = "AAA"
            });

            Assert.Single(bookStore);
        }

        [Fact]
        public void Check_valid_get_api_request()
        {
            var bookStore = _bookService.GetBookStore();
            _bookService.Post(new Book
            {
                ID = 2,
                Name = "PQRs",
                Price = 200,
                Author = "GSanap",
                Category = "AAA"
            });
            var actual = _bookService.Get();
            Assert.Equal(actual, bookStore);
        }

        [Theory]
        [InlineData(2)]
        public void Check_for_valid_get_request_using_valid_id(int id)
        {
            var bookStore = _bookService.GetBookStore();
            _bookService.Post(new Book
            {
                ID = id,
                Name = "PQRs",
                Price = 200,
                Author = "GSanap",
                Category = "AAA"
            });
            var actualResult = _bookService.Get(id);

            Assert.Equal(id, actualResult.ID);
        }

        [Theory]
        [InlineData(3)]
        public void Check_for_valid_get_request_using_invalid_id(int id)
        {
            var bookStore = _bookService.GetBookStore();
            _bookService.Post(new Book
            {
                ID = id,
                Name = "PQRs",
                Price = 200,
                Author = "GSanap",
                Category = "AAA"
            });
            Assert.Throws<BookNotFoundException>(() => _bookService.Get(2));
        }

        [Fact]
        public void Insert_book_using_post_with_invalid_id()
        {
            var bookStore = _bookService.GetBookStore();

            Assert.Throws<InvalidIDException>(() => _bookService.Post(new Book
            {
                ID = -2,
                Name = "PQRs",
                Price = 200,
                Author = "GSanap",
                Category = "AAA"
            }));
        }

        [Fact]
        public void Insert_book_using_post_with_invalid_name()
        {
            var bookStore = _bookService.GetBookStore();

            Assert.Throws<InvalidParameterException>(() => _bookService.Post(new Book
            {
                ID = 2,
                Name = "PQRs123",
                Price = 200,
                Author = "GSanap",
                Category = "AAA"
            }));
        }

        [Fact]
        public void Insert_book_using_post_with_invalid_price()
        {
            var bookStore = _bookService.GetBookStore();

            Assert.Throws<InvalidBookPriceException>(() => _bookService.Post(new Book
            {
                ID = 2,
                Name = "PQRs",
                Price = 00,
                Author = "GSanap",
                Category = "AAA"
            }));
        }
        [Fact]
        public void Insert_book_using_post_with_invalid_author_name()
        {
            var bookStore = _bookService.GetBookStore();

            Assert.Throws<InvalidParameterException>(() => _bookService.Post(new Book
            {
                ID = 2,
                Name = "PQRs",
                Price = 100,
                Author = "2314",
                Category = "AAA"
            }));
        }

        [Fact]
        public void Insert_book_using_post_with_invalid_category()
        {
            var bookStore = _bookService.GetBookStore();

            Assert.Throws<InvalidParameterException>(() => _bookService.Post(new Book
            {
                ID = 2,
                Name = "PQRs",
                Price = 100,
                Author = "Sanape",
                Category = "@#1"
            }));
        }

        [Fact]
        public void Update_book_using_put_with_valid_parameter()
        {
            var bookStore = _bookService.GetBookStore();
            _bookService.Post(new Book
            {
                ID = 2,
                Name = "PQRs",
                Price = 200,
                Author = "GSanap",
                Category = "AAA"
            });

            _bookService.Put(2, new Book
            {
                Name = "PQRS",
                Price = 200,
                Author = "GSANAP",
                Category = "AAA"
            });
            string expectedResult = "PQRS";
            var actualResult = _bookService.Get(2);
            Assert.Equal(expectedResult, actualResult.Name);
        }

        [Fact]
        public void Update_book_using_put_with_invalid_name()
        {
            var bookStore = _bookService.GetBookStore();
            _bookService.Post(new Book
            {
                ID = 2,
                Name = "PQRs",
                Price = 200,
                Author = "GSanap",
                Category = "AAA"
            });

            Assert.Throws<InvalidParameterException>(() => _bookService.Put(2, new Book
            {
                Name = "PQRS@!#",
                Price = 200,
                Author = "GSANAP",
                Category = "AAA"
            }));
        }

        [Fact]
        public void Update_book_using_put_with_invalid_id()
        {
            var bookStore = _bookService.GetBookStore();
            _bookService.Post(new Book
            {
                ID = 2,
                Name = "PQRs",
                Price = 200,
                Author = "GSanap",
                Category = "AAA"
            });

            Assert.Throws<InvalidIDException>(() => _bookService.Put(0, new Book
            {
                Name = "PQRS@!#",
                Price = 200,
                Author = "GSANAP",
                Category = "AAA"
            }));
        }

        [Fact]
        public void Update_book_using_put_with_invalid_price()
        {
            var bookStore = _bookService.GetBookStore();
            _bookService.Post(new Book
            {
                ID = 2,
                Name = "PQRs",
                Price = 200,
                Author = "GSanap",
                Category = "AAA"
            });

            Assert.Throws<InvalidParameterException>(() => _bookService.Put(2, new Book
            {
                Name = "PQRS",
                Price = 0,
                Author = "GSANAP",
                Category = "AAA"
            }));
        }

        [Fact]
        public void Update_book_using_put_with_invalid_author()
        {
            var bookStore = _bookService.GetBookStore();
            _bookService.Post(new Book
            {
                ID = 2,
                Name = "PQRs",
                Price = 200,
                Author = "GSanap",
                Category = "AAA"
            });

            Assert.Throws<InvalidParameterException>(() => _bookService.Put(2, new Book
            {
                Name = "PQRS",
                Price = 200,
                Author = "#GSANAP",
                Category = "AAA"
            }));
        }


        [Fact]
        public void Update_book_using_put_with_invalid_category()
        {
            var bookStore = _bookService.GetBookStore();
            _bookService.Post(new Book
            {
                ID = 2,
                Name = "PQRs",
                Price = 200,
                Author = "GSanap",
                Category = "AAA"
            });

            Assert.Throws<InvalidParameterException>(() => _bookService.Put(2, new Book
            {
                Name = "PQRS",
                Price = 200,
                Author = "GSANAP",
                Category = "$#@!"
            }));
        }

        [Theory]
        [InlineData(2)]
        public void Delete_book_using_delete_with_valid_id(int id)
        {
            var bookStore = _bookService.GetBookStore();
            _bookService.Post(new Book
            {
                ID = id,
                Name = "PQRs",
                Price = 200,
                Author = "GSanap",
                Category = "AAA"
            });

            _bookService.Delete(id);

            Assert.Throws<BookNotFoundException>(() => _bookService.Get(id));
        }

        [Theory]
        [InlineData(3)]
        public void Delete_book_using_delete_with_invalid_id(int id)
        {
            var bookStore = _bookService.GetBookStore();
            _bookService.Post(new Book
            {
                ID = 2,
                Name = "PQRs",
                Price = 200,
                Author = "GSanap",
                Category = "AAA"
            });
            
            Assert.Throws<BookNotFoundException>(() => _bookService.Delete(3));
        }
    }
}
