using System.Collections;
using System.Collections.Generic;

namespace WolleWinkel.Domain.Entities
{
    public class ShopItemEntity:Entities.Entity
    {
        public string Name {get;set;}
        public string Description {get;set;}
        public double Price {get;set;}
        public ICollection<ShopItemEntity> Options { get; private set; }
        public int MaxAmount {get;set;}

        public ShopItemEntity()
        {
            Options = new List<ShopItemEntity>();
        }

        public void AddOption(ShopItemEntity option)
        {
            Options.Add(option);
        }

        public void RemoveOption(ShopItemEntity option)
        {
            Options.Remove(option);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is ShopItemEntity entity)
            {
                return entity.Id.Equals(this.Id);
            }
            else
            {
                return false;
            }
        }
    }
}