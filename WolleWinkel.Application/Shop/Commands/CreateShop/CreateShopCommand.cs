using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Shop.Commands.CreateShop
{
    public class CreateShopCommand:IRequest<CreateShopResult>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public class Handler:IRequestHandler<CreateShopCommand,CreateShopResult>
        {
            private readonly IDbContext _dbContext;
            private readonly IMediator _mediator;

            public Handler(IDbContext dbContext,IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }
            
            
            public async Task<CreateShopResult> Handle(CreateShopCommand request, CancellationToken cancellationToken)
            {
                var entity = new ShopEntity
                {
                    Name = request.Name,
                    Description = request.Description
                };
                _dbContext.Shops.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                await _mediator.Publish(new ShopCreated(){ShopId = entity.Id}, cancellationToken);
                return CreateShopResult.Create(entity);


            }
        }
    }
}