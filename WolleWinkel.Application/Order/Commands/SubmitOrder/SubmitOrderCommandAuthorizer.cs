using System;
using System.Data;
using System.Linq;
using FluentValidation;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Order.Commands.UpdateOrder;
using WolleWinkel.Domain.EnumObjects;

namespace WolleWinkel.Application.Order.Commands.SubmitOrder
{
    public class SubmitOrderCommandAuthorizer:Authorizer<SubmitOrderCommand>
    {
        private readonly IDbContext _dbContext;
        public SubmitOrderCommandAuthorizer(ICurrentUser currentUser,IDbContext dbContext)
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