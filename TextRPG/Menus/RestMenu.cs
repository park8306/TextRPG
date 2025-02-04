using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Menus
{
    public class RestMenu
    {
        Player player;
        int restGold;

        public RestMenu(Player player)
        {
            this.player = player;
            restGold = 500;
        }

        public void Exe()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("휴식하기");
                Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {player.Gold} G)");
                Console.WriteLine();

                Console.WriteLine(player.InfoStr());
                Console.WriteLine();

                Console.WriteLine("1. 휴식하기");
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
                            Rest();
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

        private void Rest()
        {
            if (player.Gold >= restGold)
            {
                player.Gold -= restGold;
                player.CurHP += 100;
                Console.WriteLine("휴식을 완료했습니다.");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Gold 가 부족합니다."); 
            }
        }
    }
}
