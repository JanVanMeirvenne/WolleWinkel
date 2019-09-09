using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WolleWinkel.Application.Shop.Commands.UpdateShop;

namespace WolleWinkel.Application.Order.Commands.PayOrder
{
    public class OrderPaid:INotification
    {
        public Guid Id { get; set; }
        
        public class Handler:INotificationHandler<OrderPaid>
        {
            public async Task Handle(OrderPaid notification, CancellationToken cancellationToken)
            {
                await Task.FromResult(0);
            }
        }
    }
}