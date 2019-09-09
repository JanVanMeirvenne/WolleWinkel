using WolleWinkel.Domain.ValueObjects;

namespace WolleWinkel.Infrastructure.Payment.Models
{
    public class WireTransferPaymentDetails:PaymentDetails
    {
        public string Reference { get; set; }
        public string AccountNumber { get; set; }
    }
}