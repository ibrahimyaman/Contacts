using Contact.DataAccess.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;

namespace Contact.Bussiness.Abstract
{
    public interface IPersonService
    {
        IDataResult<IList<Person>> GetAll();
        IDataResult<Person> GetByUuid(Guid uuid);
        IDataResult<Person> Add(Person person);
        IDataResult<Person> Update(Person person);
        IDataResult<Person> Delete(Guid uuid);
        IDataResult<IList<ContactInfo>> GetContactInfosByPersonUuid(Guid personUuid);
        IDataResult<ContactInfo> GetContactInfoById(int id);
    }
}
