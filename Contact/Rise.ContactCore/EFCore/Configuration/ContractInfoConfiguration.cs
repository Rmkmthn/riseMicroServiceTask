using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rise.ContactCore;
using Rise.ContactCore.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rise.ContactCore.Configuration
{
    public class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.Property(s => s.InfoValue).HasMaxLength(100);
        }
    }
}
