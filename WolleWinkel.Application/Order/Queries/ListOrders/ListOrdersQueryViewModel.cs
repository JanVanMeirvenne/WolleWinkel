using System.Collections.Generic;

namespace WolleWinkel.Application.Order.Queries.ListOrders
{
    public class ListOrdersQueryViewModel
    {
        public IEnumerable<OrderDto> Orders { get; set; }
        public bool Admin { get; set; }
    }
}