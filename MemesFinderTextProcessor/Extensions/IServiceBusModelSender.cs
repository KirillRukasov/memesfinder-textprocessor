using MemesFinderTextProcessor.Models;
using System.Threading.Tasks;

namespace MemesFinderTextProcessor.Extensions
{
    public interface IServiceBusModelSender
    {
        Task SendMessageAsync(TgMessageModel tgMessageModel);
    }
}