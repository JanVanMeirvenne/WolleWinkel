using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.UpdateShop;

namespace WolleWinkel.Application.Shop.Queries.ListShops
{
    public class ListShopsQuery:IRequest<ListShopsViewModel>
    {
        public bool All { get; set; }
    };

    public class Handler : IRequestHandler<ListShopsQuery,ListShopsViewModel>
    {
        private readonly IDbContext _dbContext;
        private readonly ICurrentUser _currentUser;

        public Handler(IDbContext dbContext,ICurrentUser currentUser)
        {
            _dbContext = dbContext;
            _currentUser = currentUser;
        }


        public async Task<ListShopsViewModel> Handle(ListShopsQuery request, CancellationToken cancellationToken)
        {
            var shops = _dbContext.Shops.Where(o => o.Open || request.All).Select(o => new ShopDto()
            {
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                Open = o.Open
            });
            return new ListShopsViewModel(shops)
            {
                Admin = _currentUser.IsAdmin
            };
        }
    }
}