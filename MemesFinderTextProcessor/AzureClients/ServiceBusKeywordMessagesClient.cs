using System;
using Azure.Messaging.ServiceBus;
using MemesFinderTextProcessor.Interfaces.AzureClients;
using MemesFinderTextProcessor.Options;
using Microsoft.Extensions.Options;

namespace MemesFinderTextProcessor.AzureClients
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

