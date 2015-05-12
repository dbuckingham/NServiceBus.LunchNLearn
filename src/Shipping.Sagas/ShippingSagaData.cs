using NServiceBus.Saga;

namespace Shipping.Sagas
{
    public class ShippingSagaData : ContainSagaData
    {
        public int OrderId { get; set; }
        public bool OrderAccepted { get; set; }
        public bool OrderBilled { get; set; }
    }
}