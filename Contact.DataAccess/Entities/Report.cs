using Contact.DataAccess.Constant;
using Core.DataAccess;
using System;

namespace Contact.DataAccess.Entities
{
    public class Report : IEntity
    {
        public Guid UUID { get; set; }
        public DateTime RequestedDateTime { get; set; }
        public ReportStatus Status { get; set; }
        public string Path { get; set; }
    }
}
