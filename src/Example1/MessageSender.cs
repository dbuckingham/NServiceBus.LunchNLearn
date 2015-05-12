using Example1.Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Example1.Client
{
    class MessageSender : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            var message = new MyMessage { SaySomething = "Something." };

            //Bus.Send("Example1.Server", message);
            Bus.Send(message);

            LogManager.GetLogger("MessageSender").Info("Message sent.");
        }

        public void Stop()
        {
        }
    }
}
