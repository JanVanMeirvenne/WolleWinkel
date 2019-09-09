using System;
using System.Collections.Generic;
using AutoMapper;
using WolleWinkel.Application.Interfaces.Mapping;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Order.Queries.GetOrder
{
    public class OrderItemDto : IHaveCustomMapping
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        
        public IEnumerable<OrderItemDto> Options { get; set; }
        
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<OrderItemEntity, OrderItemDto>()
                .ForMember(o => o.Name, a => a.MapFrom(b => b.Item.Name))
                .ForMember(o => o.Amount, a => a.MapFrom(b => b.Amount))
                .ForMember(o => o.UnitPrice, a => a.MapFrom(b => b.Item.Price))
                .ForMember(o => o.TotalPrice, a => a.MapFrom(b => b.Price))
                .ForMember(o => o.Options, a => a.MapFrom(b => b.Options));


        }
    }
    public class OrderDto:IHaveCustomMapping
    {
        public Guid OrderId { get; set; }
        public double Price { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Mail { get; set; }
        
        public string Phone { get; set; }
        
        public bool Paid { get; set; }
        
        public bool Created { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<OrderEntity, OrderDto>()
                .ForMember(o => o.OrderId, a => a.MapFrom(b => b.Id))
                .ForMember(o => o.Price, a => a.MapFrom(b => b.Price))
                .ForMember(o => o.FirstName, a => a.MapFrom(b => b.User.FirstName))
                .ForMember(o => o.Mail, a => a.MapFrom(b => b.User.Mail))
                .ForMember(o => o.Phone, a => a.MapFrom(b => b.User.Phone))
                .ForMember(o => o.LastName, a => a.MapFrom(b => b.User.LastName))
                .ForMember(o => o.Paid, a => a.MapFrom(b => b.PaymentInformation != null && b.PaymentInformation.Paid))
                .ForMember(o => o.Created, a => a.MapFrom(b => b.CompletedOn ?? b.PaymentInformation.PaidOn));
        }
    }
}