using System.ComponentModel.Design;

namespace TextRPG
{
    internal class Program
    {
        enum GameState
        {
            Info = 1,
            Inventory,
            Shop,
            Dungeon,
            Rest,
            Count
        }

        static void Main(string[] args)
        {
            Player player = new Player();

            Console.WriteLine("Text RPG에 입장하신 것을 환영합니다.");
            Console.WriteLine("이름을 입력해주세요!");
            Console.Write(">>");
            player.Name = Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("TextRPG");
                Console.WriteLine();

                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 던전입장");
                Console.WriteLine("5. 휴식하기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int select;
                if ((int.TryParse(Console.ReadLine(), out select))
                    && select > 0
                    && select <= (int)GameState.Count)
                {
                    switch (select)
                    {
                        case 1:
                            while(true)
                            {
                                Console.Clear();
                                Console.WriteLine("상태 보기");
                                Console.WriteLine("캐릭터 정보");
                                Console.WriteLine();

                                Console.WriteLine(player.ToString());
                                Console.WriteLine();

                                Console.WriteLine("0. 나가기");
                                Console.WriteLine();

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
                            break;
                        default:
                            break;
                    }
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
