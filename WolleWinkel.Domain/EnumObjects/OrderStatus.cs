using WolleWinkel.CrossCutting.Infrastructure;
using WolleWinkel.Domain.Infrastructure;

namespace WolleWinkel.Domain.EnumObjects
{
    public class OrderStatus:EnumObject
    {
        public static OrderStatus Open = new OrderStatus(1,"Open");
        public static OrderStatus PendingPayment = new OrderStatus(2,"PendingPayment");
        public static OrderStatus Paid = new OrderStatus(3,"Paid");
        public static OrderStatus Completed = new OrderStatus(4,"Completed");
        
            public OrderStatus(int id, string name) : base(id, name)
            {
            
            }
        
    }
}