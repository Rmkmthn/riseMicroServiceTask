using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rise.ReportCore;
using Rise.ReportCore.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rise.ReportCore.Configuration
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
