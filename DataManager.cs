using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public static class DataManager
{
  
    //Tallentaa tilatiedot JSON tiedoksi
    public static void SavePlayerDataToJSON(Player player)
    {
        PlayerData playerData = new PlayerData(player);
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText($"{Application.dataPath}/playerData.json", json);
    }

    public static PlayerData LoadPlayerDataFromJSON()
    {
        string json = File.ReadAllText($"{Application.dataPath}/playerData.json");
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
        return playerData;
    }

}
