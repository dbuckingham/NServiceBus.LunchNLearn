using System;
using NServiceBus;
using Sales.Events;

namespace Sales
{
    public class Startup : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Console.WriteLine(">> Sales Service");
            Console.WriteLine(">>");

            while (true)
            {
                Console.Write("Please enter an order id: ");
                int orderId = Convert.ToInt32(Console.ReadLine());

                Bus.Publish(new OrderAcceptedEvent() {OrderId = orderId});

                Console.WriteLine(">> Order Id {0} accepted.");
            }
        }

        public void Stop()
        {
        }
    }
}