using System.Collections.Generic;
using System.Threading.Tasks;

namespace shared.interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> List();
        Task<Order> Get(string orderId);
        Task<Order> Create(Order order);
        Task<Order> Update(Order order);
        Task Delete(string orderId);
    }
}