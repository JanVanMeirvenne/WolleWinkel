using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WolleWinkel.Application.User.Commands.CreateUser
{
    public class UserCreated:INotification
    {
        public Guid UserId { get; set; }

        public class Handler : INotificationHandler<UserCreated>
        {
            public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
            {
                return;
            }
        }
    }
}