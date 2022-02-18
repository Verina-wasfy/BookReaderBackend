using Bookstore.Entity;
using Bookstore.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBooks _Books;

        public BooksController(IBooks Books)
        {
            _Books = Books;
        }


        [HttpGet("Books")]
        public ActionResult<List<BooksEntity>> GetAllBooks()
        {
            try
            {
                var result = _Books.GetAllBooks();
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeleteBook")]
        public ActionResult DeleteBook(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = _Books.DeleteBook(Id);
                return Ok(result);
            }
        }


        [HttpPost]
        [Route("SaveBook")]
        public ActionResult SaveBook([FromBody] BooksEntity BookEntity)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = _Books.SaveBook(BookEntity);
                return Ok(result);
            }
        }




    }
}
