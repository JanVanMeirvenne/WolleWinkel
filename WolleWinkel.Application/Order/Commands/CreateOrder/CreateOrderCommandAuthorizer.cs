using FluentValidation;
using WolleWinkel.Application.Infrastructure;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.CreateShop;

namespace WolleWinkel.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommandAuthorizer:Authorizer<CreateOrderCommand>
    {
        public CreateOrderCommandAuthorizer(ICurrentUser currentUser)
        {
            RuleFor(o => o.UserId).Must(o => o.Equals(currentUser.UserId));
        }
        
        
    }
}