using Example2.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace Example2.NoAutoSubscriber
{
    public class MyEventHandler : IHandleMessages<MyEvent>
    {
        public void Handle(MyEvent myEvent)
        {
            LogManager.GetLogger("MyEventHandler").Info(myEvent.SaySomething);
        }
    }
}
