using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Notifications.Models;
using WolleWinkel.Application.Shop.Commands.CreateShop;

namespace WolleWinkel.Application.Shop.Commands.UpdateShop
{
    public class ShopUpdated : INotification
    {
        public Guid ShopId { get; set; }

        public class ShopUpdatedHandler : INotificationHandler<ShopUpdated>
        {
            private readonly INotificationService _notification;

            public ShopUpdatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(ShopUpdated notification, CancellationToken cancellationToken)
            {
                await _notification.Send(new Message());
            }
        }
    }
}