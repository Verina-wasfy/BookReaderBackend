using BookStore.Business.Authors;
using BookStore.Model.CustomEntities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthors _authors;

        public AuthorsController(IAuthors authors)
        {
            _authors = authors;
        }


        [HttpGet("Authors")]
        public ActionResult<List<BookAuthorsEntity>> GetAllAuthors()
        {
            try
            {
                var result = _authors.GetAllAuth();
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
