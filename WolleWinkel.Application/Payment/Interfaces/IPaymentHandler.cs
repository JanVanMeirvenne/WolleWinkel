using WolleWinkel.Application.Payment.Models;
using WolleWinkel.Domain.ValueObjects;

namespace WolleWinkel.Application.Payment.Interfaces
{
    public interface IPaymentHandler
    {
        PaymentOutput Handle(PaymentInput paymentInput);
        bool CanHandle(PaymentInput paymentInput);

    }
}