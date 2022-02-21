using Contact.Bussiness.Abstract;
using Contact.Bussiness.Constant;
using Core.MessageQueue;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.API.Services
{
    public class ReportCreatorService : BackgroundService
    {
        private readonly IReportService _reportService;
        private readonly IMessageQueueService _messageQueueService;
        private readonly string reportSaveFolder;

        public ReportCreatorService(IServiceProvider serviceProvider, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _reportService = serviceProvider.CreateScope().ServiceProvider.GetService<IReportService>();
            _messageQueueService = serviceProvider.CreateScope().ServiceProvider.GetService<IMessageQueueService>();

            reportSaveFolder = Path.Combine(env.WebRootPath, "report");
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _messageQueueService.RecieveMessage(QueueNames.Contact, DoWork);

            return Task.CompletedTask;
        }
        private bool DoWork(string message)
        {
            try
            {
                var queueMessage = JsonSerializer.Deserialize<QueueMessage<Guid, QueueProc>>(message);
                switch (queueMessage.Proccess)
                {
                    case QueueProc.CreateReport:
                    var result = _reportService.PrepareReportFile(queueMessage.Data, reportSaveFolder);
                    if (result.Success)
                    {
                        var report = _reportService.GetByUuid(queueMessage.Data);
                        if (report.Data != null)
                        {
                            report.Data.Path = result.Data;
                            report.Data.Status = DataAccess.Constant.ReportStatus.Done;
                            _reportService.UpdateReport(report.Data);
                        }
                    }
                    else
                        return false;
                    break;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
