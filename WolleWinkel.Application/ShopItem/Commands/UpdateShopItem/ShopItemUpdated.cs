using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WolleWinkel.Application.ShopItem.Commands.UpdateShopItem
{
    public class ShopItemUpdated:INotification
    {
        public Guid ShopId { get; set; }

        public class Handler : INotificationHandler<ShopItemUpdated>
        {
            public async Task Handle(ShopItemUpdated notification, CancellationToken cancellationToken)
            {
                return;
            }
        }
        
    }
}