using System.Collections.Generic;

namespace WolleWinkel.Application.Order.Queries.GetOrder
{
    public class GetOrderQueryViewModel
    {
        public OrderDto Order { get; set; }
        public bool Admin { get; set; }
    }
}