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
        private Item[] items;

        public int ItemCount { get; set; }

        public Inventory()
        {
            ItemCount = 0;
            items = new Item[MAX_INVENTORY_COUNT];
            ItemSB = new StringBuilder();
        }

        public void PrintItems()
        {
            ItemSB.Clear();
            for (int i = 0; i < ItemCount; i++)
            {
                ItemSB.AppendLine(items[i].InfoStr());
            }
        }
    }
}
