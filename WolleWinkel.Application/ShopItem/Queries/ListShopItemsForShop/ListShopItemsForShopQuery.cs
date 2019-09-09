using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.ShopItem.Queries.ListShopItemsForShop
{
    public class ListShopItemsForShopQuery : IRequest<ListShopItemsForShopViewModel>
    {
        public Guid ShopId { get; set; }

        public class Handler : IRequestHandler<ListShopItemsForShopQuery, ListShopItemsForShopViewModel>
        {
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;
            private readonly ICurrentUser _currentUser;

            public Handler(IDbContext dbContext, IMapper mapper, ICurrentUser currentUser)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                _currentUser = currentUser;
            }

            public async Task<ListShopItemsForShopViewModel> Handle(ListShopItemsForShopQuery request,
                CancellationToken cancellationToken)
            {
                var shopItems = _dbContext.Shops.FirstOrDefault(o => o.Id.Equals(request.ShopId));
                var model = new ListShopItemsForShopViewModel()
                {
                    Items = _mapper.Map<IEnumerable<ShopItemDto>>(shopItems),
                    IsAdmin = _currentUser.IsAdmin
                };
                return model;
            }

        }
    }
}