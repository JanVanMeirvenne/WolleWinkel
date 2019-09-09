using System.Collections;
using System.Collections.Generic;

namespace WolleWinkel.Domain.Entities {
    public class ShopEntity : Entities.Entity {
        public string Name {get;set;}
        public string Description { get; set; }
        
        public bool Open { get; set; }
        
        public ICollection<ShopItemEntity> Items { get; private set; }
        
        public override bool Equals(object obj)
        {
            var item = obj as ShopEntity;
            if (item == null)
            {
                return false;
            }

            return item.Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public ShopEntity()
        {
            Items = new List<ShopItemEntity>();
        }

        public void AddItem(ShopItemEntity item)
        {
            Items.Add(item);
        }

        public void RemoveItem(ShopItemEntity item)
        {
            Items.Remove(item);
        }
    }
}