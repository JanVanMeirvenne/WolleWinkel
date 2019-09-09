using System.Linq;
using FluentValidation;
using FluentValidation.Validators;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.OrderItem.Commands.DeleteOrderItem
{
    public class DeleteOrderItemCommandValidator:Validator<DeleteOrderItemCommand>
    {
        private readonly IDbContext _dbContext;
        private ShopEntity _shopEntity;
        private OrderEntity _orderEntity;

        public DeleteOrderItemCommandValidator(IDbContext dbContext,ICurrentUser currentUser)
        {

            RuleFor(o => o.OrderId).Must((b, c) => { return IsValid(b); });
        }

        private bool IsValid(DeleteOrderItemCommand deleteOrderItemCommand,DeleteOrderItemCommand parent = null)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id.Equals(deleteOrderItemCommand.OrderId));
            var orderItem = order?.Items.Where(o => o.Id.Equals(deleteOrderItemCommand.OrderItemId));
            if (order == null || orderItem == null)
            {
                return false;
            }

            return true;
            
        }
    }
}