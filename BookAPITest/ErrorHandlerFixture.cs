﻿using System;
using System.Collections.Generic;
using System.Text;
using WebAPIDemo.lib;
using WebAPIDemo.Model;
using Xunit;
namespace FirstWebApi.Tests
{
    public class ErrorHandlerTests
    {
        private ErrorHandler _errorHandler = new ErrorHandler();
        [Fact]
        public void Check_invalid_book_name()
        {

            var book = new Book()
            {
                ID = 1,
                Name = "Dotnet..",
                Category = "Programming",
                Author = "Sanap",
                Price = 1000
            };
            var errorMessagesList = _errorHandler.BookValidation(book);
            Assert.Equal("Name is invalid", errorMessagesList[0]);
        }
        [Fact]
        public void Check_invalid_book_category()
        {
            var book = new Book()
            {
                ID = 1,
                Name = "Dotnet",
                Category = "Programming1",
                Author = "Sanap",
                Price = 1000
            };
            var errorMessagesList = _errorHandler.BookValidation(book);
            Assert.Equal("Category is invalid", errorMessagesList[0]);
        }
        [Fact]
        public void Check_invalid_book_author()
        {
            var book = new Book()
            {
                ID = 1,
                Name = "Dotnet",
                Category = "Programming",
                Author = "Sanap  ",
                Price = 1000
            };
            var errorMessagesList = _errorHandler.BookValidation(book);
            Assert.Equal("Author is invalid", errorMessagesList[0]);
        }
        [Fact]
        public void Check_valid_book_data()
        {
            var book = new Book()
            {
                ID = 1,
                Name = "Dotnet",
                Category = "Programming",
                Author = "Sanap",
                Price = 1000
            };
            Assert.Empty(_errorHandler.BookValidation(book));
        }
        [Fact]
        public void Check_invalid_book_name_and_author()
        {
            var book = new Book()
            {
                ID = 1,
                Name = "Dotnet..",
                Category = "Programming",
                Author = "Sanap ",
                Price = 1000
            };
            var errorMessagesList = _errorHandler.BookValidation(book);
            var expectedList = new List<string>()
                    {
                        "Name is invalid",
                        "Author is invalid"
                    };
            Assert.True((errorMessagesList.Exists(o => o.Equals("Name is invalid"))) && (errorMessagesList.Exists(o => o.Equals("Author is invalid"))));
        }
    }
}