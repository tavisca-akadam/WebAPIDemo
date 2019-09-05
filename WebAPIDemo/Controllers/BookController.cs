using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Model;
using Newtonsoft.Json.Linq;
using WebAPIDemo.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private static List<Book> _bookList = new List<Book>();
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.Get();
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
                return NotFound("404 not found");
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
                return NotFound("400 Bad request" + ex.ToString());
            }
            return Ok("Inserted");
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
                return NotFound("Invalid Parameter");
            }
            return NoContent();
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
                return NotFound("Something Went Wrong" + ex.ToString());
            }
            return Ok("Deleted");
        }
    }
}
