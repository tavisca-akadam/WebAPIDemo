using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Model;
using Newtonsoft.Json.Linq;
using WebAPIDemo.Service;
using WebAPIDemo.lib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private static List<Book> _bookList = new List<Book>();
        private IBookService _bookService;
        private Response _response;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
            _response = new Response();
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookService.Get());
        }

        // GET api/values/5
        [HttpGet("{id}") ]
        public IActionResult Get(int id)
        {
            //return "value";
            Book book = null;
            try
            {
                book = _bookService.Get(id);
            }
            catch(Exception ex)
            {
                if (ex is InvalidIDException)
                    return BadRequest($"Inavlid Id {id}, id should be positive");
                if(ex is BookNotFoundException)
                    return NotFound($"Book with id {id}, not found");
            }
            return Ok(book);
                
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Book value)
        {
            try
            {
                _bookService.Post(value);
            }
            catch(Exception ex)
            {
                _response.Error = new ErrorHandler().BookValidation(value);
                if (ex is InvalidParameterException)
                    return BadRequest(_response.Error);
                return StatusCode(500);
            }
            _response.Book = value;
            return Created("http://localhost:50886/api/book", _response.Book);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Book updateBook)
        {
            try
            {
                _bookService.Put(id, updateBook);
            }
            catch(Exception ex)
            {
                _response.Error = new ErrorHandler().BookValidation(updateBook);
                if (ex is InvalidParameterException)
                    return BadRequest(_response.Error);
                if (ex is InvalidIDException)
                    return BadRequest("ID not specified");
                return StatusCode(500);
            }
            _response.Book = _bookService.Get(id);
            return Ok(_response.Book);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _bookService.Delete(id);
            }
            catch(Exception ex)
            {
                if (ex is InvalidIDException)
                    return BadRequest($"Inavlid Id {id}, id should be positive");
                if (ex is BookNotFoundException)
                    return NotFound($"Book with id {id}, not found");
            }
            return Ok("Deleted");
        }
    }
}
