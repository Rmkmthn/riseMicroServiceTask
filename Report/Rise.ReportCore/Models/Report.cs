using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ReportCore.Models
{
    public class Report : BaseEntity
    {
        public string ReportID { get; set; }
        public string ReportName { get; set; }
    }
}
