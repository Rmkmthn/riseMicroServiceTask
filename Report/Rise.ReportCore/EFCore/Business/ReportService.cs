using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Rise.ReportCore.Models;
using Rise.ReportCore.Models.HelperModels;
using Rise.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Rise.ReportCore.Business
{
    public interface IReportService
    {
        Report GetReport(Guid gID);

        IQueryable<Report> GetReports();

        IQueryable<ReportRequest> GetReportRequests();

        IQueryable<ReportRequest> GetCompletedReportRequests();
        //ReturnObject<ReportRequestViewModel> RunReport(Guid gID);

        ReportRequest AddReportRequest(ReportRequest oReportRequest);

        ReportRequest SaveReportAsCompleted(Guid gID, string strFilePath);

        Report GetReportWithRequests(Guid gID);
        ReturnObject<object> GetReportDetail(Guid gID, Guid gReportRequestRID);
        ReturnObject<string> SaveExcelFile(string strReportID, object lstReportDetail);
    }
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _ctxApplication;

        private readonly IConfiguration _config;

        public ReportService(ApplicationDbContext ctxApplication, IConfiguration configuration)
        {
            _ctxApplication = ctxApplication;
            _config = configuration;
        }

        public ReportService(ApplicationDbContext ctxApplication)
        {
            _ctxApplication = ctxApplication;

            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            _config = config;
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
            return _ctxApplication.ReportRequests.Include(x => x.ConstReportStatus).AsNoTracking();
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

        public ReturnObject<object> GetReportDetail(Guid gID, Guid gReportRequestRID)
        {
            ReturnObject<object> oResult = new ReturnObject<object>();

            var oReport = _ctxApplication.Reports.Where(w => w.Id == gID).FirstOrDefault();
            if (oReport != null)
            {
                if (oReport.ReportID == "00001")
                {
                    var oReportResult = GetReport00001Detail().Result;
                    if (oReportResult.IsValid /*&& oReportResult.ResultObject?.Count > 0*/)
                    {
                        oResult.ResultObject = oReportResult.ResultObject;
                    }
                    else /*if (oReportResult.Errors != null)*/
                        oResult.AddError(Guid.NewGuid().ToString("N"), string.Join(Environment.NewLine, oReportResult.Errors.Select(x => x.Value)));
                }
                else
                {
                    oResult.AddError(Guid.NewGuid().ToString("N"), "Report not supported!!");
                }
            }

            return oResult;
        }

        public async Task<ReturnObject<List<Report00001Response>>> GetReport00001Detail()
        {
            ReturnObject<List<Report00001Response>> oResult = new ReturnObject<List<Report00001Response>>();
            string strResult = "";
            try
            {
                string strURL = _config["URL:ContactAPI"].ToString();
                strURL += (strURL.EndsWith("/") ? "" : "/") + "api/ContactReport/GetReport00001Detail";
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(10);
                    client.BaseAddress = new Uri(strURL);
                    client.DefaultRequestHeaders.Add("Accept-Language", "tr");
                    HttpResponseMessage result = await client.GetAsync(strURL).ConfigureAwait(false);
                    strResult = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (result.IsSuccessStatusCode)
                    {

                        oResult.ResultObject = JsonConvert.DeserializeObject<List<Report00001Response>>(strResult);
                    }
                    else
                    {
                        int intStatusCode = (int)result.StatusCode;
                        oResult.AddError(Guid.NewGuid().ToString("N"), string.Format("HTTP StatusCode:{0},Http ReasonPhrase :{1} ", intStatusCode, result.ReasonPhrase));

                    }
                }
            }
            catch (HttpRequestException ex)
            {
                oResult.AddError(Guid.NewGuid().ToString("N"), string.Format("HttpRequestException Error-- Exception: {0} - Detail : {1}", ex.Message, ex.InnerException));

            }
            catch (Exception ex)
            {
                oResult.AddError(Guid.NewGuid().ToString("N"), string.Format("Exception Error-- Exception: {0} - Detail : {1}", ex.Message, ex.InnerException));
            }
            return oResult;
        }

        public ReturnObject<string> SaveExcelFile(string strReportID, object lstReportDetail)
        {
            ReturnObject<string> oResult = new ReturnObject<string>();

            try
            {
                string strFilePath = Path.GetTempFileName();

                var strObj = JsonConvert.SerializeObject(lstReportDetail);

                using (var writer = File.CreateText(strFilePath))
                {
                    writer.WriteLine(strObj);
                }

                oResult.ResultObject = strFilePath;
            }
            catch (Exception ex)
            {
                oResult.AddError(Guid.NewGuid().ToString("N"), string.Format("Exception Error-- Exception: {0} - Detail : {1}", ex.Message, ex.InnerException));
            }            

            return oResult;
        }

        public Report GetReportWithRequests(Guid gID)
        {
            return _ctxApplication.Reports.Include(r => r.ReportRequests).FirstOrDefault();
        }
    }
}
