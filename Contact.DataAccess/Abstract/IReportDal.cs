using Contact.DataAccess.Entities;
using Core.DataAccess;

namespace Contact.DataAccess.Abstract
{
    public interface IReportDal : IReadOnlyEntityRepository<Report>, ICRUDEntityRepository<Report>
    {
    }
}
