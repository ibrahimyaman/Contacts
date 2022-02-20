using Contact.DataAccess.Constant;
using Core.DataAccess;
using System;

namespace Contact.DataAccess.Entities
{
    public class ContactInfo : IEntity
    {
        public int Id { get; set; }
        public Guid PersonUUID { get; set; }
        public Person Person { get; set; }
        public InfoType InfoType { get; set; }
        public string Info { get; set; }
    }
}
