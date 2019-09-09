using System;
using System.Collections.Generic;
using System.Linq;
using WolleWinkel.Domain.EnumObjects;
using WolleWinkel.Domain.Infrastructure;

namespace WolleWinkel.Domain.ValueObjects
{
    public class PaymentInformation:ValueObject
    {
        public PaymentDetails Details { get; set; }
        public PaymentType Type { get; set; }
        public string Reference { get; set; }
        public bool Paid { get; set; }
        public DateTimeOffset? PaidOn { get; set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            return Enumerable.Empty<object>(); }
        
    }
}