using System;
using System.Text.Json.Serialization;

namespace EventBus.Events
{
    public record IntegrationEvent
    {        
        public IntegrationEvent()
        {
            Id = Guid.NewGuid().ToString();
            CreationDate = DateTime.UtcNow;
        }

        [JsonConstructor]
        public IntegrationEvent(string id, DateTime createDate)
        {
            Id = id;
            CreationDate = createDate;
        }

        [JsonInclude]
        public string Id { get; set; }

        [JsonInclude]
        public DateTime CreationDate { get; private init; }

        public string TypeName { get; set; }
    }
}
