using Contact.Bussiness.Abstract;
using Contact.DataAccess.Abstract;
using Contact.DataAccess.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contact.Bussiness.Concrete
{
    public class PersonService : IPersonService
    {
        private readonly IPersonDal _personDal;
        private readonly IContactInfoDal _contactInfoDal;

        public PersonService(IPersonDal personDal, IContactInfoDal contactInfoDal)
        {
            _personDal = personDal;
            _contactInfoDal = contactInfoDal;
        }

        public IDataResult<Person> Add(Person person)
        {
            _personDal.Add(person);

            return new SuccessDataResult<Person>(person);
        }
        public IDataResult<Person> Update(Person person)
        {
            var oldPerson = _personDal.Get(w => w.UUID.Equals(person.UUID));
            if (oldPerson is null)
                return new ErrorDataResult<Person>("Record not found");

            _personDal.Update(person);

            return new SuccessDataResult<Person>(person);
        }
        public IDataResult<Person> Delete(Guid uuid)
        {
            var person = _personDal.Get(w => w.UUID.Equals(uuid));
            if (person is null)
                return new ErrorDataResult<Person>("Record not found");

            _personDal.Delete(person);

            return new SuccessDataResult<Person>(person);
        }

        public IDataResult<IList<Person>> GetAll()
        {
            return new SuccessDataResult<IList<Person>>(_personDal.GetList().ToList());
        }

        public IDataResult<Person> GetByUuid(Guid uuid)
        {
            var person = _personDal.Get(w => w.UUID.Equals(uuid));
            if (person is null)
                return new ErrorDataResult<Person>("Record not found");

            return new SuccessDataResult<Person>(person);
        }

        public IDataResult<IList<ContactInfo>> GetContactInfosByPersonUuid(Guid personUuid)
        {
            var person = _personDal.Get(w => w.UUID.Equals(personUuid));
            if (person is null)
                return new ErrorDataResult<IList<ContactInfo>>("Record not found");

            var contactInfos = _contactInfoDal.GetList(w => w.PersonUUID.Equals(personUuid));

            throw new NotImplementedException();
        }

        public IDataResult<ContactInfo> GetContactInfoById(int id)
        {
            var contactInfo = _contactInfoDal.Get(w => w.Id.Equals(id));
            if (contactInfo is null)
                return new ErrorDataResult<ContactInfo>("Record not found");

            return new SuccessDataResult<ContactInfo>(contactInfo);
        }
    }
}
