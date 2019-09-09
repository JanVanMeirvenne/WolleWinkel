using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WolleWinkel.Application.Shop.Commands.UpdateShop;

namespace WolleWinkel.Application.OrderItem.Commands.DeleteOrderItem
{
    public class OrderItemDeleted:INotification
    {
        public Guid OrderId { get; set; }
        public Guid OrderItemId { get; set; }
        
        public class Handler:INotificationHandler<OrderItemDeleted>
        {
            public async Task Handle(OrderItemDeleted notification, CancellationToken cancellationToken)
            {
                await Task.FromResult(0);
            }
        }
        
    }
}