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
    public class ReportRequestConfiguration : IEntityTypeConfiguration<ReportRequest>
    {
        public void Configure(EntityTypeBuilder<ReportRequest> builder)
        {
        }
    }
}
