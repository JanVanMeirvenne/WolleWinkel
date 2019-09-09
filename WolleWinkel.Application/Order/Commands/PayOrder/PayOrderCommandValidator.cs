using System;
using System.Linq;
using FluentValidation;
using Microsoft.VisualBasic.CompilerServices;
using WolleWinkel.Application.Interfaces;

namespace WolleWinkel.Application.Order.Commands.PayOrder
{
    public class PayOrderCommandValidator:Validator<PayOrderCommand>
    {
        private readonly IDbContext _dbContext;

        public PayOrderCommandValidator(IDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(o => o.OrderId).Must(o => Exist(o));
        }

        private bool Exist(Guid guid)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id.Equals(guid));
            return order != null;
        }
    }
}