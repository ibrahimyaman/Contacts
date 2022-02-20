using AutoMapper;
using Contact.DataAccess.Dtos;
using Contact.DataAccess.Entities;

namespace Contact.API.Utilities.Mapper.AutoMapperProfiles
{
    public class ContactInfoProfile : Profile
    {
        public ContactInfoProfile()
        {
            CreateMap<ContactInfoAddDto, ContactInfo>();
            CreateMap<ContactInfoUpdateDto, ContactInfo>();
        }
    }
}
