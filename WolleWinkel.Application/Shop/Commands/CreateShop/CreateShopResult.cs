using System;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Shop.Commands.CreateShop
{
    public class CreateShopResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }

        public static CreateShopResult Create(ShopEntity shopEntity)
        {
            return new CreateShopResult()
            {
                Id = shopEntity.Id,
                Name = shopEntity.Name,
                Description = shopEntity.Description
            };
        }
        
    }
}