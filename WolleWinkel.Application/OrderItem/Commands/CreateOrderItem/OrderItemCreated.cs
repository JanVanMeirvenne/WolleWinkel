using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WolleWinkel.Application.Shop.Commands.UpdateShop;

namespace WolleWinkel.Application.OrderItem.Commands.CreateOrderItem
{
    public class OrderItemCreated:INotification
    {
        public Guid OrderId { get; set; }
        public Guid OrderItemId { get; set; }
        
        public class Handler:INotificationHandler<OrderItemCreated>
        {
            public async Task Handle(OrderItemCreated notification, CancellationToken cancellationToken)
            {
                await Task.FromResult(0);
            }
        }
        
    }
}