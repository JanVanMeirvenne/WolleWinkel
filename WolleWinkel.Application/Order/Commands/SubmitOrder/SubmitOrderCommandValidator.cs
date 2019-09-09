using System;
using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.CreateShop;
using WolleWinkel.Domain.Entities;
using WolleWinkel.Domain.EnumObjects;

namespace WolleWinkel.Application.Order.Commands.UpdateOrder
{
    public class SubmitOrderCommandValidator:Validator<SubmitOrderCommand>
    {
        private readonly IDbContext _dbContext;

        public SubmitOrderCommandValidator(IDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(o => o.Id).NotEmpty().Must(Exist);
            RuleFor(o => o.Id).Must(o => BeInOpenState(o));
            RuleFor(o => o.Type).Must(o => PaymentType.TryParse(o,out PaymentType dummy));
        }

        private bool Exist(Guid id)
        {
            var item = _dbContext.Orders.FirstOrDefault(o => o.Id.Equals(id));
            return item != null;
        }
        
        private bool BeInOpenState(Guid id)
        {
            var item = _dbContext.Orders.FirstOrDefault(o => o.Id.Equals(id));
            return item?.Status == OrderStatus.Open;
        }
        
        

        
    }
}