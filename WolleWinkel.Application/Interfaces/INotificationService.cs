using System.Threading.Tasks;
using WolleWinkel.Application.Notifications.Models;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Interfaces
{
    public interface INotificationService
    {
        Task Send(Message message);
    }
}