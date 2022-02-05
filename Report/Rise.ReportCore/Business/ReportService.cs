using Rise.ReportCore.Models;
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
        Report GetReport(Guid gID);

        IQueryable<Report> GetReports();
    }
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _ctxApplication;

        public ReportService(ApplicationDbContext ctxApplication)
        {
            _ctxApplication = ctxApplication;
        }

        public Report GetReport(Guid gID)
        {
            return _ctxApplication.Reports.Where(r => r.Id == gID).FirstOrDefault();
        }

        public IQueryable<Report> GetReports()
        {
            return _ctxApplication.Reports;
        }
    }
}
