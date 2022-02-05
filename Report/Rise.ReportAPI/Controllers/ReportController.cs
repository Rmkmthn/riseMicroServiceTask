using EventBus.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rise.ReportAPI.Services;
using Rise.ReportCore.Business;
using Rise.ReportCore.Models;
using Rise.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Rise.ReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _svcReport;
        private readonly IReportConstService _svcConst;
        private readonly IReportIntegrationEventService _eventService;
        public ReportController(IReportService svcReport, IReportIntegrationEventService eventService, IReportConstService svcConst)
        {
            _svcReport = svcReport;
            _eventService = eventService;
            _svcConst = svcConst;
        }
        [HttpGet("GetReports")]
        public IActionResult GetReports()
        {
            var qryOrdered = _svcReport.GetReports();
            //pagination & search islemleri
            var oResult = qryOrdered.ToList();

            return Ok(oResult);
        }

        [HttpGet("GetReportRequests")]
        public IActionResult GetReportRequests()
        {
            //pagination & search islemleri
            var oResult = _svcReport.GetReportRequests().ToList();

            return Ok(oResult);
        }

        [HttpGet("GetReport")]
        public IActionResult GetReport(Guid gID)
        {
            var oResult = _svcReport.GetReport(gID);

            return Ok(oResult);
        }
        [HttpGet("GetCompletedReportRequests")]
        public IActionResult GetCompletedReportRequests()
        {
            var oResult = _svcReport.GetCompletedReportRequests().ToList();

            return Ok(oResult);
        }

        

       [HttpGet("RunReport")]
        public async Task<IActionResult> RunReport(Guid gID)
        {
            ReturnObject<ReportRequestedIntegrationEvent> oResult = new ReturnObject<ReportRequestedIntegrationEvent>();
            try
            {
                if (!gID.Equals(Guid.Empty))
                {
                    var oReport = _svcReport.GetReport(gID);
                    if (oReport != null)
                    {
                        var oWaitingStatus = _svcConst.GetReportStatuses().Where(r => r.ConstValue == "0").FirstOrDefault();
                        if (oWaitingStatus != null)
                        {
                            //var transactionOptions = new TransactionOptions();
                            //transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted;
                            //transactionOptions.Timeout = TimeSpan.FromMinutes(10);
                            //using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                            //{
                            ReportRequest oReportRequest = new ReportRequest
                            {
                                ReportRID = gID,
                                ReportStatusRID = oWaitingStatus.Id,
                                RequestedDate = DateTimeOffset.Now
                            };

                            _svcReport.AddReportRequest(oReportRequest);

                            var eventMessage = new ReportRequestedIntegrationEvent(oReportRequest.Id, oReportRequest.ReportRID, oReport.ReportID, oReport.ReportName, oReportRequest.RequestedDate, oWaitingStatus.ConstDesc, oWaitingStatus.ConstValue);
                            try
                            {
                                await _eventService.AddAndSaveEventAsync(eventMessage);
                                await _eventService.PublishEventsThroughEventBusAsync(eventMessage.Id);
                            }
                            catch (Exception ex)
                            {
                                oResult.AddError(Guid.NewGuid().ToString("N"), string.Format("Publist Error-- Exception: {0} - Detail : {1}", ex.Message, ex.InnerException));
                            }

                            if (!oResult.IsValid) { string strResult = "Rapor durumu olarak 'Hatalı' eklenir ve o değer seçili db kayıt edilir."; }
                            else return Ok(eventMessage);

                            //        scope.Complete();                                
                            //}                               
                        }
                        else
                            oResult.AddError(Guid.NewGuid().ToString("N"), "ReportStatus consts not found !!");

                    }
                    else
                        oResult.AddError(Guid.NewGuid().ToString("N"), "Report not found!");
                }
                else
                    oResult.AddError(Guid.NewGuid().ToString("N"), "Guid is empty.");
            }
            catch (Exception ex)
            {
                oResult.AddError(Guid.NewGuid().ToString("N"), string.Format("API Error-- Exception: {0} - Detail : {1}", ex.Message, ex.InnerException));
            }


            return Ok(oResult);
        }
    }
}
