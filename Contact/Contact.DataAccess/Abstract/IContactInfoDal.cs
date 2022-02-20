using Contact.DataAccess.Entities;
using Core.DataAccess;

namespace Contact.DataAccess.Abstract
{
    public interface IContactInfoDal : IReadOnlyEntityRepository<ContactInfo>, ICRUDEntityRepository<ContactInfo>
    {
    }
}
