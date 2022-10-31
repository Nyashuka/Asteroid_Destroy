
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSaveSystem : ISaveSystem
{
    private readonly string _filePath;

    public JsonSaveSystem()
    {
        _filePath = Application.persistentDataPath + "/save_data.json";
    }

    public void Save(SaveData saveData)
    {
        var jsonData = JsonUtility.ToJson(saveData);

        using (StreamWriter writer = new StreamWriter(_filePath))
        {
            writer.WriteLine(jsonData);
        }
    }

    public SaveData Load()
    {
        string receivedJsonData = "";

        if (!File.Exists(_filePath))
            return new SaveData(new List<PlayerData>());

        using (StreamReader reader = new StreamReader(_filePath))
        {
            receivedJsonData = reader.ReadToEnd();
        }

        if (string.IsNullOrEmpty(receivedJsonData))
        {
            return new SaveData(new List<PlayerData>());
        }

        return JsonUtility.FromJson<SaveData>(receivedJsonData);
    }
}

