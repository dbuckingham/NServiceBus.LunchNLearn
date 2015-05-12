using System;
using Billing.Events;
using NServiceBus;
using Sales.Events;

namespace Billing
{
    public class OrderAcceptedHandler : IHandleMessages<OrderAcceptedEvent>
    {
        public IBus Bus { get; set; }

        public void Handle(OrderAcceptedEvent orderAcceptedEvent)
        {
            Console.WriteLine(">> Received order id {0}", orderAcceptedEvent.OrderId);

            Bus.Publish(new OrderBilledEvent()
            {
                OrderId = orderAcceptedEvent.OrderId
            });

            Console.WriteLine(">> Order id {0} billed.", orderAcceptedEvent.OrderId);
        }
    }
}