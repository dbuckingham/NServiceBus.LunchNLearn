using Shared.Events;

namespace Billing.Events
{
    [Event]
    public class OrderBilledEvent
    {
        public int OrderId { get; set; }
    }
}