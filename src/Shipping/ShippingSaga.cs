using System;
using Billing.Events;
using NServiceBus.Saga;
using Sales.Events;
using Shipping.Sagas;

namespace Shipping
{
    public class ShippingSaga : Saga<ShippingSagaData>, 
        IAmStartedByMessages<OrderAcceptedEvent>, 
        IAmStartedByMessages<OrderBilledEvent>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<ShippingSagaData> mapper)
        {
            mapper.ConfigureMapping<OrderAcceptedEvent>(a => a.OrderId).ToSaga(s => s.OrderId);
            mapper.ConfigureMapping<OrderBilledEvent>(b => b.OrderId).ToSaga(s => s.OrderId);
        }

        public void Handle(OrderAcceptedEvent orderAcceptedEvent)
        {
            Console.WriteLine(">> Order {0} has been accepted.", orderAcceptedEvent.OrderId);
            Data.OrderId = orderAcceptedEvent.OrderId;
            Data.OrderAccepted = true;

            AmIFinished();
        }

        public void Handle(OrderBilledEvent orderBilledEvent)
        {
            Console.WriteLine(">> Order {0} has been billed.", orderBilledEvent.OrderId);
            Data.OrderId = orderBilledEvent.OrderId;
            Data.OrderBilled = true;

            AmIFinished();
        }

        private void AmIFinished()
        {
            if (Data.OrderAccepted && Data.OrderBilled)
            {
                Console.WriteLine(">> Shipping order {0}.", Data.OrderId);

                MarkAsComplete();
            }
        }
    }
}