using Rise.ContactCore;
using Rise.ContactCore.Business;
using Rise.ContactCore.Models;
using Rise.ContactCore.Models.HelperModels;
using Rise.Shared;
using System;
using System.Linq;
using Xunit;

namespace Rise.ContactUnitTests
{
    public class CoreTests
    {
        [Fact]
        public void DbContextTest()
        {
            Contact test = null;
            using (var _ctx = new ApplicationDbContext(DbOptionsFactory.DbContextOptions))
                test = _ctx.Contacts.FirstOrDefault();   

            Assert.NotNull(test);
        }

        [Fact]
        public void AddContact()
        {
            ContactViewModel oContact = new ContactViewModel
            {
                ContactName = "test",
                ContactSurname = "sds",
                ContactCompany = "comp"
            };

            using (var _ctx = new ApplicationDbContext(DbOptionsFactory.DbContextOptions))
            {
                ContactService _svcContact = new ContactService(_ctx);

                var oResult = _svcContact.AddContact(oContact);

                Assert.NotNull(oResult);
            }
        }

        [Fact]
        public void DeleteContact()
        {
            string strGuid = "8340ebdf-3a79-4293-ae18-c1855adaa19d";

            ReturnObject<bool> oResult = new ReturnObject<bool>();
            using (var _ctx = new ApplicationDbContext(DbOptionsFactory.DbContextOptions))
            {
                using (var _svcContact = new ContactService(_ctx))
                {
                    Guid gID = new Guid(strGuid);

                    oResult = _svcContact.DeleteContact(gID);
                }

                Assert.True(oResult.IsValid && oResult.ResultObject);
            }
        }
        [Fact]
        public void AddContactInfo()
        {
            ContactInfo oContactInfo = new ContactInfo
            {
                ContactRID = new Guid(""),
                InfoTypeRID = new Guid(""),
                InfoValue = ""
            };

            using (var _ctx = new ApplicationDbContext(DbOptionsFactory.DbContextOptions))
            {
                ContactInfoService _svcContactInfo = new ContactInfoService(_ctx);

                var oResult = _svcContactInfo.SaveContactInfo(oContactInfo);

                Assert.True(oResult.IsValid && oResult.ResultObject != null);
            }
        }

        [Fact]
        public void DeleteContactInfo()
        {
            string strGuid = "8340ebdf-3a79-4293-ae18-c1855adaa19d";

            ReturnObject<bool> oResult = new ReturnObject<bool>();
            using (var _ctx = new ApplicationDbContext(DbOptionsFactory.DbContextOptions))
            {
                using (var _svcContactInfo = new ContactInfoService(_ctx))
                {
                    Guid gID = new Guid(strGuid);

                    oResult = _svcContactInfo.DeleteContactInfo(gID);
                }

                Assert.True(oResult.IsValid && oResult.ResultObject);
            }
        }
    }
}
