using System.Net.Sockets;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Repositories
{
    public interface IOrderRepository
    {
        void Add(OrderEntity order);

        OrderEntity GetOrderById(string id);
        void SaveOrder(OrderEntity order);
        void DeleteOrder(string id);
       
    }
}