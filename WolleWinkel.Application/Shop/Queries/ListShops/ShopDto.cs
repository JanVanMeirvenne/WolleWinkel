using System;
using System.ComponentModel;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Shop.Queries.ListShops
{
    public class ShopDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Open { get; set; }

        public static ShopDto Create(ShopEntity shopEntity)
        {
            return new ShopDto()
            {
                Description = shopEntity.Description,
                Name = shopEntity.Name,
                Id = shopEntity.Id,
                Open = shopEntity.Open
            };
        }
    }
}