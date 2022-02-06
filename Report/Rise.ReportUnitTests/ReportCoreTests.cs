using Rise.ContactUnitTests;
using Rise.ReportCore;
using Rise.ReportCore.Business;
using Rise.ReportCore.Models;
using Rise.Shared;
using System;
using System.Linq;
using Xunit;

namespace Rise.ReportUnitTests
{
    public class ReportCoreTests
    {
        [Fact]
        public void DbContextTest()
        {
            Report test = null;
            using (var _ctx = new ApplicationDbContext(DbOptionsFactory.DbContextOptions))
                test = _ctx.Reports.FirstOrDefault();   

            Assert.NotNull(test);
        }
        [Fact]
        public void GetReportDetail()
        {
            using (var _ctx = new ApplicationDbContext(DbOptionsFactory.DbContextOptions))
            {
                var _svcReport = new ReportService(_ctx);

                var lstResult = _svcReport.GetReport00001Detail().Result;


                Assert.True(lstResult.IsValid && lstResult.ResultObject?.Count > 0);
            }
        }
    }
}
