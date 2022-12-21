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
using MemesFinderTextProcessor.Extensions;

namespace MemesFinderTextProcessor
{
    public class MemesFinderTextProcessor
    {
        private readonly ILogger<MemesFinderTextProcessor> _logger;
        private readonly IServiceBusModelSender _serviceBusModelSender;
        private readonly ITextAnalyticsClient _textAnalyticsClient;

        public MemesFinderTextProcessor(
            ILogger<MemesFinderTextProcessor> log,
            IServiceBusModelSender serviceBusModelSender,
            ITextAnalyticsClient textAnalyticsClient)
        {
            _logger = log;
            _serviceBusModelSender = serviceBusModelSender;
            _textAnalyticsClient = textAnalyticsClient;
        }

        [FunctionName("MemesFinderTextProcessor")]
        public async Task Run([ServiceBusTrigger("allmessages", "textprocessor", Connection = "ServiceBusOptions")] Update tgUpdate)
        {
            Message incomeMessage = new MessageProcessFactory().GetMessageToProcess(tgUpdate);
            if (String.IsNullOrEmpty(incomeMessage.Text))
            {
                _logger.LogInformation("Message is not text");
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

            await _serviceBusModelSender.SendMessageAsync(tgMessageModel);
        }
    }
}

