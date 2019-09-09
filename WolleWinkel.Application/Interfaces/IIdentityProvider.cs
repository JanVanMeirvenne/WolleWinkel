using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Interfaces
{
    public interface IIdentityProvider
    {
        CustomerEntity CreateUser(string firstName, string lastName, string mail, string phone);
        CustomerEntity EditUser(string firstName, string lastName, string mail, string phone);

    }
}