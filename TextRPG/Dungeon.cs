using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{

    public class Dungeon
    {
        public string DungeonName { get; set; }
        public int DungeonDef { get; set; }

        public int RewardGold {  get; set; }

        public Dungeon(string dungeonName, int dungeonDef, int rewardGold)
        {
            this.DungeonName = dungeonName;
            this.DungeonDef = dungeonDef;
            this.RewardGold = rewardGold;
        }
    }
}
