using EventBus.Events;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegrationEventLogEF.Services
{
    public interface IIntegrationEventLogService
    {
        Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPendingToPublishAsync(string transactionId);
        Task SaveEventAsync(IntegrationEvent @event, IDbContextTransaction transaction);
        Task MarkEventAsPublishedAsync(string eventId);
        Task MarkEventAsInProgressAsync(string eventId);
        Task MarkEventAsPublishedFailedAsync(string eventId);
        Task MarkEventAsConsumingAsync(string eventId, string strType, IntegrationEvent @event, IDbContextTransaction transaction);
        Task MarkEventAsConsumedAsync(string eventId);
        Task MarkEventAsConsumedFailedAsync(string eventId);
    }
}
