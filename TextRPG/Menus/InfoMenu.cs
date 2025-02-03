using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class InfoMenu
    {
        Player player;

        public InfoMenu(Player player)
        {
            this.player = player;
        }
        public void Exe()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터 정보");
                Console.WriteLine();

                Console.WriteLine(player.InfoStr());
                Console.WriteLine();

                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int select;
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
