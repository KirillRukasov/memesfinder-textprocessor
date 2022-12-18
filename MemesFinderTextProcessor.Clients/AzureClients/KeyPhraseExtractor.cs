using System;
using Azure;
using Azure.AI.TextAnalytics;
using MemesFinderTextProcessor.Interfaces.AzureClients;

namespace MemesFinderTextProcessor.Clients.AzureClients
{
	public class KeyPhraseExtractor : ITextAnalyticsClient
	{
        private readonly TextAnalyticsClient _textAnalyticsClient;

        public KeyPhraseExtractor(TextAnalyticsClient textAnalyticsClient)
		{
            _textAnalyticsClient = textAnalyticsClient;
        }

        public async Task<Response<KeyPhraseCollection>> ExtractKeyPhrasesAsync(string document)
            => await _textAnalyticsClient.ExtractKeyPhrasesAsync(document);
    }
}

