using System;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Shipping
{
    using NServiceBus;

    /*
        This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
        can be found here: http://particular.net/articles/the-nservicebus-host
    */
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public EndpointConfig()
        {
            // Configure Logging
            var configuration = new LoggingConfiguration();
            var debuggerTarget = new DebuggerTarget
            {
                Layout = "${level}|${logger}|${message}${onexception:${newline}${exception:format=tostring}}"
            };
            configuration.AddTarget("debug", debuggerTarget);
            configuration.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, debuggerTarget));
            LogManager.Configuration = configuration;

            NServiceBus.Logging.LogManager.Use<NLogFactory>();

            Console.WriteLine(">> Shipping Service");
            Console.WriteLine(">>");
        }

        public void Customize(BusConfiguration configuration)
        {
            // NServiceBus provides the following durable storage options
            // To use RavenDB, install-package NServiceBus.RavenDB and then use configuration.UsePersistence<RavenDBPersistence>();
            // To use SQLServer, install-package NServiceBus.NHibernate and then use configuration.UsePersistence<NHibernatePersistence>();
            
            // If you don't need a durable storage you can also use, configuration.UsePersistence<InMemoryPersistence>();
            // more details on persistence can be found here: http://docs.particular.net/nservicebus/persistence-in-nservicebus
            
            //Also note that you can mix and match storages to fit you specific needs. 
            //http://docs.particular.net/nservicebus/persistence-order
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.UseSerialization<XmlSerializer>().Namespace("http://acme.com");
        }
    }
}
