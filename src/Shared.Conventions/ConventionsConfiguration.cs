using System.Linq;
using NServiceBus;

namespace Shared.Conventions
{
    public class ConventionsConfiguration : INeedInitialization
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.Conventions()
                .DefiningEventsAs(type =>
                    type.GetCustomAttributes(true).Any(t => t.GetType().Name == "EventAttribute"));
        }
    }
}
