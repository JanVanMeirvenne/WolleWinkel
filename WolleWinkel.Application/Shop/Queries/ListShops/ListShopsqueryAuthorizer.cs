using WolleWinkel.Application.Infrastructure;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.UpdateShop;

namespace WolleWinkel.Application.Shop.Queries.ListShops
{
    public class ListShopsQueryAuthorizer:Authorizer<ListShopsQuery>
    {
        public ListShopsQueryAuthorizer(ICurrentUser currentUser)
        {
            When(o => o.All, () => { RuleFor(o => currentUser.Roles.Contains(AuthorizationRoles.Admin)); });
        }
        
        
    }
}