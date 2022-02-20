using Contact.DataAccess.Constant;
using Core.DataAccess;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contact.DataAccess.Entities
{
    public class Report : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UUID { get; set; }
        public DateTime RequestedDateTime { get; set; }
        public ReportStatus Status { get; set; }
        public string Path { get; set; }
    }
}
