using FluentValidation;

namespace WolleWinkel.Application.Interfaces
{
    public interface IValidator<in T>:FluentValidation.IValidator<T>
    {
        
    }

    public class Validator<T> : AbstractValidator<T>, IValidator<T>
    {
        
    }
}