using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Events
{
    public record ReportRequestedIntegrationEvent : IntegrationEvent
    {
        public Guid ReportRequestRID { get; set; }
        public Guid ReportRID { get; set; }
        public string ReportID { get; set; }
        public string ReportName { get; set; }
        public DateTimeOffset? ReportRequestedDate { get; set; }
        public string ReportStatusDesc { get; set; }

        public string ReportStatusValue { get; set; }
        public ReportRequestedIntegrationEvent(Guid gID, Guid _ReportRID, string _ReportID, string _ReportName, DateTimeOffset? _ReportRequestedDate, string _ReportStatusDesc, string _ReportStatusValue)
        {
            ReportRequestRID = gID;
            ReportRID = _ReportRID;
            ReportID = _ReportID;
            ReportName = _ReportName;
            ReportRequestedDate = _ReportRequestedDate;
            ReportStatusDesc = _ReportStatusDesc;
            ReportStatusValue = _ReportStatusValue;
        }

    }
}
