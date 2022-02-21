using ClosedXML.Excel;
using Contact.Bussiness.Abstract;
using Contact.Bussiness.Constant;
using Contact.DataAccess.Abstract;
using Contact.DataAccess.Constant;
using Contact.DataAccess.Entities;
using Core.MessageQueue;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Contact.Bussiness.Concrete
{
    public class ReportService : IReportService
    {
        private readonly IReportDal _reportDal;
        private readonly IPersonDal _personDal;
        private readonly IMessageQueueService _messageQueueService;

        public ReportService(IReportDal reportDal, IMessageQueueService messageQueueService, IPersonDal personDal)
        {
            _reportDal = reportDal;
            _messageQueueService = messageQueueService;
            _personDal = personDal;
        }

        public IDataResult<Report> CreateReport()
        {
            var report = new Report
            {
                Status = ReportStatus.Preparing,
                RequestedDateTime = DateTime.Now
            };

            _reportDal.Add(report);

            var messageQueueObject = new QueueMessage<Guid, QueueProc> { Proccess = QueueProc.CreateReport, Data = report.UUID };
            var message = JsonSerializer.Serialize(messageQueueObject);

            _messageQueueService.SendMessage(QueueNames.Contact, message);

            return new SuccessDataResult<Report>(report);
        }

        public IDataResult<IList<Report>> GetAll()
        {
            return new SuccessDataResult<IList<Report>>(_reportDal.GetList().ToList());
        }

        public IDataResult<Report> GetByUuid(Guid uuid)
        {
            var report = _reportDal.Get(w => w.UUID.Equals(uuid));
            if (report is null)
                return new ErrorDataResult<Report>("Record not found");

            return new SuccessDataResult<Report>(report);
        }

        public IDataResult<string> PrepareReportFile(Guid uuid, string folderPath)
        {
            var people = _personDal.GetList(includes: i => i.ContactInfos);
            var locations = people.SelectMany(s => s.ContactInfos).Where(w => w.InfoType.Equals(InfoType.Location)).ToList();

            if (locations.Count < 1)
                return new ErrorDataResult<string>(string.Empty);

            var filePath = Path.Combine(folderPath, $"{uuid.ToString().ToUpper()} {DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx");
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Contacts");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Location";
                worksheet.Cell(currentRow, 2).Value = "Total Contact";
                worksheet.Cell(currentRow, 3).Value = "Total Phone";

                var result = locations.GroupBy(g => g.Info).Select(s =>
                  new
                  {
                      Location = s.Key,
                      PeopleCount = s.Count(),
                      PhonesCount = s.SelectMany(ss => ss.Person.ContactInfos.Where(w => w.InfoType.Equals(InfoType.Phone))).Count()
                  });

                foreach (var item in result)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.Location;
                    worksheet.Cell(currentRow, 2).Value = item.PeopleCount;
                    worksheet.Cell(currentRow, 3).Value = item.PhonesCount;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    using (var file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {                       
                        stream.WriteTo(file);
                        file.Close();
                    }
                    stream.Close();
                }
            }

            return new SuccessDataResult<string>(filePath);
        }

        public IDataResult<Report> UpdateReport(Report report)
        {
            var oldReport = _reportDal.Get(w => w.UUID.Equals(report.UUID));
            if (oldReport is null)
                return new ErrorDataResult<Report>("Record not found");

            _reportDal.Update(report);

            return new SuccessDataResult<Report>(report);
        }
    }
}
