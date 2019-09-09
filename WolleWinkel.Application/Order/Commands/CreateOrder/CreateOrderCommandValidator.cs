using System;
using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.CreateShop;
using WolleWinkel.Domain.Entities;
using WolleWinkel.Domain.EnumObjects;

namespace WolleWinkel.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommandValidator:Validator<CreateOrderCommand>
    {
        private readonly IDbContext _dbContext;

        public CreateOrderCommandValidator(IDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(o => o.UserId).NotEmpty().Must(Exist).Must(NotHavePendingOrder);
        }

        private bool Exist(Guid userId)
        {
            var item = _dbContext.Customers.FirstOrDefault(o => o.Id.Equals(userId));
            return item != null;
        }

        private bool NotHavePendingOrder(Guid userId)
        {
            var openOrder =
                _dbContext.Orders.FirstOrDefault(
                    o => o.Customer.Id.Equals(userId) && Equals(o.Status, OrderStatus.Open));
            return openOrder == null;
        }
    }
}