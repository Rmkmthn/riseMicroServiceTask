using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ReportCore.Models.HelperModels
{
    //Db view yapilabilir.
    public class ReportRequestViewModel
    {
        public Guid ReportRID { get; set; }

        public string ReportID { get; set; }

        public string ReportName { get; set; }

        public DateTimeOffset? ReportRequestedDate { get; set; }
        public string ReportStatusDesc { get; set; }
    }
}
