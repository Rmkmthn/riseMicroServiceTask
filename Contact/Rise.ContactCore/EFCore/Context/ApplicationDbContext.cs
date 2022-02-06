using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rise.ContactCore.Models;
namespace Rise.ContactCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Const> Consts { get; set; }
        public DbSet<ConstLang> ConstLangs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<Const>().HasData(new Const[] {
                new Const{Id=Guid.NewGuid(),ConstID="ContactInfoTypes",ConstDesc="Cell Phone",ConstValue = "0",ConstOrder = 0},
                new Const{Id=Guid.NewGuid(),ConstID="ContactInfoTypes",ConstDesc="E-Mail",ConstValue = "1",ConstOrder = 1},
                new Const{Id=Guid.NewGuid(),ConstID="ContactInfoTypes",ConstDesc="Location",ConstValue = "2",ConstOrder = 2},
                new Const{Id=Guid.NewGuid(),ConstID="ReportStatus",ConstDesc="Preparing",ConstValue = "0",ConstOrder = 0},
                new Const{Id=Guid.NewGuid(),ConstID="ReportStatus",ConstDesc="Completed",ConstValue = "1",ConstOrder = 1},                
            });

            modelBuilder.Entity<ContactInfo>()
                        .HasIndex(c => new { c.ContactRID, c.InfoTypeRID })
                        .IsUnique();

            modelBuilder.Entity<ContactInfo>()
                        .HasIndex(c => c.ContactRID);

            modelBuilder.Entity<ContactInfo>()
                        .HasIndex(c => c.InfoTypeRID);

            modelBuilder.Entity<Contact>()
                        .HasIndex(c => c.ContactCompany);           

            modelBuilder.Entity<ContactInfo>()
                .HasOne<Contact>(g => g.Contact)
                .WithMany(s => s.ContactInfos)
                .HasForeignKey(s => s.ContactRID);

            modelBuilder.Entity<ContactInfo>()
                .HasOne<Const>(g => g.ConstInfoType)
                .WithMany(s => s.ContactInfos)
                .HasForeignKey(s => s.InfoTypeRID);

            modelBuilder.Entity<ConstLang>()
               .HasOne<Const>(g => g.Const)
               .WithMany(s => s.ConstLangs)
               .HasForeignKey(s => s.ConstRID);

            modelBuilder.Entity<Const>()
                        .HasIndex(c => new { c.ConstID, c.ConstValue })
                        .IsUnique();
        }
    }

}
