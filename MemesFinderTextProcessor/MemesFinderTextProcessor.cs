using System.Threading.Tasks;
using Azure.AI.TextAnalytics;
using Azure;
using MemesFinderTextProcessor.Factories;
using MemesFinderTextProcessor.Interfaces.AzureClients;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using MemesFinderTextProcessor.Models;
using System;

namespace MemesFinderTextProcessor
{
    public class MemesFinderTextProcessor
    {
        private readonly ILogger<MemesFinderTextProcessor> _logger;
        private readonly IServiceBusClient _serviceBusClient;
        private readonly ITextAnalyticsClient _textAnalyticsClient;

        public MemesFinderTextProcessor(
            ILogger<MemesFinderTextProcessor> log,
            IServiceBusClient serviceBusClient,
            ITextAnalyticsClient textAnalyticsClient)
        {
            _logger = log;
            _serviceBusClient = serviceBusClient;
            _textAnalyticsClient = textAnalyticsClient;
        }

        [FunctionName("MemesFinderTextProcessor")]
        public async Task Run([ServiceBusTrigger("allmessages", "textprocessor", Connection = "ServiceBusOptions")] Update tgUpdate)
        {
            Message incomeMessage = new MessageProcessFactory().GetMessageProcess(tgUpdate);
            if (incomeMessage.Text == null)
            {
                _logger.LogInformation("Message is not text");
                //Console.WriteLine($"Message is {incomeMessage.Type}");
                return;
            }

            Response<KeyPhraseCollection> response = await _textAnalyticsClient.ExtractKeyPhrasesAsync(incomeMessage.Text);
            KeyPhraseCollection keyPhrases = response.Value;
            
            var tgMessageModel = new TgMessageModel
            {
                Message = incomeMessage,
                //return random array element from keyPhrases
                Keyword = keyPhrases[new Random().Next(0, keyPhrases.Count)]
            };
        }
    }
}

