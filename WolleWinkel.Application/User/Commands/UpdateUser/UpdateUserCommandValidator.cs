using System;
using System.Data;
using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WolleWinkel.Application.Interfaces;

namespace WolleWinkel.Application.User.Commands.UpdateUser
{
    public class UpdateUserCommandValidator:Validator<UpdateUserCommand>
    {
        private readonly IDbContext _dbContext;

        public UpdateUserCommandValidator(IDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(o => o.Mail).NotEmpty().Must(BeUnique);
            RuleFor(o => o.Id).NotEmpty().Must(Exist);
            RuleFor(o => o.Phone).NotEmpty();
            RuleFor(o => o.FirstName).NotEmpty();
            RuleFor(o => o.LastName).NotEmpty();
        }

        private bool Exist(Guid arg)
        {
            var user = _dbContext.Customers.FirstOrDefault(o => o.Id.Equals(arg));
            return user != null;
        }

        private bool BeUnique(string mail)
        {
            var item = _dbContext.Customers.FirstOrDefault(o => o.Mail.Equals(mail,StringComparison.OrdinalIgnoreCase));
            return item != null;
        }
    }
}