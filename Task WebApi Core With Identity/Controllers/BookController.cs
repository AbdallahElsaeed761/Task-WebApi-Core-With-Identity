using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_WebApi_Core_With_Identity.Interfaces;
using Task_WebApi_Core_With_Identity.Models;
using Task_WebApi_Core_With_Identity.Services;

namespace Task_WebApi_Core_With_Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBook _bookServices;

        public BookController(IBook bookServices)
        {
            _bookServices = bookServices;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //Get All Book
        [HttpGet]
        public ActionResult<List<Book>> GetAllBook()
        {
            var result = _bookServices.GetAllbooks();
            if (result == null)
                return NotFound();
            return Ok(result);
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Author")]
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
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public ActionResult deleteBook(int id)
        {
            _bookServices.DeleteBook(id);
          
            return NotFound();
        }


    }
}
