using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void saveData(float health, float positionX, float positionY, float positionZ)
    {
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.persistentDataPath +  "/player.woodaxe";
        FileStream file = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData( health,  positionX,  positionY,  positionZ);

        binary.Serialize(file, data);
        file.Close();
    }

    public static PlayerData loadPlayer()
    {
        string path = Application.persistentDataPath + "/player.woodaxe";
        if (File.Exists(path))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);
            PlayerData data = binary.Deserialize(file) as PlayerData;
            file.Close();
            return data;
        }
        else
        {
            Debug.LogError("File not found " + path);
            return null;
        }
    }
}
