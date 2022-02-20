using Contact.DataAccess.Entities;
using Core.DataAccess;

namespace Contact.DataAccess.Abstract
{
    public interface IPersonDal : IReadOnlyEntityRepository<Person>, ICRUDEntityRepository<Person>
    {
    }
}
