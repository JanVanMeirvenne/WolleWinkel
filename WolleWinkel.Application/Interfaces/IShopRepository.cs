using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Interfaces
{
    public interface IShopRepository
    {
        IEnumerable<ShopEntity> List();
        ShopEntity GetById(Guid shopId);
        ShopEntity GetByName(string shopName);
        void Update(ShopEntity shop);
        void Delete(ShopEntity shop);

        Task Add(ShopEntity shopEntity);
        
        IEnumerable<ShopItemEntity> ListItemsByShop(string shopId);
        ShopItemEntity GetItemById(string id);

        void Delete(Guid requestShopId);
        IEnumerable<ShopEntity> ListOpen();
    }
}