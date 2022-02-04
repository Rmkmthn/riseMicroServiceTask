using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ContactCore.Models
{
    public class Contact : BaseEntity
    {
        public string ContactName { get; set; }

        public string ContactSurname { get; set; }

        public string ContactCompany { get; set; }
    }
}
