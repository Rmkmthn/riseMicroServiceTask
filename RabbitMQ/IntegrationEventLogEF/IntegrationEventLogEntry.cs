using EventBus.Events;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IntegrationEventLogEF
{
    public class IntegrationEventLogEntry
    {
        private IntegrationEventLogEntry() { }
        public IntegrationEventLogEntry(IntegrationEvent @event, string transactionId, string masterEventId = "")
        {
            EventId = @event.Id;
            CreationTime = @event.CreationDate;
            EventTypeName = @event.GetType().FullName;                     
            Content = JsonConvert.SerializeObject(@event, @event.GetType(), new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.Indented
            });
            State = EventStateEnum.NotPublished;
            TimesSent = 0;
            TransactionId = transactionId;
            TypeName = @event.TypeName;
            MasterEventId = masterEventId;
        }
        public string EventId { get; private set; }
        public string MasterEventId { get; set; }
        public string EventTypeName { get; private set; }
        [NotMapped]
        public string EventTypeShortName => EventTypeName.Split('.')?.Last();
        [NotMapped]
        public IntegrationEvent IntegrationEvent { get; private set; }
        public EventStateEnum State { get; set; }
        public int TimesSent { get; set; }
        public DateTime CreationTime { get; private set; }
        public string Content { get; set; }
        public string TransactionId { get; private set; }

        public string TypeName { get; set; }

        public IntegrationEventLogEntry DeserializeJsonContent(Type type)
        {            
            IntegrationEvent = JsonConvert.DeserializeObject(Content, type) as IntegrationEvent;
            return this;
        }
    }
}
