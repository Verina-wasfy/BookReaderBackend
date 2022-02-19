using BookStore.Business.Publishers;
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
    public class PublishersController : ControllerBase
    {
        private readonly IPublishers _pubs;

        public PublishersController(IPublishers pubs)
        {
            _pubs = pubs;
        }


        [HttpGet("Publishers")]
        public ActionResult<List<PublishersEntity>> GetAllPublishers()
        {
            try
            {
                var result = _pubs.GetAllPublish();
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
