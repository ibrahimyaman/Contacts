using Contact.DataAccess.Constant;
using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Contact.DataAccess.Dtos
{
    public class ContactInfoAddDto : IDto
    {
        [Required]
        public InfoType InfoType { get; set; }
        public string Info { get; set; }
    }
}
