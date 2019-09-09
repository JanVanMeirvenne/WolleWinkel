using System;
using System.Linq;
using FluentValidation;
using Microsoft.VisualBasic.CompilerServices;
using WolleWinkel.Application.Interfaces;

namespace WolleWinkel.Application.Order.Commands.PayOrder
{
    public class PayOrderCommandAuthorizer:Validator<PayOrderCommand>
    {
        private readonly IDbContext _dbContext;

        public PayOrderCommandAuthorizer(IDbContext dbContext,ICurrentUser currentUser)
        {
            _dbContext = dbContext;
            RuleFor(o => o.OrderId).Must(o => currentUser.IsAdmin);
        }

       
    }
}