using System;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WolleWinkel.Application.Infrastructure;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Shop.Commands.CreateShop
{
    public class CreateShopCommandValidator:Validator<CreateShopCommand>
    {
        private readonly IDbContext _dbContext;

        public CreateShopCommandValidator(IDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(o => o.Name).NotEmpty().Must(BeUnique);
        }

        private bool BeUnique(string shopName)
        {
            var item = _dbContext.Shops.FirstAsync(o => o.Name.Equals(shopName, StringComparison.OrdinalIgnoreCase)).Result;
            return item == null;
        }
    }
}