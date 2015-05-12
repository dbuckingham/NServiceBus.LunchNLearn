using Example2.Events;
using NServiceBus;

namespace Example2.NoAutoSubscriber
{
    class Startup : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Bus.Subscribe<MyEvent>();
        }

        public void Stop()
        {
            Bus.Unsubscribe<MyEvent>();
        }
    }
}
