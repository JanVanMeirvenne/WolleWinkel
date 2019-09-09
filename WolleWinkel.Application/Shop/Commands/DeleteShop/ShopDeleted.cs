using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Notifications.Models;

namespace WolleWinkel.Application.Shop.Commands.DeleteShop
{
    public class ShopDeleted:INotification
    {
        public Guid ShopId { get; set; }

        public class Handler:INotificationHandler<ShopDeleted>
        {
            private INotificationService _notificationService;

            public Handler(INotificationService notificationService)
            {
                _notificationService = notificationService;
            }
            
            public async Task Handle(ShopDeleted notification, CancellationToken cancellationToken)
            {
                await _notificationService.Send(new Message());
            }
        }
        
    }
}