using MemesFinderTextProcessor.Models;
using System.Threading.Tasks;

namespace MemesFinderTextProcessor.Clients
{
    public interface IServiceBusModelSender
    {
        Task SendMessageAsync(TgMessageModel tgMessageModel);
    }
}