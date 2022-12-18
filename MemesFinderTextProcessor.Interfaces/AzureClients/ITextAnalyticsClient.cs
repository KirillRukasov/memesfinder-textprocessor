using System;
using Azure;
using Azure.AI.TextAnalytics;

namespace MemesFinderTextProcessor.Interfaces.AzureClients
{
	public interface ITextAnalyticsClient
	{
		public Task<Response<KeyPhraseCollection>> ExtractKeyPhrasesAsync(string document);
    }
}

