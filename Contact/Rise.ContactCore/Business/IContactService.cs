using Rise.ContactCore.Models;
using Rise.ContactCore.Models.HelperModels;
using System;

namespace Rise.ContactCore.Business
{
    public interface IContactService
    {
        Contact AddContact(ContactViewModel oNewContact);

        bool DeleteContact(Guid gID);
    }
}