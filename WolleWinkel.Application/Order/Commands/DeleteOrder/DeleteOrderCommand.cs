using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommand:IRequest
    {
        public Guid Id { get; set; }
        
        public class Handler:IRequestHandler<DeleteOrderCommand>
        {
            private readonly IDbContext _dbContext;
            private readonly IMediator _mediator;

            public Handler(IMediator mediator,IDbContext dbContext)
            {
                _mediator = mediator;
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
            {
                var order = _dbContext.Orders.FirstOrDefault(o => o.Id.Equals(request.Id));
               
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync(cancellationToken);
                await _mediator.Publish(new OrderDeleted()
                {
                    OrderId = order.Id
                },cancellationToken);
                return Unit.Value;
            }
        }
        
    }
}