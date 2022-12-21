using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MemesFinderTextProcessor.Factories
{
    // public class that returns content depending on the content in tgUpdate
    public class MessageProcessFactory
    {
        private Message _tgMessage;
        public Message GetMessageToProcess(Update tgUpdate)
        {
            if (tgUpdate.Type == UpdateType.Message)
            {
                _tgMessage = tgUpdate.Message;
                return _tgMessage;
            }
            else if (tgUpdate.Type == UpdateType.EditedMessage)
            {
                _tgMessage = tgUpdate.EditedMessage;
                return _tgMessage;
            }

            // other message type
            return null;
        }
    }
}

