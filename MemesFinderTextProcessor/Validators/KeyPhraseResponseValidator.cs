using System;
using Azure;
using Azure.AI.TextAnalytics;
using FluentValidation;

namespace MemesFinderTextProcessor.Validators
{
	public class KeyPhraseResponseValidator : AbstractValidator<Response<KeyPhraseCollection>>
	{
		public KeyPhraseResponseValidator()
		{
			RuleFor(response => response.Value).Must(value => value.Count > 0).WithMessage("Key phrases not found");
		}
	}
}

