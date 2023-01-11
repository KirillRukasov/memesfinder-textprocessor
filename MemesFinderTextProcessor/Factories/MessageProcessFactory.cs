using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MemesFinderTextProcessor.Factories
{
    public class MessageProcessFactory
    {
        public static Message GetMessageToProcess(Update tgUpdate) => tgUpdate.Type switch
        {
            UpdateType.Message => tgUpdate.Message,
            UpdateType.EditedMessage => tgUpdate.EditedMessage,
            _ => new Message()
        };
    }
}

