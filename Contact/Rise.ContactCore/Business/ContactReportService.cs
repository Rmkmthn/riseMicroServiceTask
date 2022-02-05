using Microsoft.EntityFrameworkCore;
using Rise.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ContactCore.Business
{
    public interface IContactReportService
    {
        List<Report00001Response> GetReport00001Detail();
    }

    public class ContactReportService : IContactReportService
    {
        private readonly ApplicationDbContext _ctxApplication;

        public ContactReportService(ApplicationDbContext ctxApplication)
        {
            _ctxApplication = ctxApplication;
        }

        public List<Report00001Response> GetReport00001Detail()
        {
            List<Report00001Response> oResponse = new List<Report00001Response>();
            /*
            SP yapilip cagirilabilir.
            

            select CI."InfoValue" as "Location", count(CT."Id")  as "ContactCount", count(DISTINCT CI1."InfoValue") as "TelephoneCount"
                from "ContactInfos" CI INNER JOIN "Consts" CO 
                ON CO."Id" = CI."InfoTypeRID" and CO."ConstValue" = '2'
                INNER JOIN "Contacts" CT ON CT."Id" = CI."ContactRID"
                INNER JOIN "Consts" CO1 ON CO1."ConstID" = 'ContactInfoTypes' and CO1."ConstValue" = '0'
                LEFT JOIN "ContactInfos" CI1 ON CO1."Id" = CI1."InfoTypeRID" AND CI1."ContactRID" = CT."Id"
                group by CI."InfoValue"
             */

            var oResponseQuery = (from ci in _ctxApplication.ContactInfos.AsNoTracking()
                                  join c in _ctxApplication.Consts.AsNoTracking()
                                  on new { I = ci.InfoTypeRID, CValue = "2" } equals new { I = c.Id, CValue = c.ConstValue }
                                  join con in _ctxApplication.Contacts.AsNoTracking()
                                  on ci.ContactRID equals con.Id
                                  join c1 in _ctxApplication.Consts.AsNoTracking()
                                  on new { I = "ContactInfoTypes", CValue = "0" } equals new { I = c1.ConstID, CValue = c1.ConstValue }
                                  join ci1 in _ctxApplication.ContactInfos.AsNoTracking()
                                  on new { I = c1.Id, CValue = con.Id } equals new { I = ci1.InfoTypeRID, CValue = ci1.ContactRID } into cc
                                  from tp in cc.DefaultIfEmpty()
                                      //group tp by ci.InfoValue into gr
                                  select new
                                  {
                                      InfoValue = ci.InfoValue,
                                      ContractRID = con.Id,
                                      TelephoneInfo = tp.InfoValue ?? ""
                                  }).ToList();

            oResponse = oResponseQuery.GroupBy(x => x.InfoValue).Select(x => new Report00001Response
            {
                Location = x.First().InfoValue,
                ContactCount = x.Count(),
                TelephoneCount = x.Count(a => a.TelephoneInfo != "")
            }).ToList();

            return oResponse;
        }
    }
}
