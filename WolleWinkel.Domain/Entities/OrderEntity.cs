using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WolleWinkel.Domain.EnumObjects;
using WolleWinkel.Domain.ValueObjects;

namespace WolleWinkel.Domain.Entities
{
  
    
    public class OrderEntity:Entities.Entity
    {
      
      public CustomerEntity Customer { get; set; }
        
        public IEnumerable<OrderItemEntity> Items {get;private set;}
        public double Price => Items.Sum(o => o.Price);

        public OrderStatus Status {get;set;}
        public PaymentInformation PaymentInformation { get; set; }
        
        public DateTimeOffset? CompletedOn { get; private set; }
        
        public CustomerEntity User { get; set; }

        public OrderEntity()
        {
            
            Items = new List<OrderItemEntity>();
            Status = OrderStatus.Open;
            //PaymentType = PaymentType.WireTransfer;
        }

        public void AddOrderItem(OrderItemEntity orderItemEntity)
        {
           
            var items = this.Items.ToList();
            items.Add(orderItemEntity);
            this.Items = items;
        }

        public void RemoveOrderItem(OrderItemEntity orderItem)
        {
            var items = this.Items.ToList();
            items.Remove(orderItem);
            this.Items = items;
        }

        public void SubmitOrder(PaymentType paymentType)
        {
            
            this.Status = OrderStatus.Open;
        }

        public void PaidOrder()
        {
            
            this.PaymentInformation.Paid = true;
            this.PaymentInformation.PaidOn = DateTimeOffset.Now;
        }

        public void CompleteOrder()
        {
            this.CompletedOn = DateTimeOffset.UtcNow;
            this.Status = OrderStatus.Completed;
        }

        public override bool Equals(object obj)
        {
            var item = obj as OrderEntity;
            if (item == null)
            {
                return false;
            }

            return item.Id.Equals(this.Id);
        }
    }
}