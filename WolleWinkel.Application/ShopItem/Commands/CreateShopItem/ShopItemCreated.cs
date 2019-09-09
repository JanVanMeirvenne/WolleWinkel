using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WolleWinkel.Application.ShopItem.Commands.CreateShopItem
{
    public class ShopItemCreated:INotification
    {
        public Guid ShopItemId { get; set; }
        public Guid ShopId { get; set; }

        public class Handler:INotificationHandler<ShopItemCreated>
        {
            public Task Handle(ShopItemCreated notification, CancellationToken cancellationToken)
            {
                return Task.FromResult(0);
            }
        }
    }
}