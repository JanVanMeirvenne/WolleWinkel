using WolleWinkel.Application.Infrastructure;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.UpdateShop;

namespace WolleWinkel.Application.Shop.Commands.DeleteShop
{
    public class DeleteShopCommandAuthorizer:Authorizer<DeleteShopCommand>
    {
        public DeleteShopCommandAuthorizer(ICurrentUser currentUser)
        {
            RuleFor(o => currentUser.Roles.Contains(AuthorizationRoles.Admin));
        }
        
        
    }
}