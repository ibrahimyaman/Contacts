using Core.DataAccess;
using System;
using System.Collections.Generic;

namespace Contact.DataAccess.Entities
{
    public class Person : IEntity
    {
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public ICollection<ContactInfo> ContactInfos  { get; set; }
    }
}
