using AutoMapper;
using Contact.DataAccess.Dtos;
using Contact.DataAccess.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Contact.API.Utilities.Extensions
{
    public static class MapperExtesions
    {
        private static IMapper _mapper;

        private static IMapper mapper {
            get 
            
            {
                if (_mapper is null)
                    _mapper = StaticServiceProvider.Provider.GetService<IMapper>();

                return _mapper;
            }
        }

        public static Person ToPerson(this PersonAddDto personAddDto)
        {
            return mapper.Map<Person>(personAddDto);
        }
        public static Person ToPerson(this PersonUpdateDto personUpdateDto, Guid guid)
        {
            Person person = mapper.Map<Person>(personUpdateDto);
            person.UUID = guid;
            return person;
        }

        public static ContactInfo ToContactInfo(this ContactInfoAddDto contactInfoAddDto, Guid personUuid)
        {
            ContactInfo contactInfo = mapper.Map<ContactInfo>(contactInfoAddDto);
            contactInfo.PersonUUID = personUuid;
            return contactInfo;
        }
        public static ContactInfo ToContactInfo(this ContactInfoUpdateDto contactInfoUpdateDto, int id, Guid personUuid)
        {
            ContactInfo contactInfo = mapper.Map<ContactInfo>(contactInfoUpdateDto);
            contactInfo.PersonUUID = personUuid;
            contactInfo.Id = id;
            return contactInfo;
        }
    }
}
