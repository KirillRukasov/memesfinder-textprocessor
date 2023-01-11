using System;
using FluentValidation;
using Telegram.Bot.Types;

namespace MemesFinderTextProcessor.Validators
{
	public class MessageValidator : AbstractValidator<Message>
	{
		public MessageValidator()
		{
			RuleFor(message => message.Text).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
		}
	}
}

