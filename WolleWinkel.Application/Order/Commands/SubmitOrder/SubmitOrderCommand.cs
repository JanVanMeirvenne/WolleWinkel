using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Payment.Interfaces;
using WolleWinkel.Application.Payment.Models;
using WolleWinkel.Domain.Entities;
using WolleWinkel.Domain.EnumObjects;
using WolleWinkel.Domain.ValueObjects;

namespace WolleWinkel.Application.Order.Commands.UpdateOrder
{
    public class SubmitOrderCommand:IRequest<SubmitOrderCommandViewModel>
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        
        public class Handler:IRequestHandler<SubmitOrderCommand,SubmitOrderCommandViewModel>
        {
            private readonly IDbContext _dbContext;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IPaymentProcessor _paymentProcessor;

            public Handler(IMediator mediator,IDbContext dbContext, IMapper mapper,IPaymentProcessor paymentProcessor)
            {
                _mediator = mediator;
                _dbContext = dbContext;
                _mapper = mapper;
                _paymentProcessor = paymentProcessor;
            }

            public async Task<SubmitOrderCommandViewModel> Handle(SubmitOrderCommand request, CancellationToken cancellationToken)
            {
                var order = _dbContext.Orders.FirstOrDefault(o => o.Id.Equals(request.Id));
                var paymentType = Domain.EnumObjects.PaymentType.Parse<PaymentType>(request.Type);
                var paymentInput = new PaymentInput()
                {
                    Amount = order.Price,
                    OrderId = order.Id,
                    Type = paymentType
                };
                var output = _paymentProcessor.Process(paymentInput);
                order.PaymentInformation = new PaymentInformation()
                {
                    Details = output.Details,
                    Type = paymentInput.Type
                };
                _dbContext.Orders.Update(order);
                await _dbContext.SaveChangesAsync(cancellationToken);
                await _mediator.Publish(new OrderSubmitted()
                {
                    OrderId = order.Id
                },cancellationToken);
                return new SubmitOrderCommandViewModel()
                {
                    Order = _mapper.Map<OrderDto>(order)
                };
            }
        }
        
    }
}