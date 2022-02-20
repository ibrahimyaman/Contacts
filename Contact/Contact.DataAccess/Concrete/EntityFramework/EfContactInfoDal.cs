using Contact.DataAccess.Abstract;
using Contact.DataAccess.Concrete.EntityFramework.Context;
using Contact.DataAccess.Entities;
using Core.DataAccess.EntityFramework;

namespace Contact.DataAccess.Concrete.EntityFramework
{
    public  class EfContactInfoDal : EfEntityRepositoryBase<ContactInfo, ContactDbContext>, IContactInfoDal
    {
    }
}
