﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rest_Web_API.Model;
using Rest_Web_API.Services;

namespace Rest_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private IPersonService _personService;



        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        public PersonController(IPersonService personService)
        {
            _personService = personService;
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
        //[HttpPost]
        //public ActionResult Post([FromBody] Person person)
        //{
            
        //    if (person == null)
        //    {
        //       return BadRequest();
        //    }

        //   // return new ObjectResult(_personService.Create(person));

        //    return Ok(_personService.Create(person));

        //}

        // PUT api/values/5
        [HttpPut("{id}")]
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
