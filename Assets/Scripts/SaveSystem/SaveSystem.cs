using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem {

    public static void SavePlayer(GameObject gameObject)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream;
        string path = Application.persistentDataPath + "/save.sav";

        //if (!File.Exists(path))
        //{
        //    stream = new FileStream(path, FileMode.Create);
        //}
        //else
        //{
        //    stream = new FileStream(path, FileMode.Append);
        //}
        stream = new FileStream(path, FileMode.Create);
        
        PlayerData data = new PlayerData(gameObject);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    //public static PlayerData LoadPlayer()
    //{
    //    string path = Application.persistentDataPath + "/save.sav";
    //    if(File.Exists(path))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream stream = new FileStream(path, FileMode.Open);
    //        PlayerData data = formatter.Deserialize(stream) as PlayerData;
    //        stream.Close();
    //        return data;

    //    }
    //    else
    //    {
    //        return null;
    //    }
    //}

    //public static void DeleteSave()
    //{
    //    string path = Application.persistentDataPath + "/save.sav";
    //    File.Delete(path);
    //}

}
