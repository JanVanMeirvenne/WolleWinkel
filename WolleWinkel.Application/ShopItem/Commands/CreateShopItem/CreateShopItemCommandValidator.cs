using System;
using System.Linq;
using FluentValidation;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.UpdateShop;

namespace WolleWinkel.Application.ShopItem.Commands.CreateShopItem
{
    public class CreateShopItemCommandValidator:AbstractValidator<CreateShopItemCommand>, Interfaces.IValidator<CreateShopItemCommand>
    {
        private readonly IDbContext _dbContext;
        
        public CreateShopItemCommandValidator(IDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(o => o.Name).NotEmpty();
            RuleFor(o => o.ParentId).NotEmpty().Must(Exist);
            RuleFor(o => o.Description).NotEmpty();

        }

        public bool Exist(Guid shopId)
        {
            var shop = _dbContext.Shops.FirstOrDefault(o => o.Id.Equals(shopId));
            return shop != null;
        }
    }
}