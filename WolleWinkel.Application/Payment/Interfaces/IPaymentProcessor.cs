using WolleWinkel.Application.Payment.Models;

namespace WolleWinkel.Application.Payment.Interfaces
{
    public interface IPaymentProcessor
    {
        PaymentOutput Process(PaymentInput processInput);
    }
}