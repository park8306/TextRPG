using System;
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
        public string Chad { get; set; }
        public int Att {  get; set; }
        public int Def { get; set; }
        public int MaxHP { get; set; }
        public int CurHP {  get; set; }
        public int Gold {  get; set; }
        public Inventory Inventory { get; set; }

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

            Inventory = new Inventory();
        }

        public string InfoStr()
        {
            string level = Level.ToString().Length > 2 ? Level.ToString() : "0" + Level.ToString();

            string info = $"Lv. {level}\nChad ( {Chad} )\n공격력 : {Att}\n방어력 : {Def}\n체력 : {CurHP} / {MaxHP}\nGold : {Gold} G";
            return info;
        }

        public string InventoryStr()
        {
            return Inventory.ItemSB.ToString();
        }

    }
}
