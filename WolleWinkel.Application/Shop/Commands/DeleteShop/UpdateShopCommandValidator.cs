using System;
using FluentValidation;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.UpdateShop;

namespace WolleWinkel.Application.Shop.Commands.DeleteShop
{
    public class DeleteShopCommandValidator:AbstractValidator<UpdateShopCommand>
    {
        private readonly IShopRepository _shopRepository;
        
        public DeleteShopCommandValidator(IShopRepository shopRepository)
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