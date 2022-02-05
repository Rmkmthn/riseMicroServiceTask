using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ReportCore.Models
{
    public class Const : BaseEntity
    {
        public string ConstID { get; set; }

        public string ConstDesc { get; set; }

        public string ConstValue { get; set; }

        public int? ConstOrder { get; set; }

        public virtual ICollection<ConstLang> ConstLangs { get; set; }

        public virtual ICollection<ReportRequest> ReportRequests { get; set; }
    }
}
