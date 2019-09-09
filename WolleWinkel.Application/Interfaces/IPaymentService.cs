using WolleWinkel.Domain.EnumObjects;
using WolleWinkel.Domain.ValueObjects;

namespace WolleWinkel.Application.Interfaces
{
    public interface IPaymentService
    {
        PaymentInformation GeneratePaymentInformation(PaymentType paymentType);
    }
}