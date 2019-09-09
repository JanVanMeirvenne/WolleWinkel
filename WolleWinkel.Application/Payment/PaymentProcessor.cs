using System;
using System.Collections.Generic;
using WolleWinkel.Application.Payment.Interfaces;
using WolleWinkel.Application.Payment.Models;
using WolleWinkel.Domain.Entities;
using WolleWinkel.Domain.ValueObjects;

namespace WolleWinkel.Application.Payment
{
    public class PaymentProcessor
    {
        private readonly IEnumerable<IPaymentHandler> _handlers;

        public PaymentProcessor(IEnumerable<IPaymentHandler> handlers)
        {
            _handlers = handlers;
        }

        public PaymentOutput Process(PaymentInput paymentInput)
        {
            foreach (var handler in _handlers)
            {
                if (handler.CanHandle(paymentInput))
                {
                    return handler.Handle(paymentInput);
                }
            }
            
            throw new Exception("No payment handler found");

        }
    }

}