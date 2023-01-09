using System;
using Azure.AI.TextAnalytics;
using MemesFinderTextProcessor.Interfaces.Adapters;
using MemesFinderTextProcessor.Models;
using Telegram.Bot.Types;

namespace MemesFinderTextProcessor.Adapters
{
	public class TgMessageToModelAdapter : IModelAdapter<Message, KeyPhraseCollection>
	{
        private readonly Random _random;

        public TgMessageToModelAdapter()
		{
            _random = Random.Shared;
		}

        public TgMessageModel Adapt(Message message, KeyPhraseCollection keyPhrases) =>
            new()
            {
                Message = message,
                //return random array element from keyPhrases
                Keyword = keyPhrases[_random.Next(0, keyPhrases.Count)]
            };
    }
}

