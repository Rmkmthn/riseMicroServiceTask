﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rise.ContactCore.Models;
using Rise.Shared;
using System.Data;
using System.Text.RegularExpressions;

namespace Rise.ContactCore.Business
{
    public interface IContactInfoService
    {
        ReturnObject<bool> DeleteContactInfo(Guid gID);
        ReturnObject<ContactInfo> SaveContactInfo(ContactInfo oContactInfo);        
    }
    public class ContactInfoService : IContactInfoService, IDisposable
    {
        private readonly ApplicationDbContext _ctxApplication;

        public ContactInfoService(ApplicationDbContext ctxApplication)
        {
            _ctxApplication = ctxApplication;
        }

        public ReturnObject<ContactInfo> SaveContactInfo(ContactInfo oContactInfo)
        {
            ReturnObject<ContactInfo> oResult = new ReturnObject<ContactInfo>();

            try
            {
                var oConstInfo = _ctxApplication.Consts.Where(c => c.Id == oContactInfo.InfoTypeRID).FirstOrDefault();
                if (oConstInfo != null)
                {
                    if (oConstInfo.ConstValue == "1")
                    {
                        bool isEmail = Regex.IsMatch(oContactInfo.InfoValue, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                        if (!isEmail)
                        {
                            oResult.AddError(Guid.NewGuid().ToString("N"), "Email is not valid!!");
                            return oResult;
                        }
                    }

                    var oExistCI = _ctxApplication.ContactInfos.FirstOrDefault(c => c.InfoTypeRID == oContactInfo.InfoTypeRID && c.Contact.Id == oContactInfo.ContactRID);
                    if (oExistCI != null)
                    {
                        if (oExistCI.Id != oContactInfo.Id)
                        {
                            oResult.AddError(Guid.NewGuid().ToString("N"), "This record's info type can not change!!");
                        }
                        else
                        {
                            oResult.ResultObject = oExistCI;
                            oResult.ResultObject.MDate = DateTimeOffset.Now;
                        }
                    }
                    else
                    {
                        oResult.ResultObject = oContactInfo;
                        _ctxApplication.Add(oResult.ResultObject);
                    }

                    _ctxApplication.SaveChanges();
                }
                else
                    oResult.AddError(Guid.NewGuid().ToString("N"), "Info Type not found !!");

            }
            catch (Exception ex)
            {
                string strErrorMsg = string.Format("Error : {0} -- Detail : {1}", ex.Message, ex.InnerException);
                Console.WriteLine(strErrorMsg);
                oResult.AddError(Guid.NewGuid().ToString("N"), strErrorMsg);
            }

            return oResult;
        }

        public ReturnObject<bool> DeleteContactInfo(Guid gID)
        {
            ReturnObject<bool> oResult = new ReturnObject<bool>();
            bool blnResult = true;
            try
            {
                var oExistCI = _ctxApplication.ContactInfos.Where(c => c.Id == gID).FirstOrDefault();
                if (oExistCI != null)
                {
                    _ctxApplication.Remove(oExistCI);
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
        
        public void Dispose()
        {

        }
    }
}
