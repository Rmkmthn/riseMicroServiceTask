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
    public class CoreTests
    {
        [Fact]
        public void DbContextTest()
        {
            Report test = null;
            using (var _ctx = new ApplicationDbContext(DbOptionsFactory.DbContextOptions))
                test = _ctx.Reports.FirstOrDefault();   

            Assert.NotNull(test);
        }   
    }
}
