using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rest_Web_API_NET_5.Business;
using Rest_Web_API_NET_5.Model;
using Rest_Web_API_NET_5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Web_API_NET_5.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;


        private IBookBusiness _bookbusiness;


        public BookController(IBookBusiness bookbusiness,ILogger<PersonController> logger)
        {
            _logger = logger;
            _bookbusiness = bookbusiness;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookbusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_bookbusiness.FindById(id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            return Ok(_bookbusiness.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            return Ok(_bookbusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           _bookbusiness.Delete(id);

            return NoContent();
        }

    }
}
