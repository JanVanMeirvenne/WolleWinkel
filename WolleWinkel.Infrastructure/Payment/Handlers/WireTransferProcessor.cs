using WolleWinkel.Application.Payment.Interfaces;
using WolleWinkel.Application.Payment.Models;
using WolleWinkel.Domain.EnumObjects;
using WolleWinkel.Infrastructure.Payment.Models;

namespace WolleWinkel.Infrastructure.Payment.Processors
{
    public class WireTransferHandler:IPaymentHandler
    {
        
        
        

        public PaymentOutput Handle(PaymentInput paymentInput)
        {
            return new PaymentOutput()
            {
                Details = new WireTransferPaymentDetails()
                {
                    AccountNumber = "1234567890",
                    Reference = "1234567890"
                }
            };
            
                
            
        }

        public bool CanHandle(PaymentInput paymentInput)
        {
            return paymentInput.Type == PaymentType.WireTransfer;
        }
    }
}