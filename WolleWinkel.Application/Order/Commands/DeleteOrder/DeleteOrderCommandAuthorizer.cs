using System;
using System.Linq;
using FluentValidation;
using WolleWinkel.Application.Infrastructure;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.CreateShop;

namespace WolleWinkel.Application.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommandAuthorizer:Authorizer<DeleteOrderCommand>
    {
        private readonly IDbContext _dbContext;
        
        public DeleteOrderCommandAuthorizer(ICurrentUser currentUser, IDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(o => o.Id).Must(o => BeOwnerOfOrder(currentUser.UserId,o));
        }

        public bool BeOwnerOfOrder(Guid userId, Guid orderId)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id.Equals(orderId));
            return order.Customer.Id.Equals(userId);
        }
        
        
    }
}