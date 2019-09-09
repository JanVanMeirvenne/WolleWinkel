using System;
using System.Data;
using FluentValidation;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.CreateShop;

namespace WolleWinkel.Application.Shop.Commands.UpdateShop
{
    public class UpdateShopCommandValidator:AbstractValidator<UpdateShopCommand>
    {
        private readonly IShopRepository _shopRepository;
        
        public UpdateShopCommandValidator(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
            RuleFor(o => o.Name).NotEmpty();
            RuleFor(o => o.Id).NotEmpty().Must(Exist);
            
        }

        public bool Exist(Guid shopId)
        {
            var shop = _shopRepository.GetById(shopId);
            return shop != null;
        }
    }
}