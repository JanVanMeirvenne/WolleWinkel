using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Order.Queries.ListOrders
{
    public class ListOrdersQuery:IRequest<ListOrdersQueryViewModel>
    {
        public class Handler : IRequestHandler<ListOrdersQuery,ListOrdersQueryViewModel>
        {
            private readonly IDbContext _dbContext;
            private IMediator _mediator;
            private readonly ICurrentUser _currentUser;
            private IMapper _mapper;

            public Handler(IDbContext dbContext,IMediator mediator,ICurrentUser currentUser,IMapper mapper)
            {
                _dbContext = dbContext;
                _mediator = mediator;
                _currentUser = currentUser;
                _mapper = mapper;
            }
            
            public async Task<ListOrdersQueryViewModel> Handle(ListOrdersQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<OrderEntity> orders = null;
                if (_currentUser.IsAdmin)
                {
                    orders = _dbContext.Orders;
                }
                else
                {
                    orders = _dbContext.Orders.Where(o => o.User.Id.Equals(_currentUser.UserId));
                }
                
                return new ListOrdersQueryViewModel()
                {
                    Orders = orders.Select(o => _mapper.Map<OrderEntity,OrderDto>(o))
                };
            }
        }
    }
}