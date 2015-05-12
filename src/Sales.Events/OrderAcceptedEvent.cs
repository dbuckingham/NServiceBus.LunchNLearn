using Shared.Events;

namespace Sales.Events
{
    [Event]
    public class OrderAcceptedEvent
    {
        public int OrderId { get; set; }
    }
}