using Core.DataAccess;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report.DataAccess.Entities
{
    public class ContactReport : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UUID { get; set; }
        public DateTime RequestDatetime { get; set; }
        public ReportStatus Status { get; set; }
    }
}
