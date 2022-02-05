using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ReportCore.Models
{
    public class ReportRequest : BaseEntity
    {
        public Guid ReportRID { get; set; }
        public DateTimeOffset? RequestedDate { get; set; }

        public Guid ReportStatusRID { get; set; }

        public string ReportFilePath { get; set; }

        public virtual Const ConstReportStatus { get; set; }

        public virtual Report Report { get; set; }
    }
}
