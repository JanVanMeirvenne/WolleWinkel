using System;
using System.Data;
using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WolleWinkel.Application.Interfaces;

namespace WolleWinkel.Application.User.Commands.DeleteUser
{
    public class DeleteUserCommandValidator:Validator<DeleteUserCommand>
    {
        private readonly IDbContext _dbContext;

        public DeleteUserCommandValidator(IDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(o => o.Id).NotEmpty().Must(Exist);
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