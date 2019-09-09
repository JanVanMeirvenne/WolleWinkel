using WolleWinkel.Application.Infrastructure;
using WolleWinkel.Application.Interfaces;

namespace WolleWinkel.Application.ShopItem.Commands.DeleteShopItem
{
    public class DeleteShopItemCommandAuthorizer:Authorizer<DeleteShopItemCommand>
    {

        private ICurrentUser _currentUser;


        public DeleteShopItemCommandAuthorizer(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
            RuleFor(o => _currentUser.Roles.Contains(AuthorizationRoles.Admin));
        }
        
        
    }
}