using Contact.DataAccess.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;

namespace Contact.Bussiness.Abstract
{
    public interface IReportService
    {
        IDataResult<IList<Report>> GetAll();
        IDataResult<Report> GetByUuid(Guid uuid);
        IDataResult<Report> CreateReport();
        IDataResult<Report> UpdateReport(Report report);
        IDataResult<string> PrepareReportFile(Guid uuid, string folderPath);
    }
}
