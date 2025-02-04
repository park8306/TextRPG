using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG
{
    // 여러 아이템들의 정보가 담겨있는 클래스
    public class ItemInfos
    {
        // 아이템의 정보를 어디에서든 쉽게 가져다 쓸 수 있도록 싱글톤으로 구현
        private static ItemInfos instance;

        public List<Item> Items { get; set; }

        public static ItemInfos Instance()
        {
            if(instance == null)
                instance = new ItemInfos();

            return instance;
        }

        public ItemInfos()
        {
            Items = new List<Item>();

            AddItem(ItemType.Defence, "무쇠갑옷", 0, 5, "무쇠로 만들어져 튼튼한 갑옷입니다.", 1000);
            AddItem(ItemType.Attack, "스파르타의 창", 7, 0, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 1000);
            AddItem(ItemType.Attack, "낡은 검", 2, 0, "쉽게 볼 수 있는 낡은 검 입니다.", 1000);
        }

        public void AddItem(ItemType type, string name, int att, int def, string description, int purchaseGold, bool isEquip = false)
        {
            Item item = new Item(type, name, att, def, description, purchaseGold, isEquip);

            AddItem(item);
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
    }
}
