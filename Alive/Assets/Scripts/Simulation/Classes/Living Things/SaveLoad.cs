using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {

    public static List<Data> savedGames = new List<Data>();

    public static void Save() {
        savedGames.Add(Data.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, SaveLoad.savedGames);
        file.Close();
    }

    public static void Load() {
        if (File.Exists(Path.Combine(Application.persistentDataPath,"savedGames.gd"))) {
            Debug.Log("Le ficher existe");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            SaveLoad.savedGames = (List<Data>)bf.Deserialize(file);
            file.Close();
        }
    }

}