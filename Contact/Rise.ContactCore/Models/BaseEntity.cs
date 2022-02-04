using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ContactCore.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public bool? Deleted { get; set; }

        public DateTimeOffset? CDate { get; set; } = new DateTimeOffset();

        public DateTimeOffset? MDate { get; set; }
    }
}
