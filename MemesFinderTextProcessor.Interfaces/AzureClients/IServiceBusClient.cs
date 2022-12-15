using System;
using Azure.Messaging.ServiceBus;

namespace MemesFinderTextProcessor.Interfaces.AzureClients
{
    public interface IServiceBusClient
    {
        public ServiceBusSender CreateSender();
    }
}

