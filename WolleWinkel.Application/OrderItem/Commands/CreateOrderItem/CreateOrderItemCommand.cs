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

namespace WolleWinkel.Application.OrderItem.Commands.CreateOrderItem
{
    public class CreateOrderItemCommand:IRequest<OrderItemDto>
    {
        public Guid ParentOrderItem { get; set; }
        public Guid ParentShopItem { get; set; }
        
        public Guid Item { get;set; }
        public int Amount { get; set; }
        
        public IEnumerable<CreateOrderItemCommand> Options { get; set; }

        public class Handler:IRequestHandler<CreateOrderItemCommand,OrderItemDto>
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


            public async Task<OrderItemDto> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
            {
                var order = _dbContext.Orders.FirstOrDefault(o => o.Id.Equals(request.ParentOrderItem));
                var shop = _dbContext.Shops.FirstOrDefault(o => o.Id.Equals(request.ParentShopItem));
                var shopItem = shop.Items.FirstOrDefault(o => o.Id.Equals(request.Item));

                var orderItem = new OrderItemEntity
                {
                    Amount = request.Amount,
                    Item = shopItem,
                    Options = request.Options.Select(o => ProcessSubRequest(o, shop)).ToList()
                };
                order.AddOrderItem(orderItem);
                _dbContext.Orders.Update(order);
                await _dbContext.SaveChangesAsync(cancellationToken);
                await _mediator.Publish(new OrderItemCreated()
                {
                    OrderId = request.ParentOrderItem,
                    OrderItemId = orderItem.Id
                });
                return _mapper.Map<OrderItemDto>(orderItem);

            }

            private OrderItemEntity ProcessSubRequest(CreateOrderItemCommand request,ShopEntity parentShop)
            {
                var shopItem = parentShop.Items.FirstOrDefault(o => o.Id.Equals(request.Item));
                return new OrderItemEntity
                {
                    Amount = request.Amount,
                    Item = shopItem,
                    Options = Enumerable.Empty<OrderItemEntity>().ToList()
                };
            }
        }
        
        
        
    }
}