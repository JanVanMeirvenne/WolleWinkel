using System;
using WolleWinkel.Domain.EnumObjects;

namespace WolleWinkel.Application.Payment.Models
{
    public class PaymentInput
    {
        public Guid OrderId { get; set; }
        
        public double Amount { get; set; }

        public PaymentType Type { get; set; }
    }
}