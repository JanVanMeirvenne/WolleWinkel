using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WolleWinkel.Application.Order.Commands.DeleteOrder
{
    public class OrderDeleted:INotification
    {
        public Guid OrderId { get; set; }
        
        public class Handler:INotificationHandler<OrderDeleted>
        {
            public async Task Handle(OrderDeleted notification, CancellationToken cancellationToken)
            {
                return;
            }
        }
    }
}