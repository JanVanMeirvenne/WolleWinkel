using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Notifications.Models;

namespace WolleWinkel.Application.Shop.Commands.CreateShop
{
    public class ShopCreated : INotification
        {
            public Guid ShopId { get; set; }

            public class ShopCreatedHandler : INotificationHandler<ShopCreated>
            {
                private readonly INotificationService _notification;

                public ShopCreatedHandler(INotificationService notification)
                {
                    _notification = notification;
                }

                public async Task Handle(ShopCreated notification, CancellationToken cancellationToken)
                {
                    await _notification.Send(new Message());
                }
            }
        }
    }
