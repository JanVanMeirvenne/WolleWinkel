using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.UpdateShop;

namespace WolleWinkel.Application.Shop.Commands.DeleteShop
{
    public class DeleteShopCommand:IRequest
    {
        public Guid ShopId { get; set; }
        
        public class Handler:IRequestHandler<DeleteShopCommand>
        {
            private readonly IDbContext _dbContext;
            private readonly Mediator _mediator;

            public Handler(IDbContext dbContext, Mediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(DeleteShopCommand request,CancellationToken cancellationToken)
            {
                _dbContext.Shops.Remove(_dbContext.Shops.FirstOrDefault(o => o.Id.Equals(request.ShopId)));
                await _dbContext.SaveChangesAsync(cancellationToken);
                await _mediator.Publish(new ShopDeleted()
                {
                    ShopId = request.ShopId
                },cancellationToken);
                return Unit.Value;
            }

           
        }
        
    }
}