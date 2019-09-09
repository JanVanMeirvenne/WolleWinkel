using System;
using System.Linq;
using FluentValidation;
using FluentValidation.Validators;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.OrderItem.Commands.CreateOrderItem
{
    public class CreateOrderItemCommandAuthorizer:Authorizer<CreateOrderItemCommand>
    {
        private readonly IDbContext _dbContext;
        private ShopEntity _shopEntity;
        private OrderEntity _orderEntity;

        public CreateOrderItemCommandAuthorizer(IDbContext dbContext,ICurrentUser currentUser)
        {

            RuleFor(o => o.ParentOrderItem).Must(c => BeOwnedByUser(c, currentUser));
        }

        private bool BeOwnedByUser(Guid guid, ICurrentUser currentUser)
        {
            var orderUser = _dbContext.Orders.FirstOrDefault(o => o.Id.Equals(guid)).User.Id;
            return orderUser == currentUser.UserId;
            
        }

        
    }
}