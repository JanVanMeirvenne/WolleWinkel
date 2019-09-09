using FluentValidation;
using WolleWinkel.Application.Infrastructure;
using WolleWinkel.Application.Interfaces;

namespace WolleWinkel.Application.Shop.Commands.UpdateShop
{
    public class UpdateShopCommandAuthorizer:Authorizer<UpdateShopCommand>
    {
        public UpdateShopCommandAuthorizer(ICurrentUser currentUser)
        {
            RuleFor(o => currentUser.Roles.Contains(AuthorizationRoles.Admin));
        }
        
        
    }
}