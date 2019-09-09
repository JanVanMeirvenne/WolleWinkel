using FluentValidation;
using WolleWinkel.Application.Infrastructure;
using WolleWinkel.Application.Interfaces;
using WolleWinkel.Application.Shop.Commands.CreateShop;

namespace WolleWinkel.Application.User.Commands.CreateUser
{
    public class CreateUserCommandAuthorizer:Authorizer<CreateUserCommand>
    {
        public CreateUserCommandAuthorizer(ICurrentUser currentUser)
        {
            RuleFor(o => o.Id).Must(o => o.Equals(currentUser.UserId));
        }
        
        
    }
}