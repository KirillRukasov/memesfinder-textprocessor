using System;
namespace MemesFinderTextProcessor.Clients.AzureClients
{
    public class ServiceBusOptions
    {
        public string FullyQualifiedNamespace { get; set; }
        public string KeywordMessagesTopic { get; set; }
    }
}

