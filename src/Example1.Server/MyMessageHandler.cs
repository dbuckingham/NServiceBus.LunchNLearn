using Example1.Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Example1.Server
{
    public class MyMessageHandler : IHandleMessages<MyMessage>
    {
        public void Handle(MyMessage message)
        {
            LogManager.GetLogger("MyMessageHandler").Info(message.SaySomething);
        }
    }
}
