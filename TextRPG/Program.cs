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
            Save,
            Count
        }

        static Player player;

        static void Main(string[] args)
        {
            GameState gameState;
            player = new Player();
            QuestionPlayer();

            if(player.Name == string.Empty)
            {
                SetName(player);
                SetChad(player);
            }

            InfoMenu infoMenu = new InfoMenu(player);
            InventoryMenu inventoryMenu = new InventoryMenu(player);
            ShopMenu shopMenu = new ShopMenu(player);
            RestMenu restMenu = new RestMenu(player);
            DungeonMenu dungeonMenu = new DungeonMenu(player);

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
                Console.WriteLine("6. 저장하기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int select;
                if ((int.TryParse(Console.ReadLine(), out select))
                    && select > 0
                    && select <= (int)GameState.Count)
                {
                    gameState = (GameState)select;
                    switch (gameState)
                    {
                        case GameState.Info:
                            infoMenu.Exe();
                            break;
                        case GameState.Inventory: // 인벤토리
                            inventoryMenu.Exe();
                            break;
                        case GameState.Shop:
                            shopMenu.Exe();
                            break;
                        case GameState.Dungeon:
                            dungeonMenu.Exe();
                            break;
                        case GameState.Rest:
                            restMenu.Exe();
                            break;
                        case GameState.Save:
                            JsonManager.Instance().SaveInfo(player);
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
        // 저장된 데이터가 있는지 플레이어에게 물어보는 함수
        private static void QuestionPlayer()
        {
            bool isExit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Text RPG에 입장하신 것을 환영합니다.");
                Console.WriteLine("저장한 데이터가 있으십니까?");
                Console.WriteLine();

                Console.WriteLine("1. 예");
                Console.WriteLine("2. 아니요");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                if (int.TryParse(Console.ReadLine(), out int select) && select > 0 && select <=2)
                {
                    switch (select)
                    {
                        case 1:
                            isExit = LoadPlayerInfo();
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
            }
            while (!isExit);
        }

        // 입력한 이름을 바탕으로 json 파일을 찾아보고 있으면 load
        private static bool LoadPlayerInfo()
        {
            bool isExit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("저장한 캐릭터의 이름을 입력해주세요.");
                Console.Write(">>");
                string enterName = Console.ReadLine();

                if (JsonManager.Instance().CheckFile(enterName))
                {
                    Console.WriteLine($"{enterName}의 정보를 불러옵니다.");
                    player.Name = enterName;
                    JsonManager.Instance().LoadInfo(player);
                    Thread.Sleep(1000);
                    isExit = true;
                }
                else
                {
                    Console.WriteLine("입력하신 저장 정보가 없습니다.");
                    Console.WriteLine();

                    Console.WriteLine("1. 다시 입력");
                    Console.WriteLine("2. 처음 부터 플레이");
                    Console.WriteLine();

                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    Console.Write(">>");

                    if (int.TryParse(Console.ReadLine(), out int select) && select > 0 && select <= 2)
                    {
                        if( select == 2) isExit = true;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(1000);
                    }
                }
            }
            while (!isExit);

            return isExit;
        }

        private static void SetName(Player player)
        {
            bool isExit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Text RPG에 입장하신 것을 환영합니다.");
                Console.WriteLine("이름을 입력해주세요!");
                Console.Write(">>");
                player.Name = Console.ReadLine();

                Console.WriteLine($"입력하신 이름은 {player.Name}입니다.");
                Console.WriteLine();

                Console.WriteLine("1. 저장");
                Console.WriteLine("2. 다시 입력");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                if (int.TryParse(Console.ReadLine(), out int select) && select > 0 && select <= 2)
                {
                    if (select == 1)
                        isExit = true;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
            while (!isExit);
        }


        // 직업 선택
        private static void SetChad(Player player)
        {
            bool isExit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Text RPG에 입장하신 것을 환영합니다.");
                Console.WriteLine("직업을 선택해주세요");
                Console.WriteLine();

                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 궁수");
                Console.WriteLine("3. 도적");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                if (int.TryParse(Console.ReadLine(), out int select) && select > 0 && select <= 3)
                {
                    switch(select)
                    {
                        case 1:
                            player.Chad = "전사";
                            break;
                        case 2:
                            player.Chad = "궁수";
                            break;
                        case 3:
                            player.Chad = "도적";
                            break;
                    }
                    isExit = true;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
            while (!isExit);
        }

    }

}
