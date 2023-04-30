using UnityEngine;
using System.Collections.Generic;

// Klasa do przechowywania danych save
[System.Serializable]
public class SaveData
{
    public Dictionary<string, object> data; // Slownik przechowujacy dane w parach klucz/wartosc
}

public class SaveManager : MonoBehaviour
{
    public enum SaveFormat
    {
        JSON,
        Binary
    }

    public SaveFormat saveFormat; // Format zapisu (JSON, Binary)

    // Zapis danych do pliku lokalnego
    public void SaveToLocal(Dictionary<string, object> data)
    {
        SaveData saveData = new SaveData();
        saveData.data = data;

        switch (saveFormat)
        {
            case SaveFormat.JSON:
                string json = JsonUtility.ToJson(saveData);
                System.IO.File.WriteAllText("save.json", json);
                break;
            case SaveFormat.Binary:
                byte[] binary = SerializeToBinary(saveData);
                System.IO.File.WriteAllBytes("save.bin", binary);
                break;
        }
    }

    // Zapis danych do us³ugi chmurowej (klasa mockuj¹ca)
    public void SaveToCloud(Dictionary<string, object> data)
    {
        // Symulacja zapisu do us³ugi chmurowej
        Debug.Log("Zapis do chmury: " + data);
    }

    // Odczyt danych z pliku lokalnego
    public Dictionary<string, object> LoadFromLocal()
    {
        Dictionary<string, object> data = new Dictionary<string, object>();

        switch (saveFormat)
        {
            case SaveFormat.JSON:
                if (System.IO.File.Exists("save.json"))
                {
                    string json = System.IO.File.ReadAllText("save.json");
                    SaveData saveData = JsonUtility.FromJson<SaveData>(json);
                    data = saveData.data;
                }
                break;
            case SaveFormat.Binary:
                if (System.IO.File.Exists("save.bin"))
                {
                    byte[] binary = System.IO.File.ReadAllBytes("save.bin");
                    SaveData saveData = DeserializeFromBinary(binary);
                    data = saveData.data;
                }
                break;
        }

        return data;
    }

    // Metoda do serializacji danych do formatu binarnego
    private byte[] SerializeToBinary(object obj)
    {
        using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }
    }

    // Metoda do deserializacji danych z formatu binarnego
    private SaveData DeserializeFromBinary(byte[] binary)
    {
        using (System.IO.MemoryStream stream = new System.IO.MemoryStream(binary))
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            SaveData saveData = (SaveData)formatter.Deserialize(stream);
            return saveData;
        }
    }
}

//using UnityEngine;
//using System.Collections.Generic;
//using System.IO;

//public class SaveSystem
//{
//    private static Dictionary<string, object> saveData = new Dictionary<string, object>();

//    public static void SetValue(string key, object value)
//    {
//        if (!saveData.ContainsKey(key))
//        {
//            saveData.Add(key, value);
//        }
//        else
//        {
//            saveData[key] = value;
//        }
//    }

//    public static T GetValue<T>(string key, T defaultValue = default(T))
//    {
//        if (saveData.ContainsKey(key))
//        {
//            return (T)saveData[key];
//        }
//        return defaultValue;
//    }

//    public static void SaveLocal(string fileName)
//    {
//        string filePath = Path.Combine(Application.persistentDataPath, fileName);
//        SaveToFile(filePath);
//    }

//    public static void SaveCloud(string fileName)
//    {
//        // Mock implementation of cloud saving - simply save to a file with the given name in the root directory of the project
//        string filePath = Path.Combine(Application.dataPath, fileName);
//        SaveToFile(filePath);
//    }

//    private static void SaveToFile(string filePath)
//    {
//        string json = JsonUtility.ToJson(saveData);
//        File.WriteAllText(filePath, json);
//    }

//    public static void LoadLocal(string fileName)
//    {
//        string filePath = Path.Combine(Application.persistentDataPath, fileName);
//        LoadFromFile(filePath);
//    }

//    public static void LoadCloud(string fileName)
//    {
//        // Mock implementation of cloud loading - simply load from a file with the given name in the root directory of the project
//        string filePath = Path.Combine(Application.dataPath, fileName);
//        LoadFromFile(filePath);
//    }

//    private static void LoadFromFile(string filePath)
//    {
//        if (File.Exists(filePath))
//        {
//            string json = File.ReadAllText(filePath);
//            saveData = JsonUtility.FromJson<Dictionary<string, object>>(json);
//        }
//    }
//}
