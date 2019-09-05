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
        BookService service = new BookService();

        //public BookController()
        //{
        //    _bookList.Add(new Book { ID = 1, Name = "Wings of Fire", ISBN = "2018:123", Author = "G. Sanap" });
        //    _bookList.Add(new Book { ID = 2, Name = "ABC", ISBN = "2001:002", Author = "G. Sanap" });
        //    _bookList.Add(new Book { ID = 3, Name = "PQR", ISBN = "2009:234", Author = "G. Sanap" });
        //}
        // GET: api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return service.Get();
        }

        // GET api/values/5
        [HttpGet("{id}") ]
        public IActionResult Get(int id)
        {
            //return "value";
            Book book = null;
            try
            {
                book = service.Get(id);
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
                service.Post(value);
            }
            catch(Exception ex)
            {
                return NotFound("400 Bad request" + ex.ToString());
            }
            return Ok("Inserted");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
