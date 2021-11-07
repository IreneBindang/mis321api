using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Models.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        // GET: api/books
        [EnableCors("AnotherPolicy")]

        [HttpGet]
        public List<Book> Get()
        {
            IGetAllBooks readobject = new ReadBookData();
            return readobject.GetAllBooks();
        }

        // GET: api/books/5
        [EnableCors("AnotherPolicy")]

        [HttpGet("{id}", Name = "Get")]
        public Book Get(int id)
        {
            IGetBook readobject = new ReadBookData();
            return readobject.GetBook(id);
        }

        // POST: api/books
        [EnableCors("AnotherPolicy")]

        [HttpPost]
        public void Post([FromBody] Book value)
        {
            IInsertBook insertobject = new SaveBook();
            insertobject.InsertBook(value);
        }

        // PUT: api/books/5
        [EnableCors("AnotherPolicy")]

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")]

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
