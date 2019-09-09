using System;
using AutoMapper;
using WolleWinkel.Application.Interfaces.Mapping;
using WolleWinkel.Domain.Entities;

namespace WolleWinkel.Application.Order.Queries.ListOrders
{
    public class OrderDto:IHaveCustomMapping
    {
        public Guid OrderId { get; set; }
        public double Price { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public bool Paid { get; set; }
        
        public bool Created { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<OrderEntity, OrderDto>()
                .ForMember(o => o.OrderId, a => a.MapFrom(b => b.Id))
                .ForMember(o => o.Price, a => a.MapFrom(b => b.Price))
                .ForMember(o => o.FirstName, a => a.MapFrom(b => b.User.FirstName))
                .ForMember(o => o.LastName, a => a.MapFrom(b => b.User.LastName))
                .ForMember(o => o.Paid, a => a.MapFrom(b => b.PaymentInformation != null && b.PaymentInformation.Paid))
                .ForMember(o => o.Created, a => a.MapFrom(b => b.CompletedOn ?? b.PaymentInformation.PaidOn));
        }
    }
}