using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WolleWinkel.Application.User.Commands.DeleteUser
{
    public class UserDeleted:INotification
    {
        public Guid UserId { get; set; }

        public class Handler : INotificationHandler<UserDeleted>
        {
            public async Task Handle(UserDeleted notification, CancellationToken cancellationToken)
            {
                return;
            }
        }
    }
}