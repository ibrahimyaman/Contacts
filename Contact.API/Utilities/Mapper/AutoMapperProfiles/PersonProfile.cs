using AutoMapper;
using Contact.DataAccess.Dtos;
using Contact.DataAccess.Entities;

namespace Contact.API.Utilities.Mapper.AutoMapperProfiles
{
    public class PersonProfile:Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonAddDto, Person>();
            CreateMap<PersonUpdateDto, Person>();
        }
    }
}
