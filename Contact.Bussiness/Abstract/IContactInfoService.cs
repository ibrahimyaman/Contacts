using Contact.DataAccess.Constant;
using Contact.DataAccess.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;

namespace Contact.Bussiness.Abstract
{
    public interface IContactInfoService
    {
        IDataResult<IDictionary<string, InfoType>> GetContactInfoTypes();
        IDataResult<IList<ContactInfo>> GetAllByPersonUuid(Guid uuid);
        IDataResult<ContactInfo> GetById(int id);
        IDataResult<ContactInfo> Add(ContactInfo contactInfo);
        IDataResult<ContactInfo> Update(ContactInfo contactInfo);
        IDataResult<ContactInfo> Delete(int id);
    }
}
