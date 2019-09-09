using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WolleWinkel.Application.ShopItem.Commands.DeleteShopItem
{
    public class ShopItemDeleted:INotification
    {
        public Guid ShopId { get; set; }
        public Guid ShopItemId { get; set; }

        public class Handler : INotificationHandler<ShopItemDeleted>
        {
            public Task Handle(ShopItemDeleted notification, CancellationToken cancellationToken)
            {
                return Task.FromResult(0);
            }
        }
    }
}