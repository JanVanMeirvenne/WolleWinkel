using System;
using System.Linq;
using FluentValidation;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Order.Queries.GetOrder
{
    public class GetOrderQueryAuthorizer:Authorizer<GetOrderQuery>
    {
        private readonly IDbContext _dbContext;

        public GetOrderQueryAuthorizer(IDbContext dbContext,ICurrentUser currentUser)
        {
            _dbContext = dbContext;
            RuleFor(o => o.OrderId).Must(c => BeOwnedByUser(c, currentUser));
        }

        private bool BeOwnedByUser(Guid guid, ICurrentUser currentUser)
        {
            var orderUser = _dbContext.Orders.FirstOrDefault(o => o.Id.Equals(guid)).User.Id;
            return orderUser == currentUser.UserId;
            
        }

        
    }
}