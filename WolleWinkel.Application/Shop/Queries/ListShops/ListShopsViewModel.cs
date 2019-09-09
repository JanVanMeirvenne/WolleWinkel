using System.Collections.Generic;

namespace WolleWinkel.Application.Shop.Queries.ListShops
{
    public class ListShopsViewModel

    {
    public IEnumerable<ShopDto> Shops { get; set; }
    public bool Admin{ get; set; }

    public ListShopsViewModel(IEnumerable<ShopDto> model)
    {
        this.Shops = model;
        
    }
    }
}