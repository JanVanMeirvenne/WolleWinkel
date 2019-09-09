using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using WolleWinkel.Application.Interfaces.Mapping;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.OrderItem.Commands.DeleteOrderItem
{
    public class OrderItemDto:IHaveCustomMapping
    {
       
        
        public Guid OrderItemId { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int Amount { get; set; }

        public double Price { get; set; }
        
        public ICollection<OrderItemDto> Options { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<OrderItemEntity, OrderItemDto>()
                .ForMember(o => o.OrderItemId, a => a.MapFrom(b => b.Id))
                .ForMember(o => o.Name, a => a.MapFrom(b => b.Item.Name))
                .ForMember(o => o.Description, a => a.MapFrom(b => b.Item.Description)
                );
        }
    }
}