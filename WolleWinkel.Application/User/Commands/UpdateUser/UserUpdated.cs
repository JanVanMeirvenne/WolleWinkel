using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WolleWinkel.Application.User.Commands.UpdateUser
{
    public class UserUpdated:INotification
    {
        public Guid UserId { get; set; }

        public class Handler : INotificationHandler<UserUpdated>
        {
            public async Task Handle(UserUpdated notification, CancellationToken cancellationToken)
            {
                return;
            }
        }
    }
}