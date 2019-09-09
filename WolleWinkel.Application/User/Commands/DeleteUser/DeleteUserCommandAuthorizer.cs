using FluentValidation;
using WolleWinkel.Application.Infrastructure;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.CreateShop;

namespace WolleWinkel.Application.User.Commands.DeleteUser
{
    public class DeleteUserCommandAuthorizer:Authorizer<DeleteUserCommand>
    {
        public DeleteUserCommandAuthorizer(ICurrentUser currentUser)
        {
            RuleFor(o => o.Id).Must(o => o.Equals(currentUser.UserId));
        }
        
        
    }
}