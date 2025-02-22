﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Menus
{
    public class ShopMenu
    {
        Player player;
        Inventory inventory;

        public ShopMenu(Player player) 
        {
            this.player = player;

            inventory = new Inventory();
            for (int i = 0; i <ItemInfos.Instance().Items.Count; i++)
            {
                inventory.AddItem(ItemInfos.Instance().Items[i]);
            }
        }

        public void Exe()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();

                Console.WriteLine("[보유 골드]");

                Console.WriteLine($"{player.Gold} G");
                Console.WriteLine();

                Console.WriteLine("[아이템 목록]");

                inventory.PrintShopItems();
                Console.WriteLine(inventory.ItemSB.ToString());

                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("3. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int select;
                bool isExit = false;
                if ((int.TryParse(Console.ReadLine(), out select)) && select > 0 && select <= 3)
                {
                    switch (select)
                    {
                        case 1:
                            Purchase();
                            break;
                        case 2:
                            Sell();
                            break;
                        case 3:
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

        // 아이템 구매창
        private void Purchase()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();

                Console.WriteLine("[보유 골드]");

                Console.WriteLine($"{player.Gold} G");
                Console.WriteLine();

                Console.WriteLine("[아이템 목록]");

                for (int i = 1; i <= inventory.ItemCount; i++)
                    Console.WriteLine($"- {i} {inventory.Items[i - 1].ShopItemStr()}");
                Console.WriteLine();

                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int select;
                bool isExit = false;
                if ((int.TryParse(Console.ReadLine(), out select)) && select >= 0 && select <= inventory.ItemCount)
                {
                    if (select != 0)
                    {
                        select -= 1;
                        // 구매를 진행
                        if (!inventory.Items[select].IsPurchase)
                        {
                            if (player.Gold >= inventory.Items[select].PurchaseGold)
                            {
                                player.Gold -= inventory.Items[select].PurchaseGold;
                                player.Inventory.AddItem(inventory.Items[select]);

                                inventory.Items[select].IsPurchase = true;
                                Console.WriteLine("구매를 완료했습니다.");
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Console.WriteLine("Gold가 부족합니다.");
                                Thread.Sleep(1000);
                            }
                        }
                        else
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                            Thread.Sleep(1000);
                        }
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

        // 아이템 판매창
        private void Sell()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 판매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();

                Console.WriteLine("[보유 골드]");

                Console.WriteLine($"{player.Gold} G");
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
                if ((int.TryParse(Console.ReadLine(), out select)) && select >= 0 && select <= inventory.ItemCount)
                {
                    if (select != 0)
                    {
                        select -= 1;
                        // 판매를 진행

                        Item item = player.Inventory.Items[select];
                        int itemPrice = (int)(item.PurchaseGold * 0.85f);

                        // 장착된 아이템이면 해제, 골드 적립, 인벤토리에서 제거
                        if(item.IsEquip)
                        {
                            player.UnEquipItem(item);
                        }
                        player.Gold += itemPrice;
                        player.Inventory.RemoveItem(select);
                        player.Inventory.ItemCount--;

                        item.IsPurchase = false;
                        Console.WriteLine("판매를 완료했습니다.");
                        Thread.Sleep(1000);
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
