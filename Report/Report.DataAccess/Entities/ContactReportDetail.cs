using System;
using System.Collections.Generic;
using System.Text;

namespace Report.DataAccess.Entities
{
    public class ContactReportDetail
    {
        public int MyProperty { get; set; }
        public Guid ContactReportUuid { get; set; }
        public ContactReport ContactReport { get; set; }

    }
}
