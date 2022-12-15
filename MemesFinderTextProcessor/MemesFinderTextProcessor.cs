using MemesFinderTextProcessor.Interfaces.AzureClients;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;

namespace MemesFinderTextProcessor
{
    public class MemesFinderTextProcessor
    {
        private readonly ILogger<MemesFinderTextProcessor> _logger;
        private readonly IServiceBusClient _serviceBusClient;

        public MemesFinderTextProcessor(ILogger<MemesFinderTextProcessor> log, IServiceBusClient serviceBusClient)
        {
            _logger = log;
            _serviceBusClient = serviceBusClient;
        }

        [FunctionName("MemesFinderTextProcessor")]
        public void Run([ServiceBusTrigger("allmessages", "textprocessor", Connection = "ServiceBusOptions")] Update tgUpdate)
        {
            
        }
    }
}

