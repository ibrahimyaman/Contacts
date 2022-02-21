using Core.DataAccess;
using Report.DataAccess.Entities;

namespace Report.DataAccess.Abstract
{
    public interface IReportDal : IReadOnlyEntityRepository<ContactReport>, ICRUDEntityRepository<ContactReport>
    {
    }
}
