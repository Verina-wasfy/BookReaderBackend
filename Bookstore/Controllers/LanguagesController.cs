using BookStore.Business.Languages;
using BookStore.Model.CustomEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguages _languages;

        public LanguagesController(ILanguages Languages)
        {
            _languages = Languages;
        }


        [HttpGet("Languages")]
        public ActionResult<List<BookLanguagesEntity>> GetAllLangs()
        {
            try
            {
                var result = _languages.GetAllLang();
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
