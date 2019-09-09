using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.UpdateShop;

namespace WolleWinkel.Application.Order.Commands.PayOrder
{
    public class PayOrderCommand:IRequest
    {
        public Guid OrderId { get; set; }
        
        public class Handler:IRequestHandler<PayOrderCommand>
        {
            private readonly IMediator _mediator;
            private readonly IDbContext _dbContext;

            public Handler(IMediator mediator, IDbContext dbContext)
            {
                _mediator = mediator;
                _dbContext = dbContext;
            }
            
            public async Task<Unit> Handle(PayOrderCommand request, CancellationToken cancellationToken)
            {
                var order = _dbContext.Orders.FirstOrDefault(o => o.Id.Equals(request.OrderId));
                order.PaidOrder();
                _dbContext.Orders.Update(order);
                await _dbContext.SaveChangesAsync(cancellationToken);
                await _mediator.Publish(new OrderPaid()
                {
                    Id = order.Id
                },cancellationToken);
                return Unit.Value;
                

            }
        }
    }
}