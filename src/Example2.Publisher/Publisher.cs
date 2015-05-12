using System;
using Example2.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace Example2.Publisher
{
    public class Publisher : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            LogManager.GetLogger("Publisher").Info("Look at me. I am the Publisher now!");

            while (true)
            {
                var keyPressed = Console.ReadKey();
                Bus.Publish(new MyEvent { SaySomething = string.Format("{0} key was pressed.", keyPressed.KeyChar) });
            }
        }

        public void Stop()
        {
        }
    }
}
