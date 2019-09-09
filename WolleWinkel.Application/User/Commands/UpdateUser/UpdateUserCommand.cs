using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.UpdateShop;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.User.Commands.UpdateUser
{
    public class UpdateUserCommand:IRequest<UpdateUserViewModel>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        
        public class Handler:IRequestHandler<UpdateUserCommand,UpdateUserViewModel>
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
            public async Task<UpdateUserViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = _dbContext.Customers.FirstOrDefault(o => o.Id.Equals(request.Id));
                var entity = new CustomerEntity()
                {
                    Id = user.Id,
                    Mail = request.Mail,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Phone = request.Phone

                };
                _dbContext.Customers.Update(entity);
                await _mediator.Publish(new UserUpdated()
                {
                    UserId = user.Id
                });
                return new UpdateUserViewModel()
                {
                    User = _mapper.Map<UserDto>(entity)
                };

            }
        }
    }
}