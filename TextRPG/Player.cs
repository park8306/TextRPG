﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{

    // 레벨 / 이름 / 직업 / 공격력 / 방어력 / 체력 / Gold
    public class Player
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public string Chad { get; set; }    // 직업
        public int Att {  get; set; }
        public int Def { get; set; }
        public int MaxHP { get; set; }
        public int CurHP {  get; set; }
        public int Gold {  get; set; }
        public Inventory Inventory { get; set; }

        public Item EquipAtt { get; set; }
        public Item EquipDef { get; set; }

        public Player(int level = 1, string name = "", string chad = "전사", int att = 10, int def = 5, int maxHP = 100, int gold = 1500)
        {
            Level = level;
            Name = name;
            Chad = chad;
            Att = att;
            Def = def;
            MaxHP = maxHP;
            CurHP = MaxHP;
            Gold = gold;
            EquipAtt = null;
            EquipDef = null;

            Inventory = new Inventory();
        }

        public void EquipItem(Item item)
        {
            if (EquipAtt != null || EquipDef != null)
                UnEquipItem(item);

            Att += item.Att;
            Def += item.Def;

            if (item.Type == ItemType.Attack)
                EquipAtt = item;
            else
                EquipDef = item;

            item.IsEquip = true;
        }
        public void UnEquipItem(Item item)
        {
            Item unEquipItem;
            if (item.Type == ItemType.Attack)
            {
                unEquipItem = EquipAtt;
                EquipAtt = null;
            }
            else
            {
                unEquipItem = EquipDef;
                EquipDef = null;
            }

            Att -= unEquipItem.Att;
            Def -= unEquipItem.Def;

            unEquipItem.IsEquip = false;
        }

        public string InfoStr()
        {
            string level = Level.ToString().Length > 2 ? Level.ToString() : "0" + Level.ToString();

            string info = $"이름 : {Name}\n" +
                $"Lv. {level}\n" +
                $"Chad ( {Chad} )\n";

            info += $"공격력 : {Att}";
            if (EquipAtt != null)
                info += $" (+{EquipAtt.Att})\n";
            else
                info += "\n";

            info += $"방어력 : {Def}";
            if (EquipDef != null)
                info += $" (+{EquipDef.Def})\n";
            else
                info += "\n";

            info += $"체력 : {CurHP} / {MaxHP}\n" +
                $"Gold : {Gold} G";

            return info;
        }

        public string InventoryStr()
        {
            return Inventory.ItemSB.ToString();
        }

    }
}
