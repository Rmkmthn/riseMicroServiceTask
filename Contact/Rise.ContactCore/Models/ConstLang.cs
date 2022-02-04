using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ContactCore.Models
{
    public class ConstLang : BaseEntity
    {
        public string LangID { get; set; }

        public Guid ConstRID { get; set; }

        public int ConstLangDesc { get; set; }
    }
}
