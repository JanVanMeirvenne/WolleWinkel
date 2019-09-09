using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.CreateShop;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Shop.Commands.UpdateShop
{
    public class UpdateShopCommand:IRequest<UpdateShopResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Open { get; set; }

        public class Handler : IRequestHandler<UpdateShopCommand, UpdateShopResult>
        {

            private readonly IDbContext _dbContext;
            private readonly IMediator _mediator;

            public Handler(IDbContext dbContext,IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<UpdateShopResult> Handle(UpdateShopCommand request, CancellationToken cancellationToken)
            {
                var entity = new ShopEntity
                {
                    Name = request.Name,
                    Id = request.Id,
                    Description = request.Description,
                    Open = request.Open
                };
                _dbContext.Shops.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                await _mediator.Publish(new ShopUpdated() {ShopId = entity.Id},cancellationToken);
                return UpdateShopResult.Create(entity);
            }
        }

    }
}