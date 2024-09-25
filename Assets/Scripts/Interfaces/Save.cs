using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class Save
{
    
    public static List<string> saveData;

    public static StreamWriter writer;

    static void Start()
    {
        
        //item = new List<Item>();
    }
    public static void SaveGame(string data)
    {
        string path = Path.Combine(Application.persistentDataPath, "save.txt");
        if (!File.Exists(path))
        {
            File.Create(path).Close();

        }
        writer = new StreamWriter(path, true);
        writer.WriteLine(data.ToString());
        writer.Flush();
        writer.Close();

    }

    public static void GetSave(string data)
    {
        
    }
    
    /// <summary>
    /// Writer close on app closed
    /// </summary>
    static void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
           
        }
    }
}
