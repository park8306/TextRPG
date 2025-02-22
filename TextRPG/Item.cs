﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public enum ItemType
    {
        Attack,     // 무기
        Defence,    // 방어구
        Count
    }

    public class Item
    {
        public int ID {  get; set; }
        public bool IsEquip { get; set; }
        public ItemType Type { get; set; } = ItemType.Attack;
        public string Name { get; set; }
        public int Att {  get; set; }
        public int Def {  get; set; }
        public string Description { get; set; }
        
        public int PurchaseGold { get; set; }

        public bool IsPurchase { get; set; }

        public Item(int id, ItemType type, string name, int att, int def, string description, int purchaseGold, bool isEquip = false)
        {
            ID = id;
            IsEquip = isEquip;
            Type = type;
            Name = name;
            Att = att;
            Def = def;
            Description = description;
            PurchaseGold = purchaseGold;
            IsPurchase = false;
        }

        public string ItemStr()
        {
            string info = $"{Name}\t| ";

            if (Type == ItemType.Attack)
                info += $"공격력 +{Att}\t |";
            else
                info += $"방어력 +{Def}\t |";

            info += " " + Description;

            if (IsEquip) info = "[E]" + info;

            return info;
        }

        public string ShopItemStr()
        {
            string info = $"{Name}\t| ";

            if (Type == ItemType.Attack)
                info += $"공격력 +{Att}\t|";
            else
                info += $"방어력 +{Def}\t|";

            info += " " + Description + "\t|";

            if (IsPurchase) info += "구매완료";
            else info += $" {PurchaseGold} G";

            return info;
        }
    }
}
