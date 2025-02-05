using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
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
        public float Att {  get; set; }
        public float Def { get; set; }
        public int MaxHP { get; set; }

        private int curHP;
        public int CurHP 
        { 
            get { return curHP; } 
            set 
            { 
                curHP = value;
                if (curHP > MaxHP) curHP = MaxHP;
                else if (curHP < 0) curHP = 0; 
            } 
        }
        public int Gold {  get; set; }
        public Inventory Inventory { get; set; }

        public Item EquipAtt { get; set; }
        public Item EquipDef { get; set; }

        public int ClearCount { get; set; }

        const float ATT_PER_LEVEL = 0.5f; // 레벨 당 공격력 증가 값
        const float DEF_PER_LEVEL = 1.0f; // 레벨 당 방어력 증가

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
            ClearCount = 0;

            Inventory = new Inventory();
        }

        public void EquipItem(Item item)
        {
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
            if (EquipAtt == null && EquipDef == null)
                return;

            Item unEquipItem = null;
            if (item.Type == ItemType.Attack)
            {
                if(EquipAtt != null)
                {
                    unEquipItem = EquipAtt;
                    EquipAtt = null;
                }
            }
            else
            {
                if (EquipDef != null)
                {
                    unEquipItem = EquipDef;
                    EquipDef = null;
                }
            }

            if (unEquipItem != null)
            {
                Att -= unEquipItem.Att;
                Def -= unEquipItem.Def;
            }

            if(unEquipItem != null)
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

        public void LevelCheck()
        {
            Level = ClearCount + 1;

            Att += ATT_PER_LEVEL * Level;
            Def += DEF_PER_LEVEL * Level;
        }
    }
}
