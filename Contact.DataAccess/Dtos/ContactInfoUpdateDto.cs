using Contact.DataAccess.Constant;
using Core.DataAccess;

namespace Contact.DataAccess.Dtos
{
    public class ContactInfoUpdateDto : IDto
    {
        public InfoType InfoType { get; set; }
        public string Info { get; set; }
    }
}
