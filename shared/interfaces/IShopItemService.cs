using System.Collections.Generic;
using System.Threading.Tasks;

namespace shared.interfaces
{
    public interface IShopItemService
    {
        Task<IEnumerable<ShopItem>> List(string shopId);
        Task<ShopItem> Get(string shopItemId);
        Task<ShopItem> Create(ShopItem shopItem);
        Task<ShopItem> Update(ShopItem shopItem);
        Task Delete(string shopItem);
    }
}