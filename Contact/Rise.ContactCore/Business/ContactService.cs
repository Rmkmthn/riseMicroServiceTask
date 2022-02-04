using Rise.ContactCore.Models;
using Rise.ContactCore.Models.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ContactCore.Business
{
    public class ContactService : IContactService
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

        public bool DeleteContact(Guid gID)
        {
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
                Console.WriteLine(ex.Message);
                blnResult = false;
            }

            return blnResult;
        }
    }
}
