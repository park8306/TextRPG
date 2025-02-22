﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Menus
{
    public class DungeonMenu
    {
        Player player;

        Dungeon[] dungeons;
        string[] dungeonNames = { "쉬운", "일반", "어려운" };
        int[] dungeonDefs = { 5, 11, 17 };
        int[] rewardGolds = { 1000, 1700, 2500 };

        bool IsClear { get; set; }

        public DungeonMenu(Player player)
        {
            this.player = player;

            dungeons = new Dungeon[3];
            for (int i = 0; i < dungeons.Length; i++)
            {
                dungeons[i] = new Dungeon(dungeonNames[i], dungeonDefs[i], rewardGolds[i]);
            }
        }

        public void Exe()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("던전입장");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine();

                Console.WriteLine($"1. 쉬운 던전\t| 방어력 {dungeons[0].DungeonDef} 이상 권장");
                Console.WriteLine($"2. 일반 던전\t| 방어력 {dungeons[1].DungeonDef} 이상 권장");
                Console.WriteLine($"3. 어려운 던전\t| 방어력 {dungeons[2].DungeonDef} 이상 권장");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int select;
                bool isExit = false;
                if ((int.TryParse(Console.ReadLine(), out select)) && select >= 0 && select <= 3)
                {
                    switch (select)
                    {
                        case 0:
                            isExit = true;
                            break;
                        case 1:
                        case 2:
                        case 3:
                            if(IsDungeonClear(select))
                                DungeonClear(select);
                            else
                                DungeonFail(select);

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

        private bool IsDungeonClear(int dungeonLv)
        {
            if (player.Def >= dungeonDefs[dungeonLv - 1])
            {
                IsClear = true;
                return true;
            }
            else
            {
                int percent;
                Random rand = new Random();
                percent = rand.Next(0, 10);

                if (percent <= 4)
                {
                    IsClear = true;
                    return true;
                }
                else
                {
                    IsClear = false;
                    return false;
                }
            }
        }

        private void DungeonClear(int dungeonLv)
        {
            player.ClearCount++;
            player.LevelCheck();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("던전 클리어");
                Console.WriteLine($"{dungeonNames[dungeonLv - 1]} 던전을 클리어 하였습니다.");
                Console.WriteLine();

                DungeonResult(IsClear, dungeonLv);
                Console.WriteLine();

                Console.WriteLine("0. 나가기");

                int select;
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                if ((int.TryParse(Console.ReadLine(), out select)) && select == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }

        }

        private void DungeonResult(bool isClear, int dungeonLv)
        {
            Console.WriteLine("[탐험 결과]");

            HPResult(isClear, dungeonLv);
            GoldResult(isClear, dungeonLv);
        }

        private void HPResult(bool isClear, int dungeonLv)
        {
            // 결과 적용 전 HP
            int originHP = player.CurHP;
            if (isClear)
            {
                int randHP = new Random().Next(20, 36);
                // 내 방어력 - 권장 방어력
                int diffDef = (int)player.Def - dungeons[dungeonLv - 1].DungeonDef;
                randHP -= diffDef;

                player.CurHP -= randHP;
            }
            else
            {
                player.CurHP /= 2;
            }
            Console.WriteLine($"체력 {originHP} -> {player.CurHP}");
        }

        private void GoldResult(bool isClear, int dungeonLv)
        {
            int originGold = player.Gold;
            int rewardGold = dungeons[dungeonLv-1].RewardGold;

            if(isClear)
            {
                int rewardPercent = new Random().Next((int)player.Att, (int)player.Att * 2 + 1);
                rewardGold += (int)(rewardGold  * (rewardPercent / 100.0f));
            }
            else
            {
                rewardGold = 0;
            }

            int resultGold = originGold + rewardGold;
            player.Gold = resultGold;

            Console.WriteLine($"Gold {originGold} G -> {resultGold} G");
        }

        private void DungeonFail(int dungeonLv)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("던전 실패");
                Console.WriteLine();

                DungeonResult(IsClear, dungeonLv);
                Console.WriteLine();

                Console.WriteLine("0. 나가기");

                int select;
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                if ((int.TryParse(Console.ReadLine(), out select)) && select == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
