namespace IntegrationEventLogEF
{
    public enum EventStateEnum
    {
        NotPublished = 0,
        InProgress = 1,
        Published = 2,
        PublishedFailed = 3,
        Consuming = 4,
        Consumed = 5,
        ConsumedFailed = 6
    }
}
