using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WolleWinkel.Application.Infrastructure;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.UpdateShop;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.ShopItem.Commands.CreateShopItem
{
    public class CreateShopItemCommand:IRequest<CreateShopItemResult>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int MaxAmount { get; set; }
        public ICollection<CreateShopItemCommand> Options { get; private set; }
        public Guid ParentId { get; set; }
        

        public CreateShopItemCommand()
        {
            Options = new List<CreateShopItemCommand>();
        }
        
        public class Handler():IRequestHandler<CreateShopItemCommand,CreateShopItemResult>
        {
            private readonly IDbContext _dbContext;
            private readonly Mediator _mediator;

            public Handler(IDbContext dbContext,Mediator mediator)
            {
                _mediator = mediator;
                _dbContext = dbContext;
            }
            
            public async Task<CreateShopItemResult> Handle(CreateShopItemCommand request, CancellationToken cancellationToken)
            {
                var entity = GetEntityFromRequest(request);
                foreach (var option in request.Options)
                {
                    entity.AddOption(GetEntityFromRequest(option));
                }

                var shop = _dbContext.Shops.FirstOrDefault(o => o.Id.Equals(request.ParentId));

                if (shop != null)
                {
                    shop.AddItem(entity);

                    _dbContext.Shops.Update(shop);

                    //_dbContext.ShopItems.Add(entity);
                }

                await _dbContext.SaveChangesAsync(cancellationToken);
                await _mediator.Publish(new ShopItemCreated()
                {
                    ShopItemId = entity.Id,
                    ShopId = shop.Id
                }, cancellationToken);
                return new CreateShopItemResult()
                {
                    Model = CreateShopItemViewModel.Create(entity, shop.Id)
                };



            }

            private ShopItemEntity GetEntityFromRequest(CreateShopItemCommand request)
            {
                var entity = new ShopItemEntity()
                {
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