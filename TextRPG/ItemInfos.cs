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

        public Dictionary<int, Item> Items { get; set; }

        public static ItemInfos Instance()
        {
            if(instance == null)
                instance = new ItemInfos();

            return instance;
        }

        public ItemInfos()
        {
            Items = new Dictionary<int, Item>();

            AddItem(0, ItemType.Attack, "낡은 검", 2, 0, "쉽게 볼 수 있는 낡은 검 입니다.", 300);
            AddItem(1, ItemType.Attack, "나무 검", 4, 0, "나무로 만들어진 검 입니다.", 500);
            AddItem(2, ItemType.Attack, "강철 검", 10, 0, "단단한 철로 만들어진 강력한 검 입니다.", 1500);
            AddItem(3, ItemType.Attack, "스파르타의 창", 7, 0, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 1000);
            AddItem(4, ItemType.Defence, "낡은 갑옷", 0, 2, "오래 사용해 낡은 갑옷입니다.", 300);
            AddItem(5, ItemType.Defence, "나무 갑옷", 0, 5, "나무로 만들어진 갑옷입니다.", 700);
            AddItem(6, ItemType.Defence, "무쇠갑옷", 0, 10, "무쇠로 만들어져 튼튼한 갑옷입니다.", 1500);
        }

        public void AddItem(int id,ItemType type, string name, int att, int def, string description, int purchaseGold, bool isEquip = false)
        {
            Item item = new Item(id, type, name, att, def, description, purchaseGold, isEquip);

            AddItem(item);
        }
        public void AddItem(Item item)
        {
            Items.Add(item.ID, item);
        }
    }
}
