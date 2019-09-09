using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.UpdateShop;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.User.Commands.CreateUser
{
    public class CreateUserCommand:IRequest<CreateUserViewModel>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        
        public class Handler:IRequestHandler<CreateUserCommand,CreateUserViewModel>
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
            public async Task<CreateUserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var entity = new CustomerEntity()
                {
                    Id = request.Id,
                    Mail = request.Mail,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Phone = request.Phone

                };
                _dbContext.Customers.Add(entity);
                await _mediator.Publish(new UserCreated()
                {
                    UserId = entity.Id
                });

                return new CreateUserViewModel()
                {
                    User = _mapper.Map<UserDto>(entity)
                };

            }
        }
    }
}