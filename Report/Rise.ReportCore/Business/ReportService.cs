using Microsoft.EntityFrameworkCore;
using Rise.ReportCore.Models;
using Rise.ReportCore.Models.HelperModels;
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

        IQueryable<ReportRequest> GetReportRequests();

        //ReturnObject<ReportRequestViewModel> RunReport(Guid gID);

        ReportRequest AddReportRequest(ReportRequest oReportRequest);
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

        public IQueryable<ReportRequest> GetReportRequests()
        {
            return _ctxApplication.ReportRequests;
        }

        public IQueryable<ReportRequest> GetCompletedReportRequests()
        {
            return _ctxApplication.ReportRequests.Where(r => r.ConstReportStatus.ConstValue == "1");
        }

        //public ReturnObject<ReportRequestViewModel> RunReport(Guid gID)
        //{
        //    ReturnObject<ReportRequestViewModel> oResult = new ReturnObject<ReportRequestViewModel>();

        //      var oReport =_ctxApplication.Reports.Where(r => r.Id == gID).FirstOrDefault();

        //    if (oReport != null)
        //    {
        //        ReportRequestViewModel oRRView = new ReportRequestViewModel();
        //        oRRView.ReportRID = gID;
        //        //oRRView.
        //    }
        //    else
        //    {
        //        oResult.AddError(Guid.NewGuid().ToString("N"), "Report not found!!");
        //    }

        //    return oResult;
        //}

        public ReportRequest AddReportRequest(ReportRequest oReportRequest)
        {
            _ctxApplication.Add(oReportRequest);
            _ctxApplication.SaveChanges();

            return oReportRequest;
        }

        public ReportRequest SaveReportAsCompleted(Guid gID, string strFilePath)
        {
            var oReportRequest = _ctxApplication.ReportRequests.Where(r => r.Id == gID).FirstOrDefault();
            if (oReportRequest != null)
            {
                oReportRequest.ReportFilePath = strFilePath;
                oReportRequest.ReportStatusRID = _ctxApplication.Consts.Where(c => c.ConstID == "ReportStatus" && c.ConstValue == "1").FirstOrDefault().Id;

                _ctxApplication.SaveChanges();
            }

            return oReportRequest;
        }

        public Report GetReportWithRequests(Guid gID)
        {
            return _ctxApplication.Reports.Include(r => r.ReportRequests).FirstOrDefault();
        }
    }
}
