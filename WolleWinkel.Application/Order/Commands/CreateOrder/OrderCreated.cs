using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WolleWinkel.Application.Order.Commands.CreateOrder
{
    public class OrderCreated:INotification
    {
        public Guid OrderId { get; set; }
        
        public class Handler:INotificationHandler<OrderCreated>
        {
            public async Task Handle(OrderCreated notification, CancellationToken cancellationToken)
            {
                return;
            }
        }
    }
}