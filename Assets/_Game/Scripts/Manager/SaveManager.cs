using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    public int currentCharacter;
    public int coin;

    public bool[] charectersUnlocked = new bool[6] { true, false, false, false, false, false};

    void Awake()
    {
        Load();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            coin = data.money;
            currentCharacter = data.currentCar;
            charectersUnlocked = data.carsUnlocked;

            if (data.carsUnlocked ==  null)
                charectersUnlocked = new bool[6] { true, false, false, false, false, false };

            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();

        data.money = coin;
        data.currentCar = currentCharacter;
        data.carsUnlocked = charectersUnlocked;

        bf.Serialize(file, data);
        file.Close();
    }
}

[Serializable]
class PlayerData_Storage
{
    public int currentCar;
    public int money;
    public bool[] carsUnlocked;
}