using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using WolleWinkel.Application.Interfaces.Mapping;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.ShopItem.Queries.ListShopItemsForShop
{
    public class ShopItemDto:IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int MaxAmount { get; set; }
        public ICollection<ShopItemDto> Options { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<ShopItemEntity, ShopItemDto>();

        }
        
        
    }
}