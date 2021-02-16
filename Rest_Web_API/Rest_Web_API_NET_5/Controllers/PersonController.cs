using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rest_Web_API_NET_5.Model;
using Rest_Web_API_NET_5.Services;
using Rest_Web_API_NET_5.Services.Implementacao;

namespace Rest_Web_API_NET_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        private IPersonService _personService;

        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }




       // GET api/values
       [HttpGet]
        public ActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var person = _personService.FindById(id);
            if (person == null)
            {
                NotFound();
            }

            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {

            if (person == null)
            {
                return BadRequest();
            }

            // return new ObjectResult(_personService.Create(person));

            return Ok(_personService.Create(person));

        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] Person person)
        {

            if (person == null)
            {
                return BadRequest();
            }

            return Ok(_personService.Update(person));

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _personService.Delete(id);

            return NoContent();
        }
    }
}
