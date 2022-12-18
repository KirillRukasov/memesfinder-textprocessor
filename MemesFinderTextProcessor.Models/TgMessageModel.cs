using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace MemesFinderTextProcessor.Models
{
    public class TgMessageModel
    {
        public Message Message { get; set; }
        public string Keyword { get; set; }
    }
}
