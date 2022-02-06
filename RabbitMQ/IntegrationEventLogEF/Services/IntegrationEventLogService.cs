using EventBus.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace IntegrationEventLogEF.Services
{
    public class IntegrationEventLogService : IIntegrationEventLogService, IDisposable
    {
        private readonly IntegrationEventLogContext _integrationEventLogContext;
        private readonly DbConnection _dbConnection;
        private readonly List<Type> _eventTypes;
        private volatile bool disposedValue;

        public IntegrationEventLogService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            _integrationEventLogContext = new IntegrationEventLogContext(
                new DbContextOptionsBuilder<IntegrationEventLogContext>()
                    .UseNpgsql(_dbConnection)
                    .Options);
            _eventTypes = Assembly.Load("EventBus")
                .GetTypes()
                .Where(t => t.Name.EndsWith(nameof(IntegrationEvent)))
                .ToList();
            //_eventTypes = new List<Type>();
            //_eventTypes.Add(typeof(UserCreatedIntegrationEvent));
        }

        public async Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPendingToPublishAsync(string transactionId)
        {
            var tid = transactionId.ToString();

            var result = await _integrationEventLogContext.IntegrationEventLogs
                .Where(e => e.EventId == tid && e.State == EventStateEnum.NotPublished).ToListAsync();

            if (result != null && result.Any())
            {
                return result.OrderBy(o => o.CreationTime)
                    .Select(e => e.DeserializeJsonContent(_eventTypes.Find(t => t.Name == e.EventTypeShortName)));
            }

            return new List<IntegrationEventLogEntry>();
        }

        public Task SaveEventAsync(IntegrationEvent @event, IDbContextTransaction transaction)
        {
            //if (transaction == null) throw new ArgumentNullException(nameof(transaction));

            var eventLogEntry = new IntegrationEventLogEntry(@event, Guid.NewGuid().ToString());

            //_integrationEventLogContext.Database.UseTransaction(transaction.GetDbTransaction());
            _integrationEventLogContext.IntegrationEventLogs.Add(eventLogEntry);

            return _integrationEventLogContext.SaveChangesAsync();
            
        }

        public Task SaveMasterEventAsync(IntegrationEvent @event, IDbContextTransaction transaction)
        {
            string strMasterId = @event.Id;
            @event.Id = Guid.NewGuid().ToString();
            var eventLogEntry = new IntegrationEventLogEntry(@event, Guid.NewGuid().ToString(), strMasterId);

            //_integrationEventLogContext.Database.UseTransaction(transaction.GetDbTransaction());
            _integrationEventLogContext.IntegrationEventLogs.Add(eventLogEntry);

            return _integrationEventLogContext.SaveChangesAsync();

        }

        public Task MarkEventAsPublishedAsync(string eventId)
        {
            return UpdateEventStatus(eventId, EventStateEnum.Published);
        }

        public Task MarkEventAsInProgressAsync(string eventId)
        {
            return UpdateEventStatus(eventId, EventStateEnum.InProgress);
        }

        public Task MarkEventAsPublishedFailedAsync(string eventId)
        {
            return UpdateEventStatus(eventId, EventStateEnum.PublishedFailed);
        }

        public Task MarkEventAsConsumedFailedAsync(string eventId)
        {
            return UpdateEventStatus(eventId, EventStateEnum.ConsumedFailed);
        }

        public Task MarkEventAsConsumingAsync(string eventId, string strType, IntegrationEvent @event, IDbContextTransaction transaction)
        {
            return UpdateEventStatusForClient(eventId, EventStateEnum.Consuming, strType, @event, transaction);
        }

        public Task MarkEventAsConsumedAsync(string eventId)
        {
            return UpdateEventStatus(eventId, EventStateEnum.Consumed);
        }

        private Task UpdateEventStatus(string eventId, EventStateEnum status)
        {
            var tid = eventId.ToString();

            var eventLogEntry = _integrationEventLogContext.IntegrationEventLogs.OrderByDescending(o => o.CreationTime).FirstOrDefault(ie => ie.EventId == tid);
            eventLogEntry.State = status;

            if (!string.IsNullOrEmpty(eventLogEntry.MasterEventId))
                eventLogEntry.Content = "";
            if (status == EventStateEnum.InProgress)
                eventLogEntry.TimesSent++;

            _integrationEventLogContext.IntegrationEventLogs.Update(eventLogEntry);

            return _integrationEventLogContext.SaveChangesAsync();
        }

        private Task UpdateEventStatusForClient(string eventId, EventStateEnum status, string strType, IntegrationEvent @event= null, IDbContextTransaction transaction= null)
        {
            var eventLogEntry = _integrationEventLogContext.IntegrationEventLogs.OrderByDescending(o => o.CreationTime).FirstOrDefault(ie => ie.MasterEventId == eventId && ie.TypeName == strType);
            if (eventLogEntry == null)
            {
                SaveMasterEventAsync(@event, transaction).Wait();
                eventLogEntry = _integrationEventLogContext.IntegrationEventLogs.OrderByDescending(o => o.CreationTime).FirstOrDefault(ie => ie.MasterEventId == eventId && ie.TypeName == strType);
            }
            eventLogEntry.State = status;

            if (status == EventStateEnum.Consuming)
                eventLogEntry.TimesSent++;

            _integrationEventLogContext.IntegrationEventLogs.Update(eventLogEntry);

            return _integrationEventLogContext.SaveChangesAsync();
        }        

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _integrationEventLogContext?.Dispose();
                }


                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
