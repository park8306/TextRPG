using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Inventory
    {
        public StringBuilder ItemSB { get; set; }

        const int MAX_INVENTORY_COUNT = 30;
        public Item[] Items { get; set; }

        public int ItemCount { get; set; }

        public Inventory()
        {
            ItemCount = 0;
            Items = new Item[MAX_INVENTORY_COUNT];
            ItemSB = new StringBuilder();
        }

        public void AddItem(Item item)
        {
            if (!(ItemCount >= MAX_INVENTORY_COUNT))
                Items[ItemCount++] = item;
        }
        
        public void RemoveItem(int index)
        {
            if (ItemCount <= 0) return;

            Items[index] = null;
            if (index != ItemCount - 1)
            {
                for (int i = index; i < ItemCount; i++)
                {
                    Items[index] = Items[index + 1];
                }
            }
        }

        public void PrintItems()
        {
            ItemSB.Clear();
            for (int i = 0; i < ItemCount; i++)
            {
                ItemSB.AppendLine(Items[i].ItemStr());
            }
        }

        public void PrintShopItems()
        {
            ItemSB.Clear();
            for (int i = 0; i < ItemCount; i++)
            {
                ItemSB.AppendLine(Items[i].ShopItemStr());
            }
        }
    }
}
