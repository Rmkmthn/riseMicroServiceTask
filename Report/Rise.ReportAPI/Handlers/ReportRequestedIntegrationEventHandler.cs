using EventBus.Abstractions;
using EventBus.Events;
using IntegrationEventLogEF;
using IntegrationEventLogEF.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rise.ReportCore.Business;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Rise.ReportAPI.Handlers
{
    public class ReportRequestedIntegrationEventHandler : IIntegrationEventHandler<ReportRequestedIntegrationEvent>
    {
        private readonly ILogger<ReportRequestedIntegrationEventHandler> _logger;
        private readonly IReportService _svcReport;
        private readonly IntegrationEventLogContext _integrationContext;
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly IIntegrationEventLogService _eventLogService;
        private readonly IConfiguration _configuration;
        private readonly string strType;
        public ReportRequestedIntegrationEventHandler(
            ILogger<ReportRequestedIntegrationEventHandler> logger,
            IntegrationEventLogContext integrationContext,
            IReportService svcReport,
            Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory,
            IConfiguration configuration
            )
        {
            _configuration = configuration;
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            _integrationContext = integrationContext ?? throw new System.ArgumentNullException(nameof(integrationContext));
            _svcReport = svcReport;
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _eventLogService = _integrationEventLogServiceFactory(_integrationContext.Database.GetDbConnection());
            strType = !string.IsNullOrEmpty(_configuration.GetValue<string>("APIType")) ? _configuration.GetValue<string>("APIType") : "Report";
        }

        public async Task Handle(ReportRequestedIntegrationEvent @event)
        {
            bool blnHasError = false;
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}"))
            {
                @event.TypeName = strType;
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} - ({@IntegrationEvent})", @event.Id, @event);
                                

                await _eventLogService.MarkEventAsConsumingAsync(@event.Id, @event.TypeName, @event, _integrationContext.GetCurrentTransaction());
              
                if (@event.ReportRequestRID == Guid.Empty)
                {
                    _logger.LogInformation("User id error");
                    blnHasError = true;
                    
                }
                else
                {
                    var lstResult = _svcReport.GetReportDetail(@event.ReportRID, @event.ReportRequestRID);

                    if (lstResult.IsValid && lstResult.ResultObject != null)
                    {
                        var oSaveResult = _svcReport.SaveExcelFile(@event.ReportID,lstResult.ResultObject);
                        if (oSaveResult.IsValid)
                        {
                            var oReportRequest = _svcReport.SaveReportAsCompleted(@event.ReportRequestRID, oSaveResult.ResultObject);
                            if (oReportRequest != null)
                            {
                                _logger.LogInformation("Success transfer");
                            }
                            else
                                blnHasError = true;
                        }
                        else
                            blnHasError = true;
                    }
                    else
                        blnHasError = true;
                }

                if (blnHasError)
                    await _eventLogService.MarkEventAsConsumedFailedAsync(@event.Id);
                else
                    await _eventLogService.MarkEventAsConsumedAsync(@event.Id);
            }
        }


    }
}
