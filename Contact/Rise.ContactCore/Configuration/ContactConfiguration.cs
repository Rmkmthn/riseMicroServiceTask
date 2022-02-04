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
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(s => s.ContactName).HasMaxLength(100);
        }
    }
}
