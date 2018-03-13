using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechConService1.Models;

namespace TechConService1.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private List<Book> _books = new List<Book>()
        {
            new Book { BookId = 1, Title = "Professional C# 6 and .NET Core 1.0"},
            new Book { BookId = 2, Title = "Professional C# 7 and .NET Core 2.0"},
            new Book { BookId = 3, Title = "Professional C# 8 and .NET Core 3.0"}
        };

        // GET api/values
        [HttpGet]
        public IEnumerable<Book> Get() => _books;

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!_books.Any(b => b.BookId == id))
                return NotFound();

            return Ok(_books.Find(b => b.BookId == id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
