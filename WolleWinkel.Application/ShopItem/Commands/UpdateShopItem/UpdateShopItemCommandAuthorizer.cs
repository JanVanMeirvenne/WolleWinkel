using WolleWinkel.Application.Infrastructure;
using WolleWinkel.Application.Interfaces;

namespace WolleWinkel.Application.ShopItem.Commands.UpdateShopItem
{
    public class UpdateShopItemCommandAuthorizer:Authorizer<UpdateShopItemCommand>
    {

        private ICurrentUser _currentUser;


        public UpdateShopItemCommandAuthorizer(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
            RuleFor(o => _currentUser.Roles.Contains(AuthorizationRoles.Admin));
        }
        
        
    }
}