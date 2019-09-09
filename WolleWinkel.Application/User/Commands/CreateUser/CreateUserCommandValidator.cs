using System;
using System.Data;
using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WolleWinkel.Application.Interfaces;

namespace WolleWinkel.Application.User.Commands.CreateUser
{
    public class CreateUserCommandValidator:Validator<CreateUserCommand>
    {
        private readonly IDbContext _dbContext;

        public CreateUserCommandValidator(IDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(o => o.Mail).NotEmpty().Must(BeUnique);
            RuleFor(o => o.Id).NotEmpty();
            RuleFor(o => o.Phone).NotEmpty();
            RuleFor(o => o.FirstName).NotEmpty();
            RuleFor(o => o.LastName).NotEmpty();
        }
 
        private bool BeUnique(string mail)
        {
            var item = _dbContext.Customers.FirstOrDefault(o => o.Mail.Equals(mail,StringComparison.OrdinalIgnoreCase));
            return item != null;
        }
    }
}