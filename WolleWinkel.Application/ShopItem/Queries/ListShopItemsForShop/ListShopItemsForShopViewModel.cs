using System.Collections;
using System.Collections.Generic;

namespace WolleWinkel.Application.ShopItem.Queries.ListShopItemsForShop
{
    public class ListShopItemsForShopViewModel
    {
        public IEnumerable<ShopItemDto> Items { get; set; }
        public bool IsAdmin { get; set; }
        
    }
}