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
        public void A1_AddContactInfo()
        {
            ContactInfo oContactInfo = new ContactInfo
            {
                ContactRID = new Guid("267eda3f-96c8-42e5-b59f-d30eab8f3d70"),
                InfoTypeRID = new Guid("66ba54e7-a1d4-4f3f-8a4c-696fbf25b263"),
                InfoValue = "tolkuba@gmail.com"
            };

            using (var _ctx = new ApplicationDbContext(DbOptionsFactory.DbContextOptions))
            {
                ContactInfoService _svcContactInfo = new ContactInfoService(_ctx);

                var oResult = _svcContactInfo.SaveContactInfo(oContactInfo);

                Assert.True(oResult.IsValid && oResult.ResultObject != null);
            }
        }

        [Fact]
        public void A2_AddContactInfo()
        {
            ContactInfo oContactInfo = new ContactInfo
            {
                Id = new Guid("267eda3f-96c8-42e5-b59f-d30eab8f3d70"),
                ContactRID = new Guid("267eda3f-96c8-42e5-b59f-d30eab8f3d70"),
                InfoTypeRID = new Guid("66ba54e7-a1d4-4f3f-8a4c-696fbf25b263"),
                InfoValue = "tolkuba@xxx.com"
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

        [Fact]
        public void GetContactWithInfo()
        {
            string strGuid = "267eda3f-96c8-42e5-b59f-d30eab8f3d70";

            Contact oResult = null;
            using (var _ctx = new ApplicationDbContext(DbOptionsFactory.DbContextOptions))
            {
                using (var _svcContact = new ContactService(_ctx))
                {
                    Guid gID = new Guid(strGuid);

                    oResult = _svcContact.GetContactWithInfo(gID);
                }

                Assert.True(oResult != null && oResult.ContactInfos?.Count > 0);
            }
        }
    }
}
