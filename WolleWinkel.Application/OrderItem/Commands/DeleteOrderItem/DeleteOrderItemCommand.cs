using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.UpdateShop;
using WolleWinkel.Domain.Entities;
using WolleWinkel.Domain.EnumObjects;
using WolleWinkel.Domain.ValueObjects;

namespace WolleWinkel.Application.OrderItem.Commands.DeleteOrderItem
{
    public class DeleteOrderItemCommand:IRequest
    {
        public Guid OrderId { get; set; }
        public Guid OrderItemId { get; set; }
        
        public IEnumerable<DeleteOrderItemCommand> Options { get; set; }

        public class Handler:IRequestHandler<DeleteOrderItemCommand>
        {
            private readonly IMediator _mediator;
            private readonly IDbContext _dbContext;
            private readonly IMapper _mapper;
          

            public Handler(IMediator mediator, IDbContext dbContext,IMapper mapper)
            {
                _mediator = mediator;
                _dbContext = dbContext;
                _mapper = mapper;
            }


            public async Task<Unit> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
            {
                var order = _dbContext.Orders.FirstOrDefault(o => o.Id.Equals(request.OrderId));
                var orderItem = order.Items.FirstOrDefault(o => o.Id.Equals(request.OrderItemId));
                order.RemoveOrderItem(orderItem);
                _dbContext.Orders.Update(order);
                await _dbContext.SaveChangesAsync(cancellationToken);
                await _mediator.Publish(new OrderItemDeleted()
                {
                    OrderId = request.OrderId,
                    OrderItemId = orderItem.Id
                });
               return Unit.Value;
               

            }
        }
        
        
        
    }
}