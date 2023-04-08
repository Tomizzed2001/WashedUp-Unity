using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save
{
    //Player Saving and Loading
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

    //Tower Saving and Loading
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

    //Trap Saving and Loading
    public static void SaveTraps(Trap[] traps)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/traps.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        TrapData[] trapsData = new TrapData[traps.Length];

        for (int i = 0; i < traps.Length; i++)
        {
            trapsData[i] = new TrapData(traps[i]);
        }

        AllTrapData data = new AllTrapData(trapsData);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static AllTrapData LoadTraps()
    {
        string path = Application.persistentDataPath + "/traps.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            AllTrapData data = formatter.Deserialize(stream) as AllTrapData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found");
            return null;
        }
    }

    //Inventory Saving and Loading
    public static void SaveInventory(int[] nums, string[] names)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/inventory.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        InventoryData data = new InventoryData(nums, names);

        formatter.Serialize(stream, data);

        stream.Close();

    }

    public static InventoryData LoadInventory()
    {
        string path = Application.persistentDataPath + "/inventory.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            InventoryData data = formatter.Deserialize(stream) as InventoryData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found");
            return null;
        }
    }

    //Time Saving and Loading
    public static void SaveTime(double time, int day)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/time.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        TimeData data = new TimeData(time, day);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static TimeData LoadTime()
    {
        string path = Application.persistentDataPath + "/time.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            TimeData data = formatter.Deserialize(stream) as TimeData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found");
            return null;
        }
    }

    //House Saving and Loading
    public static void SaveHouse(bool buildingStatus)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/house.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        HouseData data = new HouseData(buildingStatus);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static HouseData LoadHouse()
    {
        string path = Application.persistentDataPath + "/house.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HouseData data = formatter.Deserialize(stream) as HouseData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found");
            return null;
        }
    }

    //Object Saving and Loading
    public static void SaveObjects(bool[] arebroken)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/objects.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        ObjectData data = new ObjectData(arebroken);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static ObjectData LoadObjects()
    {
        string path = Application.persistentDataPath + "/objects.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ObjectData data = formatter.Deserialize(stream) as ObjectData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found");
            return null;
        }
    }

    //Objectives Saving and Loading
    public static void SaveObjectives(bool[] objectives)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/objectives.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        ObjectiveData data = new ObjectiveData(objectives);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static ObjectiveData LoadObjectives()
    {
        string path = Application.persistentDataPath + "/objectives.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ObjectiveData data = formatter.Deserialize(stream) as ObjectiveData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found");
            return null;
        }
    }

    //Boat Saving and Loading
    public static void SaveBoat(int boatLevel, bool todayFix, bool isFixed)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/boat.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        BoatData data = new BoatData(boatLevel, todayFix, isFixed);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static BoatData LoadBoat()
    {
        string path = Application.persistentDataPath + "/boat.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            BoatData data = formatter.Deserialize(stream) as BoatData;

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
