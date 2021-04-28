using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rest_Web_API_NET_5.Data.VO;
using Rest_Web_API_NET_5.Model;
<<<<<<< HEAD
using Rest_Web_API_NET_5.Services;
=======
using Rest_Web_API_NET_5.Repository;
>>>>>>> d51d9278772cc8945ed97ff1b3e2bda77e2b2146

namespace Rest_Web_API_NET_5.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        private readonly IPersonBusiness _personBusiness;

        public  PersonController(IPersonBusiness personBusiness, ILogger<PersonController> logger)
        {
            _personBusiness = personBusiness;
            _logger = logger;
        }




        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null)
            {
                NotFound();
            }

            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] PersonVO person)
        {

            if (person == null)
            {
                return BadRequest();
            }

            // return new ObjectResult(_personService.Create(PersonVO));

            return Ok(_personBusiness.Create(person));

        }

        // PUT api/values/5
        [HttpPut]
<<<<<<< HEAD
        public ActionResult Put([FromBody] Person person)
=======
        public ActionResult Put([FromBody] PersonVO person)
>>>>>>> d51d9278772cc8945ed97ff1b3e2bda77e2b2146
        {

            if (person == null)
            {
                return BadRequest();
            }

            return Ok(_personBusiness.Update(person));

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _personBusiness.Delete(id);

            return NoContent();
        }
    }
}
