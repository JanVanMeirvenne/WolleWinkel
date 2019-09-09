using FluentValidation;
using WolleWinkel.Application.Infrastructure;
using WolleWinkel.Application.Interfaces;

namespace WolleWinkel.Application.Shop.Commands.CreateShop
{
    public class CreateShopCommandAuthorizer:Authorizer<CreateShopCommand>
    {
        public CreateShopCommandAuthorizer(ICurrentUser currentUser)
        {
            RuleFor(o => currentUser.Roles.Contains(AuthorizationRoles.Admin));
        }
        
        
    }
}