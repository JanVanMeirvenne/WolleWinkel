using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WolleWinkel.Application.Order.Commands.UpdateOrder
{
    public class OrderSubmitted:INotification
    {
        public Guid OrderId { get; set; }
        
        public class Handler:INotificationHandler<OrderSubmitted>
        {
            public async Task Handle(OrderSubmitted notification, CancellationToken cancellationToken)
            {
                return;
            }
        }
    }
}