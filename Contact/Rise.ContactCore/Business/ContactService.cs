using Microsoft.EntityFrameworkCore;
using Rise.ContactCore.Models;
using Rise.ContactCore.Models.HelperModels;
using Rise.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ContactCore.Business
{
    public interface IContactService
    {
        Contact AddContact(ContactViewModel oNewContact);

        ReturnObject<bool> DeleteContact(Guid gID);

        IQueryable<Contact> GetContacts();

        Contact GetContactWithInfo(Guid gID);
    }
    public class ContactService : IContactService, IDisposable
    {
        private readonly ApplicationDbContext _ctxApplication;

        public ContactService(ApplicationDbContext ctxApplication)
        {
            _ctxApplication = ctxApplication;
        }

        public Contact AddContact(ContactViewModel oNewContact)
        {
            var oPostContact = new Contact
            {
                ContactName = oNewContact.ContactName,
                ContactSurname = oNewContact.ContactSurname,
                ContactCompany = oNewContact.ContactCompany
            };

            _ctxApplication.Add(oPostContact);
            _ctxApplication.SaveChanges();

            return oPostContact;
        }

        public ReturnObject<bool> DeleteContact(Guid gID)
        {
            ReturnObject<bool> oResult = new ReturnObject<bool>();
            bool blnResult = true;
            try
            {
                var oContact = (Contact)_ctxApplication.Find(typeof(Contact), gID);
                if (oContact != null)
                {
                    _ctxApplication.Remove(oContact);
                    _ctxApplication.SaveChanges();
                }
                else
                    blnResult = false;
            }
            catch (Exception ex)
            {
                string strErrorMsg = string.Format("Error : {0} -- Detail : {1}", ex.Message, ex.InnerException);
                Console.WriteLine(strErrorMsg);
                oResult.AddError(Guid.NewGuid().ToString("N"), strErrorMsg);
                blnResult = false;
            }

            oResult.ResultObject = blnResult;
            return oResult;
        }

        public IQueryable<Contact> GetContacts()
        {
            return _ctxApplication.Contacts;
        }

        public Contact GetContactWithInfo(Guid gID)
        {
            return _ctxApplication.Contacts.Include(x => x.ContactInfos).Where(c => c.Id == gID).FirstOrDefault();
        }

        public void Dispose()
        {
        }
    }
}
