using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WolleWinkel.Domain.Entities
{
    public class OrderItemEntity:Entities.Entity
    {
        public ShopItemEntity Item {get;set;}
        
        public ICollection<OrderItemEntity> Options { get; set; }

        public int Amount {get;set;}

        public double Price => (Item.Price + (Options.Sum(o => o.Price))) * Amount;

        public OrderItemEntity()
        {
            Options = new List<OrderItemEntity>();
        }

        public void AddOption(OrderItemEntity orderItem)
        {
            Options.Add(orderItem);
        }

        public void RemoveOption(OrderItemEntity orderItem)
        {
            Options.Remove(orderItem);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is OrderItemEntity entity)
            {
                return entity.Id.Equals(this.Id);
            }
            else
            {
                return false;
            };
        }
    }
}