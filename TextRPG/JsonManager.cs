using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace TextRPG
{
    public class JsonManager
    {
        public static JsonManager instance;

        public static JsonManager Instance()
        {
            if (instance == null)
            {
                instance = new JsonManager();
            }
            return instance;
        }

        string folderPath = @"D:\NBC\CsProject\TextRPG\TextRPG\TextRPG\Save\";

        public void SaveInfo(Player player)
        {
            JObject playerInfo = new JObject(
                new JProperty("Name", player.Name),
                new JProperty("Level", player.Level),
                new JProperty("Chad", player.Chad),
                new JProperty("Att", player.Att),
                new JProperty("Def", player.Def),
                new JProperty("MaxHP", player.MaxHP),
                new JProperty("CurHP", player.CurHP),
                new JProperty("Gold", player.Gold),
                new JProperty("ClearCount", player.ClearCount)
            );

            if (player.EquipAtt != null)
                playerInfo.Add(new JProperty("EquipAttID", player.EquipAtt.ID));
            else
                playerInfo.Add(new JProperty("EquipAttID", -1));

            if (player.EquipDef != null)
                playerInfo.Add(new JProperty("EquipDefID", player.EquipDef.ID));
            else
                playerInfo.Add(new JProperty("EquipDefID", -1));

            JArray inventoryInfo = new JArray();
            if (player.Inventory.ItemCount > 0)
            {
                for (int i = 0; i < player.Inventory.ItemCount; i++)
                {
                    JObject itemInfo = new JObject();
                    itemInfo.Add("ID", player.Inventory.Items[i].ID);
                    itemInfo.Add("IsEquip", player.Inventory.Items[i].IsEquip);

                    inventoryInfo.Add(itemInfo);
                }
            }
            playerInfo.Add("Inventory", inventoryInfo);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string filePath = folderPath + player.Name + ".json";
            File.WriteAllText(filePath, playerInfo.ToString());
        }

        public void LoadInfo(Player player)
        {
            string filePath = folderPath + player.Name + ".json";
            string loadFile = File.ReadAllText(filePath).ToString();
            JObject playerInfo = JObject.Parse(loadFile);

            player.Name = playerInfo["Name"].ToString();
            player.Level = int.Parse(playerInfo["Level"].ToString());
            player.Chad = playerInfo["Chad"].ToString();
            player.Att = float.Parse(playerInfo["Att"].ToString());
            player.Def = float.Parse(playerInfo["Def"].ToString());
            player.MaxHP = int.Parse(playerInfo["MaxHP"].ToString());
            player.CurHP = int.Parse(playerInfo["CurHP"].ToString());
            player.Gold = int.Parse(playerInfo["Gold"].ToString());
            player.ClearCount = int.Parse(playerInfo["ClearCount"].ToString());

            JArray inventoryInfo = JArray.Parse(playerInfo["Inventory"].ToString());
            if(inventoryInfo.Count>0)
            {
                int itemCount = inventoryInfo.Count;
                player.Inventory.ItemCount = inventoryInfo.Count;

                for (int i = 0; i < itemCount; i++)
                {
                    int itemID = int.Parse(inventoryInfo[i]["ID"].ToString());
                    bool itemIsEquip = bool.Parse(inventoryInfo[i]["IsEquip"].ToString());

                    Item item = ItemInfos.Instance().Items[itemID];
                    item.IsEquip = itemIsEquip;

                    player.Inventory.Items[i] = item;

                    if (item.IsEquip)
                    {
                        player.EquipItem(item);
                    }
                }
            }
        }

        // 캐릭터 이름에 맞는 json 파일이 있는지 확인하는 함수
        public bool CheckFile(string enterName)
        {
            return File.Exists(folderPath + enterName + ".json"); 
        }
    }
}
