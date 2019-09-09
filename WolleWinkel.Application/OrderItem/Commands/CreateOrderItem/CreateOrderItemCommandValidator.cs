using System.Linq;
using FluentValidation;
using FluentValidation.Validators;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.OrderItem.Commands.CreateOrderItem
{
    public class CreateOrderItemCommandValidator:Validator<CreateOrderItemCommand>
    {
        private readonly IDbContext _dbContext;
        private ShopEntity _shopEntity;
        private OrderEntity _orderEntity;

        public CreateOrderItemCommandValidator(IDbContext dbContext,ICurrentUser currentUser)
        {

            RuleFor(o => o.ParentShopItem).Must((b, c) => { return IsValid(b); });
        }

        private bool IsValid(CreateOrderItemCommand createOrderItemCommand,CreateOrderItemCommand parent = null)
        {
            var shop = _dbContext.Shops.FirstOrDefault(o => o.Id.Equals(createOrderItemCommand.ParentShopItem));
            if (shop == null)
            {
                return false;
            }
            var shopItem = shop.Items.FirstOrDefault(o => o.Id.Equals(createOrderItemCommand.Item));
            if (shopItem == null)
            {
                return false;
            }

            if (createOrderItemCommand.Amount > shopItem.MaxAmount)
            {
                return false;
            }

            if (parent != null && createOrderItemCommand.ParentOrderItem != parent.Item)
            {
                return false;
            }
    

            foreach (var subCommand in createOrderItemCommand.Options)
            {
                if (!IsValid(subCommand,createOrderItemCommand))
                {
                    return false;
                }
            }

            return true;
        }
    }
}