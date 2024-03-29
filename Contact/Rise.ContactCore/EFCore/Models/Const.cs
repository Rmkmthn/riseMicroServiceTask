﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ContactCore.Models
{
    public class Const : BaseEntity
    {
        public string ConstID { get; set; }

        public string ConstDesc { get; set; }

        public string ConstValue { get; set; }

        public int? ConstOrder { get; set; }

        public ICollection<ConstLang> ConstLangs { get; set; }

        public ICollection<ContactInfo> ContactInfos { get; set; }
    }
}
