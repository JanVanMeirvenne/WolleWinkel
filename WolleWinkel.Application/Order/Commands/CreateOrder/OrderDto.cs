using System;
using AutoMapper;
using WolleWinkel.Application.Interfaces.Mapping;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Order.Commands.CreateOrder
{
    public class OrderDto:IHaveCustomMapping
        {
            public Guid Id { get; set; }
            
            public string FirstName { get; set; }
            
            public string LastName { get; set; }
            
            public string Mail { get; set; }
            
            public string Phone { get; set; }
            public void CreateMappings(Profile configuration)
            {
                configuration.CreateMap<OrderEntity, OrderDto>()
                    .ForMember(o => o.Mail, a => a.MapFrom(b => b.User.Mail))
                    .ForMember(o => o.Phone, a => a.MapFrom(b => b.User.Phone))
                    .ForMember(o => o.FirstName, a => a.MapFrom(b => b.User.FirstName))
                    .ForMember(o => o.LastName, a => a.MapFrom(b => b.User.LastName));
            }
        }
}