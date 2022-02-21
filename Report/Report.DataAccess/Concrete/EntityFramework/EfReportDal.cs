using Core.DataAccess.EntityFramework;
using Report.DataAccess.Abstract;
using Report.DataAccess.Concrete.EntityFramework.Context;
using Report.DataAccess.Entities;

namespace Report.DataAccess.Concrete.EntityFramework
{
    public class EfReportDal : EfEntityRepositoryBase<ContactReport, ReportDbContext>, IReportDal
    {
    }
}
