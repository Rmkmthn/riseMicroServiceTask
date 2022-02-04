using Rise.ContactCore.Models;
using Rise.Shared;
using System;

namespace Rise.ContactCore.Business
{
    public interface IContactInfoService
    {
        ReturnObject<bool> DeleteContactInfo(Guid gID);
        ReturnObject<ContactInfo> SaveContactInfo(ContactInfo oContactInfo);
    }
}