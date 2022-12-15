using Azure.Messaging.ServiceBus;
using MemesFinderTextProcessor.Interfaces.AzureClients;
using Microsoft.Extensions.Options;

namespace MemesFinderTextProcessor.Clients.AzureClients
{
    public class ServiceBusKeywordMessagesClient : IServiceBusClient
    {
        private readonly ServiceBusClient _serviceBusClient;
        private readonly ServiceBusOptions _serviceBusOptions;

        public ServiceBusKeywordMessagesClient(ServiceBusClient serviceBusClient, IOptions<ServiceBusOptions> options)
        {
            _serviceBusClient = serviceBusClient;
            _serviceBusOptions = options.Value;
        }

        public ServiceBusSender CreateSender()
            => _serviceBusClient.CreateSender(_serviceBusOptions.KeywordMessagesTopic);
    }
}

