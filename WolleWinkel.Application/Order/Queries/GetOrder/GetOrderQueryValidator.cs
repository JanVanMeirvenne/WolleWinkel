using System;
using System.Linq;
using FluentValidation;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.OrderItem.Commands.CreateOrderItem;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Order.Queries.GetOrder
{
    public class GetOrderQueryValidator:Validator<GetOrderQuery>
    {
        private readonly IDbContext _dbContext;

        public GetOrderQueryValidator(IDbContext dbContext,ICurrentUser currentUser)
        {
            _dbContext = dbContext;
            RuleFor(o => o.OrderId).NotEmpty().Must((b) => { return Exist(b); });
        }

        private bool Exist(Guid orderId)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Equals(orderId));
            return order != null;
        }
        
    }
}