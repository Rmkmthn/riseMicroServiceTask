using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rise.ReportCore.Models;
namespace Rise.ReportCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Const> Consts { get; set; }
        public DbSet<ConstLang> ConstLangs { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportRequest> ReportRequests { get; set; }
                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<Const>().HasData(new Const[] {
                new Const{Id=Guid.NewGuid(),ConstID="ReportInfoTypes",ConstDesc="Cell Phone",ConstValue = "0",ConstOrder = 0},
                new Const{Id=Guid.NewGuid(),ConstID="ReportInfoTypes",ConstDesc="E-Mail",ConstValue = "1",ConstOrder = 1},
                new Const{Id=Guid.NewGuid(),ConstID="ReportInfoTypes",ConstDesc="Location",ConstValue = "2",ConstOrder = 2},
                new Const{Id=Guid.NewGuid(),ConstID="ReportStatus",ConstDesc="Preparing",ConstValue = "0",ConstOrder = 0},
                new Const{Id=Guid.NewGuid(),ConstID="ReportStatus",ConstDesc="Completed",ConstValue = "1",ConstOrder = 1},                
            });

            //modelBuilder.Entity<ReportRequest>()
            //.Property(p => p.Id)
            //.HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<ReportRequest>()
                .HasOne<Const>(g => g.ConstReportStatus)
                .WithMany(s => s.ReportRequests)
                .HasForeignKey(s => s.ReportStatusRID);

            modelBuilder.Entity<ConstLang>()
               .HasOne<Const>(g => g.Const)
               .WithMany(s => s.ConstLangs)
               .HasForeignKey(s => s.ConstRID);
        }
    }

}
