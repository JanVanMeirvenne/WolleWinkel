using System;
using System.Linq;
using FluentValidation;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.ShopItem.Commands.CreateShopItem;

namespace WolleWinkel.Application.ShopItem.Commands.DeleteShopItem
{
    public class DeleteShopItemCommandValidator:AbstractValidator<DeleteShopItemCommand>, Interfaces.IValidator<DeleteShopItemCommand>
    {
        private readonly IDbContext _dbContext;
       

        public DeleteShopItemCommandValidator(IDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(o => o.ShopId).NotEmpty().Must((args, shopId) => { return Exist(shopId, args.ShopItemId); });

        }

        public bool Exist(Guid shopId, Guid shopItemId)
        {
            var shop = _dbContext.Shops.FirstOrDefault(o => o.Id.Equals(shopId));
            if (shop != null)
            {
                var shopItem = shop.Items.FirstOrDefault(o => o.Id.Equals(shopItemId));
                return shopItem != null;
            }
            return shop != null;
        }
    }
}