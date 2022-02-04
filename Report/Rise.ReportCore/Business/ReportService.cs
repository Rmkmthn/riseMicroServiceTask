using Rise.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.ReportCore.Business
{
    public interface IReportService
    {
        ReturnObject<bool> GetReport(Guid gID);
    }
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _ctxApplication;

        public ReportService(ApplicationDbContext ctxApplication)
        {
            _ctxApplication = ctxApplication;
        }

        public ReturnObject<bool> GetReport(Guid gID)
        {
            ReturnObject<bool> oResult = new ReturnObject<bool>();




            return oResult;
        }
    }
}
