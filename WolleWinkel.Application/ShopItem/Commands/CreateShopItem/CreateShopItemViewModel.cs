using System;
using System.Collections.Generic;
using System.Linq;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.ShopItem.Commands.CreateShopItem
{
    public class CreateShopItemViewModel
    {
        public Guid Id { get; set;}
        public string Description { get; set; }
        public string Name { get; set;}
        public double Price { get; set;}
        public int MaxAmount { get; set;}
        public IEnumerable<CreateShopItemViewModel> Options { get; set; }
        
        public Guid Parent { get; set; }

        public static CreateShopItemViewModel Create(ShopItemEntity entity, Guid Parent)
        {
            return new CreateShopItemViewModel()
            {
                Name = entity.Name,
                Id = entity.Id,
                Description = entity.Description,
                Options = entity.Options.Select(o => Create(o,entity.Id)),
                Price = entity.Price,
                MaxAmount = entity.MaxAmount,
                Parent = Parent
            };
        }
    }
        
}