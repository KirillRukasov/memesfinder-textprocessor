using System;
using MemesFinderTextProcessor.Models;

namespace MemesFinderTextProcessor.Interfaces.Adapters
{
	public interface IModelAdapter<in T1, in T2>
		where T1 : class
		where T2 : class
	{
		public TgMessageModel Adapt(T1 message, T2 keyPhrases);
    }
}

