using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rise.ContactCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ContactUnitTests
{
    public static class DbOptionsFactory
    {
        static DbOptionsFactory()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = config["Data:DefaultConnection:ConnectionString"];

            DbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseNpgsql(connectionString)
                .Options;
        }

        public static DbContextOptions<ApplicationDbContext> DbContextOptions { get; }

    }
}
