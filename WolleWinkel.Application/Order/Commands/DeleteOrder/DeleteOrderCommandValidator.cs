using System;
using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.CreateShop;

namespace WolleWinkel.Application.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidator:Validator<DeleteOrderCommand>
    {
        private readonly IDbContext _dbContext;

        public DeleteOrderCommandValidator(IDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(o => o.Id).NotEmpty().Must(Exist);
        }

        private bool Exist(Guid orderId)
        {
            var item = _dbContext.Orders.FirstOrDefault(o => o.Id.Equals(orderId));
            return item != null;
        }
    }
}