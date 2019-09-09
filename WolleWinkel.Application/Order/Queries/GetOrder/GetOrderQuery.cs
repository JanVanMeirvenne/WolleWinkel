using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Order.Queries.GetOrder
{
    public class GetOrderQuery:IRequest<GetOrderQueryViewModel>
    {
        public Guid OrderId { get; set; }
        public class Handler : IRequestHandler<GetOrderQuery,GetOrderQueryViewModel>
        {
            private readonly IDbContext _dbContext;
            private IMediator _mediator;
            private readonly ICurrentUser _currentUser;
            private readonly IMapper _mapper;

            public Handler(IDbContext dbContext,IMediator mediator,ICurrentUser currentUser,IMapper mapper)
            {
                _dbContext = dbContext;
                _mediator = mediator;
                _currentUser = currentUser;
                _mapper = mapper;
            }
            
            public async Task<GetOrderQueryViewModel> Handle(GetOrderQuery request, CancellationToken cancellationToken)
            {
                var order = _dbContext.Orders.FirstOrDefault(o => o.Id.Equals(request.OrderId));
                
                
                return new GetOrderQueryViewModel()
                {
                    Order = _mapper.Map<OrderEntity,OrderDto>(order),
                    Admin = _currentUser.IsAdmin
                };
            }
        }
    }
}