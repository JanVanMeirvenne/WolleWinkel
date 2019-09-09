using WolleWinkel.CrossCutting.Infrastructure;
using WolleWinkel.Domain.Infrastructure;

namespace WolleWinkel.Domain.EnumObjects
{
    public class PaymentType:EnumObject
    {
        public static PaymentType WireTransfer = new PaymentType(0,"WireTransfer");
        public static PaymentType BanContact = new PaymentType(1,"BanContact");
        public PaymentType(int id, string name) : base(id, name)
        {
            
        }
    }
}