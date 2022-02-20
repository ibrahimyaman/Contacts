using Contact.API.Utilities.Extensions;
using Contact.Bussiness.Abstract;
using Contact.DataAccess.Dtos;
using Contact.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Contact.API.Controllers
{
    [Route("api/people/{personUuid:guid}/[controller]")]    
    public class ContactInfosController : BaseController
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfosController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }
        [HttpGet]
        [Route("/api/infotypes")]
        public IActionResult GetContactInfoTypes()
        {
            var result = _contactInfoService.GetContactInfoTypes();
            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }
        [HttpGet]
        public IActionResult GetContactInfos(Guid personUuid)
        {
            var result = _contactInfoService.GetAllByPersonUuid(personUuid);
            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetContactInfo(int id)
        {
            var result = _contactInfoService.GetById(id);
            if (result.Success)
                return Ok(result);

            return NotFound(result);
        }

        [HttpPost]
        public IActionResult Add(Guid personUuid, ContactInfoAddDto contactInfo)
        {
            if (!ModelState.IsValid)
                return NotValid(contactInfo);

            var result = _contactInfoService.Add(contactInfo.ToContactInfo(personUuid));
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPut("{id:int}")]
        public IActionResult Update(Guid personUuid, int id, ContactInfoUpdateDto contactInfo)
        {
            if (!ModelState.IsValid)
                return NotValid(contactInfo);

            var result = _contactInfoService.Update(contactInfo.ToContactInfo(id, personUuid));
            if (result.Success)
                return Ok();

            return BadRequest(result);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _contactInfoService.Delete(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
