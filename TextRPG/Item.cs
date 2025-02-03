using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    enum ItemType
    {
        Attack,
        Defence,
        Count
    }

    internal class Item
    {
        public bool IsEquip { get; set; }
        public ItemType Type { get; set; } = ItemType.Attack;
        public string Name { get; set; }
        public int Att {  get; set; }
        public int Def {  get; set; }
        public string Description { get; set; }

        public Item( ItemType type, string name, int att, int def, string description, bool isEquip = false)
        {
            IsEquip = isEquip;
            Type = type;
            Name = name;
            Att = att;
            Def = def;
            Description = description;
        }

        public string InfoStr()
        {
            string info = $"{Name}\t| ";

            if (Type == ItemType.Attack)
                info += $"공격력 +{Att} ";
            else
                info += $"방어력 +{Def} ";

            info += Description;

            if (IsEquip) info = "- [E]" + info;
            else info = "- " + info;

            return info;
        }
    }
}
