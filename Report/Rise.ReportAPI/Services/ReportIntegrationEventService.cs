using EventBus.Abstractions;
using EventBus.Events;
using IntegrationEventLogEF;
using IntegrationEventLogEF.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Rise.ReportAPI.Services
{
    public interface IReportIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(string transactionId);
        Task AddAndSaveEventAsync(IntegrationEvent evt);
    }
    public class ReportIntegrationEventService : IReportIntegrationEventService
    {
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly IEventBus _eventBus;
        private readonly IntegrationEventLogContext _integrationContext;
        private readonly IIntegrationEventLogService _eventLogService;
        private readonly ILogger<ReportIntegrationEventService> _logger;

        public ReportIntegrationEventService(IEventBus eventBus,
            IntegrationEventLogContext integrationContext,
            Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory,
            ILogger<ReportIntegrationEventService> logger)
        {
            _integrationContext = integrationContext ?? throw new ArgumentNullException(nameof(integrationContext));
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _eventLogService = _integrationEventLogServiceFactory(_integrationContext.Database.GetDbConnection());
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task PublishEventsThroughEventBusAsync(string transactionId)
        {
            var pendingLogEvents = await _eventLogService.RetrieveEventLogsPendingToPublishAsync(transactionId);

            foreach (var logEvt in pendingLogEvents)
            {
                _logger.LogInformation("----- Publishing integration event: {IntegrationEventId} from {AppName} - ({@IntegrationEvent})", logEvt.EventId, /*Program.AppName ??*/ "", logEvt.IntegrationEvent);

                try
                {
                    await _eventLogService.MarkEventAsInProgressAsync(logEvt.EventId);
                    _eventBus.Publish(logEvt.IntegrationEvent);
                    await _eventLogService.MarkEventAsPublishedAsync(logEvt.EventId);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "ERROR publishing integration event: {IntegrationEventId} ", logEvt.EventId);

                    await _eventLogService.MarkEventAsPublishedFailedAsync(logEvt.EventId);
                }
            }
        }

        public async Task AddAndSaveEventAsync(IntegrationEvent evt)
        {
            _logger.LogInformation("----- Enqueuing integration event {IntegrationEventId} to repository ({@IntegrationEvent})", evt.Id, evt);

            await _eventLogService.SaveEventAsync(evt, _integrationContext.GetCurrentTransaction());
        }
    }
}
