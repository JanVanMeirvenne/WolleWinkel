using System;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Shop.Commands.CreateShop
{
    public class UpdateShopResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public bool Open { get; set; }

        public static UpdateShopResult Create(ShopEntity shopEntity)
        {
            return new UpdateShopResult()
            {
                Id = shopEntity.Id,
                Name = shopEntity.Name,
                Description = shopEntity.Description,
                Open = shopEntity.Open
            };
        }
        
    }
}