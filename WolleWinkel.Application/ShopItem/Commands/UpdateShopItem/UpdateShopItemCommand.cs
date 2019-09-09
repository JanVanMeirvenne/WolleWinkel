using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.UpdateShop;
using WolleWinkel.Application.ShopItem.Commands.CreateShopItem;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.ShopItem.Commands.UpdateShopItem
{
    public class UpdateShopItemCommand:IRequest
    {
        public Guid ParentId { get; set; }
        public Guid ShopItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxAmount { get; set; }
        public double Price { get; set; }
        public ICollection<UpdateShopItemCommand> Options { get; set; }
        
        public class Handler:IRequestHandler<UpdateShopItemCommand>
        {
            private IDbContext _dbContext;
            private IMediator _mediator;
            
            public Handler(IDbContext dbContext,IMediator mediator)
            {
                _dbContext = _dbContext;
                _mediator = _mediator;
            }
            public async Task<Unit> Handle(UpdateShopItemCommand request, CancellationToken cancellationToken)
            {
                var entity = GetEntityFromRequest(request);
                foreach (var option in request.Options)
                {
                    entity.Options.Add(GetEntityFromRequest(option));
                }

                var shop = _dbContext.Shops.FirstOrDefault(o => o.Id.Equals(entity.Id));
                shop.Items.Remove(entity);
                shop.Items.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                
                return Unit.Value;

            }
            
            private ShopItemEntity GetEntityFromRequest(UpdateShopItemCommand request)
            {
                var entity = new ShopItemEntity()
                {
                    Id = request.ShopItemId,
                    Description = request.Description,
                    MaxAmount = request.MaxAmount,
                    Name = request.Name,
                    Price = request.Price
                };
                return entity;
            }
        }

    }
}