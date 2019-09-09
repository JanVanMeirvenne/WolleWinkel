using FluentValidation;

namespace WolleWinkel.Application.Interfaces
{
    public interface IAuthorizer<in T>: FluentValidation.IValidator<T>
    {
        
    }

    public class Authorizer<T> : AbstractValidator<T>, IAuthorizer<T>
    {
        
    }
}