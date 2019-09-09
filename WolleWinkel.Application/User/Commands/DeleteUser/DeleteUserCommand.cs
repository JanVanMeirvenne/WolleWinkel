using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.UpdateShop;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.User.Commands.DeleteUser
{
    public class DeleteUserCommand:IRequest
    {
        public Guid Id { get; set; }
       
        
        public class Handler:IRequestHandler<DeleteUserCommand>
        {
            private readonly IDbContext _dbContext;
            private readonly IMediator _mediator;
            private readonly ICurrentUser _currentUser;
            private readonly IMapper _mapper;

            public Handler(IDbContext dbContext, IMediator mediator, ICurrentUser currentUser,IMapper mapper)
            {
                _mediator = mediator;
                _currentUser = currentUser;
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var user = _dbContext.Customers.FirstOrDefault(o => o.Id.Equals(request.Id));

                _dbContext.Customers.Remove(user);
                await _dbContext.SaveChangesAsync(cancellationToken);
                await _mediator.Publish(new UserDeleted()
                {
                    UserId = user.Id
                });
                return Unit.Value;


            }
        }
    }
}