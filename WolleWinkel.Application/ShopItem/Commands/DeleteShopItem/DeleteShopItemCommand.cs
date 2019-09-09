using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.UpdateShop;

namespace WolleWinkel.Application.ShopItem.Commands.DeleteShopItem
{
    public class DeleteShopItemCommand:IRequest<Unit>
    {
        public Guid ShopId { get; set; }
        public Guid ShopItemId { get; set; }

        public class Handler : IRequestHandler<DeleteShopItemCommand, Unit>
        {
            private readonly IDbContext _dbContext;
            private readonly Mediator _mediator;
            
            public Handler(IDbContext dbContext,Mediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }
            public async Task<Unit> Handle(DeleteShopItemCommand request, CancellationToken cancellationToken)
            {
                var shop = _dbContext.Shops.FirstOrDefault(o => o.Id.Equals(request.ShopId));
                //var shopItem = _dbContext.ShopItems.FirstOrDefault(o => o.Id.Equals(request.ShopItemId));
                var shopItem = shop.Items.FirstOrDefault(o => o.Id.Equals(request.ShopItemId));

                shop.RemoveItem(shopItem);
               // _dbContext.ShopItems.Remove(shopItem);
                _dbContext.Shops.Update(shop);

                await _mediator.Publish(new ShopItemDeleted()
                {
                    ShopId = shop.Id,
                    ShopItemId = shopItem.Id
                }, cancellationToken);

                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;

            }
        }
        
    }
}