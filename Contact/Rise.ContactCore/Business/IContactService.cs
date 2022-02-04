using Rise.ContactCore.Models;
using Rise.ContactCore.Models.HelperModels;
using Rise.Shared;
using System;

namespace Rise.ContactCore.Business
{
    public interface IContactService
    {
        Contact AddContact(ContactViewModel oNewContact);

        ReturnObject<bool> DeleteContact(Guid gID);
    }
}