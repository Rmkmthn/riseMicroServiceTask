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
    public class ConstConfiguration : IEntityTypeConfiguration<Const>
    {
        public void Configure(EntityTypeBuilder<Const> builder)
        {
            builder.Property(s => s.ConstID).HasMaxLength(20);
            builder.Property(s => s.ConstDesc).HasMaxLength(100);
        }
    }
}
