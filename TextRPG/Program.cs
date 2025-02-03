using System.ComponentModel.Design;
using TextRPG.Menus;

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

            InfoMenu infoMenu = new InfoMenu(player);
            InventoryMenu inventoryMenu = new InventoryMenu(player);
            ShopMenu shopMenu = new ShopMenu(player);

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
                        case 1: // 정보
                            infoMenu.Exe();
                            break;
                        case 2: // 인벤토리
                            inventoryMenu.Exe();
                            break;
                        case 3: shopMenu.Exe(); 
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
