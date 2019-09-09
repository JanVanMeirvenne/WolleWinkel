using System;
using System.Linq;
using FluentValidation;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.ShopItem.Commands.CreateShopItem;

namespace WolleWinkel.Application.ShopItem.Commands.UpdateShopItem
{
    public class UpdateShopItemCommandValidator:Validator<UpdateShopItemCommand>
    {
        private readonly IDbContext _dbContext;
       

        public UpdateShopItemCommandValidator(IDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(o => o.ParentId).NotEmpty().Must((args, shopId) => { return Exist(shopId, args.ShopItemId); });

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