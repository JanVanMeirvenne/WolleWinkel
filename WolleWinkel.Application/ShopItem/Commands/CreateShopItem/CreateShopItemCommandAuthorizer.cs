using WolleWinkel.Application.Infrastructure;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.UpdateShop;

namespace WolleWinkel.Application.ShopItem.Commands.CreateShopItem
{
    public class CreateShopItemCommandAuthorizer:Authorizer<CreateShopItemCommand>
    {

        private ICurrentUser _currentUser;


        public CreateShopItemCommandAuthorizer(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
            RuleFor(o => _currentUser.Roles.Contains(AuthorizationRoles.Admin));
        }
        
        
    }
}