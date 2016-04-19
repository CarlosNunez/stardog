using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class GameSingleObject
{
    private static string FilePath()
    {
        return Application.persistentDataPath + "/myData.dat";
    }

    public static void SaveData(Stats data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create(FilePath());

        formatter.Serialize(saveFile, data);

        saveFile.Close();
    }

    public static Stats LoadData()
    {
        Stats data;

        if (File.Exists(FilePath()))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream saveFile = File.Open(FilePath(), FileMode.Open);

            data = (Stats)formatter.Deserialize(saveFile);

            saveFile.Close();
        }
        else
        {
            data = new Stats();
        }

        return data;
    }

}
