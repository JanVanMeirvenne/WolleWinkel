using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommand:IRequest<CreateOrderCommandViewModel>
    {
        public Guid UserId { get; set; }
        
        public class Handler:IRequestHandler<CreateOrderCommand,CreateOrderCommandViewModel>
        {
            private readonly IDbContext _dbContext;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public Handler(IMediator mediator,IDbContext dbContext, IMapper mapper)
            {
                _mediator = mediator;
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<CreateOrderCommandViewModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                var user = _dbContext.Customers.FirstOrDefault(o => o.Id.Equals(request.UserId));
                var entity = new OrderEntity()
                {
                    Customer = user
                };
                _dbContext.Orders.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                await _mediator.Publish(new OrderCreated()
                {
                    OrderId = entity.Id
                },cancellationToken);
                return new CreateOrderCommandViewModel()
                {
                    Order = _mapper.Map<OrderDto>(entity)
                };
            }
        }
        
    }
}