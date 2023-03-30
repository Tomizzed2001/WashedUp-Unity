using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save
{
    public static void SavePlayer(PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);

        stream.Close();

    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found");
            return null;
        }
    }

    public static void SaveTower(Tower[] towers)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/towers.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        TowerData[] towersData = new TowerData[towers.Length];

        for (int i = 0; i < towers.Length; i++)
        {
            towersData[i] = new TowerData(towers[i]);
        }

        AllTowerData data = new AllTowerData(towersData);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static AllTowerData LoadTower()
    {
        string path = Application.persistentDataPath + "/towers.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            AllTowerData data = formatter.Deserialize(stream) as AllTowerData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found");
            return null;
        }
    }
}
