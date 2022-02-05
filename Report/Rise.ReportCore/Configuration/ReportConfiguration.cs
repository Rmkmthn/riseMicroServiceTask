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
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.Property(s => s.ReportName).HasMaxLength(100);
            builder.HasData(new Report[] {
                new Report{Id=Guid.NewGuid(),ReportID="00001",ReportName="Statistics of Contact by Location"}                
            });
        }
    }
}
