using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class InventoryMenu
    {
        Player player;

        public InventoryMenu(Player player)
        {
            this.player = player;
        }

        public void Exe()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();

                Console.WriteLine("[아이템 목록]");

                player.Inventory.PrintItems();
                Console.WriteLine(player.InventoryStr());
                Console.WriteLine();

                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("2. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int select;
                bool isExit = false;
                if ((int.TryParse(Console.ReadLine(), out select)) && select > 0 && select <= 2)
                {
                    switch (select)
                    {
                        case 1:
                            Equip();
                            break;
                        case 2:
                            isExit = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }

                if (isExit)
                {
                    break;
                }
            }
        }

        private void Equip()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();

                Console.WriteLine("[아이템 목록]");

                if (player.Inventory.ItemCount > 0)
                {
                    for (int i = 1; i <= player.Inventory.ItemCount; i++)
                        Console.WriteLine($"- {i} {player.Inventory.Items[i - 1].ItemStr()}");
                    Console.WriteLine();
                }

                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int select;
                bool isExit = false;
                if ((int.TryParse(Console.ReadLine(), out select)) && select >= 0 && select <= player.Inventory.ItemCount)
                {
                    if (select != 0)
                    {
                        select--;

                        Item item = player.Inventory.Items[select];
                        if (!item.IsEquip)
                            player.EquipItem(item);
                    }
                    else
                        isExit = true;

                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }

                if (isExit)
                {
                    break;
                }
            }
        }
    }
}
