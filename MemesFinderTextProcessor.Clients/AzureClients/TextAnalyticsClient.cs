using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.AI.TextAnalytics;
using Azure.Identity;


namespace MemesFinderTextProcessor.Clients.AzureClients
{
    internal class TextAnalyticsClient
    {
        //constructor with dependency injection
        private readonly TextAnalyticsClient _textAnalyticsClient;
        public TextAnalyticsClient(TextAnalyticsClient textAnalyticsClient)
        {
            _textAnalyticsClient = textAnalyticsClient;
        }

        public async Task<string> GetLanguageAsync(string text)
        {
            var response = await _textAnalyticsClient.DetectLanguageAsync(text);
            var detectedLanguage = response.PrimaryLanguage;
            return detectedLanguage.Name;
        }


        TextAnalyticsClient client = new(new Uri("https://ccweprivatememesfinder.cognitiveservices.azure.com/"), new DefaultAzureCredential());

        string testRequest = "мне не оч нравится идея с локальными моделями (не сервисами) потому что их надо где-то размещать и хуй найдешь либу для шарпа под них (т. к. их создают как правило слишком дохуя и не особо заботятся о совместимости). но технически, если будет прям очень хорошая модель, то мы можем сделать ажурную функцию на питоне (они это поддерживают). и сделать ее как сервис в нашей экосистеме";

        Response<KeyPhraseCollection> response = await client.ExtractKeyPhrasesAsync(testRequest, "ru");
        KeyPhraseCollection keyPhrases = response.Value;

        Console.WriteLine($"Extracted {keyPhrases.Count} key phrases:");
        foreach (string keyPhrase in keyPhrases)
        {
            Console.WriteLine($"  {keyPhrase}");
        }
}
}
