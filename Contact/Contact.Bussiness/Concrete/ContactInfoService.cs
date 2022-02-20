using Contact.Bussiness.Abstract;
using Contact.DataAccess.Abstract;
using Contact.DataAccess.Constant;
using Contact.DataAccess.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact.Bussiness.Concrete
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly IContactInfoDal _contactInfoDal;
        private readonly IPersonDal  _personDal;

        public ContactInfoService(IContactInfoDal contactInfoDal, IPersonDal personDal)
        {
            _contactInfoDal = contactInfoDal;
            _personDal = personDal;
        }

        public IDataResult<ContactInfo> Add(ContactInfo contactInfo)
        {
            var person = _personDal.Get(w => w.UUID.Equals(contactInfo.PersonUUID));
            if (person is null)
                return new ErrorDataResult<ContactInfo>(contactInfo, "Person not found");

            _contactInfoDal.Add(contactInfo);

            return new SuccessDataResult<ContactInfo>(contactInfo);
        }

        public IDataResult<ContactInfo> Delete(int id)
        {
            var contactInfo = _contactInfoDal.Get(w => w.Id.Equals(id));
            if (contactInfo is null)
                return new ErrorDataResult<ContactInfo>("Record not found");

            _contactInfoDal.Delete(contactInfo);

            return new SuccessDataResult<ContactInfo>(contactInfo);
        }

        public IDataResult<IList<ContactInfo>> GetAllByPersonUuid(Guid uuid)
        {
            return new SuccessDataResult<IList<ContactInfo>>(_contactInfoDal.GetList(w => w.PersonUUID.Equals(uuid)));
        }

        public IDataResult<ContactInfo> GetById(int id)
        {
            var contactInfo = _contactInfoDal.Get(w => w.Id.Equals(id));
            if (contactInfo is null)
                return new ErrorDataResult<ContactInfo>("Record not found");

            return new SuccessDataResult<ContactInfo>(contactInfo);
        }

        public IDataResult<IDictionary<string, InfoType>> GetContactInfoTypes()
        {
            var enumList = Enum.GetValues(typeof(InfoType)).Cast<InfoType>().ToDictionary(d => d.ToString());
            return new SuccessDataResult<IDictionary<string, InfoType>>(enumList);
        }

        public IDataResult<ContactInfo> Update(ContactInfo contactInfo)
        {
            var oldContactInfo = _contactInfoDal.Get(w => w.Id.Equals(contactInfo.Id));
            if (oldContactInfo is null)
                return new ErrorDataResult<ContactInfo>("Record not found");

            _contactInfoDal.Update(contactInfo);

            return new SuccessDataResult<ContactInfo>(contactInfo);
        }
    }
}
