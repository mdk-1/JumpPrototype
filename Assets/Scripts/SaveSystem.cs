using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//script to hand serialization/deserialization
public static class SaveSystem
{
    // declate binary formatter, set persistent path for save file
    // stream file save data, close stream
    public static void SavePlayer (ScoreManager player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    // declare path of file to deserialize
    // check if file exists, declare binary formatter, open stream and load data
    // close stream and pass back deserialized data
    // else return error message
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.sav";
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
            Debug.Log("No save file found");
            return null;
        }
    }
}
