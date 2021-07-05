using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_WebApi_Core_With_Identity.Models;
using Task_WebApi_Core_With_Identity.Services;

namespace Task_WebApi_Core_With_Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly BookServices _bookServices;

        public BookController(BookServices bookServices)
        {
            _bookServices = bookServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        // get brand by id
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var result = _bookServices.getById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        // add brand
        [HttpPost]
        public ActionResult<Book> AddBook([FromBody] Book b)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                Book result = _bookServices.AddBook(b);

                return Ok(result);
            }

        }
        [HttpPut("{id}")]
        public ActionResult EditBook(int id, [FromBody] Book b)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
               
                var result = _bookServices.EditBook(id,b);
                if (result != null)
                    return NoContent();
                return NotFound();
            }

        }

        // delete category
        [HttpDelete("{id}")]
        public ActionResult deleteBook(int id)
        {
            _bookServices.DeleteBook(id);
          
            return NotFound();
        }


    }
}
