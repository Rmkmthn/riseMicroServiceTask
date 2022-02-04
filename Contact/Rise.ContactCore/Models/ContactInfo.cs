using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ContactCore.Models
{
    public class ContactInfo : BaseEntity
    {
        public Guid ContactRID { get; set; }
        public Guid InfoTypeRID { get; set; }

        public string InfoValue { get; set; }
    }
}
