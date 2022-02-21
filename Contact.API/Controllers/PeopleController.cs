using Contact.API.Utilities.Extensions;
using Contact.Bussiness.Abstract;
using Contact.DataAccess.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]   
    public class PeopleController : BaseController
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult GetAll()
        {
            return Ok(_personService.GetAll());
        }
        [HttpGet("{uuid:guid}")]
        public IActionResult Get(Guid uuid)
        {
            var result = _personService.GetByUuid(uuid);
            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPost]
        public IActionResult Add(PersonAddDto person)
        {
            if(!ModelState.IsValid)
                return NotValid(person);

            var result = _personService.Add(person.ToPerson());
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPut("{uuid:guid}")]
        public IActionResult Update(Guid uuid, PersonUpdateDto person)
        {
            if (!ModelState.IsValid)
                return NotValid(person);

            var result = _personService.Update(person.ToPerson(uuid));
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpDelete("{uuid:guid}")]
        public IActionResult Delete(Guid uuid) 
        {
            var result = _personService.Delete(uuid);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }       
    }
}
