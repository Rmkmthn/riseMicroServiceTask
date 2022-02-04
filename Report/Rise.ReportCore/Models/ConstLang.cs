using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ReportCore.Models
{
    public class ConstLang : BaseEntity
    {
        public string LangID { get; set; }

        public Guid ConstRID { get; set; }

        public string ConstLangDesc { get; set; }

        public Const Const { get; set; }
    }
}
